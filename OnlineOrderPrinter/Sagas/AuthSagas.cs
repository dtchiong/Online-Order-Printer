using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
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
                        AuthActions.SetUser(response.User);
                        EventActions.FetchCurrentDayEvents();
                        RestaurantActions.FetchRestaurant();
                        NavigationActions.NavigateToMainPage();
                        AuthActions.ClearLoginFields();
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
