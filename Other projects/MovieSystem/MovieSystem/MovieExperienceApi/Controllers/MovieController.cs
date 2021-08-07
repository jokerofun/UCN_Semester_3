using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExperienceDb.Model;
using MovieExperienceDb.Data;

namespace MovieExperienceApi.Controllers {

    [RoutePrefix("api/movie")]
    public class MovieController : ApiController {

        [HttpGet]
        [Route("showing/{showingId}")]
        public IHttpActionResult GetByName(int showingId = 0, bool includeReservations = false) {
            IHttpActionResult foundToReturn;
            Showing foundShowing;
            List<SeatReservation> seatReservations;
            //
            DbAccessShowing dbAccShow = new DbAccessShowing();
            try {
                foundShowing = dbAccShow.GetShowingById(showingId);
                if (foundShowing != null && includeReservations) {
                    seatReservations = dbAccShow.GetSeatReservationByShowingId(showingId);
                    if (seatReservations != null) {
                        foundShowing.SeatReservations = seatReservations;
                    } else {
                        foundToReturn = InternalServerError();
                        foundShowing = null;            // Failed to include reservations (seats)
                    }
                }
                if (foundShowing != null) {
                    foundToReturn = Ok(foundShowing);
                } else {
                    foundToReturn = NotFound();
                }
            } catch {
                foundToReturn = InternalServerError();
            }

            return foundToReturn;
        }

        [HttpGet]
        [Route("showing/{showingId}/reservations")]
        public IHttpActionResult GetShowingReservations(int showingId) {
            IHttpActionResult foundToReturn;
            List<SeatReservation> foundReservations;
            //
            DbAccessShowing dbAccShow = new DbAccessShowing();
            try {
                foundReservations = dbAccShow.GetSeatReservationByShowingId(showingId);
                if (foundReservations != null && foundReservations.Count > 0) {
                    foundToReturn = Ok(foundReservations);
                } else {
                    foundToReturn = NotFound();
                }
            } catch {
                foundToReturn = InternalServerError();
            }

            return foundToReturn;
        }

        [HttpPut, Route("showing/{showingId}/reservations")]
        public IHttpActionResult UpdateShowingReservations(int showingId, List<SeatReservation> newReservations) {
            IHttpActionResult foundToReturn;
            //
            DbAccessShowing dbAccShow = new DbAccessShowing();
            bool wasOk = true;
            try {
                wasOk = dbAccShow.UpdateShowingReservations(showingId, newReservations);
                if (wasOk) {
                    foundToReturn = Ok();
                } else {
                    foundToReturn = InternalServerError();
                }
            } catch {
                foundToReturn = InternalServerError();
            }
            return foundToReturn;
        }

    }
}
