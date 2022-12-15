using FacadePattern.Models;

namespace FacadePattern.Services
{
    public class TicketCalculator
    {
        private readonly decimal amount = 1.99m;

        public decimal Calculate(RailwayConnection railwayConnection, byte numberOfPlaces)
        {
            return railwayConnection.Distance * amount * numberOfPlaces;
        }

    }



}
