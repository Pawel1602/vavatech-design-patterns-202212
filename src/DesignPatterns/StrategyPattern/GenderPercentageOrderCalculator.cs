namespace StrategyPattern
{
    // Gender - 20% upustu dla kobiet
    public class GenderPercentageOrderCalculator
    {
        private readonly Gender gender;

        private readonly decimal percentage;

        public GenderPercentageOrderCalculator(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.Customer.Gender == gender)
            {
                return order.Amount * percentage;
            }
            else
                return 0;
        }
    }
}
