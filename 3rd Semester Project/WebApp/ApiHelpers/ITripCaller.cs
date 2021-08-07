using RestSharp;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ApiHelpers
{
    interface ITripCaller
        {
            IRestResponse CreateTrip(Trip trip);
            Trip GetTripById(int id);
            List<Trip> GetMatchingTripsUpToDate(Trip trip);
            List<Trip> GetMatchingTripsByUserId(Trip trip);
            IRestResponse UpdateTrip(Trip trip);
            IRestResponse DeleteTrip(Trip trip);


        }
    
}

