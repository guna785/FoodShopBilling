using System;
using System.Linq;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class CustomerEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/Customer?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (string orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1]; // remove trailing comma
            }
            return url;
        }

        public static string GetAllData = "api/v1/Customer/GetAll";
        public static string GetCount = "api/v1/Customer/count";

        public static string GetCustomerById(int customerId)
        {
            return $"api/v1/Customer/{customerId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/Customer";
        public static string Delete = "api/v1/Customer/Delete";
        public static string Export = "api/v1/Customer/export";
    }
}
