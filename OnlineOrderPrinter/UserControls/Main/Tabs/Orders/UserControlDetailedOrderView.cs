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
            ConfigureModifierListDataGridView();
            AppState.UserControlDetailedOrderView = this;
        }

        public void HandleSelectedEventChanged(Event @event) {
            UpdateOrderDetails(@event);
            UpdateItemList(@event?.Order);
        }

        private void ConfigureItemListDataGridView() {
            dataGridViewItemList.AutoGenerateColumns = false;
        }

        private void ConfigureModifierListDataGridView() {
            modifierListDataGridView.AutoGenerateColumns = false;
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
                e.Value = FormatItemName((OrderItemBase)row.DataBoundItem);
            }
        }

        private void dataGridViewItemList_SelectionChanged(object sender, EventArgs e) {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewItemList.SelectedRows;
            OrderItem orderItem = null;

            if (selectedRows.Count > 0) {
                orderItem = (OrderItem)selectedRows[0].DataBoundItem;
            }
            HandleSelectedItemChanged(orderItem);
        }

        private void HandleSelectedItemChanged(OrderItem orderItem) {
            UpdateModifierList(orderItem);
            UpdateSpecialInstructions(orderItem);
        }

        private void UpdateModifierList(OrderItem orderItem) {
            modifierListDataGridView.DataSource = orderItem?.OrderItemModifiers;
        }

        private void UpdateSpecialInstructions(OrderItem orderItem) {
            textBoxSpecialInstructions.Text = orderItem?.SpecialInstructions;
        }

        private void modifierListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];

            if (row.DataBoundItem == null) {
                return;
            }

            if (col.DataPropertyName == modifierNameDataGridViewTextBoxColumn.DataPropertyName) {
                e.Value = FormatItemName((OrderItemBase)row.DataBoundItem);
            }
        }

        /**
         * Formats names for items or modifiers, since they're both derived from OrderItemBase
         * Prioritizes returning the item's set name, otherwise it returns the parsed name that's 
         * associated with the service that the order is from.
         */
        private string FormatItemName(OrderItemBase orderItemBase) {
            if (orderItemBase.Name != null) {
                return orderItemBase.Name;
            }

            Order order = AppState.UserControlOrdersView.GetCurrentSelectedEvent()?.Order;

            switch (order?.Service) {
                case ServiceType.DoorDash:
                    return orderItemBase.DoordashName;
                case ServiceType.Grubhub:
                    return orderItemBase.GrubhubName;
                case ServiceType.UberEats:
                    return orderItemBase.UbereatsName;
                default:
                    return "";
            }
        }
    }
}
