using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Models {
    class OrderItem : OrderItemBase {
        public int Quantity { get; set; }
        public string SpecialInstructions { get; set; }
        public string LabelName { get; set; }
        public string Error { get; set; }
        public OrderItemModifier[] OrderItemModifiers { get; set; }
    }
}
