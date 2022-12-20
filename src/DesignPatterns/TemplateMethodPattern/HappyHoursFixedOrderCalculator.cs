using System;

namespace TemplateMethodPattern
{
    // Happy Hours  - 10 PLN w godzinach od 8:30 do 15
    public class HappyHoursFixedOrderCalculator : TemplateOrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal amount;

        public HappyHoursFixedOrderCalculator(TimeSpan from, TimeSpan to, decimal amount)
        {
            this.from = from;
            this.to = to;
            this.amount = amount;
        }

        public override bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
        }

        public override decimal Discount(Order order)
        {
            return amount;
        }       

    }

}
