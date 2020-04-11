using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.UserControls.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.State {
    class AppState {
        public static List<Event> Events { get; set; } = new List<Event>();
        public static string LatestEventId { get; set; }
        public static User User { get; set; }

        public static FormContainer FormContainer { get; set; }
        public static UserControlMainPage UserControlMainPage { get; set; }

        public static void ReceiveEvents(Event[] events) {
            foreach (Event @event in events) {
                Events.Add(@event);
            }
            SetLatestEventId(events);
        }

        public static void ReceiveUser(User user) {
            User = user;
        }

        private static void SetLatestEventId(Event[] events) {
            if (events != null && events.Length > 0) {
                LatestEventId = events[events.Length - 1].Id;
            }
        }
    }
}
