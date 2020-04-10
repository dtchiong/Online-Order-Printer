using OnlineOrderPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.State {
    class AppState {
        public static List<Event> Events = new List<Event>();

        public static void ReceiveEvents(Event[] events) {
            foreach (Event @event in events) {
                Events.Add(@event);
            }
        }
    }
}
