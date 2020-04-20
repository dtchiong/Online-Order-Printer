using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Sagas {
    abstract class CancellableSaga {
        protected static ConcurrentDictionary<CancellationToken, CancellationTokenSource> CtsPairMap
            = new ConcurrentDictionary<CancellationToken, CancellationTokenSource>();

        public static void Cancel(CancellationTokenSource cts) {
            try {
                if (cts != null) {
                    cts.Cancel();
                }
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
