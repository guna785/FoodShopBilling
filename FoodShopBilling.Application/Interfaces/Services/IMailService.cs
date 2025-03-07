using FoodShopBilling.Utilities.Requests.Mail;

namespace FoodShopBilling.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
