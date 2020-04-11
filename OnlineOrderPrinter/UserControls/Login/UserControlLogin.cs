using OnlineOrderPrinter.State;
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

namespace OnlineOrderPrinter.UserControls.Login {
    public partial class UserControlLogin : UserControl {
        public UserControlLogin() {
            InitializeComponent();
        }

        public void ClearLoginFields() {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button1_Click(object sender, EventArgs e) {
            string email = textBox1.Text;
            string password = textBox2.Text;

            AuthActions.Authenticate(email, password);
        }
    }
}
