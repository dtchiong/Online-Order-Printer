using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Sagas {
    class EventSagas {
        private static int FetchingEvents = 0;

        public static void FetchEvents(
            string restaurantId,
            string bearerToken,
            string startEventId = null,
            DateTime? startTime = null,
            DateTime? endTime = null) {

            if (Interlocked.Exchange(ref FetchingEvents, 1) == 0) {
                Debug.WriteLine("Starting FetchEvents saga");
                Task.Run(() => {
                    FetchEventsResponse response = Api.FetchEvents(
                        restaurantId,
                        bearerToken,
                        startEventId,
                        startTime,
                        endTime).Result;
                    if (response.IsSuccessStatusCode()) {
                        AppState.ReceiveEvents(response.Events);
                    }
                    Debug.WriteLine("Ended FetchEvents saga");
                    Interlocked.Exchange(ref FetchingEvents, 0);
                });
            }
        }
    }
}
