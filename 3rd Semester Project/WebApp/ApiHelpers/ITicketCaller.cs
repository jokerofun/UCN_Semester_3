using RestSharp;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ApiHelpers
{
    interface ITicketCaller
    {
        IRestResponse CreateTicket(Ticket ticket);
        List<Ticket> GetAllTickets();
        List<Ticket> GetActiveTickets();
        Ticket GetTicketById(int id);
        IRestResponse UpdateTicket(Ticket ticket);
        IRestResponse DeleteTicket(Ticket ticket);
        IRestResponse DeactivateTicket(Ticket ticket);
        List<Ticket> GetTicketsByTripId(int id);
    }
}
