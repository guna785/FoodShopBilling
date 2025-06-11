using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class CompanyEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/Company?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllData = "api/v1/Company/GetAll";
        public static string GetCount = "api/v1/Company/count";

        public static string GetCompanyById(string companyId)
        {
            return $"api/v1/Company/{companyId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        internal static string? GetAllPaged(int pageNumber, int pageSize, string searchString, string orderby)
        {
            throw new NotImplementedException();
        }

        public static string Save = "api/v1/Company";
        public static string Delete = "api/v1/Company/Delete";
        public static string Export = "api/v1/Company/export";
    }
}