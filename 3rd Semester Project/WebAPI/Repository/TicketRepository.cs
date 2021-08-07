using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using WebAPI.DatabaseAccess;

namespace WebAPI.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private TicketDB ticketDb;

        public TicketRepository()
        {
            ticketDb = new TicketDB();
        }
        public bool AddTicket(Ticket ticket)
        {
            return ticketDb.InsertTicket(ticket);
        }

        public bool DeleteTicket(Ticket ticket)
        {
            return ticketDb.DeleteTicket(ticket);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return ticketDb.GetAllTickets();
        }
        public IEnumerable<Ticket> GetActiveTickets()
        {
            return ticketDb.GetActiveTickets();
        }

        public Ticket GetTicketById(int id)
        {
            return ticketDb.GetTicketById(id);
        }

        public List<Ticket> GetTicketsByTripId(int id)
        {
            return ticketDb.GetTicketsByTripId(id);
        }

        public Ticket GetTicketByName(string name)
        {
            return ticketDb.GetTicketByName(name);
        }

        public bool UpdateTicket(Ticket ticket)
        {
            return ticketDb.UpdateTicket(ticket);
        }
    }
}