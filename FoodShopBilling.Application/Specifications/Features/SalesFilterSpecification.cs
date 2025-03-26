using FoodShopBilling.Application.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Specifications.Features
{
    public class SalesFilterSpecification : Specification<Domain.Entities.Sales>
    {
        public SalesFilterSpecification(string searchString)
        {
            Criteria = !string.IsNullOrWhiteSpace(searchString) ?
                 (x => x.CustomerMobile!.ToLower().Contains(searchString!.ToLower()!) ||
                   x.CustomerName!.ToLower().Contains(searchString!.ToLower()!)) :
                   (x => true);
        }
    }
}
