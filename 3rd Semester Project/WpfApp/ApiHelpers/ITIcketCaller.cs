using RestSharp;
using System.Collections.Generic;
using WpfApp.Models;

namespace WpfApp.ApiHelpers
{
    interface ITicketCaller
    {
        IRestResponse CreateTicket(Ticket ticket);
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        IRestResponse UpdateTicket(Ticket ticket);
        IRestResponse DeleteTicket(Ticket ticket);
        List<Ticket> GetTicketsByTripId(int id);

    }

}
