using RestSharp;
using WebApp.Models;

namespace WebApp.ApiHelpers
{
    interface IAccountCaller
    {
        IRestResponse Register(RegisterAccountModel account);
    }
}
