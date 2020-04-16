using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Models {
    public class Order {
        public string Id { get; set; }
        public ServiceType Service { get; set; }
        public string ServiceOrderId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime PlacedAtTime { get; set; }
        public DateTime PickupTime { get; set; }
        public int OrderSize { get; set; }
        public int UniqueItemCount { get; set; }
        public int? DrinkCount { get; set; }
        public int? FoodCount { get; set; }
        public string ConfirmOrderUrl { get; set; }
        public bool ConfirmStatus { get; set; }
        public bool PrintStatus { get; set; }
        public string GmailMessageId { get; set; }
        public string Error { get; set; }
        public OrderItem[] OrderItems { get; set; }
    }
}
