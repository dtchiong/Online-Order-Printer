using OnlineOrderPrinter.Actions;
using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.Services;
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
        private Dictionary<string, Action<DataGridViewCellFormattingEventArgs, object>> eventListDataGridViewFormatters;

        private bool initialEventsSelectionOccurred = false;

        public UserControlOrdersView() {
            InitializeComponent();
            InitializeEventsSelectionAndComboBox();
            InitializeEventListDataGridViewFormatters();
            InitializeEventListDataGridView();
            AppState.UserControlOrdersView = this;
        }

        public void UpdateEventList(List<Event> eventList, bool clearRequired, EventsContext eventsContext) {
            SetComboBoxEnabled(false);

            if (clearRequired) {
                eventListBindingList.Clear();
            }

            foreach (Event @event in eventList) {
                eventListBindingList.Add(@event);

                if (eventsContext == EventsContext.Latest) {
                    PlayEventSound(@event);
                }
            }

            // Workaround for bug where changing the selection to "Today" just before the list updates  desyncs
            // the AppState's selection from the combobox's selection. Maybe just disable combo boxes right after selection.
            // But pagination should be implemented before that to prevent long running fetches from holding the combobox hostage
            if (comboBoxEventsSelector.SelectedValue.ToString() == EventsSelection.Today && AppState.CurrentEventsSelection != EventsSelection.Today) {
                AppState.CurrentEventsSelection = EventsSelection.Today;
                UpdateEventList(AppState.CurrentEvents, true, eventsContext);
            }
            SetComboBoxEnabled(true);
        }

        public Event GetCurrentSelectedEvent() {
            return eventListDataGridView.SelectedRows.Count > 0 ?
                (Event)eventListDataGridView.SelectedRows[0].DataBoundItem : null;
        }

        public void SetComboBoxEnabledSafe(bool enabled) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate { SetComboBoxEnabled(enabled); });
            } else {
                SetComboBoxEnabled(enabled);
            }
        }

        private void InitializeEventsSelectionAndComboBox() {
            comboBoxEventsSelector.Enabled = false;
            comboBoxEventsSelector.MouseWheel += new MouseEventHandler(comboBoxEventsSelector_MouseWheel);

            string[] eventsSelections = new string[] {
                EventsSelection.Today, EventsSelection.Yesterday, EventsSelection.Last7Days, EventsSelection.Last14Days
            };
            AppState.CurrentEventsSelection = eventsSelections[0];

            comboBoxEventsSelector.DataSource = eventsSelections;
        }

        private void InitializeEventListDataGridViewFormatters() {
            eventListDataGridViewFormatters = new Dictionary<string, Action<DataGridViewCellFormattingEventArgs, object>> {
                { timeReceivedDataGridViewTextBoxColumn.DataPropertyName, FormatDateCell },
                { typeDataGridViewTextBoxColumn.DataPropertyName, FormatEventTypeCell },
                { pickupTimeDataGridViewTextBoxColumn.DataPropertyName, FormatDateCell },
                { confirmStatusDataGridViewTextBoxColumn.DataPropertyName, FormatConfirmStatusCell },
                { printStatusDataGridViewTextBoxColumn.DataPropertyName, FormatPrintStatusCell }
            };
        }

        private void InitializeEventListDataGridView() {
            eventListDataGridView.AutoGenerateColumns = false;
            eventListBindingSource.DataSource = eventListBindingList;
            eventListDataGridView.DataSource = eventListBindingSource;
        }

        private void SetComboBoxEnabled(bool enabled) {
            if (AppState.User?.UserType > UserType.Restaurant) {
                comboBoxEventsSelector.Enabled = enabled;
            }
        }

        // TODO: Play a different sound for updated orders
        private void PlayEventSound(Event @event) {
            switch (@event.EventType) {
                case EventType.NewOrder:
                case EventType.UpdateOrder:
                    SoundPlayer.Play(Sound.NewOrder);
                    break;
                case EventType.CancelOrder:
                    SoundPlayer.Play(Sound.CancelOrder);
                    break;
            }
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

            FormatEventListDataGridViewCell(e, col.DataPropertyName, columnVal);
        }

        private void FormatEventListDataGridViewCell(DataGridViewCellFormattingEventArgs e, string dataPropertyName, object cellValue) {
            if (eventListDataGridViewFormatters.TryGetValue(dataPropertyName, out Action<DataGridViewCellFormattingEventArgs, object> formatter)) {
                formatter(e, cellValue);
            } else {
                e.Value = cellValue?.ToString();
            }
        }

        private void FormatDateCell(DataGridViewCellFormattingEventArgs e, object val) {
            DateTime dateTime = ((DateTime)val).ToLocalTime();
            bool sameDay = dateTime.Date == DateTime.Now.Date;
            string time = dateTime.ToShortTimeString();
            string date = dateTime.ToShortDateString();

            string formattedVal;
            if (sameDay) {
                formattedVal = $"{$" Today {time,8}",-19}";
            } else {
                formattedVal = $"{date,10} {time,8}";
            }
            e.Value = formattedVal;
        }

        private void FormatEventTypeCell(DataGridViewCellFormattingEventArgs e, object val) {
            EventType eventType = (EventType)val;
            string formattedVal;

            switch (eventType) {
                case EventType.NewOrder:
                    formattedVal = "New Order";
                    break;
                default:
                    formattedVal = eventType.ToString();
                    break;
            }
            e.Value = formattedVal;
        }

        private void FormatConfirmStatusCell(DataGridViewCellFormattingEventArgs e, object val) {
            string formattedVal = "";

            switch ((bool)val) {
                case true:
                    StyleSuccessCell(e);
                    formattedVal = "Confirmed!";
                    break;
                case false:
                    StyleErrorCell(e);
                    formattedVal = "Not Confirmed";
                    break;
            }
            e.Value = formattedVal;
        }

        private void FormatPrintStatusCell(DataGridViewCellFormattingEventArgs e, object val) {
            string formattedVal = "";

            switch ((bool)val) {
                case true:
                    StyleSuccessCell(e);
                    formattedVal = "Printed!";
                    break;
                case false:
                    StyleErrorCell(e);
                    formattedVal = "Not Printed";
                    break;
            }
            e.Value = formattedVal;
        }

        private void StyleSuccessCell(DataGridViewCellFormattingEventArgs e) {
            e.CellStyle.ForeColor = Colors.SuccessGreen;
            e.CellStyle.SelectionForeColor = Colors.SuccessGreen;
            e.CellStyle.Font = Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        private void StyleErrorCell(DataGridViewCellFormattingEventArgs e) {
            e.CellStyle.ForeColor = Colors.ErrorRed;
            e.CellStyle.SelectionForeColor = Colors.ErrorRed;
            e.CellStyle.Font = Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                UpdateEventList(AppState.CurrentEvents, true, EventsContext.CurrentDay);
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
        public const string Last14Days = "Last 14 Days";
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

    public static class Colors {
        public static Color SuccessGreen = Color.FromArgb(255, 21, 189, 0);
        public static Color ErrorRed = Color.FromArgb(255, 196, 13, 0);
        public static Color LoadingGray = Color.DimGray;
    }
}
