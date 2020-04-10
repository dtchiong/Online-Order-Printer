﻿using OnlineOrderPrinter.State;
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
        public const string MainPage = "userControlMainPage";
    }

    public partial class FormContainer : Form {

        public FormContainer() {
            InitializeComponent();
            AppState.FormContainer = this;
        }

        public void NavigateToMainPage() {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate { NavigateToPage(ControlNames.MainPage); });
            } else {
                NavigateToPage(ControlNames.MainPage);
            }
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
                case ControlNames.MainPage:
                    return new UserControlMainPage();
                case ControlNames.LoginPage:
                    return new UserControlLoginPage();
                default:
                    return null;
            }
        }
    }
}
