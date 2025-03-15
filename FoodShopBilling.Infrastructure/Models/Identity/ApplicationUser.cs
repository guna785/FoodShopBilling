using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FoodShopBilling.Domain.Contracts;
using FoodShopBilling.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodShopBilling.Infrastructure.Models.Identity
{
    public class ApplicationUser : IdentityUser<int>, IAuditableEntity<int>
    {
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public string? Designation { get; set; }
        public string? CreatedBy { get; set; }

        [Column(TypeName = "text")]
        public string? ProfilePictureDataUrl { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? IPAddress { get; set; }

    }
}
