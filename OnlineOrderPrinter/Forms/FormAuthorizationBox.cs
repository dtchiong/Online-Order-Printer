using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.Sagas;
using OnlineOrderPrinter.Sagas.AuthSagaResponses;
using OnlineOrderPrinter.UserControls.Main.Tabs.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.Forms {
    public partial class FormAuthorizationBox : Form {
        private UserType requiredPermissionLevel;
        private string indefiniteArticle;

        public FormAuthorizationBox(string title, UserType requiredPermissionLevel) {
            InitializeComponent();
            this.requiredPermissionLevel = requiredPermissionLevel;

            labelTitle.Text = title;
            SetIndefiniteArticle();
            SetPermissionText();
        }

        private void SetPermissionText() {
            labelPermissionText.Text = $"This action requires {requiredPermissionLevel.ToString()} level permissions or higher to execute.";
        }

        private void SetIndefiniteArticle() {
            switch (requiredPermissionLevel) {
                case UserType.Restaurant:
                case UserType.Manager:
                    indefiniteArticle = "a";
                    break;
                case UserType.Owner:
                case UserType.Admin:
                    indefiniteArticle = "an";
                    break;
            }
        }

        private void SetButtonsEnabled(bool enabled) {
            buttonConfirm.Enabled = enabled;
            buttonCancel.Enabled = enabled;
        }

        private async void buttonConfirm_Click(object sender, EventArgs e) {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            SetButtonsEnabled(false);

            labelErrorStatus.Text = "Authorizing...";
            labelErrorStatus.ForeColor = Colors.LoadingGray;

            AuthorizeActionSagaResponse response = await AuthSagas.AuthorizeAction(username, password, UserType.Owner);

            if (response.IsSuccessStatusCode()) {
                DialogResult = DialogResult.OK;
                Close();
            } else {
                if (response.StatusCode == HttpStatusCode.Unauthorized) {
                    labelErrorStatus.Text = "Invalid username or password. Please try again.";
                } else if (response.StatusCode == HttpStatusCode.Forbidden) {
                    labelErrorStatus.Text = $"Unauthorized. Contact {indefiniteArticle} {requiredPermissionLevel.ToString()}.";
                } else if (response.IsServerErrorStatusCode()) {
                    labelErrorStatus.Text = "A server error occurred.";
                } else {
                    labelErrorStatus.Text = "Unknown error. Please try again.";
                }
                labelErrorStatus.ForeColor = Colors.ErrorRed;
            }

            SetButtonsEnabled(true);
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
