using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.UserControls.Login;
using OnlineOrderPrinter.UserControls.Main;
using OnlineOrderPrinter.UserControls.Main.Tabs.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.State {
    class AppState {
        public static List<Event> CurrentEvents { get; set; } = new List<Event>();
        public static List<Event> PastEvents { get; set; } = new List<Event>();
        public static string LatestEventId { get; set; }
        public static string CurrentEventsSelection { get; set; }
        public static User User { get; set; }
        public static Restaurant Restaurant { get { return restaurant; } set { restaurant = value; OnRestaurantChanged(value); } }
        public static Control ActivePage { get; set; }
        public static string ApiKey { get; set; }

        public static FormContainer FormContainer { get; set; }
        public static UserControlLoginPage UserControlLoginPage { get; set; }
        public static UserControlMainPage UserControlMainPage { get; set; }
        public static UserControlOrdersView UserControlOrdersView { get; set; }
        public static UserControlDetailedOrderView UserControlDetailedOrderView { get; set; }

        private static Restaurant restaurant;

        private static void OnRestaurantChanged(Restaurant restaurant) {
            UserControlMainPage.SetLabelRestaurantNameSafe(Restaurant?.Name);
            UserControlOrdersView.SetComboBoxEnabledSafe(true);
        }
    }
}
