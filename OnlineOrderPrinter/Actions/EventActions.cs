using OnlineOrderPrinter.State;
using OnlineOrderPrinter.Sagas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class EventActions {

        public static void FetchCurrentDayEvents() {
            string restaurantId = AppState.User.RestaurantId;
            string bearerToken = AppState.User.Token;

            EventSagas.FetchEvents(restaurantId, bearerToken);
        }
    }
}
