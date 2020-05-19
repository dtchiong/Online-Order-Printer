using OnlineOrderPrinter.Apis;
using OnlineOrderPrinter.Apis.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Sagas {
    class OrderSagas {
        public static void SyncOrderPrinted(string restaurantId, string bearerToken, string orderId) {
            Task.Run(() => {
                Debug.WriteLine("Starting SyncOrderPrinted saga");
                try {
                    SyncOrderPrintedResponse response = Api.SyncOrderPrinted(restaurantId, orderId, bearerToken).Result;
                } catch (Exception e) {
                    Debug.WriteLine(e);
                }
                Debug.WriteLine("Ended SyncOrderPrinted saga");
            });
        }
    }
}
