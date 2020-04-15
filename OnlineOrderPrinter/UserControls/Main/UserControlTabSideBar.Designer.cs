namespace OnlineOrderPrinter.UserControls.Main {
    partial class UserControlTabSideBar {
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labelRestaurantText = new System.Windows.Forms.Label();
            this.labelRestaurantName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAboutTab = new System.Windows.Forms.Button();
            this.buttonSettingsTab = new System.Windows.Forms.Button();
            this.buttonOrdersTab = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(214, 800);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.labelRestaurantText);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.labelRestaurantName);
            this.splitContainer2.Size = new System.Drawing.Size(214, 130);
            this.splitContainer2.SplitterDistance = 67;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // labelRestaurantText
            // 
            this.labelRestaurantText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRestaurantText.AutoSize = true;
            this.labelRestaurantText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestaurantText.ForeColor = System.Drawing.Color.White;
            this.labelRestaurantText.Location = new System.Drawing.Point(3, 46);
            this.labelRestaurantText.Name = "labelRestaurantText";
            this.labelRestaurantText.Size = new System.Drawing.Size(88, 21);
            this.labelRestaurantText.TabIndex = 0;
            this.labelRestaurantText.Text = "Restaurant";
            // 
            // labelRestaurantName
            // 
            this.labelRestaurantName.AutoSize = true;
            this.labelRestaurantName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRestaurantName.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestaurantName.ForeColor = System.Drawing.Color.White;
            this.labelRestaurantName.Location = new System.Drawing.Point(0, 0);
            this.labelRestaurantName.Name = "labelRestaurantName";
            this.labelRestaurantName.Size = new System.Drawing.Size(0, 37);
            this.labelRestaurantName.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAboutTab, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSettingsTab, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOrdersTab, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(214, 669);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAboutTab
            // 
            this.buttonAboutTab.BackColor = System.Drawing.Color.Transparent;
            this.buttonAboutTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAboutTab.FlatAppearance.BorderSize = 0;
            this.buttonAboutTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAboutTab.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAboutTab.ForeColor = System.Drawing.Color.White;
            this.buttonAboutTab.Location = new System.Drawing.Point(3, 163);
            this.buttonAboutTab.Name = "buttonAboutTab";
            this.buttonAboutTab.Size = new System.Drawing.Size(208, 74);
            this.buttonAboutTab.TabIndex = 2;
            this.buttonAboutTab.TabStop = false;
            this.buttonAboutTab.Text = "About";
            this.buttonAboutTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAboutTab.UseVisualStyleBackColor = false;
            this.buttonAboutTab.Click += new System.EventHandler(this.buttonTab_Click);
            // 
            // buttonSettingsTab
            // 
            this.buttonSettingsTab.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSettingsTab.FlatAppearance.BorderSize = 0;
            this.buttonSettingsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettingsTab.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettingsTab.ForeColor = System.Drawing.Color.White;
            this.buttonSettingsTab.Location = new System.Drawing.Point(3, 83);
            this.buttonSettingsTab.Name = "buttonSettingsTab";
            this.buttonSettingsTab.Size = new System.Drawing.Size(208, 74);
            this.buttonSettingsTab.TabIndex = 1;
            this.buttonSettingsTab.TabStop = false;
            this.buttonSettingsTab.Text = "Settings";
            this.buttonSettingsTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettingsTab.UseVisualStyleBackColor = false;
            this.buttonSettingsTab.Click += new System.EventHandler(this.buttonTab_Click);
            // 
            // buttonOrdersTab
            // 
            this.buttonOrdersTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(22)))));
            this.buttonOrdersTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOrdersTab.FlatAppearance.BorderSize = 0;
            this.buttonOrdersTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrdersTab.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOrdersTab.ForeColor = System.Drawing.Color.White;
            this.buttonOrdersTab.Location = new System.Drawing.Point(3, 3);
            this.buttonOrdersTab.Name = "buttonOrdersTab";
            this.buttonOrdersTab.Size = new System.Drawing.Size(208, 74);
            this.buttonOrdersTab.TabIndex = 0;
            this.buttonOrdersTab.TabStop = false;
            this.buttonOrdersTab.Text = "Orders";
            this.buttonOrdersTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOrdersTab.UseVisualStyleBackColor = false;
            this.buttonOrdersTab.Click += new System.EventHandler(this.buttonTab_Click);
            // 
            // UserControlTabSideBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlTabSideBar";
            this.Size = new System.Drawing.Size(214, 800);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labelRestaurantText;
        private System.Windows.Forms.Label labelRestaurantName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonOrdersTab;
        private System.Windows.Forms.Button buttonAboutTab;
        private System.Windows.Forms.Button buttonSettingsTab;
    }
}
