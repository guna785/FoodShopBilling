using FluentValidation;
using FoodShopBilling.Application.Features.SalesDetails.Commands.AddEdit;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Validators
{
    public class AddEditSalesCommandValidator : AbstractValidator<AddEditSalesCommand>
    {

        public AddEditSalesCommandValidator(IStringLocalizer<AddEditSalesCommandValidator> localizer)
        {
            _ = RuleFor(request => request.Amount)
               .Must(x => x > 0).WithMessage(x => localizer["Amount Must be Greater than 0!"]);
           
        }
    }
}
