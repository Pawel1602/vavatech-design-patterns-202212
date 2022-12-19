using System;

namespace AbstractFactoryPattern
{

    public class NfzVisit : Visit
    {
        public NfzVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return 0;
        }
    }

    public class PrivateVisit : Visit
    {
        public PrivateVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return (decimal)Duration.TotalHours * PricePerHour;
        }
    }

    public class PackageVisit : Visit
    {
        public PackageVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return 100;
        }
    }

    public class CompanyVisit : Visit
    {
        private const decimal companyDiscountPercentage = 0.9m;

        public CompanyVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return (decimal)Duration.TotalHours * PricePerHour * companyDiscountPercentage;
        }
    }

    public abstract class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }


        public Visit(TimeSpan duration, decimal pricePerHour)
        {
            VisitDate = DateTime.Now;
            Duration = duration;
            PricePerHour = pricePerHour;
        }

        public abstract decimal CalculateCost();
       
    }
}
