using FoodShopBilling.Shared.Wrapper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodShopBilling.UI.Shared.Extensions
{
    internal static class ResultExtensions
    {
        internal static async Task<IResult<T>> ToResult<T>(this HttpResponseMessage response)
        {
            try
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<T>>(responseAsString); ;
                return responseObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal static async Task<IResult> ToResult(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(responseAsString);
            return responseObject;
        }

        internal static async Task<PaginatedResult<T>> ToPaginatedResult<T>(this HttpResponseMessage response)
        {
            try
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<PaginatedResult<T>>(responseAsString);
                return responseObject!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}