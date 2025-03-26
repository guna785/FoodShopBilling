using FoodShopBilling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Utilities.Responses.Features
{
    public class SalesResponse
    {
        public string? CustomerName { get; set; }
        public string? CustomerMobile { get; set; }
        public string? ProductImage { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string PaymentMode { get; set; }
        public bool IsPaid { get; set; }
    }
}
