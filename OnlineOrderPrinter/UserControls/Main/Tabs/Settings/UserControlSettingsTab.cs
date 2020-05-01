using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Forms;
using OnlineOrderPrinter.Models;
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

namespace OnlineOrderPrinter.UserControls.Main.Tabs.Settings {
    public partial class UserControlSettingsTab : UserControl {
        public UserControlSettingsTab() {
            InitializeComponent();
        }

        /**
         * If the logged in user is already has owner level permissions or higher, just log out.
         * Otherwise popup a form authorize the action using a user's credentials
         */
        private void buttonLogout_Click(object sender, EventArgs e) {
            bool logoutPermitted = false;

            if (AppState.User.UserType >= UserType.Owner) {
                logoutPermitted = true;
            } else {
                FormAuthorizationBox authorizationBox = new FormAuthorizationBox("Logout", UserType.Owner);
                DialogResult dialogResult = authorizationBox.ShowDialog(this);

                if (dialogResult == DialogResult.OK) {
                    logoutPermitted = true;
                }
            }

            if (logoutPermitted) {
                AuthActions.Logout();
            }
        }
    }
}
