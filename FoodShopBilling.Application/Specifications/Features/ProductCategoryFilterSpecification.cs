using FoodShopBilling.Application.Specifications.Base;
using FoodShopBilling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Specifications.Features
{
    public class ProductCategoryFilterSpecification : Specification<ProductCategory>
    {
        public ProductCategoryFilterSpecification(string searchString)
        {
            Criteria = !string.IsNullOrWhiteSpace(searchString) ?
                 (x => x.Name!.ToLower().Contains(searchString!.ToLower()!) ||
                   x.Description!.ToLower().Contains(searchString!.ToLower()!)) :
                   (x => true);
        }
    }
}
