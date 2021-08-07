using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    interface ITripRepository {

        bool AddTrip(Trip trip);
        Trip GetTripById(int id);
        bool UpdateTrip(Trip trip);
        bool DeleteTrip(Trip trip);
        IEnumerable<Trip> GetAllTripsMatchingSearchPattern(Trip trip);
    }
}
