using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
using OnlineOrderPrinter.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Sagas {
    class RestaurantSagas : CancellableSaga {

        public static int FetchingRestaurant = 0;

        public static CancellationTokenSource CurrentFetchRestaurantCTS;

        public static void FetchRestaurant(string restaurantId, string bearerToken) {
            if (Interlocked.Exchange(ref FetchingRestaurant, 1) == 0) {
                Debug.WriteLine("Starting FetchRestaurant saga");

                CurrentFetchRestaurantCTS = new CancellationTokenSource();
                CtsPairMap.TryAdd(CurrentFetchRestaurantCTS.Token, CurrentFetchRestaurantCTS);

                Task.Run(() => {
                    CancellationToken cancellationToken = CurrentFetchRestaurantCTS.Token;

                    try {
                        FetchRestaurantResponse response = Api.FetchRestaurant(restaurantId, bearerToken).Result;
                        if (response.IsSuccessStatusCode()) {
                            RestaurantActions.SetRestaurant(response.Restaurant);
                            EventPollingServiceSupervisor.Start();
                        }
                    } catch (AggregateException e) {
                        Debug.WriteLine(e.Message);
                    }
                    finally {
                        if (CtsPairMap.TryRemove(cancellationToken, out CancellationTokenSource cancellationTokenSource)) {
                            cancellationTokenSource.Dispose();
                        }
                        Debug.WriteLine("Ended FetchRestaurant saga");
                        Interlocked.Exchange(ref FetchingRestaurant, 0);
                    }
                });
            }
        }
    }
}
