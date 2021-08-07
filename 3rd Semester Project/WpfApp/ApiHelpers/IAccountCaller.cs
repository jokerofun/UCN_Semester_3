using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.ApiHelpers
{
    interface IAccountCaller
    {
        IRestResponse Register(RegisterAccountModel account);
        IRestResponse Login(LoginViewModel model);
    }
}
