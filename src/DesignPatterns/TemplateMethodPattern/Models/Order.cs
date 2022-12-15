using System;

namespace TemplateMethodPattern
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }

        public Order(DateTime orderDate, Customer customer, decimal amount)
        {
            OrderDate = orderDate;
            Customer = customer;
            Amount = amount;
        }
    }

}
