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
using System.Reflection;
using System.Diagnostics;

namespace OnlineOrderPrinter.UserControls.Main.Tabs.Orders {
    public partial class UserControlDetailedOrderView : UserControl {

        public UserControlDetailedOrderView() {
            InitializeComponent();
            ConfigureItemListDataGridView();
            AppState.UserControlDetailedOrderView = this;
        }

        public void HandleSelectedEventChanged(Event @event) {
            UpdateOrderDetails(@event);
            UpdateItemList(@event?.Order);
        }

        private void ConfigureItemListDataGridView() {
            dataGridViewItemList.AutoGenerateColumns = false;
        }

        private void UpdateOrderDetails(Event @event) {
            labelNameValue.Text = @event?.Order?.CustomerName;
            labelContactValue.Text = @event?.Order?.ContactNumber;
            labelOrderSizeValue.Text = @event?.Order?.OrderSize.ToString();
            label4.Text = @event?.Order?.GmailMessageId;
            label5.Text = @event?.Order?.Id;
        }

        private void UpdateItemList(Order order) {
            dataGridViewItemList.DataSource = order?.OrderItems;
        }

        private void dataGridViewItemList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];

            if (row.DataBoundItem == null) {
                return;
            }

            if (col.DataPropertyName == itemNameDataGridViewTextBoxColumn.DataPropertyName) {
                e.Value = FormatItemName((OrderItem)row.DataBoundItem);
            }
        }

        private string FormatItemName(OrderItem orderItem) {
            if (orderItem.Name != null) {
                return orderItem.Name;
            }

            Order order = AppState.UserControlOrdersView.GetCurrentSelectedEvent()?.Order;

            if (order != null) {
                switch (order.Service) {
                    case ServiceType.DoorDash:
                        return orderItem.DoordashName;
                    case ServiceType.Grubhub:
                        return orderItem.GrubhubName;
                    case ServiceType.UberEats:
                        return orderItem.UbereatsName;
                }
            }
            return "";
        }
    }
}
