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

namespace OnlineOrderPrinter.UserControls.Main {
    public partial class UserControlMainPage : UserControl {

        public string ActiveTabName = TabNames.Orders;
        public List<Control> Tabs;

        public UserControlMainPage() {
            InitializeComponent();
            AppState.UserControlMainPage = this;
            SetTabRefs();
        }

        private void UserControlMain_Load(object sender, EventArgs e) {

        }

        private void SetTabRefs() {
            Tabs = new List<Control> {
                userControlOrdersTab1,
                userControlSettingsTab1,
                userControlAboutTab1
            };
        }

        public void NavigateToTab(string nextTabName) {
            if (nextTabName == ActiveTabName) {
                return;
            }
            foreach (Control tab in Tabs) {
                if (nextTabName == tab.Name) {
                    tab.Show();
                    ActiveTabName = tab.Name;
                } else {
                    tab.Hide();
                }
            }
        }
    }

    public static class TabNames {
        public const string Orders = "userControlOrdersTab1";
        public const string Settings = "userControlSettingsTab1";
        public const string About = "userControlAboutTab1";
    }
}
