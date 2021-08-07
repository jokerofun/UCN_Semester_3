using RestSharp;
using System.Collections.Generic;
using WpfApp.Models;

namespace WpfApp.ApiHelpers
{
    interface IUserTicketCaller
    {
        List<UserTicket> GetUserTickets();
        IRestResponse UpdateUserTicket(UserTicket userTicket);
    }
}
