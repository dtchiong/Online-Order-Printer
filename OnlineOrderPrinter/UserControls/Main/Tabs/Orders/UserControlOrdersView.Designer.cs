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
            this.eventListDataGridView = new System.Windows.Forms.DataGridView();
            this.timeReceivedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickupTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.eventListDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 608);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // eventListDataGridView
            // 
            this.eventListDataGridView.AllowUserToAddRows = false;
            this.eventListDataGridView.AllowUserToDeleteRows = false;
            this.eventListDataGridView.AllowUserToResizeColumns = false;
            this.eventListDataGridView.AllowUserToResizeRows = false;
            this.eventListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventListDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.eventListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eventListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.eventListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.eventListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventListDataGridView.Size = new System.Drawing.Size(1038, 547);
            this.eventListDataGridView.TabIndex = 0;
            this.eventListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.eventListDataGridView_CellFormatting);
            // 
            // timeReceivedDataGridViewTextBoxColumn
            // 
            this.timeReceivedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.timeReceivedDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.timeReceivedDataGridViewTextBoxColumn.HeaderText = "Time Received";
            this.timeReceivedDataGridViewTextBoxColumn.Name = "timeReceivedDataGridViewTextBoxColumn";
            this.timeReceivedDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeReceivedDataGridViewTextBoxColumn.Width = 115;
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
            this.pickupTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pickupTimeDataGridViewTextBoxColumn.DataPropertyName = "Order.PickupTime";
            this.pickupTimeDataGridViewTextBoxColumn.HeaderText = "Pickup Time";
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
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(OnlineOrderPrinter.Models.Event);
            // 
            // UserControlOrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlOrdersView";
            this.Size = new System.Drawing.Size(1038, 608);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView eventListDataGridView;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeReceivedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickupTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn printStatusDataGridViewTextBoxColumn;
    }
}
