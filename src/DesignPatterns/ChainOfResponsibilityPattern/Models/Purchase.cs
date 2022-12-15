using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Models
{
    public class Purchase
    {
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public Approver ApprovedBy { get; set; }

        public Purchase(decimal amount, string purpose)
        {
            Amount = amount;
            Purpose = purpose;
        }
    }

    public abstract class Approver
    {
    }

    public class ProductManager : Approver
    {
    }

    public class Director : Approver
    {
    }

    public class CEO : Approver
    {
    }

}
