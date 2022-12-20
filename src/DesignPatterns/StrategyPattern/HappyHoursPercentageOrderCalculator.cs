using System;

namespace StrategyPattern
{
    // Abstract strategy
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);        
    }

    public interface IDiscountStrategy
    {
        decimal Discount(Order order);
        decimal NoDiscount();
    }

    // Concrete strategy
    public class PercentageDiscountStrategy : BaseDiscountStrategy, IDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageDiscountStrategy(decimal percentage) => this.percentage = percentage;

        public override decimal Discount(Order order) => order.Amount * percentage;
    }

    // Concrete strategy
    public class FixedDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal amount;

        public FixedDiscountStrategy(decimal amount) => this.amount = amount;
        public decimal Discount(Order order) => amount;

        public decimal NoDiscount()
        {
            throw new NotImplementedException();
        }
    }

    // Concrete strategy
    public class HappyHoursCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public HappyHoursCanDiscountStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to;
    }

    // Concrete strategy
    public class GenderCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly Gender gender;

        public GenderCanDiscountStrategy(Gender gender) => this.gender = gender;

        public bool CanDiscount(Order order) => order.Customer.Gender == gender;
    }

    public abstract class BaseDiscountStrategy : IDiscountStrategy
    {
        public abstract decimal Discount(Order order);
        public virtual decimal NoDiscount() => decimal.Zero;
        
    }

    public class GenderPercentageStrategy : BaseDiscountStrategy, IDiscountStrategy
    {
        private readonly Gender gender;

        private readonly decimal percentage;

        public GenderPercentageStrategy(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order) => order.Customer.Gender == gender;

        public override decimal Discount(Order order) => order.Amount * percentage;        
    }

    public class GenderFixedStrategy : BaseDiscountStrategy, IDiscountStrategy
    {
        private readonly Gender gender;

        private readonly decimal amount;

        public GenderFixedStrategy(Gender gender, decimal amount)
        {
            this.gender = gender;
            this.amount = amount;
        }

        public bool CanDiscount(Order order) => order.Customer.Gender == gender;

        public override decimal Discount(Order order) => amount;
    }

    public interface IPromotion : ICanDiscountStrategy, IDiscountStrategy
    {

    }

    public class OrderCalculator
    {
        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly IDiscountStrategy _discountStrategy;

        public OrderCalculator(
            ICanDiscountStrategy canDiscountStrategy, 
            IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
            this.canDiscountStrategy = canDiscountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))   // Predykat (CanDiscount)
            {
                return _discountStrategy.Discount(order); // Upust (Discount)
            }
            else
                return decimal.Zero; // brak upustu (NoDiscount)
        }
    }

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
            if (order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to )   // Predykat (CanDiscount)
            {
                return order.Amount * percentage; // Upust (Discount)
            }
            else
                return 0; // brak upustu (NoDiscount)
        }
    }
}
