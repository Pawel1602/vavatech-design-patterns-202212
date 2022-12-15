using System;

namespace AbstractFactoryPattern
{
    public class CreditCardPaymentView : PaymentView
    {
        public override void Show(Payment payment)
        {
            Console.WriteLine($"Do zapłaty {payment.TotalAmount}");

            Console.WriteLine($"Nawiązywanie połączenia z bankiem...");

            Console.WriteLine("Transakcja zautoryzowana");
        }
    }
}
