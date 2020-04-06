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


    public static class ControlNames {
        public const string LoginPage = "userControlLoginPage1";
        public const string Mainpage = "userControlMainPage";
    }

    public partial class FormContainer : Form {
        public FormContainer() {
            InitializeComponent();
        }

        private void userControlLoginPage1_Load(object sender, EventArgs e) {

        }

        public void NavigateToMainPage() {
            NavigateToPage(ControlNames.Mainpage);
        }

        public void NavigateToLoginPage() {
            NavigateToPage(ControlNames.LoginPage);
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
                case ControlNames.Mainpage:
                    return new UserControlMainPage();
                case ControlNames.LoginPage:
                    return new UserControlLoginPage();
                default:
                    return null;
            }
        }
    }
}
