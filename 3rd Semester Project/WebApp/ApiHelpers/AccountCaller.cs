using RestSharp;
using WebApp.Models;

namespace WebApp.ApiHelpers
{
    public class AccountCaller : IAccountCaller
    {
        private RestClient client;
        public AccountCaller()
        {
            client = new RestClient("https://localhost:44352/api/");
        }

        public IRestResponse Register(RegisterAccountModel account)
        {
            var request = new RestRequest("Account/Register", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(account);
            return client.Execute(request);
        }
    }

}