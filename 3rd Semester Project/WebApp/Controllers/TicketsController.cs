using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp.ApiHelpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TicketsController : Controller
    {

        private ITicketCaller ticketCaller;
        private ITripCaller tripCaller;
        private IUserTicketCaller userTicketCaller;
        public TicketsController()
        {
            ticketCaller = new TicketCaller();
            tripCaller = new TripCaller();
            userTicketCaller = new UserTicketCaller();
        }

        [Authorize]
        //[ValidateAntiForgeryToken]
        // GET: ListOfTickets
        public ActionResult ListOfTickets(int id)
        {
            var tickets = ticketCaller.GetTicketsByTripId(id);
            tickets = tickets.Where(t => t.Active == true).ToList();
            foreach (var ticket in tickets)
            {
                ticket.TicketsRemaining = userTicketCaller.GetTicketsRemaining(ticket.Id);
            }
            ViewBag.CurrentTrip = id;
            ViewBag.Trip = tripCaller.GetTripById(id);

            return View(tickets);
        }

        [Authorize]
        // GET: CreateTicket
        public ActionResult CreateTicket(int id)
        {
            ViewBag.CurrentTrip = id;
            return View();
        }

        [Authorize]
        // POST: CreateTicket
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateTicket(int id, CreateTicketModel model)
        {
            if (ModelState.IsValid)
            {
                var ticket = new Ticket {TicketName = model.TicketName,TicketDescription = model.TicketDescription, Price = model.Price, MaxTickets = model.MaxTickets, TripId = model.TripId };
                ticket.TripId = id;
                ticket.Active = true;
                ticket.TicketsRemaining = model.MaxTickets;
                var result = ticketCaller.CreateTicket(ticket);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("ListOfTickets/" + id, "Tickets");
                }
            }
            return View();
        }
        
        [Authorize]
        // GET: DeleteTicket
        public ActionResult DeleteTicket(int? tripId)
        {
            ViewBag.CurrentTrip = tripId;
            return View();
        }
        
        [Authorize]
        // DELETE: DeleteTicket
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteTicket(int id)
        {
            if (ModelState.IsValid)
            {
                Ticket ticket = ticketCaller.GetTicketById(id);
                var result = ticketCaller.DeactivateTicket(ticket);
                if(result.IsSuccessful)
                {
                    return RedirectToAction("ListOfTickets/" + ticket.TripId, "Tickets");
                }
            }
            return View();
        }

        [Authorize]
        // GET: UpdateTicket
        public ActionResult UpdateTicket(int? id)
        {
            Ticket model = ticketCaller.GetTicketById(id.GetValueOrDefault());
            return View(model);
        }

        
        [Authorize]
        // Update: UpdateTicket
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult UpdateTicket(Ticket ticket)
        {
            if(ModelState.IsValid)
            {
                ticket.Active = true;
                   var result = ticketCaller.UpdateTicket(ticket);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("ListOfTickets/" + ticket.TripId, "Tickets");
                }
            }
            return View();
        }

        [Authorize]
        // GET: BuyTicket
        public ActionResult BuyTicket(int? tripId)
        {
            ViewBag.CurrentTrip = tripId;
            return View();
        }

        [Authorize]
        // POST: BuyTicket
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult BuyTicket(int id, CreateShopingTicketsViewModel model)
        {
            var shoppingTicket = new DisplayShopingCartTicket { AmountBought = (int)model.AmountBought };
            var ticket = ticketCaller.GetTicketById(id);
            shoppingTicket.Id = ticket.Id;
            shoppingTicket.TicketName = ticket.TicketName;
            shoppingTicket.Price = ticket.Price;
            shoppingTicket.TripId = ticket.TripId;
            return RedirectToAction("AddDisplayTicket", "UserTickets",shoppingTicket);
        }

        public void AddBuyerName(string FirstName,string LastName)
        {
            BuyerName buyerName = new BuyerName(FirstName, LastName);
            List<BuyerName> tempBuyerNameList = new List<BuyerName>();
            if (Session["BuyerName"] == null)
            {
                tempBuyerNameList.Add(buyerName);
                Session["BuyerName"] = tempBuyerNameList;
            }
            else
            {
                tempBuyerNameList = Session["BuyerName"] as List<BuyerName>;
                tempBuyerNameList.Add(buyerName);
                Session["BuyerName"] = tempBuyerNameList;
            }
        }
    }
}