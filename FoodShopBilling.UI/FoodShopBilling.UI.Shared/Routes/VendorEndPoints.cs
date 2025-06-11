using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class VendorEndPoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/Vendor?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (string orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1]; // Remove trailing comma
            }
            return url;
        }

        public static string GetAllData = "api/v1/Vendor/GetAll";
        public static string GetCount = "api/v1/Vendor/count";

        public static string GetById(int vendorId)
        {
            return $"api/v1/Vendor/{vendorId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/Vendor";
        public static string Delete = "api/v1/Vendor/Delete";
        public static string Export = "api/v1/Vendor/export";
    }
}
