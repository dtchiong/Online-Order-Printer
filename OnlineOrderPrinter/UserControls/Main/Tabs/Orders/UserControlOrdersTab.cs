using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.UserControls.Main.Tabs.Orders {
    public partial class UserControlOrdersTab : UserControl {

        private static Timer pollingTimer = new Timer();
        private const int polling_interval = 4000;

        public UserControlOrdersTab() {
            InitializeComponent();
            InitializeTimer();
        }

        public static void StartPollingEvents() {
            // The timer needs to be started on the main thread for logs to show up
            AppState.UserControlMainPage.Invoke((MethodInvoker)delegate {
                pollingTimer.Start();
            });
        }

        public static void StopPollingEvents() {
            pollingTimer.Stop();
        }

        private static void InitializeTimer() {
            pollingTimer.Tick += new EventHandler(PollingTimerEventProcessor);
            pollingTimer.Interval = polling_interval;
        }

        private static void PollingTimerEventProcessor(object myObject, EventArgs myEventArgs) {
            // TODO: Maybe only fetch if the restaurant is open or within open hours to save costs.
            // Maybe only apply the above rule is logged in as a restaurant user.
            EventActions.FetchLatestEvents();
        }
    }
}
