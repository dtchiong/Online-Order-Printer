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

        // TODO: Add more sagas that should be cancelled
        public static void CancelAllSagasAndWait() {
            EventActions.CancelFetchCurrentEventsSaga();
            EventActions.CancelFetchPastEventsSaga();

            while (EventSagas.FetchingCurrentEvents == 1) { }
            while (EventSagas.FetchPastEventsTaskCount > 0) { }

            Debug.WriteLine("Cancelled all Sagas!");
        }
    }
}
