using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TicketAmountEntry
    {
        public TicketAmountEntry(int ticketId, int amount)
        {
            TicketId = ticketId;
            Amount = amount;
        }

        public int TicketId { get; set; }
        public int Amount { get; set; }
    }
}