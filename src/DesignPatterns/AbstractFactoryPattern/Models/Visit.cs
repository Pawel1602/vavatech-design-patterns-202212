using System;

namespace AbstractFactoryPattern
{
    public class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        private const decimal companyDiscountPercentage = 0.9m;

        public Visit(TimeSpan duration, decimal pricePerHour)
        {
            VisitDate = DateTime.Now;
            Duration = duration;
            PricePerHour = pricePerHour;
        }

        public decimal CalculateCost(string kind)
        {
            decimal cost = 0;

            if (kind == "N")
            {
                cost = 0;
            }
            else if (kind == "P")
            {
                cost = (decimal)Duration.TotalHours * PricePerHour;
            }
            else if (kind == "F")
            {
                cost = (decimal)Duration.TotalHours * PricePerHour * companyDiscountPercentage;
            }

            return cost;
        }
    }
}
