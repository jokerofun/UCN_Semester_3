using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.DatabaseAccess
{
    public class TripDB
    {
        public TripDB()
        {

        }
        public bool InsertTrip(Trip trip)
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    dbContext.Trips.Add(trip);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    return dbContext.Trips.ToList<Trip>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Trip> GetAllTripsMatchingSearchPattern(Trip inputTrip)
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    var query = dbContext.Trips.AsQueryable();

                    if (inputTrip.Name != null && inputTrip.Name.Length > 0)
                    {
                        query = query.Where(trip => trip.Name.Contains(inputTrip.Name));
                    }
                    if (inputTrip.DeparturePlace != null && inputTrip.DeparturePlace.Length > 0)
                    {
                        query = query.Where(trip => trip.DeparturePlace.Contains(inputTrip.DeparturePlace));
                    }
                    if (inputTrip.ArrivalPlace != null && inputTrip.ArrivalPlace.Length > 0)
                    {
                        query = query.Where(trip => trip.ArrivalPlace.Contains(inputTrip.ArrivalPlace));
                    }
                    if (inputTrip.DepartureDate != DateTime.MinValue)
                    {
                        query = query.Where(trip => DbFunctions.TruncateTime(trip.DepartureDate) == inputTrip.DepartureDate);
                    }
                    if (inputTrip.ArrivalDate != DateTime.MinValue)
                    {
                        query = query.Where(trip => DbFunctions.TruncateTime(trip.ArrivalDate) == inputTrip.ArrivalDate);
                    }
                    return query.ToList<Trip>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Trip GetTripById(int id)
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    return dbContext.Trips.Find(id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Trip> GetTripsByUserId(string userId)
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    return dbContext.Trips.Where(trip => trip.UserId == userId).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteTrip(Trip trip)
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    var result = dbContext.Trips.FirstOrDefault(p => p.ID == trip.ID);
                    if (result != null)
                    {
                        dbContext.Trips.Remove(result);
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateTrip(Trip trip)
        {
            try
            {
                using (var dbContext = new Entities())
                {
                    var result = dbContext.Trips.Find(trip.ID);
                    if (result != null)
                    {
                        dbContext.Entry(result).CurrentValues.SetValues(trip);
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

        public void ClearTestData()
        {
            var dbContext = new Entities();
            dbContext.Database.ExecuteSqlCommand(
                "DELETE FROM UserTicket  \n" +
                "DBCC CHECKIDENT('3rdSemesterDatabase.dbo.UserTicket', RESEED, 0) \n" +
                "DELETE FROM Ticket  \n" +
                "DBCC CHECKIDENT('3rdSemesterDatabase.dbo.Ticket', RESEED, 0) \n" +
                "DELETE FROM Trip  \n" +
                "DBCC CHECKIDENT('3rdSemesterDatabase.dbo.Trip', RESEED, 0)" 
           ) ;
        }

    }
}