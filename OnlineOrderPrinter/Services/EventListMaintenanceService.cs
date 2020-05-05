using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OnlineOrderPrinter.Services {
    class EventListMaintenanceService {

        private static Timer maintenanceTimer;
        private static TimeSpan midnight = new TimeSpan(0, 0, 0);

        public static void Initialize() {
            maintenanceTimer = new Timer();
            maintenanceTimer.Elapsed += OnTimedEvent;
            // This makes the event handler code run on the main thread.
            // We use this usercontrol instead of UserControlMainPage because the latter
            // control gets disposed while this one doesn't. So this is easier.
            maintenanceTimer.SynchronizingObject = AppState.UserControlLoginPage;
        }

        public static void Start() {
            SetMaintenanceAlarm(midnight);
        }

        public static void Stop() {
            maintenanceTimer.Stop();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e) {
            maintenanceTimer.Stop();

            // TODO: Do stuff

            SetMaintenanceAlarm(midnight);
        }

        private static void SetMaintenanceAlarm(TimeSpan time) {
            maintenanceTimer.Interval = CalculateMillisecondsUntilTime(time);
            maintenanceTimer.Start();
        }

        private static int CalculateMillisecondsUntilTime(TimeSpan timeSpan) {
            TimeSpan endTime = timeSpan;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            // We need to add 24 hours to the endTime if it's less than the current time
            // to get the correct time until the next occurrence of endtime - otherwise
            // we'll only get the difference in time.
            if (endTime < currentTime) {
                endTime = endTime.Add(TimeSpan.FromDays(1));
            }

            int millisconds = (int)(endTime - currentTime).TotalMilliseconds;

            return millisconds;
        }
    }
}
