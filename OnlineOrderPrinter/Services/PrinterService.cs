using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Printer.Discovery;

namespace OnlineOrderPrinter.Services {
    class PrinterService {

        private const string OrderTemplatePath = "E:ORDERTEMP.ZPL";
        private const string MissingDriverErrorString = "Missing Zebra printing driver";

        private static Connection printerConnection;

        public static PrintResult Print(Order order) {
            PrintResult printResult;

            try {
                if (printerConnection == null) {
                    printerConnection = FindConnection();
                    OpenConnection();
                } else if (!printerConnection.Connected) {
                    OpenConnection();
                }

                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(PrinterLanguage.ZPL, printerConnection);

                var printableOrderItems = PrinterHelper.ConvertOrderToPrintableList(order);
                foreach (var printableOrderItem in printableOrderItems) {
                    printer.PrintStoredFormat(OrderTemplatePath, printableOrderItem);
                }

                printResult = new PrintResult(true);
            } catch (ConnectionException e) {
                Debug.WriteLine(e.Message);
                printResult = new PrintResult(false, PrintErrorType.Connection);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                if (e.Message == MissingDriverErrorString) {
                    printResult = new PrintResult(false, PrintErrorType.MissingDriver);
                } else {
                    printResult = new PrintResult(false, PrintErrorType.Unknown);
                }
            }
            finally {
                if (printerConnection != null && printerConnection.Connected) {
                    CloseConnection();
                }
            }
            return printResult;
        }

        public static void CheckPrinterStatus() {
            ZebraPrinter printer = ZebraPrinterFactory.GetLinkOsPrinter(printerConnection);
            if (printer == null) {
                printer = ZebraPrinterFactory.GetInstance(PrinterLanguage.ZPL, printerConnection);
            }

            PrinterStatus status = printer.GetCurrentStatus();
        }

        private static Connection FindConnection() {
            List<DiscoveredPrinterDriver> drivers = UsbDiscoverer.GetZebraDriverPrinters();

            if (drivers.Count == 0) {
                throw new Exception(MissingDriverErrorString);
            }
            // TODO: Make sure to select the correct printer driver if there are multiple
            DiscoveredPrinterDriver driver = drivers[0];
            return driver.GetConnection();
        }

        private static void OpenConnection() {
            printerConnection.Open();
        }

        /**
         * The exception is caught at this level because it probably doesn't matter that much
         * that the connection failed to close, since printing has already succeeded before this.
         */
        private static void CloseConnection() {
            try {
                printerConnection.Close();
            } catch (ConnectionException e) {
                Debug.WriteLine($"Failed to close printer connection: {e.Message}");
            }
        }
    }
}
