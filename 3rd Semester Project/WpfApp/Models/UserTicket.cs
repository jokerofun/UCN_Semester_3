namespace WpfApp.Models
{
    public class UserTicket
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TicketId { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }

        public UserTicket(int id, string firstName, string lastName, int ticketId, bool active, string userId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TicketId = ticketId;
            Active = active;
            UserId = userId;
        }
        public UserTicket()
        {
        }
    }
}
