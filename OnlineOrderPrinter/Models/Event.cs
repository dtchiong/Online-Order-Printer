﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Models {
    public class Event {
        public long Id { get; set; }
        public EventType EventType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RestaurantId { get; set; }
        public Order Order { get; set; }
    }
}
