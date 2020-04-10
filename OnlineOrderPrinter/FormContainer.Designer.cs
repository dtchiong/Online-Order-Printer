namespace OnlineOrderPrinter {
    partial class FormContainer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.userControlLoginPage1 = new OnlineOrderPrinter.UserControlLoginPage();
            this.SuspendLayout();
            // 
            // userControlLoginPage1
            // 
            this.userControlLoginPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(83)))));
            this.userControlLoginPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlLoginPage1.Location = new System.Drawing.Point(0, 0);
            this.userControlLoginPage1.Name = "userControlLoginPage1";
            this.userControlLoginPage1.Size = new System.Drawing.Size(1007, 656);
            this.userControlLoginPage1.TabIndex = 0;
            // 
            // FormContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 656);
            this.Controls.Add(this.userControlLoginPage1);
            this.Name = "FormContainer";
            this.Text = "FormContainer";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlLoginPage userControlLoginPage1;
    }
}