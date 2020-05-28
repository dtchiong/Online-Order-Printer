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

        private const string DriverNameZD410 = "ZDesigner ZD410-203dpi ZPL";
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
            List<DiscoveredPrinterDriver> printerDrivers = UsbDiscoverer.GetZebraDriverPrinters();

            DiscoveredPrinterDriver printerDriver;

            // TODO: We should select the driver for the user's selected printer instead of having it only choose ZD410
            try {
                printerDriver = printerDrivers.First(driver => HasDriverName(driver, DriverNameZD410));
            } catch (Exception e) {
                throw new Exception(MissingDriverErrorString);
            }

            return printerDriver.GetConnection();
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

        private static bool HasDriverName(DiscoveredPrinterDriver printerDriver, string driverName) {
            if (printerDriver.DiscoveryDataMap.TryGetValue("DRIVER_NAME", out string val)) {
                return val == driverName;
            }
            return false;
        }
    }
}
