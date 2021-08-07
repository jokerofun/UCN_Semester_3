using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    interface ITicketRepository
    {
        bool AddTicket(Ticket ticket);
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetActiveTickets();
        Ticket GetTicketById(int id);
        List<Ticket>GetTicketsByTripId(int id);
        Ticket GetTicketByName(string name);
        bool DeleteTicket(Ticket ticket);
        bool UpdateTicket(Ticket ticket);
    }
}
