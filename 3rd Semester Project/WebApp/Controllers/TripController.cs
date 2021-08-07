using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp.ApiHelpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TripController : Controller
    {
        private ITripCaller tripCaller;

        public TripController()
        {
            tripCaller = new TripCaller();
        }

        [Authorize]
        [HttpGet]
        // GET: ListOfTrips
        public ActionResult ListOfTrips(string name, string departurePlace, string arrivalPlace, string departureDate, string arrivalDate, int? pageNumber, string sort, string userId)
        {
            // Here the sorting type is chosen based on what query is received from the view
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
            ViewBag.SortByDeparturePlace = sort == "DeparturePlace" ? "descending departurePlace" : "DeparturePlace";
            ViewBag.SortByArrivalPlace = sort == "ArrivalPlace" ? "descending arrivalPlace" : "ArrivalPlace";
            ViewBag.SortByDepartureDate = sort == "DepartureDate" ? "descending departureDate" : "DepartureDate";
            ViewBag.SortByArrivalDate = sort == "ArrivalDate" ? "descending arrivalDate" : "ArrivalDate";

            // An empty Trip object is created and then filled with the data coming from the view; Then it is passed to the api to retrieve only the matching ones
            Trip trip = new Trip();
            trip.Name = name;
            trip.DeparturePlace = departurePlace;
            trip.ArrivalPlace = arrivalPlace;
            if (departureDate != null && !departureDate.Equals(""))
            {
                DateTime temp = DateTime.Parse(departureDate);
                trip.DepartureDate = DateTime.SpecifyKind(temp, DateTimeKind.Utc);

            }
            if (arrivalDate != null && !arrivalDate.Equals(""))
            {
                DateTime temp = DateTime.Parse(arrivalDate);
                trip.ArrivalDate = DateTime.SpecifyKind(temp, DateTimeKind.Utc);
            }

            IEnumerable<Trip> trips = new List<Trip>();

            if (userId == null)
            {
                trips = tripCaller.GetMatchingTripsUpToDate(trip);
            }
            else if (userId != null)
            {
                trip.UserId = userId;
                trips = tripCaller.GetMatchingTripsByUserId(trip);
                ViewBag.BusinessAccess = true;
            }

            // The filtered list of Trips that was returned is then passed a sorting method, which sorts based on the SortType set in the beginning
            switch (sort)
            {
                case "descending name":
                    trips = trips.OrderByDescending(c => c.Name);
                    break;

                case "descending departurePlace":
                    trips = trips.OrderByDescending(c => c.DeparturePlace);
                    break;

                case "DeparturePlace":
                    trips = trips.OrderBy(c => c.DeparturePlace);
                    break;

                case "descending arrivalPlace":
                    trips = trips.OrderByDescending(c => c.ArrivalPlace);
                    break;

                case "ArrivalPlace":
                    trips = trips.OrderBy(c => c.ArrivalPlace);
                    break;

                case "descending departureDate":
                    trips = trips.OrderByDescending(c => c.DepartureDate);
                    break;

                case "DepartureDate":
                    trips = trips.OrderBy(c => c.DepartureDate);
                    break;

                case "descending arrivalDate":
                    trips = trips.OrderByDescending(c => c.ArrivalDate);
                    break;

                case "ArrivalDate":
                    trips = trips.OrderBy(c => c.ArrivalDate);
                    break;

                default:
                    trips = trips.OrderBy(c => c.Name);
                    break;
            }

            // Redirects the user and renders the given view
            // Parameters: pagenumber - the last page the user was on; (1, 5) - pageNumber is set to 1 if it wasn't passed; the 5 is the pageSize - how many items to display per page
            return View(trips.ToPagedList(pageNumber ?? 1, 5));
        }


        [Authorize]
        // GET: CreateTrip
        public ActionResult CreateTrip(string userId)
        {
            if (userId != null)
            {
                ViewBag.BusinessAccess = true;
            }
            return View();
        }

        [Authorize]
        // POST: CreateTrip
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateTrip(string Id, CreateTripModel model, string userId)
        {
            if (ModelState.IsValid)
            {
                var trip = new Trip { Name = model.Name, Description = model.Description, DeparturePlace = model.DeparturePlace, ArrivalPlace = model.ArrivalPlace, DepartureDate = model.DepartureDate, ArrivalDate = model.ArrivalDate };
                trip.UserId = Id;
                var result = tripCaller.CreateTrip(trip);
                if (result.IsSuccessful)
                {
                    if (userId == null)
                    {
                        return RedirectToAction("ListOfTrips", "Trip");
                    }
                    else
                    {
                        return RedirectToAction("ListOfTrips", "Trip", new { userId });
                    }
                }
            }
            return View();
        }


        [Authorize]
        // GET: DeleteTrip
        public ActionResult DeleteTrip(string userId)
        {
            if (userId != null)
            {
                ViewBag.BusinessAccess = true;
            }
            return View();
        }

        [Authorize]
        // DELETE: DeleteCruise
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteTrip(int id, string userId)
        {
            if (ModelState.IsValid)
            {
                var trip = tripCaller.GetTripById(id);
                var result = tripCaller.DeleteTrip(trip);
                if (result.IsSuccessful)
                {
                    if (userId == null)
                    {
                        return RedirectToAction("ListOfTrips", "Trip");
                    }
                    else
                    {
                        return RedirectToAction("ListOfTrips", "Trip", new { userId });
                    }
                }
            }
            return View();
        }

        [Authorize]
        //GET: UpdateTrip
        public ActionResult UpdateTrip(int? id, string userId)
        {
            if (userId != null)
            {
                ViewBag.BusinessAccess = true;
            }
            Trip model = tripCaller.GetTripById(id.GetValueOrDefault());
            return View(model);
        }

        [Authorize]
        // Update: UpdateTrip
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult UpdateTrip(Trip trip, string userId)
        {
            if (ModelState.IsValid)
            {
                var result = tripCaller.UpdateTrip(trip);
                if (result.IsSuccessful)
                {
                    if (userId == null)
                    {
                        return RedirectToAction("ListOfTrips", "Trip");
                    }
                    else
                    {
                        return RedirectToAction("ListOfTrips", "Trip", new { userId });
                    }
                }
            }
            return View();
        }
    }
}