using OnlineOrderPrinter.Sagas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Actions {
    class AuthActions {
        public static void Authenticate(string email, string password) {
            AuthSagas.Authenticate(email, password);
        }
    }
}
