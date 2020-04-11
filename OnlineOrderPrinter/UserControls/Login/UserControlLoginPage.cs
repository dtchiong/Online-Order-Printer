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
using System.Diagnostics;
using System.Threading;

namespace OnlineOrderPrinter.UserControls.Login {
    public partial class UserControlLoginPage : UserControl {

        public UserControlLoginPage() {
            InitializeComponent();
            AppState.UserControlLoginPage = this;
        }

        public void ClearLoginFieldsSafe() {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate { ClearLoginFields(); });
            } else {
                ClearLoginFields();
            }
        }

        private void ClearLoginFields() {
            userControlLogin1.ClearLoginFields();
        }
    }
}
