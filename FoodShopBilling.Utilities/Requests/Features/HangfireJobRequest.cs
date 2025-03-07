using FoodShopBilling.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Utilities.Requests.Features
{
    public class HangfireJobRequest
    {
        public string Name { get; set; }
        public HangfireJobType JobType { get; set; }
        public TimeOnly? Span { get; set; }
        public string? Cron { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Days { get; set; }
        public int Months { get; set; }
        public int MinuteIntervel { get; set; } = 1;
        public int HoursIntervel { get; set; } = 1;
        public int DaysIntervel { get; set; } = 1;
        public int MonthsIntervel { get; set; } = 1;
    }
}
