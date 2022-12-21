using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public interface ITransfer
    {
        decimal Amount { get; set; }

        void MakeTransfer();
    }

    public class TaxTransfer : ITransfer
    {
        public decimal Amount {  get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Przelew podatkowy");
        }
    }

    public class ZusTransfer : ITransfer
    {
        public decimal Amount { get; set; }

        public ZusTransfer(decimal amount)
        {
            Amount = amount;
        }

        public void MakeTransfer()
        {
            Console.WriteLine("Przelew ZUS");
        }
    }

    public class StandardTransfer : ITransfer
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Przelew standardowy");
        }
    }

    public abstract class PaymentType
    {
        public string Name { get; set; }
        public abstract void MakeTransfer();

        // Implementation
        protected ITransfer transfer;

        protected PaymentType(ITransfer transfer)
        {
            this.transfer = transfer;
        }

    }

    public class Blik : PaymentType
    {
        public Blik(ITransfer transfer) : base(transfer)
        {
        }

        public override void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja BLIK za pomocą kodu");
            transfer.MakeTransfer();
        }
    }

    public class BankTransfer : PaymentType
    {
        public BankTransfer(ITransfer transfer) : base(transfer)
        {
        }

        public override void MakeTransfer()
        {
            Console.WriteLine("Logowanie do konta");
            transfer.MakeTransfer();
        }
    }

    public class CreditCard : PaymentType
    {
        public CreditCard(ITransfer transfer) : base(transfer)
        {
        }

        public override void MakeTransfer()
        {
            Console.WriteLine("Sprawdzenie pinu");
            transfer.MakeTransfer();
        }
    }
}
