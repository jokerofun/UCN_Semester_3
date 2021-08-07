using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using WpfApp.Models;

namespace WpfApp.ApiHelpers
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
        public IRestResponse UpdateUserTicket(UserTicket userTicket)
        {
            var request = new RestRequest("Put", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(userTicket);
            return client.Execute(request);
        }
    }
}
