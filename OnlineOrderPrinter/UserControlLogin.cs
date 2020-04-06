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

namespace OnlineOrderPrinter {
    public partial class UserControlLogin : UserControl {
        public UserControlLogin() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string email = textBox1.Text;
            string password = textBox2.Text;

            //FormMain formMain = new FormMain();
            //formMain.Show();
            //ParentForm.Hide();
            //FindForm().Hide();
            //Debug.WriteLine(FindForm());
            FormContainer formContainer = (FormContainer)FindForm();
            //Debug.WriteLine(formContainer);
            formContainer.PrintSup();

        }
    }
}
