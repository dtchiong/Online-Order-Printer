using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.State;
using OnlineOrderPrinter.Utility;
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

        private SortableBindingList<Event> eventListBindingList = new SortableBindingList<Event>();
        private BindingSource eventListBindingSource = new BindingSource();
        private Dictionary<string, Func<object, string>> eventListDataGridViewFormatters;
        private bool initialEventsSelectionOccurred = false;

        public UserControlOrdersView() {
            InitializeComponent();
            InitializeEventsSelectionAndComboBox();
            InitializeEventListDataGridViewFormatters();
            InitializeEventListDataGridView();
            AppState.UserControlOrdersView = this;
        }

        public void UpdateEventList(List<Event> eventList, bool clearRequired) {
            comboBoxEventsSelector.Enabled = false;

            if (clearRequired) {
                eventListBindingList.Clear();
            }

            foreach (Event @event in eventList) {
                eventListBindingList.Add(@event);
            }

            // Workaround for bug where changing the selection to "Today" just before the list updates  desyncs
            // the AppState's selection from the combobox's selection. Maybe just disable combo boxes right after selection.
            // But pagination should be implemented before that to prevent long running fetches from holding the combobox hostage
            if (comboBoxEventsSelector.SelectedValue.ToString() == EventsSelection.Today && AppState.CurrentEventsSelection != EventsSelection.Today) {
                AppState.CurrentEventsSelection = EventsSelection.Today;
                UpdateEventList(AppState.CurrentEvents, true);
            }
            comboBoxEventsSelector.Enabled = true;
        }

        public Event GetCurrentSelectedEvent() {
            return eventListDataGridView.SelectedRows.Count > 0 ?
                (Event)eventListDataGridView.SelectedRows[0].DataBoundItem : null;
        }

        private void InitializeEventsSelectionAndComboBox() {
            comboBoxEventsSelector.MouseWheel += new MouseEventHandler(comboBoxEventsSelector_MouseWheel);

            string[] eventsSelections = new string[] {
                EventsSelection.Today, EventsSelection.Yesterday, EventsSelection.Last7Days, EventsSelection.Last30Days
            };
            AppState.CurrentEventsSelection = eventsSelections[0];

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
            eventListBindingSource.DataSource = eventListBindingList;
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

            if (sameDay) {
                return $"{$" Today {time,8}",-19}";
            } else {
                return $"{date,10} {time,8}";
            }
        }

        private string FormatEventType(object val) {
            EventType eventType = (EventType)val;

            switch (eventType) {
                case EventType.NewOrder:
                    return "New Order";
                default:
                    return eventType.ToString();
            }
        }

        private void comboBoxEventsSelector_SelectedValueChanged(object sender, EventArgs e) {
            // When the comboBox is initialized, this is triggered, so ignore the first event
            if (!initialEventsSelectionOccurred) {
                initialEventsSelectionOccurred = true;
                return;
            }

            string selection = ((ComboBox)sender).SelectedValue.ToString();
            if (selection == AppState.CurrentEventsSelection) {
                return;
            }

            AppState.CurrentEventsSelection = selection;

            eventListBindingList.Clear();
            // If the selection is Today's events, then just update the list with the AppState's 
            // CurrentEvents, since we never clear that, otherwise we have to fetch the past events
            if (selection == EventsSelection.Today) {
                UpdateEventList(AppState.CurrentEvents, true);
            } else {
                AppState.PastEvents.Clear();
                EventActions.FetchPresetRangeEvents(selection);
            }
        }

        /**
         * Change focus back to the event list datagrid for convienience, and so that
         * we lose focus of the combobox
         */
        private void comboBoxEventsSelector_DropDownClosed(object sender, EventArgs e) {
            AppState.UserControlOrdersView.eventListDataGridView.Focus();
        }

        private void comboBoxEventsSelector_MouseWheel(object sender, MouseEventArgs e) {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void eventListDataGridView_SelectionChanged(object sender, EventArgs e) {
            DataGridViewSelectedRowCollection selectedRows = eventListDataGridView.SelectedRows;
            Event @event = null;

            if (selectedRows.Count > 0) {
                @event = (Event)selectedRows[0].DataBoundItem;
            }
            AppState.UserControlDetailedOrderView.HandleSelectedEventChanged(@event);
        }

        private void eventListDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            SortEventList(EventListColumn.Id, ListSortDirection.Descending);
        }

        private void SortEventList(string columnName, ListSortDirection sortDirection) {
            eventListDataGridView.Sort(eventListDataGridView.Columns[columnName], sortDirection);

            // Updating the ui to the latest selected row after sorting because there's a weird issue
            // where on the initial list load, the order details only get updated to the 1st row inserted.
            Event @event = GetCurrentSelectedEvent();
            AppState.UserControlDetailedOrderView.HandleSelectedEventChanged(@event);
        }
    }

    public static class EventsSelection {
        public const string Today = "Today";
        public const string Yesterday = "Yesterday";
        public const string Last7Days = "Last 7 Days";
        public const string Last30Days = "Last 30 Days";
    }

    public static class EventListColumn {
        // Sortable
        public const string Id = "idDataGridViewTextBoxColumn";
        public const string Type = "typeDataGridViewTextBoxColumn";
        public const string TimeReceived = "timeReceivedDataGridViewTextBoxColumn";
        // Non-sortable since these properties are in Event.Order
        public const string Service = "serviceDataGridViewTextBoxColumn";
        public const string Name = "nameDataGridViewTextBoxColumn";
        public const string PickupTime = "pickupTimeDataGridViewTextBoxColumn";
        public const string OrderSize = "orderSizeDataGridViewTextBoxColumn";
        public const string ConfirmStatus = "confirmStatusDataGridViewTextBoxColumn";
        public const string PrintStatus = "printStatusDataGridViewTextBoxColumn";
    }
}
