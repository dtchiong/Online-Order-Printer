using OnlineOrderPrinter.State;
using OnlineOrderPrinter.UserControls.Login;
using OnlineOrderPrinter.UserControls.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter {

    public partial class FormContainer : Form {

        public FormContainer() {
            InitializeComponent();
            AppState.FormContainer = this;
        }

        /**
         * Safely navigates to the specified control by checking if the navigate call
         * needs to be delegated to the main thread.
         */
        public void NavigateToPageSafe(string controlName) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate { NavigateToPage(controlName); });
            } else {
                NavigateToPage(controlName);
            }
        }

        /**
         * Navigates to the specified control and sets it as the active control
         */
        private void NavigateToPage(string controlName) {
            if (ActiveControl == Controls[controlName]) {
                return;
            }

            ActiveControl.Hide();

            Control nextControl = Controls[controlName];
            if (nextControl == null) {
                nextControl = NewControl(controlName);
                Controls.Add(nextControl);
            }
            nextControl.Show();
            ActiveControl = nextControl;
        }

        private Control NewControl(string controlName) {
            switch (controlName) {
                case ControlNames.MainPage:
                    return new UserControlMainPage();
                case ControlNames.LoginPage:
                    return new UserControlLoginPage();
                default:
                    return null;
            }
        }
    }

    public static class ControlNames {
        public const string LoginPage = "userControlLoginPage1";
        public const string MainPage = "userControlMainPage1";
    }
}
