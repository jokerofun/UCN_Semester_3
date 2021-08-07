namespace WebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Ticket
    {
        public Ticket()
        {
        }

        public Ticket(int id, string ticketName, string ticketDescription, decimal price, int maxTickets, int ticketsRemaining, bool? active, int tripId)
        {
            Id = id;
            TicketName = ticketName ?? throw new ArgumentNullException(nameof(ticketName));
            TicketDescription = ticketDescription ?? throw new ArgumentNullException(nameof(ticketDescription));
            Price = price;
            MaxTickets = maxTickets;
            TicketsRemaining = ticketsRemaining;
            Active = active;
            TripId = tripId;
        }

        public Ticket(string ticketName, string ticketDescription, decimal price, int maxTickets, int ticketsRemaining, bool? active, int tripId)
        {
            TicketName = ticketName ?? throw new ArgumentNullException(nameof(ticketName));
            TicketDescription = ticketDescription ?? throw new ArgumentNullException(nameof(ticketDescription));
            Price = price;
            MaxTickets = maxTickets;
            TicketsRemaining = ticketsRemaining;
            Active = active;
            TripId = tripId;
        }

        public int Id { get; set; }
        [Required]
        public string TicketName { get; set; }
        [Required]
        public string TicketDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int MaxTickets { get; set; }
        [Required]
        public int TicketsRemaining { get; set; }
        public Nullable<bool> Active { get; set; }
        [Required]
        public int TripId { get; set; }
        public byte[] rowversion { get; set; }

    }
}
