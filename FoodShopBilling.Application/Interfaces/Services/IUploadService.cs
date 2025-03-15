using Microsoft.AspNetCore.Http;
using FoodShopBilling.Utilities.Enums;
using FoodShopBilling.Utilities.Requests;

namespace FoodShopBilling.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}
