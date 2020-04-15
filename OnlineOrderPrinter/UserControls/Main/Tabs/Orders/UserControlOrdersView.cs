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
        private Dictionary<string, Func<object, string>> eventListDataGridViewFormatters;
        private bool initialEventsSelectionOccurred = false;
        private string currentEventsSelection;

        public UserControlOrdersView() {
            InitializeComponent();
            InitializeEventsSelectionAndComboBox();
            InitializeEventListDataGridViewFormatters();
            InitializeEventListDataGridView();
            AppState.UserControlOrdersView = this;
        }

        public void SetEventListBindingList(BindingList<Event> bindingList) {
            eventListBindingSource.DataSource = bindingList;
        }

        private void InitializeEventsSelectionAndComboBox() {
            string[] eventsSelections = new string[] {
                EventsSelection.Today, EventsSelection.Yesterday, EventsSelection.Last7Days, EventsSelection.Last30Days
            };
            currentEventsSelection = eventsSelections[0];

            comboBoxEventsSelector.DataSource = eventsSelections;
        }

        private void InitializeEventListDataGridViewFormatters() {
            eventListDataGridViewFormatters = new Dictionary<string, Func<object, string>> {
                { timeReceivedDataGridViewTextBoxColumn.DataPropertyName, FormatColumnDate },
                { typeDataGridViewTextBoxColumn.DataPropertyName, FormatEventType },
                { pickupTimeDataGridViewTextBoxColumn.DataPropertyName, FormatColumnDate }
            };
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
            object columnVal = null;

            if (row.DataBoundItem == null) {
                return;
            }

            if (col.DataPropertyName.Contains(".")) {
                string[] props = col.DataPropertyName.Split('.');
                PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                object val = propInfo.GetValue(row.DataBoundItem, null);
                for (int i = 1; i < props.Length; i++) {
                    propInfo = val.GetType().GetProperty(props[i]);
                    val = propInfo.GetValue(val, null);
                }
                columnVal = val;
            } else {
                PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(col.DataPropertyName);
                columnVal = propInfo.GetValue(row.DataBoundItem, null);
            }

            if (columnVal != null) {
                e.Value = FormatEventListDataGridViewColumn(col.DataPropertyName, columnVal);
            }
        }

        private string FormatEventListDataGridViewColumn(string dataPropertyName, object val) {
            if (eventListDataGridViewFormatters.TryGetValue(dataPropertyName, out Func<object, string> formatter)) {
                return formatter(val);
            } else {
                return val.ToString();
            }
        }

        private string FormatColumnDate(object val) {
            DateTime dateTime = ((DateTime)val).ToLocalTime();
            bool sameDay = dateTime.Date == DateTime.Now.Date;
            string time = dateTime.ToShortTimeString();
            string date = dateTime.ToShortDateString();

            return $"{(sameDay ? "Today " : date),10} {time,8}";
        }

        private string FormatEventType(object val) {
            string eventType = val.ToString();

            switch (eventType) {
                case "new_order":
                    return "New Order";
                default:
                    return eventType;
            }
        }

        private void comboBoxEventsSelector_SelectedValueChanged(object sender, EventArgs e) {
            if (!initialEventsSelectionOccurred) {
                initialEventsSelectionOccurred = true;
                return;
            }

            string selection = ((ComboBox)sender).SelectedValue.ToString();
            if (selection == currentEventsSelection) {
                return;
            }

            currentEventsSelection = selection;
            switch (selection) {
                case EventsSelection.Today:
                    // TODO
                    break;
                case EventsSelection.Yesterday:
                    // TODO
                    break;
                case EventsSelection.Last7Days:
                    // TODO
                    break;
                case EventsSelection.Last30Days:
                    // TODO
                    break;
            }
        }
    }

    public static class EventsSelection {
        public const string Today = "Today";
        public const string Yesterday = "Yesterday";
        public const string Last7Days = "Last 7 Days";
        public const string Last30Days = "Last 30 Days";
    }
}
