using FluentValidation.AspNetCore;
using FoodShopBilling.Application.Configurations;

namespace FoodShopBilling.UI.Web.Extensions
{
    internal static class MvcBuilderExtensions
    {
        internal static IMvcBuilder AddValidators(this IMvcBuilder builder)
        {
            _ = builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppConfiguration>());
            return builder;
        }


    }
}
