using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Utility {
    class PrintResult {
        public bool Success { get; set; }
        public PrintErrorType? Error { get; set; }
        public string PrintErrorMessage { get; set; }

        public PrintResult(bool success, PrintErrorType? printErrorType = null) {
            Success = success;

            if (printErrorType != null) {
                Error = printErrorType.Value;
                SetErrorMessage(printErrorType.Value);
            }
        }

        private void SetErrorMessage(PrintErrorType printErrorType) {
            switch (printErrorType) {
                case PrintErrorType.Connection:
                    PrintErrorMessage = "Error: Bad Print Connection";
                    break;
                case PrintErrorType.MissingDriver:
                    PrintErrorMessage = "Error: Missing Printing Driver";
                    break;
                default:
                    PrintErrorMessage = "Error: Unknown";
                    break;
            }
        }

    }
}
