namespace OnlineOrderPrinter.UserControls.Main.Tabs.Orders {
    partial class UserControlOrdersTab {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userControlOrdersView1 = new OnlineOrderPrinter.UserControls.Main.Tabs.Orders.UserControlOrdersView();
            this.userControlDetailedOrderView1 = new OnlineOrderPrinter.UserControls.Main.Tabs.Orders.UserControlDetailedOrderView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userControlOrdersView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.userControlDetailedOrderView1);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 802);
            this.splitContainer1.SplitterDistance = 608;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // userControlOrdersView1
            // 
            this.userControlOrdersView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlOrdersView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlOrdersView1.Location = new System.Drawing.Point(0, 0);
            this.userControlOrdersView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlOrdersView1.Name = "userControlOrdersView1";
            this.userControlOrdersView1.Size = new System.Drawing.Size(1038, 608);
            this.userControlOrdersView1.TabIndex = 0;
            // 
            // userControlDetailedOrderView1
            // 
            this.userControlDetailedOrderView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDetailedOrderView1.Location = new System.Drawing.Point(0, 0);
            this.userControlDetailedOrderView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlDetailedOrderView1.Name = "userControlDetailedOrderView1";
            this.userControlDetailedOrderView1.Size = new System.Drawing.Size(1038, 193);
            this.userControlDetailedOrderView1.TabIndex = 0;
            // 
            // UserControlOrdersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserControlOrdersTab";
            this.Size = new System.Drawing.Size(1038, 802);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControlOrdersView userControlOrdersView1;
        private UserControlDetailedOrderView userControlDetailedOrderView1;
    }
}
