﻿using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.UserControls.Main.Tabs.Orders;
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
                case EventsSelection.Last30Days:
                    EventSagas.FetchPastEvents(restaurantId, bearerToken, null, DateTime.Today.AddDays(-30), DateTime.Today.AddDays(1));
                    break;
            }
        }

        // TODO: Maybe use enum instead of string for eventsContext
        public static void ReceiveEvents(Event[] events, string eventsContext) {
            if (events == null || events.Length == 0) {
                return;
            }

            List<Event> eventList;
            if (eventsContext == "current") {
                eventList = AppState.CurrentEvents;
                SetLatestEventId(events[events.Length - 1].Id);
            } else {
                eventList = AppState.PastEvents;
            }

            foreach (Event @event in events) {
                eventList.Add(@event);
            }

            if (eventsContext == "current" && AppState.CurrentEventsSelection == EventsSelection.Today) {
                AppState.UserControlOrdersView.UpdateEventList(eventList, true);
            } else if (eventsContext == "past" && AppState.CurrentEventsSelection != EventsSelection.Today) {
                AppState.UserControlOrdersView.UpdateEventList(eventList, true);
            }
        }

        public static void SetLatestEventId(string latestEventId) {
            AppState.LatestEventId = latestEventId;
        }

        public static void ClearEvents() {
            AppState.CurrentEvents.Clear();
        }

        public static void StartPollingEvents() {
            UserControlOrdersTab.StartPollingEvents();
        }

        public static void StopPollingEvents() {
            UserControlOrdersTab.StopPollingEvents();
        }
    }
}
