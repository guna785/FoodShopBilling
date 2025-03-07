using FoodShopBilling.Utilities.Interfaces.Serialization.Options;
using System.Text.Json;

namespace FoodShopBilling.Utilities.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}
