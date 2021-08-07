using RestSharp;
using WpfApp.Models;

namespace WpfApp.ApiHelpers
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

        public IRestResponse Login(LoginViewModel model)
        {
            client = new RestClient("https://localhost:44352/");
            var request = new RestRequest("Token", Method.POST, DataFormat.Json);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&username=" + model.Email + "&password=" + model.Password, ParameterType.RequestBody);
            var result = client.Execute(request);
            return result;
        }
    }

}