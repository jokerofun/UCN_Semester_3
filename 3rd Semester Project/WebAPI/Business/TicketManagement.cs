using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Repository;
using WebAPI.Models;

namespace WebAPI.Business
{
    public class TicketManagement
    {
        readonly ITicketRepository ticketRepository;

        public TicketManagement()
        {
            ticketRepository = new TicketRepository();
        }
        public bool AddTicket(Ticket ticket)
        {
            return ticketRepository.AddTicket(ticket);
        }

        public bool DeleteTicket(Ticket ticket)
        {
            return ticketRepository.DeleteTicket(ticket);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return ticketRepository.GetAllTickets();
        }
        public IEnumerable<Ticket> GetActiveTickets()
        {
            return ticketRepository.GetActiveTickets();
        }

        public Ticket GetTicketById(int id)
        {
            return ticketRepository.GetTicketById(id);
        }

        public List<Ticket> GetTicketsByTripId(int id)
        {
            return ticketRepository.GetTicketsByTripId(id);
        }

        public Ticket GetTicketByName(string name)
        {
            return ticketRepository.GetTicketByName(name);
        }

        public bool UpdateTicket(Ticket ticket)
        {
            return ticketRepository.UpdateTicket(ticket);
        }
        public bool DeactivateTicket(Ticket ticket)
        {
            ticket.Active = false;
            return ticketRepository.UpdateTicket(ticket);
        }
    }
}