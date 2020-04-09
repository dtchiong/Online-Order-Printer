using OnlineOrderPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Apis {
    namespace Responses {
        class AuthResponse {
            public User User { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }

        class SyncOrderPrintedResponse {
            public HttpStatusCode StatusCode { get; set; }
        }

        class FetchEventResponse {
            public Event Event { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }

        class FetchOrderResponse {
            public Order Order { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }
    }
}
