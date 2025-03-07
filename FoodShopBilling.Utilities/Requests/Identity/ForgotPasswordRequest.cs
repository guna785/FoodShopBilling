using System.ComponentModel.DataAnnotations;

namespace FoodShopBilling.Utilities.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
