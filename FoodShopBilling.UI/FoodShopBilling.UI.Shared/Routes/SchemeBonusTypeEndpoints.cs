using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class SchemeBonusTypeEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/SchemeBonusType?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllData = "api/v1/SchemeBonusType/GetAll";
        public static string GetCount = "api/v1/SchemeBonusType/count";

        public static string GetSchemeBonusTypeById(int schemeBonusTypeId)
        {
            return $"api/v1/SchemeBonusType/{schemeBonusTypeId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/SchemeBonusType";
        public static string Delete = "api/v1/SchemeBonusType/Delete";
        public static string Export = "api/v1/SchemeBonusType/export";
    }
}
