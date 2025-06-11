using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class SchemeTypeEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/SchemeType?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllData = "api/v1/SchemeType/GetAll";
        public static string GetCount = "api/v1/SchemeType/count";

        public static string GetSchemeTypeById(int schemeTypeId)
        {
            return $"api/v1/SchemeType/{schemeTypeId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/SchemeType";
        public static string Delete = "api/v1/SchemeType/Delete";
        public static string Export = "api/v1/SchemeType/export";
    }
}
