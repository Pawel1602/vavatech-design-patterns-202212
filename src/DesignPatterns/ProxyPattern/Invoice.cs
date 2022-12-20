using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    // Proxy
    // Wariant klasowy (używa dziedziczenia i polimorfizmu)
    public class InvoiceProxy : Invoice
    {
        private readonly IDictionary<int, Customer> customers = new Dictionary<int, Customer>();

        public override Customer Customer 
        { 
            get  
            {
                if (customers.TryGetValue(CustomerId, out Customer customer))
                {

                }
                else
                {
                    customer = base.Customer;

                    if (customer != null)
                    {
                        customers.Add(CustomerId, customer);
                    }
                }


                return customer;
            }

            set => base.Customer = value; 
        }
    }

    // Subject
    public class Invoice
    {
        public int Id { get; set; }        
        public string Number { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Invoice> Invoices { get; set; }
    }
}
