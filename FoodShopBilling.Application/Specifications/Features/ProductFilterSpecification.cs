using FoodShopBilling.Application.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Specifications.Features
{
    public class ProductFilterSpecification : Specification<Domain.Entities.Products>
    {
        public ProductFilterSpecification(string searchString)
        {
            Criteria = !string.IsNullOrWhiteSpace(searchString) ?
                 (x => x.Name!.ToLower().Contains(searchString!.ToLower()!) ||
                   x.Description!.ToLower().Contains(searchString!.ToLower()!)) :
                   (x => true);
        }
    }
}
