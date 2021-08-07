namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UserTicket
    {
        public UserTicket()
        {
        }

        public UserTicket(string firstName, string lastName, int ticketId, string userId, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            TicketId = ticketId;
            UserId = userId;
            Active = active;
        }

        public UserTicket(string firstName, string lastName, int ticketId, string userId, AspNetUser aspNetUser, Ticket ticket)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            TicketId = ticketId;
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            AspNetUser = aspNetUser ?? throw new ArgumentNullException(nameof(aspNetUser));
            Ticket = ticket ?? throw new ArgumentNullException(nameof(ticket));
        }

        public UserTicket(int id, string firstName, string lastName, int ticketId, string userId, AspNetUser aspNetUser, Ticket ticket)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            TicketId = ticketId;
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            AspNetUser = aspNetUser ?? throw new ArgumentNullException(nameof(aspNetUser));
            Ticket = ticket ?? throw new ArgumentNullException(nameof(ticket));
        }
        /// <summary>
        /// Id of the UserTicket
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }
        /// <summary>
        /// First name of the passenger
        /// </summary>
        /// <example>Niels</example>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the passenger
        /// </summary>
        /// <example>"Hansen"</example>
        [Required]
        public string LastName { get; set; }
        public Nullable<bool> Active { get; set; }
        [Required]
        public int TicketId { get; set; }
        [Required]
        public string UserId { get; set; }


        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}