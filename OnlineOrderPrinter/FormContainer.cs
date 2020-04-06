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
    }


    public partial class FormContainer : Form {
        public FormContainer() {
            InitializeComponent();
        }

        private void userControlLoginPage1_Load(object sender, EventArgs e) {

        }

        public void PrintSup() {
            UserControlMain userControlMain = new UserControlMain();
            Controls.Add(userControlMain);
            userControlMain.Show();
            Debug.WriteLine(Controls[ControlNames.LoginPage]);
        }

        public void SwitchToMain() {
            userControlLoginPage1.Hide();
        }
    }
}
