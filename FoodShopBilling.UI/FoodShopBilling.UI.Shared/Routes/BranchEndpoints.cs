using System;
using System.Linq;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class BranchEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/Branch?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllData = "api/v1/Branch/GetAll";
        public static string GetCount = "api/v1/Branch/count";

        public static string GetBranchById(string branchId)
        {
            return $"api/v1/Branch/{branchId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/Branch";
        public static string Delete = "api/v1/Branch/Delete";
        public static string Export = "api/v1/Branch/export";
    }
}
