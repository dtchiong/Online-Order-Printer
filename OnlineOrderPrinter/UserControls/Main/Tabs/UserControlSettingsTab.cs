using OnlineOrderPrinter.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.UserControls.Main.Tabs {
    public partial class UserControlSettingsTab : UserControl {
        public UserControlSettingsTab() {
            InitializeComponent();
        }

        private void buttonLogout_Click(object sender, EventArgs e) {
            NavigationActions.NavigateToLoginPage();
            AppActions.ClearState();
        }
    }
}
