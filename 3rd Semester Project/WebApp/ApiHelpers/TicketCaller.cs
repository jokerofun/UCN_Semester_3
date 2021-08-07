using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ApiHelpers
{
    public class TicketCaller : ITicketCaller
    {
        private RestClient client;

        public TicketCaller()
        {
            client = new RestClient("https://localhost:44352/api/Tickets/");
        }

        public IRestResponse CreateTicket(Ticket ticket)
        {
            var request = new RestRequest("PostTicket", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(ticket);
            return client.Execute(request);
        }

        public IRestResponse DeleteTicket(Ticket ticket)
        {
            var request = new RestRequest("DeleteTicket", Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(ticket);
            return client.Execute(request);
        }

        public IRestResponse DeactivateTicket(Ticket ticket)
        {
            var request = new RestRequest("DeactivateTicket", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(ticket);
            return client.Execute(request);
        }

        public Ticket GetTicketById(int id)
        {
            var request = new RestRequest("GetTicketById/" + id,Method.GET);
            var response = client.Execute<Ticket>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<Ticket>(response.Content);
            return deserializedResponse;

        }

        public List<Ticket> GetAllTickets()
        {
            var request = new RestRequest("Get", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<List<Ticket>>(response.Content);
            return deserializedResponse;
        }

        public List<Ticket> GetActiveTickets()
        {
            var request = new RestRequest("GetActive", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<List<Ticket>>(response.Content);
            return deserializedResponse;
        }

        public IRestResponse UpdateTicket(Ticket ticket)
        {
            var request = new RestRequest("PutTicket", Method.PUT);
            request.AddJsonBody(ticket);
            return client.Execute(request);
        }

        public List<Ticket> GetTicketsByTripId(int id)
        {
            var request = new RestRequest("GetTicketsByTripId/" + id, Method.GET);
            var response = client.Execute(request);
            var deserializedResponse = JsonConvert.DeserializeObject<List<Ticket>>(response.Content);
            return deserializedResponse;
        }
    }
}