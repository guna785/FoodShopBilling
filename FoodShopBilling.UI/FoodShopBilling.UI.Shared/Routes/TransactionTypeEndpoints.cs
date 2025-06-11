using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class TransactionTypeEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/TransactionType?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllData = "api/v1/TransactionType/GetAll";
        public static string GetCount = "api/v1/TransactionType/count";

        public static string GetTransactionTypeById(string transactionTypeId)
        {
            return $"api/v1/TransactionType/{transactionTypeId}";
        }

        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Save = "api/v1/TransactionType";
        public static string Delete = "api/v1/TransactionType/Delete";
        public static string Export = "api/v1/TransactionType/export";
    }
}
