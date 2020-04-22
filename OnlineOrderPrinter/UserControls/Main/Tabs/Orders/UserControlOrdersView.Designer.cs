namespace OnlineOrderPrinter.UserControls.Main.Tabs.Orders {
    partial class UserControlOrdersView {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEventsSelector = new System.Windows.Forms.ComboBox();
            this.eventListDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeReceivedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickupTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.splitContainer1.Panel2.Controls.Add(this.eventListDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 608);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.comboBoxEventsSelector);
            this.splitContainer2.Size = new System.Drawing.Size(1038, 80);
            this.splitContainer2.SplitterDistance = 35;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Viewing:";
            // 
            // comboBoxEventsSelector
            // 
            this.comboBoxEventsSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventsSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEventsSelector.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEventsSelector.FormattingEnabled = true;
            this.comboBoxEventsSelector.IntegralHeight = false;
            this.comboBoxEventsSelector.Location = new System.Drawing.Point(77, 1);
            this.comboBoxEventsSelector.Name = "comboBoxEventsSelector";
            this.comboBoxEventsSelector.Size = new System.Drawing.Size(121, 28);
            this.comboBoxEventsSelector.TabIndex = 1;
            this.comboBoxEventsSelector.TabStop = false;
            this.comboBoxEventsSelector.DropDownClosed += new System.EventHandler(this.comboBoxEventsSelector_DropDownClosed);
            this.comboBoxEventsSelector.SelectedValueChanged += new System.EventHandler(this.comboBoxEventsSelector_SelectedValueChanged);
            // 
            // eventListDataGridView
            // 
            this.eventListDataGridView.AllowUserToAddRows = false;
            this.eventListDataGridView.AllowUserToDeleteRows = false;
            this.eventListDataGridView.AllowUserToResizeColumns = false;
            this.eventListDataGridView.AllowUserToResizeRows = false;
            this.eventListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventListDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.eventListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eventListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.eventListDataGridView.ColumnHeadersHeight = 40;
            this.eventListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.eventListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.timeReceivedDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.serviceDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.pickupTimeDataGridViewTextBoxColumn,
            this.orderSizeDataGridViewTextBoxColumn,
            this.confirmStatusDataGridViewTextBoxColumn,
            this.printStatusDataGridViewTextBoxColumn});
            this.eventListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventListDataGridView.EnableHeadersVisualStyles = false;
            this.eventListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.eventListDataGridView.MultiSelect = false;
            this.eventListDataGridView.Name = "eventListDataGridView";
            this.eventListDataGridView.ReadOnly = true;
            this.eventListDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.eventListDataGridView.RowHeadersVisible = false;
            this.eventListDataGridView.RowTemplate.Height = 40;
            this.eventListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventListDataGridView.Size = new System.Drawing.Size(1038, 527);
            this.eventListDataGridView.TabIndex = 0;
            this.eventListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.eventListDataGridView_CellFormatting);
            this.eventListDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.eventListDataGridView_RowsAdded);
            this.eventListDataGridView.SelectionChanged += new System.EventHandler(this.eventListDataGridView_SelectionChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // timeReceivedDataGridViewTextBoxColumn
            // 
            this.timeReceivedDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.timeReceivedDataGridViewTextBoxColumn.HeaderText = "Time Received";
            this.timeReceivedDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.timeReceivedDataGridViewTextBoxColumn.Name = "timeReceivedDataGridViewTextBoxColumn";
            this.timeReceivedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "EventType";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviceDataGridViewTextBoxColumn
            // 
            this.serviceDataGridViewTextBoxColumn.DataPropertyName = "Order.Service";
            this.serviceDataGridViewTextBoxColumn.HeaderText = "Service";
            this.serviceDataGridViewTextBoxColumn.Name = "serviceDataGridViewTextBoxColumn";
            this.serviceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Order.CustomerName";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pickupTimeDataGridViewTextBoxColumn
            // 
            this.pickupTimeDataGridViewTextBoxColumn.DataPropertyName = "Order.PickupTime";
            this.pickupTimeDataGridViewTextBoxColumn.HeaderText = "Pickup Time";
            this.pickupTimeDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.pickupTimeDataGridViewTextBoxColumn.Name = "pickupTimeDataGridViewTextBoxColumn";
            this.pickupTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderSizeDataGridViewTextBoxColumn
            // 
            this.orderSizeDataGridViewTextBoxColumn.DataPropertyName = "Order.OrderSize";
            this.orderSizeDataGridViewTextBoxColumn.HeaderText = "Order Size";
            this.orderSizeDataGridViewTextBoxColumn.Name = "orderSizeDataGridViewTextBoxColumn";
            this.orderSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // confirmStatusDataGridViewTextBoxColumn
            // 
            this.confirmStatusDataGridViewTextBoxColumn.DataPropertyName = "Order.ConfirmStatus";
            this.confirmStatusDataGridViewTextBoxColumn.HeaderText = "Confirm Status";
            this.confirmStatusDataGridViewTextBoxColumn.Name = "confirmStatusDataGridViewTextBoxColumn";
            this.confirmStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // printStatusDataGridViewTextBoxColumn
            // 
            this.printStatusDataGridViewTextBoxColumn.DataPropertyName = "Order.PrintStatus";
            this.printStatusDataGridViewTextBoxColumn.HeaderText = "Print Status";
            this.printStatusDataGridViewTextBoxColumn.Name = "printStatusDataGridViewTextBoxColumn";
            this.printStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.IntegralHeight = false;
            this.comboBox3.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "Last 7 Days",
            "Last 30 Days"});
            this.comboBox3.Location = new System.Drawing.Point(81, 3);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 28);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.TabStop = false;
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(OnlineOrderPrinter.Models.Event);
            // 
            // UserControlOrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.comboBox3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControlOrdersView";
            this.Size = new System.Drawing.Size(1038, 608);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEventsSelector;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeReceivedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickupTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn printStatusDataGridViewTextBoxColumn;
        public System.Windows.Forms.DataGridView eventListDataGridView;
    }
}
