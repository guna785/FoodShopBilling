using FoodShopBilling.Infrastructure.Models.Identity;
using FoodShopBilling.Application.Specifications.Base;

namespace FoodShopBilling.Infrastructure.Specifications
{
    public class UserFilterSpecification : Specification<ApplicationUser>
    {
        public UserFilterSpecification(string searchString)
        {
            Criteria = !string.IsNullOrEmpty(searchString)
                ? (p => p.Name.Contains(searchString)  || p.Email.Contains(searchString) || p.PhoneNumber.Contains(searchString) || p.UserName.Contains(searchString))
                : (p => true);
        }
    }
}
