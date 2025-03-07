using Newtonsoft.Json;
using FoodShopBilling.Utilities.Interfaces.Serialization.Settings;

namespace FoodShopBilling.Utilities.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}
