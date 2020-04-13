using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.State;
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
using System.Reflection;

namespace OnlineOrderPrinter.UserControls.Main.Tabs.Orders {
    public partial class UserControlOrdersView : UserControl {

        private BindingSource eventListBindingSource = new BindingSource();

        public UserControlOrdersView() {
            InitializeComponent();
            InitializeEventListDataGridView();
            AppState.UserControlOrdersView = this;
        }

        public void SetEventListBindingList(BindingList<Event> bindingList) {
            eventListBindingSource.DataSource = bindingList;
        }

        private void InitializeEventListDataGridView() {
            eventListDataGridView.AutoGenerateColumns = false;
            eventListBindingSource.DataSource = AppState.Events;
            eventListDataGridView.DataSource = eventListBindingSource;
        }

        private void eventListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];
            if (row.DataBoundItem != null && col.DataPropertyName.Contains(".")) {
                string[] props = col.DataPropertyName.Split('.');
                PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                object val = propInfo.GetValue(row.DataBoundItem, null);
                for (int i = 1; i < props.Length; i++) {
                    propInfo = val.GetType().GetProperty(props[i]);
                    val = propInfo.GetValue(val, null);
                }
                e.Value = val;
            }
        }
    }
}
