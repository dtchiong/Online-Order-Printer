using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.UserControls.Login;
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
        public static Restaurant Restaurant { get; set; }

        public static FormContainer FormContainer { get; set; }
        public static UserControlLoginPage UserControlLoginPage { get; set; }
        public static UserControlMainPage UserControlMainPage { get; set; }
    }
}
