using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.State;
using OnlineOrderPrinter.UserControls.Login;
using OnlineOrderPrinter.UserControls.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter {

    public partial class FormContainer : Form {

        public static string AppDataDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        public static string UserDataPath = Path.Combine(AppDataDirPath, "user_data.dat");

        public FormContainer() {
            InitializeComponent();
            InitializeDirectories();
            AppState.FormContainer = this;
            // TODO: Need to disable the login button or show a different screen
            // while we check if the user can authenticate with the stored credentials
            AuthActions.AuthenticateWithStoredCredentials();
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
                // Newly created controls need to be docked
                nextControl.Dock = DockStyle.Fill;
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

        private void InitializeDirectories() {
            try {
                Directory.CreateDirectory(AppDataDirPath);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
        }
    }

    public static class ControlNames {
        public const string LoginPage = "userControlLoginPage1";
        public const string MainPage = "userControlMainPage1";
    }
}
