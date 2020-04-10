using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class NavigationActions {
        public static void NavigateToMainPage() {
            AppState.FormContainer.NavigateToPageSafe(ControlNames.MainPage);
        }

        public static void NavigateToLoginPage() {
            AppState.FormContainer.NavigateToPageSafe(ControlNames.LoginPage);
        }
    }
}
