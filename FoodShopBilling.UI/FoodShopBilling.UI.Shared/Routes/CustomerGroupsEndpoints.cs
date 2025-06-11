using System.Linq;
using System;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class CustomerGroupsEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/CustomerGroups?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllData = "api/v1/CustomerGroups/GetAll";
        public static string GetCount = "api/v1/CustomerGroups/count";

        public static string GetCustomerGroupById(string id)
        {
            return $"api/v1/CustomerGroups/{id}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/CustomerGroups";
        public static string Delete = "api/v1/CustomerGroups/Delete";
        public static string Export = "api/v1/CustomerGroups/export";
    }
}
