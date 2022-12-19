using System;

namespace AbstractFactoryPattern
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory Method Pattern!");

          //  VisitCalculateAmountTest();

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
                PaymentView paymentView = PaymentViewFactory.Create(paymentType);
                
                Payment payment = new Payment(paymentType, totalAmount);
                paymentView.Show(payment);


                string icon = IconFactory.Create(payment.PaymentType);
                Console.WriteLine(icon);                
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

                    VisitFactory visitFactory = new VisitFactory(duration, 100);

                    Visit visit = visitFactory.Create(visitType);

                    decimal totalAmount = visit.CalculateCost();

                    Console.ForegroundColor = ConsoleColorFactory.Create(totalAmount);

                    Console.WriteLine($"Total amount {totalAmount:C2}");

                    Console.ResetColor();
                }
            }

        }
    }
}
