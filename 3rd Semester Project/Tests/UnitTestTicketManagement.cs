using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Models;
using WebAPI.Business;
using WebAPI.Repository;

namespace Tests
{
    /// <summary>
    /// Summary description for UnitTestTicketManagement
    /// </summary>
    [TestClass]
    public class UnitTestTicketManagement
    {
        private UserTicketManagement userTicketManagement;
        public UnitTestTicketManagement()
        {
            userTicketManagement = new UserTicketManagement();
        }
        [TestMethod]
        public void GetAllUserTicketsUniTest()
        {
            userTicketManagement.SetUserTicketRepository(new StubuUserTicketRepository());
            List<UserTicket> temp = (List<UserTicket>)userTicketManagement.GetAllUserTickets();
            bool result;
            if(temp.Count == 5)
            {
                result = true;
            }
            else
            {
               result = false;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CountUniTest()
        {
            UserTicketManagement target = new UserTicketManagement();
            PrivateObject obj = new PrivateObject(target);
            UserTicket userTicket1 = new UserTicket("Alex", "K. Stefan", 1, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            UserTicket userTicket2 = new UserTicket("Alex", "K. Nicola", 2, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            UserTicket userTicket3 = new UserTicket("Alex", "S George", 3, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            UserTicket userTicket4 = new UserTicket("Alex", "S George", 1, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            UserTicket userTicket5 = new UserTicket("Alex", "S George", 2, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            List<UserTicket> UserTickets = new List<UserTicket>();
            UserTickets.Add(userTicket1);
            UserTickets.Add(userTicket2);
            UserTickets.Add(userTicket3);
            UserTickets.Add(userTicket4);
            UserTickets.Add(userTicket5);
            var retVal = (List<TicketAmountEntry>)obj.Invoke("Count", UserTickets);
            bool result;
            if(retVal.Count == 3)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsTrue(result);
        }
    }

        public class StubuUserTicketRepository : IUserTicketRepository
        {
        public bool BuyTickets(List<UserTicket> userTicket, List<TicketAmountEntry> entries)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserTicket(UserTicket userTicket)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTicket> GetAllUserTickets()
            {
                UserTicket userTicket1 = new UserTicket("Alex", "K. Stefan", 1, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
                UserTicket userTicket2 = new UserTicket("Alex", "K. Nicola", 2, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
                UserTicket userTicket3 = new UserTicket("Alex", "S George", 3, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
                UserTicket userTicket4 = new UserTicket("Alex", "S George", 1, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
                UserTicket userTicket5 = new UserTicket("Alex", "S George", 2, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            List<UserTicket> UserTickets = new List<UserTicket>();
                UserTickets.Add(userTicket1);
                UserTickets.Add(userTicket2);
                UserTickets.Add(userTicket3);
                UserTickets.Add(userTicket4);
                UserTickets.Add(userTicket5);
                return UserTickets;
            }

        public int GetTicketsRemaining(int ticketId)
        {
            throw new NotImplementedException();
        }

        public UserTicket GetUserTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserTicket> GetUserTicketsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserTicket(UserTicket userTicket)
        {
            throw new NotImplementedException();
        }
    }
}
