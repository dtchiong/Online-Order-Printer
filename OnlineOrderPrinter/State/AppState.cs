using OnlineOrderPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.State {
    class AppState {
        public static List<Event> Events { get; set; } = new List<Event>();

        public static User User { get; set; }

        public static FormContainer FormContainer { get; set; }

        public static void ReceiveEvents(Event[] events) {
            foreach (Event @event in events) {
                Events.Add(@event);
            }
        }

        public static void ReceiveUser(User user) {
            User = user;
        }
    }
}
