using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.Sagas {
    class EventSagas : CancellableSaga {

        public static bool FetchingCurrentEvents = false;
        public static int FetchPastEventsTaskCount = 0;

        public static CancellationTokenSource CurrentFetchCurrentEventsCTS;
        public static CancellationTokenSource CurrentFetchPastEventsCTS;

        public static void FetchCurrentEvents(
            string restaurantId,
            string bearerToken,
            string startEventId = null) {

            if (FetchingCurrentEvents) {
                return;
            }
            Debug.WriteLine("Starting FetchCurrentEvents saga");
            FetchingCurrentEvents = true;
            CurrentFetchCurrentEventsCTS = new CancellationTokenSource();

            Task.Run(() => {
                FetchEventsResponse response = Api.FetchEvents(
                    restaurantId,
                    bearerToken,
                    startEventId,
                    null,
                    null,
                    CurrentFetchCurrentEventsCTS.Token).Result;
                AppState.UserControlMainPage.Invoke((MethodInvoker)delegate {
                    if (response.IsSuccessStatusCode()) {
                        EventActions.ReceiveEvents(response.Events, "current");
                    }
                    Debug.WriteLine("Ended FetchCurrentEvents saga");
                    FetchingCurrentEvents = false;
                });
                CurrentFetchCurrentEventsCTS.Dispose();
            });
        }

        public static void FetchPastEvents(
            string restaurantId,
            string bearerToken,
            string startEventId = null,
            DateTime? startTime = null,
            DateTime? endTime = null) {

            if (FetchPastEventsTaskCount > 0) {
                CurrentFetchPastEventsCTS.Cancel();
            }

            Debug.WriteLine("Starting FetchPastEvents saga");
            Interlocked.Increment(ref FetchPastEventsTaskCount);
            CurrentFetchPastEventsCTS = new CancellationTokenSource();
            CtsPairMap.TryAdd(CurrentFetchPastEventsCTS.Token, CurrentFetchPastEventsCTS);

            Task.Run(() => {
                // Capture the token so that it's the one corresponding to the current task inside the task delegate
                CancellationToken cancellationToken = CurrentFetchPastEventsCTS.Token;
                try {
                    FetchEventsResponse response = Api.FetchEvents(
                        restaurantId,
                        bearerToken,
                        startEventId,
                        startTime,
                        endTime,
                        CurrentFetchPastEventsCTS.Token).Result;
                    // TODO: Need to cancel all fetches before we log out or else this will throw
                    // an error when the fetch finishes and it tries to invoke this method
                    // on the disposed form
                    AppState.UserControlMainPage.Invoke((MethodInvoker)delegate {
                        if (response.IsSuccessStatusCode()) {
                            EventActions.ReceiveEvents(response.Events, "past");
                        }
                    });
                } catch (AggregateException e) {
                    Debug.WriteLine(e.Message);
                }
                finally {
                    // Use the cancellation token to retrieve the cancellation token source so that we can dispose
                    if (CtsPairMap.TryRemove(cancellationToken, out CancellationTokenSource cancellationTokenSource)) {
                        cancellationTokenSource.Dispose();
                    }
                    Interlocked.Decrement(ref FetchPastEventsTaskCount);
                    Debug.WriteLine("Ended FetchPastEvents saga");
                }
            });
        }
    }
}
