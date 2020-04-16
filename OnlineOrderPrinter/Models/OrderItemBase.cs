using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Models {
    abstract public class OrderItemBase {
        public string Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ItemType ItemType { get; set; }
        public string DoordashName { get; set; }
        public string GrubhubName { get; set; }
        public string UbereatsName { get; set; }
    }
}
