using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.Sagas;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class RestaurantActions {
        public static void FetchRestaurant() {
            string restaurantId = AppState.User?.RestaurantId;
            string bearerToken = AppState.User?.Token;

            RestaurantSagas.FetchRestaurant(restaurantId, bearerToken);
        }

        public static void SetRestaurant(Restaurant restaurant) {
            AppState.Restaurant = restaurant;
        }
    }
}
