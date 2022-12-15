using FacadePattern.Models;

namespace FacadePattern.Services
{
    public class EmailService
    {
        public void Send(Ticket ticket)
        {
            System.Console.WriteLine($"Send {ticket}");
        }
    }



}
