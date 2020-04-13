using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Models {
    public class Event {
        public string Id { get; set; }
        public string EventType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RestaurantId { get; set; }
        public Order Order { get; set; }

        public string UI_TimeReceived {
            get { return CreatedAt.ToLocalTime().ToString(); }
        }
        public string UI_Type {
            get { return EventType; }
        }
        public string UI_Service {
            get { return Order.Service; }
        }
        public string UI_Name {
            get { return Order.CustomerName; }
        }
        public string UI_PickupTime {
            get { return Order.PickupTime.ToLocalTime().ToString(); }
        }
        public string UI_OrderSize {
            get { return Order.OrderSize.ToString(); }
        }
        public string UI_ConfirmStatus {
            get { return Order.ConfirmStatus.ToString(); }
        }
        public string UI_PrintStatus {
            get { return Order.PrintStatus.ToString(); }
        }
    }
}
