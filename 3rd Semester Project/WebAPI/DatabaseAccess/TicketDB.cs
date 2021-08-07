using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.DatabaseAccess
{
    public class TicketDB
    {
        private Entities dbContext;

        public TicketDB()
        {
            dbContext = new Entities();
        }

        public bool InsertTicket(Ticket ticket)
        {
            try
            {
                using (dbContext = new Entities())
                {
                    dbContext.Tickets.Add(ticket);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            try
            {
                using (dbContext = new Entities())
                {
                    return dbContext.Tickets.ToList<Ticket>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Ticket> GetActiveTickets()
        {
            try
            {
                using (dbContext = new Entities())
                {
                    var query = dbContext.Tickets
                      .Where(s => s.Active == true)
                      .ToList<Ticket>();
                    return query;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Ticket GetTicketById(int id)
        {
            try
            {
                using (dbContext = new Entities())
                {
                    return dbContext.Tickets.FirstOrDefault(ticket => ticket.Id == id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Ticket> GetTicketsByTripId(int id)
        {
            try
            {
                using (dbContext = new Entities())
                {
                    return dbContext.Tickets.Where(p => p.TripId == id).ToList<Ticket>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Ticket GetTicketByName(string name)
        {
            try
            {
                using (dbContext = new Entities())
                {
                    return dbContext.Tickets.FirstOrDefault(ticket => ticket.TicketName == name);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteTicket(Ticket ticket)
        {
            try
            {
                using (dbContext = new Entities())
                {
                    var result = dbContext.Tickets.FirstOrDefault(p => p.Id == ticket.Id);
                    if (result != null)
                    {
                        dbContext.Tickets.Remove(result);
                        dbContext.SaveChanges();
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

        public bool UpdateTicket(Ticket ticket)
        {
            using (dbContext = new Entities())
            {
                try
                {
                    dbContext.Entry(ticket).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void ClearTestData()
        {
            var dbContext = new Entities();
            dbContext.Database.ExecuteSqlCommand(
                "DELETE FROM Tickets;" +
                "DBCC CHECKIDENT('3rdSemesterDatabase.dbo.Tickets', RESEED, 0)"
           );
        }
    }
}