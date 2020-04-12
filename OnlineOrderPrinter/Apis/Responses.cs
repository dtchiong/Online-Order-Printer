using OnlineOrderPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Apis {
    namespace Responses {
        abstract class Response {
            public HttpStatusCode StatusCode { get; set; }

            public bool IsSuccessStatusCode() {
                int code = (int)StatusCode;
                return (code >= 200 && code < 300);
            }
        }

        class AuthResponse : Response {
            public User User { get; set; }
        }

        class FetchRestaurantResponse : Response {
            public Restaurant Restaurant { get; set; }
        }

        class FetchEventsResponse : Response {
            public Event[] Events { get; set; }
        }

        class FetchEventResponse : Response {
            public Event Event { get; set; }
        }

        class FetchOrderResponse : Response {
            public Order Order { get; set; }
        }

        class SyncOrderPrintedResponse : Response {
        }
    }
}
