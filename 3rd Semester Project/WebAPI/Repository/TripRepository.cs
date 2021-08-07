using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.DatabaseAccess;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly TripDB tripDb;
        public TripRepository()
        {
            tripDb = new TripDB();
        }

        public bool AddTrip(Trip trip)
        {
            return tripDb.InsertTrip(trip);
        }

        public bool DeleteTrip(Trip trip)
        {
            return tripDb.DeleteTrip(trip);
        }

        public IEnumerable<Trip> GetAllTripsMatchingSearchPattern(Trip trip)
        {
            return tripDb.GetAllTripsMatchingSearchPattern(trip);
        }

        public Trip GetTripById(int id)
        {
            return tripDb.GetTripById(id);
        }

        public bool UpdateTrip(Trip trip)
        {
            return tripDb.UpdateTrip(trip);
        }
    }
}