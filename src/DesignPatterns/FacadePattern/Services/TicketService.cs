using FacadePattern.Models;
using FacadePattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Services
{
    public class TicketParameters
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime When { get; set; }
        public byte NumberOfPlaces { get; set; }
        public bool IsReturn { get; set; }

        public TicketParameters(string from, string to, DateTime when, byte numberOfPlaces = 1)
        {
            if (from == to)
            {
                throw new ArgumentException("Stacja początkowa musi się inna niż stacja końcowa");
            }

            From = from;
            To = to;
            When = when;
            NumberOfPlaces = numberOfPlaces;
        }
    }

    public interface ITicketService
    {
        Ticket Buy(TicketParameters parameters);
        void Cancel(Ticket ticket);
    }

    public class TicketService : ITicketService
    {
        private readonly RailwayConnectionRepository railwayConnectionRepository;
        private readonly TicketCalculator ticketCalculator;
        private readonly ReservationService reservationService;
        private readonly PaymentService paymentService;
        private readonly EmailService emailService;

        public TicketService(
            RailwayConnectionRepository railwayConnectionRepository, 
            TicketCalculator ticketCalculator,
            ReservationService reservationService, 
            PaymentService paymentService, 
            EmailService emailService)
        {
            this.railwayConnectionRepository = railwayConnectionRepository;
            this.ticketCalculator = ticketCalculator;
            this.reservationService = reservationService;
            this.paymentService = paymentService;
            this.emailService = emailService;
        }

        public Ticket Buy(TicketParameters parameters)
        {
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(parameters.From, parameters.To, parameters.When);
            decimal price = ticketCalculator.Calculate(railwayConnection, parameters.NumberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, parameters.NumberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;
        }

        public void Cancel(Ticket ticket)
        {
            Payment payment = paymentService.CreateActivePayment(ticket);
            reservationService.CancelReservation(ticket.RailwayConnection, ticket.NumberOfPlaces);
            paymentService.RefundPayment(payment);
        }
    }
}
