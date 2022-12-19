using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class PaymentViewFactory
    {
        public static PaymentView Create(PaymentType paymentType) => paymentType switch
        {
            PaymentType.Cash => new CashPaymentView(),
            PaymentType.CreditCard => new CreditCardPaymentView(),
            PaymentType.BankTransfer => new BankTransferPaymentView(),
            _ => throw new NotSupportedException()
        };
          
    }
}
