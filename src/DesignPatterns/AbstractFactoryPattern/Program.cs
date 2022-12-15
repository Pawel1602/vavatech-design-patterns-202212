using System;

namespace AbstractFactoryPattern
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory Method Pattern!");

            VisitCalculateAmountTest();

            PaymentTest();
        }



        private static void PaymentTest()
        {
            while (true)
            {
                Console.Write("Podaj kwotę: ");

                decimal.TryParse(Console.ReadLine(), out decimal totalAmount);

                Console.Write("Wybierz rodzaj płatności: (G)otówka (K)karta płatnicza (P)rzelew: ");

                var paymentType = Enum.Parse<PaymentType>(Console.ReadLine());

                Payment payment = new Payment(paymentType, totalAmount);

                if (payment.PaymentType == PaymentType.Cash)
                {
                    CashPaymentView cashPaymentView = new CashPaymentView();
                    cashPaymentView.Show(payment);
                }
                else
                if (payment.PaymentType == PaymentType.CreditCard)
                {
                    CreditCardPaymentView creditCardView = new CreditCardPaymentView();
                    creditCardView.Show(payment);
                }
                else
                if (payment.PaymentType == PaymentType.BankTransfer)
                {
                    BankTransferPaymentView bankTransferPaymentView = new BankTransferPaymentView();
                    bankTransferPaymentView.Show(payment);
                }

                string icon = GetIcon(payment);
                Console.WriteLine(icon);                
            }

        }

        private static string GetIcon(Payment payment)
        {
            switch (payment.PaymentType)
            {
                case PaymentType.Cash: return "[100]"; 
                case PaymentType.CreditCard: return "[abc]"; 
                case PaymentType.BankTransfer: return "[-->]";

                default: return string.Empty;
            }
        }

        private static void VisitCalculateAmountTest()
        {
            while (true)
            {
                Console.Write("Podaj rodzaj wizyty: (N)FZ (P)rywatna (F)irma: ");
                string visitType = Console.ReadLine();

                Console.Write("Podaj czas wizyty w minutach: ");
                if (double.TryParse(Console.ReadLine(), out double minutes))
                {
                    TimeSpan duration = TimeSpan.FromMinutes(minutes);

                    Visit visit = new Visit(duration, 100);

                    decimal totalAmount = visit.CalculateCost(visitType);

                    if (totalAmount == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                       if (totalAmount >= 200)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"Total amount {totalAmount:C2}");

                    Console.ResetColor();
                }
            }

        }
    }
}
