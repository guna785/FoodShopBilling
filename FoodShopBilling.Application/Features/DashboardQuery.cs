using FoodShopBilling.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Features
{
    public class DashboardQuery:IRequest<Result<string>>
    {
    }
}
