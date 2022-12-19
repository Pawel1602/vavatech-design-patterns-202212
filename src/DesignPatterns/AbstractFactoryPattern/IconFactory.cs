using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class IconFactory
    {
        public static string Create(PaymentType paymentType) => paymentType switch
        {
            PaymentType.Cash => "[100]",
            PaymentType.CreditCard => "[abc]",
            PaymentType.BankTransfer => "[-->]",
            _ => string.Empty,
        };
    }
}
