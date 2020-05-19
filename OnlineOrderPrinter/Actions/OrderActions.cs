using OnlineOrderPrinter.Sagas;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class OrderActions {
        public static void SyncOrderPrinted(string orderId) {
            string restaurantId = AppState.User?.RestaurantId;
            string bearerToken = AppState.User?.Token;

            OrderSagas.SyncOrderPrinted(restaurantId, bearerToken, orderId);
        }
    }
}
