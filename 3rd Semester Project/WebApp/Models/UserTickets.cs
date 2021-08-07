using System;

namespace WebApp.Models
{
    public partial class UserTicket
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public Nullable<bool> Active { get; set; }

        public UserTicket()
        {

        }

        public UserTicket(string UserId, int TicketId, string FirstName, string LastName)
        {
            this.UserId = UserId;
            this.TicketId = TicketId;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public UserTicket(string UserId, int TicketId, string FirstName, string LastName, bool Active)
        {
            this.UserId = UserId;
            this.TicketId = TicketId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Active = Active;
        }
    }
}