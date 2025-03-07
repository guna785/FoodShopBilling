using System.ComponentModel.DataAnnotations;

namespace FoodShopBilling.Utilities.Requests.Identity
{
    public class TokenRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class TokenMobileRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
       
        public string? DeviceGuid { get; set; }
    }
}
