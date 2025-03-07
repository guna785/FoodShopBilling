using System.ComponentModel.DataAnnotations;

namespace FoodShopBilling.Utilities.Requests.Identity
{
    public class ChangePasswordRequest
    {
        public int Id { get; set; }
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
