using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class SchemeEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/Scheme?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllData = "api/v1/Scheme/GetAll";
        public static string GetCount = "api/v1/Scheme/count";

        public static string GetSchemeById(string schemeId)
        {
            return $"api/v1/Scheme/{schemeId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        internal static string? GetById(string id)
        {
            throw new NotImplementedException();
        }

        public static string Save = "api/v1/Scheme";
        public static string Delete = "api/v1/Scheme";
        public static string Export = "api/v1/Scheme/";
    }
}