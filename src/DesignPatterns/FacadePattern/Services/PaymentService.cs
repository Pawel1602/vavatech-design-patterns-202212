using FacadePattern.Models;

namespace FacadePattern.Services
{
    public class PaymentService
    {
        public Payment CreateActivePayment(Ticket ticket)
        {
            return new Payment { TotalAmount = ticket.Price };
        }

        public void RefundPayment(Payment payment)
        {

        }
    }

}
