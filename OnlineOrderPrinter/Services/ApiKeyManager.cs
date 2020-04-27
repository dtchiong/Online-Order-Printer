using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OnlineOrderPrinter.Services {
    class ApiKeyManager {
        public static string Retrieve() {
            try {
                return File.ReadAllText(FormContainer.ApiKeyPath);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
