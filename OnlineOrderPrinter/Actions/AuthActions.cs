using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.Sagas;
using OnlineOrderPrinter.Services;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class AuthActions {
        public static void Authenticate(string email, string password) {
            AuthSagas.Authenticate(email, password);
        }

        public static void AuthenticateWithStoredCredentials() {
            AuthSagas.AuthenticateWithStoredCredentials();
        }

        public static void Logout() {
            // TODO: Should also cancel all running sagas
            EventPollingService.Stop();
            CredentialManager.DeleteCredentials();
            NavigationActions.NavigateToLoginPage();
            AppActions.ClearState();
        }

        public static void SetUser(User user) {
            AppState.User = user;
        }

        public static void ClearLoginFields() {
            AppState.UserControlLoginPage.ClearLoginFieldsSafe();
        }
    }
}
