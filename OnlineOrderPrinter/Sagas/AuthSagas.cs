﻿using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.State;
using OnlineOrderPrinter.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace OnlineOrderPrinter.Sagas {
    class AuthSagas {
        private static int authenticating = 0;
        private static int authenticatingWithStoredCredentials = 0;

        public static void Authenticate(string email, string password) {
            if (Interlocked.Exchange(ref authenticating, 1) == 0) {
                Task.Run(() => {
                    Debug.WriteLine("Starting Authenticate saga");
                    AuthResponse response = Api.Authenticate(email, password).Result;
                    if (response.IsSuccessStatusCode()) {
                        AuthActions.SetUser(response.User);
                        CredentialManager.SaveCredentials(AppState.User.Id, AppState.User.Token);
                        EventActions.FetchCurrentDayEvents();
                        RestaurantActions.FetchRestaurant();
                        NavigationActions.NavigateToMainPage();
                        AuthActions.ClearLoginFields();
                        EventPollingService.Start();
                    } else {
                        // TODO: Emit event to show an error on the login control?
                    }
                    Debug.WriteLine("Ended Authenticate saga");
                    Interlocked.Exchange(ref authenticating, 0);
                });
            }
        }

        public static void AuthenticateWithStoredCredentials() {
            if (Interlocked.Exchange(ref authenticatingWithStoredCredentials, 1) == 0) {
                Task.Run(() => {
                    Debug.WriteLine("Starting AuthenticateWithStoredCredentials saga");
                    (string userId, string bearerToken) = CredentialManager.RetrieveCredentials();
                    if (userId != null) {
                        FetchUserResponse response = Api.FetchUser(userId, bearerToken).Result;
                        if (response.IsSuccessStatusCode()) {
                            AuthActions.SetUser(response.User);
                            EventActions.FetchCurrentDayEvents();
                            RestaurantActions.FetchRestaurant();
                            NavigationActions.NavigateToMainPage();
                            EventPollingService.Start();
                        } else {
                            NavigationActions.NavigateToLoginPage();
                        }
                    } else {
                        NavigationActions.NavigateToLoginPage();
                    }
                    Debug.WriteLine("Ended AuthenticateWithStoredCredentials saga");
                    Interlocked.Exchange(ref authenticatingWithStoredCredentials, 0);
                });
            }
        }
    }
}
