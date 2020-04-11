using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.State;
using OnlineOrderPrinter.Sagas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class EventActions {

        public static void FetchCurrentDayEvents() {
            string restaurantId = AppState.User?.RestaurantId;
            string bearerToken = AppState.User?.Token;

            EventSagas.FetchEvents(restaurantId, bearerToken);
        }

        public static void FetchLatestEvents() {
            string restaurantId = AppState.User?.RestaurantId;
            string bearerToken = AppState.User?.Token;
            string latestEventId = AppState.LatestEventId;

            EventSagas.FetchEvents(restaurantId, bearerToken, latestEventId);
        }

        public static void ReceiveEvents(Event[] events) {
            if (events == null || events.Length == 0) {
                return;
            }
            foreach (Event @event in events) {
                AppState.Events.Add(@event);
            }
            SetLatestEventId(events[events.Length - 1].Id);
        }

        public static void SetLatestEventId(string latestEventId) {
            AppState.LatestEventId = latestEventId;
        }
    }
}
