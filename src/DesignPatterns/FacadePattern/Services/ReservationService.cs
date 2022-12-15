using FacadePattern.Models;

namespace FacadePattern.Services
{
    public class ReservationService
    {
        public Reservation MakeReservation(RailwayConnection railwayConnection, byte numberOfPlaces)
        {
            return new Reservation { RailwayConnection = railwayConnection, NumberOfPlaces = numberOfPlaces };
        }

        public void CancelReservation(RailwayConnection railwayConnection, byte numberOfPlaces)
        {

        }
    }

}
