namespace TemplateMethodPattern
{


    // Gender - 20% upustu dla kobiet
    public class GenderPercentageOrderCalculator : TemplateOrderCalculator
    {
        private readonly Gender gender;
        private readonly decimal percentage;

        public GenderPercentageOrderCalculator(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public override bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }

        public override decimal Discount(Order order)
        {
            return order.Amount * percentage;
        }     
    }
}
