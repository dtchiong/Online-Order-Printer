using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.Services {
    class EventPollingServiceSupervisor {
        private static Timer startingTimer = new Timer();
        private static Timer stoppingTimer = new Timer();

        public static void Initialize() {
            startingTimer.Tick += new EventHandler(StartingTimerEventProcessor);
            stoppingTimer.Tick += new EventHandler(StoppingTimerEventProcessor);
        }

        /**
         * Starts the supervisor service that starts the event polling service when the current time
         * is within the restaurant's start and end polling times. 
         * 
         * Accounts that are higher than restuarant have polling enabled at all times.
         */
        public static void Start() {
            if (AppState.User.UserType <= UserType.Restaurant) {
                TimeSpan timeNow = DateTime.Now.TimeOfDay;
                TimeSpan pollingStartTime = AppState.Restaurant.PollingStartTime.ToLocalTime().TimeOfDay;
                TimeSpan pollingEndTime = AppState.Restaurant.PollingEndTime.ToLocalTime().TimeOfDay;

                if (TimeIsWithinTimeSpan(timeNow, pollingStartTime, pollingEndTime)) {
                    EventPollingService.Start();
                    SetAlarmToStopPolling(AppState.Restaurant.PollingEndTime);
                } else {
                    SetAlarmToStartPolling(AppState.Restaurant.PollingStartTime);
                }
            } else {
                EventPollingService.Start();
            }
        }

        /**
         * Stops the event polling service and also the supervisor service that
         * starts and stops the event polling service.
         */
        public static void Stop() {
            EventPollingService.Stop();
            startingTimer.Stop();
            stoppingTimer.Stop();
        }

        private static void StartingTimerEventProcessor(object myObject, EventArgs myEventArgs) {
            EventPollingService.Start();
            startingTimer.Stop();

            SetAlarmToStopPolling(AppState.Restaurant.PollingEndTime);
        }

        private static void StoppingTimerEventProcessor(object myObject, EventArgs myEventArgs) {
            EventPollingService.Stop();
            stoppingTimer.Stop();

            SetAlarmToStartPolling(AppState.Restaurant.PollingStartTime);
        }

        private static void SetAlarmToStartPolling(DateTime dateTime) {
            startingTimer.Interval = CalculateMillisecondsUntilTime(dateTime);
            startingTimer.Start();
        }

        private static void SetAlarmToStopPolling(DateTime dateTime) {
            stoppingTimer.Interval = CalculateMillisecondsUntilTime(dateTime);
            stoppingTimer.Start();
        }

        // TODO: Refactor this method into a utility class
        private static int CalculateMillisecondsUntilTime(DateTime dateTime) {
            TimeSpan endTime = dateTime.ToLocalTime().TimeOfDay;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            if (endTime < currentTime) {
                endTime = endTime.Add(TimeSpan.FromDays(1));
            }

            int millisconds = (int)(endTime - currentTime).TotalMilliseconds;

            return millisconds;
        }

        private static bool TimeIsWithinTimeSpan(TimeSpan time, TimeSpan startTime, TimeSpan endTime) {
            if (endTime > startTime) {
                return (time >= startTime && time < endTime);
            } else {
                return (time >= startTime || time < endTime);
            }
        }
    }
}
