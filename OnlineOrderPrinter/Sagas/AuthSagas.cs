using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Sagas {
    class AuthSagas {
        private static int Authenticating = 0;

        public static void Authenticate(string email, string password) {
            if (Interlocked.Exchange(ref Authenticating, 1) == 0) {
                Task.Run(() => {
                    Debug.WriteLine("Starting Authenticate saga");
                    AuthResponse response = Api.Authenticate(email, password).Result;
                    if (response.IsSuccessStatusCode()) {
                        AppState.ReceiveUser(response.User);
                        EventActions.FetchCurrentDayEvents();
                        AppState.FormContainer.NavigateToMainPage();
                    } else {
                        // TODO: Emit event to show an error on the login control?
                    }
                    Debug.WriteLine("Ended Authenticate saga");
                    Interlocked.Exchange(ref Authenticating, 0);
                });
            }
        }

    }
}
