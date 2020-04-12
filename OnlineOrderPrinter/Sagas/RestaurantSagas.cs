using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Sagas {
    class RestaurantSagas {

        public static void FetchRestaurant(string restaurantId, string bearerToken) {
            Debug.WriteLine("Starting FetchRestaurant saga");
            Task.Run(() => {
                FetchRestaurantResponse response = Api.FetchRestaurant(restaurantId, bearerToken).Result;
                if (response.IsSuccessStatusCode()) {
                    RestaurantActions.SetRestaurant(response.Restaurant);
                }
                Debug.WriteLine("Ended FetchRestaurant saga");
            });
        }
    }
}
