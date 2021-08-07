namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            this.UserTickets = new HashSet<UserTicket>();
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
        public Nullable<bool> Active { get; set; }
        [Required]
        public int TripId { get; set; }

        public virtual Trip Trip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTicket> UserTickets { get; set; }

        public Ticket(string ticketName, string ticketDescription, decimal price, int maxTickets, bool? active, int tripId)
        {
            TicketName = ticketName ?? throw new ArgumentNullException(nameof(ticketName));
            TicketDescription = ticketDescription ?? throw new ArgumentNullException(nameof(ticketDescription));
            Price = price;
            MaxTickets = maxTickets;
            Active = active;
            TripId = tripId;
        }

        public Ticket(int id, string ticketName, string ticketDescription, decimal price, int maxTickets, bool? active, int tripId)
        {
            Id = id;
            TicketName = ticketName ?? throw new ArgumentNullException(nameof(ticketName));
            TicketDescription = ticketDescription ?? throw new ArgumentNullException(nameof(ticketDescription));
            Price = price;
            MaxTickets = maxTickets;
            Active = active;
            TripId = tripId;
        }
    }

}