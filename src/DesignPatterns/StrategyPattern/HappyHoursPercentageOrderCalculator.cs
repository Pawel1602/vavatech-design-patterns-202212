using System;

namespace StrategyPattern
{
    // Happy Hours - 10% upustu w godzinach od 9 do 15
    public class HappyHoursPercentageOrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal percentage;

        public HappyHoursPercentageOrderCalculator(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to )
            {
                return order.Amount * percentage;
            }
            else
                return 0;
        }
    }
}
