using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
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
            });
        }

        public static void Stop() {
            pollingTimer.Stop();
        }

        private static void PollingTimerEventProcessor(object myObject, EventArgs myEventArgs) {
            // TODO: Maybe only fetch if the restaurant is open or within open hours to save costs.
            // Maybe only apply the above rule is logged in as a restaurant user.
            if (AppState.LatestEventId != null) {
                EventActions.FetchLatestEvents();
            } else {
                EventActions.FetchCurrentDayEvents();
            }
        }
    }
}
