using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Models {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventType {
        [EnumMember(Value = "new_order")]
        NewOrder,
        [EnumMember(Value = "update_order")]
        UpdateOrder,
        [EnumMember(Value = "cancel_order")]
        CancelOrder
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceType {
        [EnumMember(Value = "Grubhub")]
        Grubhub,
        [EnumMember(Value = "DoorDash")]
        DoorDash,
        [EnumMember(Value = "UberEats")]
        UberEats
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserType {
        [EnumMember(Value = "restaurant")]
        Restaurant,
        [EnumMember(Value = "manager")]
        Manager,
        [EnumMember(Value = "owner")]
        Owner,
        [EnumMember(Value = "admin")]
        Admin
    }

    [JsonConverter(typeof(ItemTypeEnumConverter))]
    public enum ItemType {
        [EnumMember(Value = "drink")]
        Drink,
        [EnumMember(Value = "food")]
        Food,
        [EnumMember(Value = "modifier")]
        Modifier,
        Unknown
    }

    public class ItemTypeEnumConverter : StringEnumConverter {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (reader.Value == null) {
                return ItemType.Unknown;
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            ItemType itemType = (ItemType)value;
            if (itemType != ItemType.Unknown) {
                writer.WriteValue(itemType);
            } else {
                writer.WriteValue((string)null);
            }
        }
    }
}
