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
    class EventSagas {

        private static bool fetchingCurrentEvents = false;

        private static CancellationTokenSource currentFetchCurrentEventsCTS;
        private static CancellationTokenSource currentFetchPastEventsCTS;

        private static int fetchPastEventsTaskCount = 0;

        private static ConcurrentDictionary<CancellationToken, CancellationTokenSource> cancellationTokenSourcePairMap
            = new ConcurrentDictionary<CancellationToken, CancellationTokenSource>();

        public static void FetchCurrentEvents(
            string restaurantId,
            string bearerToken,
            string startEventId = null) {

            if (fetchingCurrentEvents) {
                return;
            }
            Debug.WriteLine("Starting FetchCurrentEvents saga");
            fetchingCurrentEvents = true;
            currentFetchCurrentEventsCTS = new CancellationTokenSource();

            Task.Run(() => {
                FetchEventsResponse response = Api.FetchEvents(
                    restaurantId,
                    bearerToken,
                    startEventId,
                    null,
                    null,
                    currentFetchCurrentEventsCTS.Token).Result;
                AppState.UserControlMainPage.Invoke((MethodInvoker)delegate {
                    if (response.IsSuccessStatusCode()) {
                        EventActions.ReceiveEvents(response.Events);
                    }
                    Debug.WriteLine("Ended FetchCurrentEvents saga");
                    fetchingCurrentEvents = false;
                });
                currentFetchCurrentEventsCTS.Dispose();
            });
        }

        public static void FetchPastEvents(
            string restaurantId,
            string bearerToken,
            string startEventId = null,
            DateTime? startTime = null,
            DateTime? endTime = null) {

            if (fetchPastEventsTaskCount > 0) {
                currentFetchPastEventsCTS.Cancel();
            }

            Debug.WriteLine("Starting FetchPastEvents saga");
            Interlocked.Increment(ref fetchPastEventsTaskCount);
            currentFetchPastEventsCTS = new CancellationTokenSource();
            cancellationTokenSourcePairMap.TryAdd(currentFetchPastEventsCTS.Token, currentFetchPastEventsCTS);

            Task.Run(() => {
                // Capture the token so that it's the one corresponding to the current task inside the task delegate
                CancellationToken cancellationToken = currentFetchPastEventsCTS.Token;
                try {
                    FetchEventsResponse response = Api.FetchEvents(
                        restaurantId,
                        bearerToken,
                        startEventId,
                        startTime,
                        endTime,
                        currentFetchPastEventsCTS.Token).Result;
                    AppState.UserControlMainPage.Invoke((MethodInvoker)delegate {
                        if (response.IsSuccessStatusCode()) {
                            EventActions.ReceiveEvents(response.Events);
                        }
                    });
                } catch (AggregateException e) {
                    Debug.WriteLine(e.Message);
                }
                finally {
                    // Use the cancellation token to retrieve the cancellation token source so that we can dispose
                    if (cancellationTokenSourcePairMap.TryRemove(cancellationToken, out CancellationTokenSource cancellationTokenSource)) {
                        cancellationTokenSource.Dispose();
                    }
                    Interlocked.Decrement(ref fetchPastEventsTaskCount);
                    Debug.WriteLine("Ended FetchPastEvents saga");
                }
            });
        }
    }
}
