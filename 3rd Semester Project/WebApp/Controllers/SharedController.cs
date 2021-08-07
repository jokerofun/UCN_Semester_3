using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult ShoppingCartOverview()
        {
            return View();
        }

        public ActionResult PaymentGateway()
        {
            return View();
        }

        public void SetViewBagTotal(string Total)
        {
            ViewBag.Total = Total;
        }
    }
}