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

        public string ActiveTabName { get { return _activeTabName; } set { _activeTabName = value; SetLabelTabName(value); } }

        private List<Control> Tabs;
        private string _activeTabName = TabNames.Orders;

        public UserControlMainPage() {
            InitializeComponent();
            Visible = false;
            AppState.UserControlMainPage = this;
            SetTabRefs();
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

        public void SetLabelRestaurantNameSafe(string name) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate { userControlTabSideBar1.SetLabelRestaurantName(name); });
            } else {
                userControlTabSideBar1.SetLabelRestaurantName(name);
            }
        }

        private void SetTabRefs() {
            Tabs = new List<Control> {
                userControlOrdersTab1,
                userControlSettingsTab1,
                userControlAboutTab1
            };
        }

        private void SetLabelTabName(string tabName) {
            switch (tabName) {
                case TabNames.Orders:
                    labelTabName.Text = "Last Orders";
                    break;
                case TabNames.Settings:
                    labelTabName.Text = "Settings";
                    break;
                case TabNames.About:
                    labelTabName.Text = "About";
                    break;
            }
        }
    }

    public static class TabNames {
        public const string Orders = "userControlOrdersTab1";
        public const string Settings = "userControlSettingsTab1";
        public const string About = "userControlAboutTab1";
    }
}
