using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Utilities.Enums
{
    public enum HangfireJobType : byte
    {
        [Description("Instant Schedule")]
        FireAndForget,
        [Description("Delayed Schedule")]
        Delayed,
        [Description("Recurring Schedule")]
        Recurring,
    }
}
