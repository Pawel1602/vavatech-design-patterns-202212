using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    // Abstract Handler
    public interface IHandler<TRequest>
    {
        IHandler<TRequest> SetNext(IHandler<TRequest> handler);
        void Handle(TRequest request);
    }


    // Abstract Handler
    public abstract class Approver
    {
        public Approver Successor { get; set; }

        public abstract void ProcessRequest(Purchase purchase);
    }

    // Concrete Handler
    public class ProductManager : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 1000)
            {
                Trace.WriteLine("ProductManager approved request");
                purchase.ApprovedBy = this;
            }
            else
            {
                Successor?.ProcessRequest(purchase); 
            }
        }
    }

    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 5000)
            {
                Trace.WriteLine("Director approved request");
                purchase.ApprovedBy = this;
            }
            else
            {
                Successor?.ProcessRequest(purchase);
            }
        }
    }

    public class CEO : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10_000)
            {
                Trace.WriteLine("CEO approved request");
                purchase.ApprovedBy = this;
            }
            else
            {
                Successor?.ProcessRequest(purchase);
            }
        }
    }

    public class Executive : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            purchase.ApprovedBy = this;
        }
    }
}
