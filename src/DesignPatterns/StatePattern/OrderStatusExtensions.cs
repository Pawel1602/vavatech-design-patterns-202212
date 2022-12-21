using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    internal static class OrderStatusExtensions
    {
        public static void Dump(this OrderState status)
        {
            Console.ForegroundColor = Create(status);
            Console.WriteLine(status);
            Console.ResetColor();
        }

        // Metoda wytwórcza (fabrykująca)
        private static ConsoleColor Create(OrderState orderState) => orderState switch
        {
            Pending => ConsoleColor.DarkYellow,
            Sent => ConsoleColor.Green,
            Delivered => ConsoleColor.Blue,
            Completed => ConsoleColor.Black,
            Cancelled => ConsoleColor.DarkGray,
            _ => Console.ForegroundColor,
        };
    }
}
