using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Business
{
    public class UserTicketManagement
    {
        private IUserTicketRepository userTicketRepository;
        readonly TicketManagement ticketManagement;
        readonly TripManagement tripManagement;

        public UserTicketManagement()
        {
            userTicketRepository = new UserTicketRepository();
            ticketManagement = new TicketManagement();
            tripManagement = new TripManagement();
        }
        public IEnumerable<UserTicket> GetAllUserTickets()
        {
            return userTicketRepository.GetAllUserTickets();
        }

        public UserTicket GetUserTicketById(int id)
        {
            return userTicketRepository.GetUserTicketById(id);
        }

        public bool BuyTickets(List<UserTicket> userTickets)
        {
            foreach (UserTicket userTicket in userTickets)
            {
                userTicket.Active = true;
            }
            List<TicketAmountEntry> entries = Count(userTickets);
            return userTicketRepository.BuyTickets(userTickets, entries);
        }

        public List<UserTicket> GetUserTicketsByUserId(string id)
        {
            return userTicketRepository.GetUserTicketsByUserId(id);
        }

        private List<TicketAmountEntry> Count(List<UserTicket> userTickets)
        {
            List<TicketAmountEntry> entries = new List<TicketAmountEntry>();
            foreach (var userTicket in userTickets)
            {
                int ok = 0;
                foreach (var entry in entries)
                {
                    if (userTicket.TicketId == entry.TicketId)
                    {
                        entry.Amount++;
                        ok = 1;
                    }
                }

                if (ok == 0)
                {
                    entries.Add(new TicketAmountEntry(userTicket.TicketId, 1));
                }
            }
            return entries;
        }
        public bool DeactivateUserTicket(UserTicket userTicket)
        {
            DateTime departureDate = tripManagement.GetTripById(ticketManagement.GetTicketById(userTicket.TicketId).TripId).DepartureDate;
            DateTime checkDate = departureDate.AddDays(-3);
            if (DateTime.Now < checkDate)
            {
                userTicket.Active = false;
                return userTicketRepository.UpdateUserTicket(userTicket);
            }
            else
            {
                return false;
            }
        }
        public int GetTicketsRemaining(int ticketId)
        {
            return userTicketRepository.GetTicketsRemaining(ticketId);
        }
        public bool UpdateUserTicket(UserTicket userTicket)
        {
            return userTicketRepository.UpdateUserTicket(userTicket);
        }
         

        //UsedForTesting in order to assign StubRepos
        public void SetUserTicketRepository(object newRepos)
        {
            userTicketRepository = (IUserTicketRepository)newRepos;
        }
    }
}