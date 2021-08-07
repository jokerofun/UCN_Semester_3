using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string TicketName { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<int> MaxTickets { get; set; }
        [Required]
        public Nullable<int> TripId { get; set; }

        public virtual Trip Trip { get; set; }


        public Ticket(string TicketName, Nullable<decimal> Price, Nullable<int> MaxTickets, Nullable<int> TripId)
        {
            this.TicketName = TicketName;
            this.Price = Price;
            this.MaxTickets = MaxTickets;
            this.TripId = TripId;
        }

        public Ticket(int Id, string TicketName, Nullable<decimal> Price, Nullable<int> MaxTickets, Nullable<int> TripId)
        {
            this.Id = Id;
            this.TicketName = TicketName;
            this.Price = Price;
            this.MaxTickets = MaxTickets;
            this.TripId = TripId;
        }

        public Ticket()
        {
        }
    }
}
