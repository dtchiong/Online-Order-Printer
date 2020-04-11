using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.Sagas;
using OnlineOrderPrinter.State;
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

        public static void SetUser(User user) {
            AppState.User = user;
        }
    }
}
