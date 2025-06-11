using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class ProductTypeEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/ProductType?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (string orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1]; // loose training ,
            }
            return url;
        }
        public static string GetAllData = "api/v1/ProductType/GetAll";
        public static string GetCount = "api/v1/ProductType/count";
        public static string GetProductTypeById(int ProductTypeId)
        {
            return $"api/v1/ProductType/{ProductTypeId.ToString()}";
        }



        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/ProductType";
        public static string Delete = "api/v1/ProductType/Delete";
        public static string Export = "api/v1/ProductType/export";
    }
}
