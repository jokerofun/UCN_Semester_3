using RestSharp;
using System.Collections.Generic;
using WpfApp.Models;

namespace WpfApp.ApiHelpers
{
    interface ITripCaller
    {
        IRestResponse CreateTrip(Trip trip);
        List<Trip> GetMatchingTripsUpToDate(Trip trip);
        Trip GetTripById(int id);
        IRestResponse UpdateTrip(Trip trip);
        IRestResponse DeleteTrip(Trip trip);

    }

}

