using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Utilities.Requests.Identity
{
    public class UserPaginatedRequest : PagedRequest
    {
        public string SearchString { get; set; } = string.Empty;
    }
}
