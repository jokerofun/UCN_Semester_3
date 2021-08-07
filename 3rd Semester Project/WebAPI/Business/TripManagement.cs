using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Business
{
    public class TripManagement
    {
        readonly ITripRepository tripRepository;
        public TripManagement()
        {
            tripRepository = new TripRepository();
        }

        public bool AddTrip(Trip trip)
        {
            return tripRepository.AddTrip(trip);
        }

        public bool DeleteTrip(Trip trip)
        {
            return tripRepository.DeleteTrip(trip);
        }

        public IEnumerable<Trip> GetAllTripsMatchingSearchPatternByUserId(Trip trip)
        {
            return tripRepository.GetAllTripsMatchingSearchPattern(trip).Where(x => x.UserId == trip.UserId);
        }

        public IEnumerable<Trip> GetAllTripsMatchingSearchPatternUpToDate(Trip trip)
        {
            return tripRepository.GetAllTripsMatchingSearchPattern(trip).Where(x => x.DepartureDate >= DateTime.Now); ;
        }

        public Trip GetTripById(int id)
        {
            return tripRepository.GetTripById(id);
        }

        public bool UpdateTrip(Trip trip)
        {
            return tripRepository.UpdateTrip(trip);
        }
    }
}