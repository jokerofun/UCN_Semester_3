using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IUserTicketRepository
    {
        IEnumerable<UserTicket> GetAllUserTickets();
        bool BuyTickets(List<UserTicket> userTicket, List<TicketAmountEntry> entries);
        List<UserTicket> GetUserTicketsByUserId(string id);
        UserTicket GetUserTicketById(int id);
        bool DeleteUserTicket(UserTicket userTicket);
        bool UpdateUserTicket(UserTicket userTicket);
        int GetTicketsRemaining(int ticketId);
    }
}
