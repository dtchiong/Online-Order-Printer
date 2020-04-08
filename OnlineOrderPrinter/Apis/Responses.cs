﻿using OnlineOrderPrinter.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Apis {
    namespace Responses {
        class AuthResponse {
            public User User { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }
    }
}