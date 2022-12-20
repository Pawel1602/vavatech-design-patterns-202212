namespace TemplateMethodPattern
{
    // Template Method
    public abstract class TemplateOrderCalculator
    {
        public abstract bool CanDiscount(Order order);
        public abstract decimal Discount(Order order);
        public virtual decimal NoDiscount() => decimal.Zero;

        public decimal CalculateDiscount(Order order)
        {
            if (CanDiscount(order)) // warunek (predykat)
            {
                return Discount(order); // upust (Discount)
            }
            else
                return NoDiscount(); // brak upustu 
        }
    }
}
