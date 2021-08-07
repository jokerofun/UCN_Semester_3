using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MovieExperienceMvc.Models;
using MovieExperienceMvc.BusinessLayer;

namespace MovieExperienceMvc.Controllers {
    public class MovieController : Controller {
        // Movie GET
        public ActionResult Index() {

            return View();
        }

        public async Task<ActionResult> SeatReservation(int? id) {
            ShowingAccessControl showingAccVtrl = new ShowingAccessControl();
            bool withReservations = true;
            int showingIdInt = (id != null) ? ((int)id) : 0;
            Showing foundShowing = await showingAccVtrl.GetShowingById(showingIdInt, withReservations);

            string bookText = "Press green seat to reserve seat";
            if (TempData["bookResult"] != null) {
                bookText = TempData["bookResult"].ToString();
            }
            ViewBag.PrevResult = bookText;

            return View(foundShowing);
        }

        [HttpPost]
        public async Task<ActionResult> SeatReservation(int showId, string reservedSeats) {
            ShowingAccessControl showingAccVtrl = new ShowingAccessControl();
            bool wasUpdated = await showingAccVtrl.UpdateShowingReservations(showId, reservedSeats);
            if (wasUpdated) {
                ViewBag.PrevResult = "Seats was reserved!";
            } else {
                ViewBag.PrevResult = "Sorry - not reserved - something went wrong";
            }

            Showing foundShowing = await showingAccVtrl.GetShowingById(1, true);

            return View("SeatReservation", foundShowing );
        }

    }
}