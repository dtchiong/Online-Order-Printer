using OnlineOrderPrinter.Apis.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Sagas {
    namespace AuthSagaResponses {
        class AuthorizeActionSagaResponse : AuthorizeActionResponse {
            public readonly ErrorType ErrorType;

            public AuthorizeActionSagaResponse(HttpStatusCode statusCode) {
                StatusCode = statusCode;
            }

            // TODO: Set different error types depending on the exception
            public AuthorizeActionSagaResponse(Exception e) {
                ErrorType = ErrorType.Unknown;
            }
        }
    }
}
