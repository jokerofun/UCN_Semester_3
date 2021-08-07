using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.ApiHelpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserTicketsController : Controller
    {
        private IUserTicketCaller userTicketCaller;

        public UserTicketsController()
        {
            userTicketCaller = new UserTicketCaller();
        }

        [Authorize]
        // GET: ListOfUserTickets
        public ActionResult ListOfUserTickets(string id)
        {
            var userTickets = userTicketCaller.GetAllUserTicketsByUserId(id);
            ViewBag.UserTickets = userTickets;

            return View();
        }

        public ActionResult DeactivateUserTicket(int id)
        {
            var userTicket = userTicketCaller.GetUserTicketById(id);
            var response = userTicketCaller.DeactivateUserTicket(userTicket);
            if (response.IsSuccessful)
            {
                TempData["Successful"] = true;
            }else
            {
                TempData["Successful"] = false;
            }
            return RedirectToAction("ListOfUserTickets/" + userTicket.UserId, "UserTickets");
        }

        [Authorize]
        public void SetViewBagShoppingCart(List<DisplayShopingCartTicket> tempList)
        {
            HttpContext c = System.Web.HttpContext.Current;
            if (c.Session != null && c.Session["TicketsBought"] != null)
            {
                c.Session["TicketsBought"] = tempList;
            }
            else
            {
                c.Session.Add("TicketsBought", tempList);
            }
        }


        //POST: ticket
        //Finish this
        public ActionResult AddDisplayTicket(DisplayShopingCartTicket shoppingTicket)
        {
            //Create new list every time or get the existing one store it localy and add or remove from it
            if (Session["BuyerName"] != null)
            {
                foreach (var item in Session["BuyerName"] as List<BuyerName>)
                {
                    shoppingTicket.AddBuyerName(item);
                }
                Session.Remove("BuyerName");
                List<DisplayShopingCartTicket> shopingList = new List<DisplayShopingCartTicket>();
                HttpContext c = System.Web.HttpContext.Current;
                if (c.Session != null && c.Session["TicketsBought"] != null)
                {
                    shopingList = c.Session["TicketsBought"] as List<DisplayShopingCartTicket>;
                    shopingList.Add(shoppingTicket);
                }
                else
                {
                    shopingList.Add(shoppingTicket);
                }
                SetViewBagShoppingCart(shopingList);
            }
            return View("~/Views/Home/Index.cshtml");
        }


        public ActionResult CompleteTransaction(string userId)
        {
            List<DisplayShopingCartTicket> shoppingList = Session["TicketsBought"] as List<DisplayShopingCartTicket>;
            BuyerName temp = new BuyerName();
            List<UserTicket> listOfUserTickets = new List<UserTicket>();
            foreach (var item in shoppingList)
            {
                for (int i = 0; i < item.AmountBought; i++)
                {
                    temp = item.GetName();
                    UserTicket userTicket = new UserTicket();
                    userTicket.UserId = userId;
                    userTicket.TicketId = item.Id;
                    userTicket.FirstName = temp.FirstName;
                    userTicket.LastName = temp.LastName;
                    listOfUserTickets.Add(userTicket);
                }
            }
            var result = CompleteTransactionDB(listOfUserTickets);
            if (result != true)
            {
                throw new Exception("Blame Alex he is a retartd");
            }
            Session.Remove("TicketsBought");
            //Session.Clear();
            return View("~/Views/Home/Index.cshtml");
        }

        //POST: ticket
        public bool CompleteTransactionDB(List<UserTicket> listOfUserTickets)
        {
            var result = userTicketCaller.CreateUserTickets(listOfUserTickets);
            if (result.IsSuccessful)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult RemoveFromShopingList(int id)
        {
            DisplayShopingCartTicket temp = new DisplayShopingCartTicket();
            List<DisplayShopingCartTicket> tempList = new List<DisplayShopingCartTicket>();
            tempList = Session["TicketsBought"] as List<DisplayShopingCartTicket>;
            foreach(var displayTicket in tempList)
            {
                if(displayTicket.Id == id)
                {
                    temp = displayTicket;
                }
            }

            tempList.Remove(temp);
            SetViewBagShoppingCart(tempList);
            return View("~/Views/Home/Index.cshtml");
        }

        public void clearSession()
        {
            Session.Remove("TicketsBought");
        }
    }
}