namespace OnlineOrderPrinter.UserControls.Main {
    partial class UserControlMainPage {
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
            this.userControlTabSideBar1 = new OnlineOrderPrinter.UserControls.Main.UserControlTabSideBar();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labelTabName = new System.Windows.Forms.Label();
            this.userControlOrdersTab1 = new OnlineOrderPrinter.UserControls.Main.Tabs.Orders.UserControlOrdersTab();
            this.userControlSettingsTab1 = new OnlineOrderPrinter.UserControls.Main.Tabs.Settings.UserControlSettingsTab();
            this.userControlAboutTab1 = new OnlineOrderPrinter.UserControls.Main.Tabs.About.UserControlAboutTab();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userControlTabSideBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1023, 800);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            // 
            // userControlTabSideBar1
            // 
            this.userControlTabSideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.userControlTabSideBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTabSideBar1.Location = new System.Drawing.Point(0, 0);
            this.userControlTabSideBar1.Name = "userControlTabSideBar1";
            this.userControlTabSideBar1.Size = new System.Drawing.Size(160, 800);
            this.userControlTabSideBar1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.labelTabName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.userControlOrdersTab1);
            this.splitContainer2.Panel2.Controls.Add(this.userControlSettingsTab1);
            this.splitContainer2.Panel2.Controls.Add(this.userControlAboutTab1);
            this.splitContainer2.Size = new System.Drawing.Size(859, 800);
            this.splitContainer2.SplitterDistance = 69;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // labelTabName
            // 
            this.labelTabName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTabName.AutoSize = true;
            this.labelTabName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTabName.ForeColor = System.Drawing.Color.Black;
            this.labelTabName.Location = new System.Drawing.Point(16, 19);
            this.labelTabName.Name = "labelTabName";
            this.labelTabName.Size = new System.Drawing.Size(166, 32);
            this.labelTabName.TabIndex = 0;
            this.labelTabName.Text = "Latest Orders";
            this.labelTabName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userControlOrdersTab1
            // 
            this.userControlOrdersTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlOrdersTab1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlOrdersTab1.Location = new System.Drawing.Point(0, 0);
            this.userControlOrdersTab1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlOrdersTab1.Name = "userControlOrdersTab1";
            this.userControlOrdersTab1.Size = new System.Drawing.Size(859, 730);
            this.userControlOrdersTab1.TabIndex = 2;
            // 
            // userControlSettingsTab1
            // 
            this.userControlSettingsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSettingsTab1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlSettingsTab1.Location = new System.Drawing.Point(0, 0);
            this.userControlSettingsTab1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlSettingsTab1.Name = "userControlSettingsTab1";
            this.userControlSettingsTab1.Size = new System.Drawing.Size(859, 730);
            this.userControlSettingsTab1.TabIndex = 1;
            // 
            // userControlAboutTab1
            // 
            this.userControlAboutTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAboutTab1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlAboutTab1.Location = new System.Drawing.Point(0, 0);
            this.userControlAboutTab1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlAboutTab1.Name = "userControlAboutTab1";
            this.userControlAboutTab1.Size = new System.Drawing.Size(859, 730);
            this.userControlAboutTab1.TabIndex = 0;
            // 
            // UserControlMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlMainPage";
            this.Size = new System.Drawing.Size(1023, 800);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UserControlTabSideBar userControlTabSideBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labelTabName;
        private Tabs.About.UserControlAboutTab userControlAboutTab1;
        private Tabs.Settings.UserControlSettingsTab userControlSettingsTab1;
        private Tabs.Orders.UserControlOrdersTab userControlOrdersTab1;
    }
}
