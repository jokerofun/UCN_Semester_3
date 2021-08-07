using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.DatabaseAccess
{
    public class UserTicketDB
    {
        private Entities dbContext;
        private static readonly object BuyingLock = new object();
        public UserTicketDB()
        {
            dbContext = new Entities();
        }

        public bool BuyTickets(List<UserTicket> userTickets, List<TicketAmountEntry> entries)
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                lock (BuyingLock)
                {
                    try
                    {
                        foreach (var entry in entries)
                        {
                            var amountBought = dbContext.UserTickets.Count(t => t.TicketId == entry.TicketId && t.Active == true);
                            var amountMax = dbContext.Tickets.First(t => t.Id == entry.TicketId).MaxTickets;

                            if (amountMax - amountBought < entry.Amount)
                            {
                                throw new DbUpdateConcurrencyException();
                            }
                        }

                        foreach (var userTicket in userTickets)
                        {
                            try
                            {
                                dbContext.UserTickets.Add(userTicket);
                            }
                            catch (Exception)
                            {
                                throw new Exception();  
                            }
                        }
                        dbContext.SaveChanges();
                        dbContextTransaction.Commit();

                        return true;

                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        dbContextTransaction.Rollback();
                        throw ex;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        return false;
                    }
                }
            }
        }


        public List<UserTicket> GetUserTicketsByUserId(string id)
        {
            try
            {
                using (dbContext = new Entities())
                {
                    return dbContext.UserTickets.Where(p => p.UserId.Equals(id)).ToList<UserTicket>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteUserTicket(UserTicket userTicket)
        {
            try
            {
                using (dbContext = new Entities())
                {
                    var result = dbContext.UserTickets.FirstOrDefault(t => t.Id == userTicket.Id);
                    if (result != null)
                    {
                        dbContext.UserTickets.Remove(result);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUserTicket(UserTicket userTicket)
        {
            using (dbContext = new Entities())
            {
                try
                {
                    dbContext.Entry(userTicket).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return true;

                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
            }
        }
        public int GetTicketsRemaining(int ticketId)
        {
            using (dbContext = new Entities())
            {
                try
                {
                    var amountBought = dbContext.UserTickets.Count(t => t.TicketId == ticketId && t.Active == true);
                    var amountMax = dbContext.Tickets.First(t => t.Id == ticketId).MaxTickets;
                    return amountMax - amountBought;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<UserTicket> GetAllUserTickets()
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    return dbContext.UserTickets.ToList<UserTicket>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserTicket GetUserTicketById(int id)
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    return dbContext.UserTickets.Find(id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}