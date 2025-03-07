using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using FoodShopBilling.Utilities.Interfaces.Serialization.Serializers;
using FoodShopBilling.Utilities.Serialization.Settings;

namespace FoodShopBilling.Utilities.Serialization.Serializers
{
    public class NewtonSoftJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerSettings _settings;

        public NewtonSoftJsonSerializer(IOptions<NewtonsoftJsonSettings> settings)
        {
            _settings = settings.Value.JsonSerializerSettings;
        }

        public T Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text, _settings)!;
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, _settings);
        }
    }
}
