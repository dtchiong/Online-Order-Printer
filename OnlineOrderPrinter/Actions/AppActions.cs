using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class AppActions {
        public static void ClearState() {
            // TODO: Should also cancel all running sagas
            EventActions.ClearEvents();
            EventActions.SetLatestEventId(null);
            AuthActions.SetUser(null);
            // Free the resources used by the main page
            AppState.UserControlMainPage.Dispose();
        }
    }
}
