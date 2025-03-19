using FoodShopBilling.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Domain.Entities
{
    public class ProductCategory : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
