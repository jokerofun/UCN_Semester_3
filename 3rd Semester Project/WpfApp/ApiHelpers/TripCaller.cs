using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using WpfApp.Models;

namespace WpfApp.ApiHelpers
{
    public class TripCaller : ITripCaller
    {
        private RestClient client;

        public TripCaller()
        {
            client = new RestClient("https://localhost:44352/api/Trips/");
        }

        public IRestResponse CreateTrip(Trip trip)
        {
            var request = new RestRequest("PostTrip", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(trip);
            return client.Execute(request);
        }

        public IRestResponse DeleteTrip(Trip trip)
        {
            var request = new RestRequest("DeleteTrip", Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(trip);
            return client.Execute(request);
        }

        public Trip GetTripById(int id)
        {
            var request = new RestRequest("GetTripById/" + id, Method.GET);
            var response = client.Execute<Trip>(request);
            var deserializeResponse = JsonConvert.DeserializeObject<Trip>(response.Content);
            return deserializeResponse;
        }

        public List<Trip> GetMatchingTripsUpToDate(Trip trip)
        {
            var request = new RestRequest("GetMatchingTripsUpToDate", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(trip);
            var response = client.Execute<List<Trip>>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<List<Trip>>(response.Content);
            return deserializedResponse;
        }

        public IRestResponse UpdateTrip(Trip trip)
        {
            var request = new RestRequest("PutTrip", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(trip);
            return client.Execute(request);
        }
    }
}