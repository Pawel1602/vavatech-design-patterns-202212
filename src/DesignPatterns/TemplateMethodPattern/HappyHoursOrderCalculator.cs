namespace TemplateMethodPattern
{
    // Happy Hours - 10% upustu w godzinach od 9 do 15
    public class HappyHoursPercentageOrderCalculator
    {
        private readonly int from;
        private readonly int to;

        private readonly decimal percentage;

        public HappyHoursPercentageOrderCalculator(int from, int to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;            
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.OrderDate.Hour >= from && order.OrderDate.Hour < to)
            {
                return order.Amount * percentage;
            }
            else
                return 0;
        }
    }

}
