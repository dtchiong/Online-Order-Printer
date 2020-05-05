using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.UserControls.Main.Tabs.Orders;
using OnlineOrderPrinter.State;
using OnlineOrderPrinter.Sagas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OnlineOrderPrinter.Actions {
    class EventActions {

        public static void FetchCurrentDayEvents() {
            string restaurantId = AppState.User?.RestaurantId;
            string bearerToken = AppState.User?.Token;

            EventSagas.FetchCurrentEvents(restaurantId, bearerToken);
        }

        public static void FetchLatestEvents() {
            string restaurantId = AppState.User?.RestaurantId;
            string bearerToken = AppState.User?.Token;
            string latestEventId = AppState.LatestEventId;

            EventSagas.FetchCurrentEvents(restaurantId, bearerToken, latestEventId);
        }

        public static void FetchPresetRangeEvents(string eventsSelection) {
            string restaurantId = AppState.User?.RestaurantId;
            string bearerToken = AppState.User?.Token;

            switch (eventsSelection) {
                case EventsSelection.Yesterday:
                    EventSagas.FetchPastEvents(restaurantId, bearerToken, null, DateTime.Today.AddDays(-1), DateTime.Today);
                    break;
                case EventsSelection.Last7Days:
                    EventSagas.FetchPastEvents(restaurantId, bearerToken, null, DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1));
                    break;
                case EventsSelection.Last14Days:
                    EventSagas.FetchPastEvents(restaurantId, bearerToken, null, DateTime.Today.AddDays(-14), DateTime.Today.AddDays(1));
                    break;
            }
        }

        public static void CancelFetchCurrentEventsSaga() {
            CancellationTokenSource cts = EventSagas.CurrentFetchCurrentEventsCTS;
            CancellableSaga.Cancel(cts);
        }

        public static void CancelFetchPastEventsSaga() {
            CancellationTokenSource cts = EventSagas.CurrentFetchPastEventsCTS;
            CancellableSaga.Cancel(cts);
        }

        public static void ReceiveEvents(Event[] events, EventsContext eventsContext) {
            if (events == null || events.Length == 0) {
                return;
            }

            List<Event> eventList;
            if (eventsContext == EventsContext.CurrentDay || eventsContext == EventsContext.Latest) {
                eventList = AppState.CurrentEvents;
                SetLatestEventId(events[events.Length - 1].Id);
            } else {
                eventList = AppState.PastEvents;
            }

            foreach (Event @event in events) {
                eventList.Add(@event);
            }

            if (eventsContext == EventsContext.CurrentDay || eventsContext == EventsContext.Latest && AppState.CurrentEventsSelection == EventsSelection.Today) {
                AppState.UserControlOrdersView.UpdateEventList(new List<Event>(events), false, eventsContext);
            } else if (eventsContext == EventsContext.Past && AppState.CurrentEventsSelection != EventsSelection.Today) {
                AppState.UserControlOrdersView.UpdateEventList(eventList, true, eventsContext);
            }
        }

        public static void SetLatestEventId(string latestEventId) {
            AppState.LatestEventId = latestEventId;
        }

        public static void ClearEvents() {
            AppState.CurrentEvents.Clear();
        }
    }

    /**
     * Latest events will trigger a sound notification
     * 
     * TODO: Maybe move this to a separate file
     */
    public enum EventsContext {
        CurrentDay,
        Latest,
        Past
    }
}
