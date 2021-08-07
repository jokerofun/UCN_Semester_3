using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ApiHelpers
{
    public class UserTicketCaller : IUserTicketCaller
    {

        private RestClient client;

        public UserTicketCaller()
        {
            client = new RestClient("https://localhost:44352/api/UserTicket/");
        }

        public List<UserTicket> GetUserTickets()
        {
            var request = new RestRequest("GetUserTickets", Method.GET);
            var response = client.Execute<List<UserTicket>>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<List<UserTicket>>(response.Content);
            return deserializedResponse;
        }

        public UserTicket GetUserTicketById(int id)
        {
            var request = new RestRequest("GetUserTicketById/" + id, Method.GET);
            var response = client.Execute<UserTicket>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<UserTicket>(response.Content);
            return deserializedResponse;
        }

        public IRestResponse CreateUserTickets(List<UserTicket> listOfUserTickets)
        {
            var request = new RestRequest("PostUserTickets", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(listOfUserTickets);
            return client.Execute(request);
        }

        public List<UserTicket> GetAllUserTicketsByUserId(string id)
        {
            var request = new RestRequest("GetUserTicketsByUserId/" + id, Method.GET);
            var response = client.Execute<List<UserTicket>>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<List<UserTicket>>(response.Content);
            return deserializedResponse;
        }

        public int GetTicketsRemaining(int ticketId)
        {
            var request = new RestRequest("GetTicketsRemaining/" + ticketId, Method.GET);
            var response = client.Execute<int>(request);
            var deserializedResponse = JsonConvert.DeserializeObject<int>(response.Content);
            return deserializedResponse;
        }
        public IRestResponse DeactivateUserTicket(UserTicket userTicket)
        {
            var request = new RestRequest("DeactivateUserTicket", Method.PUT);
            request.AddJsonBody(userTicket);
            return client.Execute(request);
        }
    }
}