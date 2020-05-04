using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.Services {
    class EventPollingService {
        private static Timer pollingTimer = new Timer();
        private const int polling_interval = 4000;

        public static void InitializeTimer() {
            pollingTimer.Tick += new EventHandler(PollingTimerEventProcessor);
            pollingTimer.Interval = polling_interval;
        }

        public static void Start() {
            // The timer needs to be started on the main thread for logs to show up
            AppState.UserControlMainPage.Invoke((MethodInvoker)delegate {
                pollingTimer.Start();
                Debug.WriteLine("EventPollingService started");
            });
        }

        public static void Stop() {
            pollingTimer.Stop();
            Debug.WriteLine("EventPollingService stopped");
        }

        private static void PollingTimerEventProcessor(object myObject, EventArgs myEventArgs) {
            if (AppState.LatestEventId != null) {
                EventActions.FetchLatestEvents();
            } else {
                EventActions.FetchCurrentDayEvents();
            }
        }
    }
}
