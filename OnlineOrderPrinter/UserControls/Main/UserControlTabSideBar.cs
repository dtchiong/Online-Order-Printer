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
using System.Diagnostics;

namespace OnlineOrderPrinter.UserControls.Main {
    public partial class UserControlTabSideBar : UserControl {

        private List<Button> TabButtons;
        private Button ActiveTabButton;
        private string ActiveTabButtonName = TabButtonNames.Orders;

        public UserControlTabSideBar() {
            InitializeComponent();
            SetButtonRefs();
        }

        private void SetButtonRefs() {
            TabButtons = new List<Button> {
                buttonOrdersTab,
                buttonSettingsTab,
                buttonAboutTab
            };
            ActiveTabButton = buttonOrdersTab;
        }

        private void buttonTab_Click(object sender, EventArgs e) {
            ChangeActiveButton(((Button)sender).Name);
            CallNavigateToTabAction(((Button)sender).Name);
        }

        private void ChangeActiveButton(string nextButtonName) {
            if (ActiveTabButtonName == nextButtonName) {
                return;
            }

            foreach (Button button in TabButtons) {
                if (nextButtonName == button.Name) {
                    button.BackColor = Color.FromArgb(255, 23, 21, 22);
                } else {
                    button.BackColor = Color.Transparent;
                }
            }
            ActiveTabButtonName = nextButtonName;
        }

        private void CallNavigateToTabAction(string buttonName) {
            switch (buttonName) {
                case TabButtonNames.Orders:
                    NavigationActions.NavigateToOrdersTab();
                    break;
                case TabButtonNames.Settings:
                    NavigationActions.NavigateToSettingsTab();
                    break;
                case TabButtonNames.About:
                    NavigationActions.NavigateToAboutTab();
                    break;
                default:
                    Debug.WriteLine($"Failed to navigate to tab corresponding to button name: {buttonName}");
                    break;
            }
        }
    }

    public static class TabButtonNames {
        public const string Orders = "buttonOrdersTab";
        public const string Settings = "buttonSettingsTab";
        public const string About = "buttonAboutTab";
    }
}
