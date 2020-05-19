using OnlineOrderPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Utility {
    class PrinterHelper {

        enum OrderTemplateLocation {
            ServiceName = 1,
            CustomerName,
            LabelName,
            ItemCounter,
            ItemName,
            ModifierList,
            SpecialInstructions
        }

        // TODO: Ideally, these character limits would be configured through app settings/be dynamic,
        // so that they can be customized for different label sizes. (Currently this is designed for 2.25w 1.25h inch labels)
        private static Dictionary<OrderTemplateLocation, int> orderTemplateCharLimits = new Dictionary<OrderTemplateLocation, int>() {
            { OrderTemplateLocation.ServiceName, 8 },
            { OrderTemplateLocation.CustomerName, 17 },
            { OrderTemplateLocation.LabelName, 25 },
            { OrderTemplateLocation.ItemCounter, 7 },
            { OrderTemplateLocation.SpecialInstructions, 50 }
        };

        /**
         * Converts an Order into a list of printable OrderItems, where each is represented by a Dictionary.
         */
        public static List<Dictionary<int, string>> ConvertOrderToPrintableList(Order order) {
            List<Dictionary<int, string>> printableList = new List<Dictionary<int, string>>();

            int currentItemCount = 0;
            foreach (OrderItem orderItem in order.OrderItems) {
                for (int i = 0; i < orderItem.Quantity; i++) {
                    currentItemCount++;
                    printableList.Add(ConvertOrderItemToPrintableObject(currentItemCount, orderItem, order));
                }
            }
            return printableList;
        }

        /**
         * Converts an OrderItem into a printable label object represented by a Dictionary where the key is
         * the integer location of the specificed text type, and the value is the value of that text type.
         */
        public static Dictionary<int, string> ConvertOrderItemToPrintableObject(int currentItemCount, OrderItem orderItem, Order order) {
            return new Dictionary<int, string>() {
                { (int)OrderTemplateLocation.ServiceName, TruncateValue(OrderTemplateLocation.ServiceName, order.Service.ToString()) },
                { (int)OrderTemplateLocation.CustomerName, TruncateValue(OrderTemplateLocation.CustomerName, order.CustomerName) },
                { (int)OrderTemplateLocation.LabelName, TruncateValue(OrderTemplateLocation.LabelName, orderItem.LabelName) },
                { (int)OrderTemplateLocation.ItemCounter, FormatItemCounter(currentItemCount, order.OrderSize) },
                { (int)OrderTemplateLocation.ItemName, ResolveItemPrintName(orderItem, order.Service) },
                { (int)OrderTemplateLocation.ModifierList, CreateModifierListString(orderItem.OrderItemModifiers, order.Service) },
                { (int)OrderTemplateLocation.SpecialInstructions, TruncateValue(OrderTemplateLocation.SpecialInstructions, orderItem.SpecialInstructions) }
            };
        }

        /**
         * Truncates the given value to the specified OrderTemplateLocation's character limit.
         */
        private static string TruncateValue(OrderTemplateLocation orderTemplateLocation, string value) {
            if (value == null) {
                return "";
            }
            if (orderTemplateCharLimits.TryGetValue(orderTemplateLocation, out int characterLimit)) {
                if (value.Length > characterLimit) {
                    return value.Substring(0, characterLimit);
                }
            }
            return value;
        }

        /**
         * Returns the item counter denoted as a fractional "itemCount/totalItems".
         */
        private static string FormatItemCounter(int itemCount, int totalItems) {
            return TruncateValue(OrderTemplateLocation.ItemCounter, $"{itemCount}/{totalItems}");
        }

        /**
         * Selects the name to use for printing, prioritizing by existence - PrintName, Name, the associated service's name.
         */
        private static string ResolveItemPrintName(OrderItemBase orderItemBase, ServiceType serviceType) {
            string name = null;

            if (orderItemBase.PrintName != null) {
                name = orderItemBase.PrintName;
            } else if (orderItemBase.Name != null) {
                name = orderItemBase.Name;
            } else {
                switch (serviceType) {
                    case ServiceType.DoorDash:
                        name = orderItemBase.DoordashName;
                        break;
                    case ServiceType.Grubhub:
                        name = orderItemBase.GrubhubName;
                        break;
                    case ServiceType.UberEats:
                        name = orderItemBase.UbereatsName;
                        break;
                }
            }
            return name ?? "";
        }

        /**
         * Filters out modifiers that shouldn't be printed, denoted by PrintName = "", then sorts the list by descending
         * PrintPriority. Finally, we return a comma-separated string representation of the modifier list.
         */
        private static string CreateModifierListString(OrderItemModifier[] orderItemModifiers, ServiceType serviceType) {
            if (orderItemModifiers.Length == 0) {
                return "";
            }

            OrderItemModifier[] modifiers = orderItemModifiers
                .Where(modifier => modifier.PrintName != "")
                .OrderByDescending(modifier => modifier.PrintPriority).ToArray();

            StringBuilder sb = new StringBuilder(ResolveItemPrintName(modifiers[0], serviceType));
            for (int i = 1; i < modifiers.Length; i++) {
                sb.Append(", ");
                sb.Append(ResolveItemPrintName(modifiers[i], serviceType));
            }
            return sb.ToString();
        }
    }
}
