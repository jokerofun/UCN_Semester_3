using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using WebAPI.DatabaseAccess;

namespace WebAPI.Repository
{
    public class UserTicketRepository : IUserTicketRepository
    {
        private UserTicketDB userTicketDB;
        public UserTicketRepository()
        {
            userTicketDB = new UserTicketDB();
        }
        public IEnumerable<UserTicket> GetAllUserTickets()
        {
            return userTicketDB.GetAllUserTickets();
        }

        public UserTicket GetUserTicketById(int id)
        {
            return userTicketDB.GetUserTicketById(id);
        }

        public bool BuyTickets(List<UserTicket> userTickets, List<TicketAmountEntry> entries)
        {
            return userTicketDB.BuyTickets(userTickets, entries);
        }

        public bool DeleteUserTicket(UserTicket userTicket)
        {
            throw new NotImplementedException();
        }

        public List<UserTicket> GetUserTicketsByUserId(string id)
        {
            return userTicketDB.GetUserTicketsByUserId(id);
        }
        public bool UpdateUserTicket(UserTicket userTicket)
        {
            return userTicketDB.UpdateUserTicket(userTicket);
        }
        public int GetTicketsRemaining(int ticketId)
        {
            return userTicketDB.GetTicketsRemaining(ticketId);
        }
    }
}