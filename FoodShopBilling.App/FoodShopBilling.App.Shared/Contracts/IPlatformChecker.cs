using FoodShopBilling.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.App.Shared.Contracts
{
    public interface IPlatformChecker
    {
        Task<Platform> GetExecutionPlatform();
    }
}
