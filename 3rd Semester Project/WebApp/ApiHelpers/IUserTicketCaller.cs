using RestSharp;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ApiHelpers
{
    interface IUserTicketCaller
    {
        IRestResponse CreateUserTickets(List<UserTicket> listOfUserTickets);
        List<UserTicket> GetAllUserTicketsByUserId(string id);
        UserTicket GetUserTicketById(int id);
        int GetTicketsRemaining(int ticketId);
        IRestResponse DeactivateUserTicket(UserTicket userTicket);
    }
}
