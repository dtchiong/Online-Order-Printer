using OnlineOrderPrinter.UserControls.Main;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class NavigationActions {
        public static void NavigateToSplashPage() {
            AppState.FormContainer.NavigateToPageSafe(ControlNames.SplashPage);
        }

        public static void NavigateToLoginPage() {
            AppState.FormContainer.NavigateToPageSafe(ControlNames.LoginPage);
        }

        public static void NavigateToMainPage() {
            AppState.FormContainer.NavigateToPageSafe(ControlNames.MainPage);
        }

        public static void NavigateToOrdersTab() {
            AppState.UserControlMainPage.NavigateToTab(TabNames.Orders);
        }

        public static void NavigateToSettingsTab() {
            AppState.UserControlMainPage.NavigateToTab(TabNames.Settings);
        }

        public static void NavigateToAboutTab() {
            AppState.UserControlMainPage.NavigateToTab(TabNames.About);
        }
    }
}
