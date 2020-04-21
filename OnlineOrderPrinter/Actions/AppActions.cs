using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Sagas;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class AppActions {
        public static void ClearState() {
            EventActions.ClearEvents();
            EventActions.SetLatestEventId(null);
            AuthActions.SetUser(null);
            RestaurantActions.SetRestaurant(null);
            // Free the resources used by the main page
            AppState.UserControlMainPage.Dispose();
        }

        /**
         * Cancels all potentially running sagas in the app, and polls for their
         * respective fetching status to be false before returning
         */
        public static void CancelAllSagasAndWait() {
            EventActions.CancelFetchCurrentEventsSaga();
            EventActions.CancelFetchPastEventsSaga();
            RestaurantActions.CancelFetchRestaurant();

            while (EventSagas.FetchingCurrentEvents == 1) { }
            while (EventSagas.FetchPastEventsTaskCount > 0) { }
            while (RestaurantSagas.FetchingRestaurant == 1) { }

            Debug.WriteLine("Cancelled all Sagas!");
        }
    }
}
