using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.UserControls.Main.Tabs.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderPrinter.Forms {
    public partial class FormAuthorizationBox : Form {
        public FormAuthorizationBox(string title, UserType requiredPermissionLevel) {
            InitializeComponent();
            labelTitle.Text = title;
            SetPermissionText(requiredPermissionLevel);
            labelErrorStatus.ForeColor = Colors.ErrorRed;
        }

        private void SetPermissionText(UserType userType) {
            labelPermissionText.Text = $"This action requires {userType.ToString()} level permissions or higher to execute.";
        }
    }
}
