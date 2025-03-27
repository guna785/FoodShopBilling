using FluentValidation;
using FoodShopBilling.Application.Features.ProductCategories.Commands.AddEdit;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Validators
{
    public class AddEditProductCategoryCommandValidator:AbstractValidator<AddEditProductCategoryCommand>
    {
        public AddEditProductCategoryCommandValidator(IStringLocalizer<AddEditProductCategoryCommandValidator> localizer)
        {
            _ = RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer[" Name is required"]);
        }
    }
}
