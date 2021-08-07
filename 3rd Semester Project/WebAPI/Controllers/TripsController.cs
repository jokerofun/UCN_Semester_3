using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Business;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TripsController : ApiController
    {

        private TripManagement tripManagement;

        public TripsController()
        {
            tripManagement = new TripManagement();
        }

        // POST: api/Trips/GetMatchingTripsByUserId
        /// <summary>
        /// Returns a list of trips that are matching specific pattern tied to user by their id
        /// </summary>
        /// <param name="trip"> Trip with searched pattern and user id </param>
        /// <returns>Trip</returns> 
        /// <response code ="200">Trips were succesfully retrieved</response>
        /// <response code ="404">Trips not found</response>
        /// <response code ="500">There was an error while retrieving Trips</response>
        [HttpPost]
        public IHttpActionResult GetMatchingTripsByUserId(Trip trip)
        {
            try
            {
                IEnumerable<Trip> foundTrips = tripManagement.GetAllTripsMatchingSearchPatternByUserId(trip);
                if (foundTrips == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(foundTrips);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // POST: api/Trips/GetMatchingTripsUpToDate
        /// <summary>
        /// Returns a list of trips that are matching specific pattern and up to date
        /// </summary>
        /// <param name="trip"> Trip with searched pattern</param>
        /// <returns>Trip</returns> 
        /// <response code ="200">Trips were succesfully retrieved</response>
        /// <response code ="404">Trips not found</response>
        /// <response code ="500">There was an error while retrieving Trips</response>
        [HttpPost]
        public IHttpActionResult GetMatchingTripsUpToDate(Trip trip)
        {
            try
            {
                IEnumerable<Trip> foundTrips = tripManagement.GetAllTripsMatchingSearchPatternUpToDate(trip);
                if (foundTrips == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(foundTrips);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/Trips/{id}
        /// <summary>
        /// Returns a Trip with specific id
        /// </summary>
        /// <param name="id"> Id of searched Trip </param>
        /// <returns>Trip</returns> 
        /// <response code ="200">Trip was succesfully retrieved</response>
        /// <response code ="404">Trip not found</response>
        /// <response code ="500">There was an error while retrieving Trip</response>
        public IHttpActionResult GetTripById(int id)
        {
            try
            {
                Trip trip = tripManagement.GetTripById(id);
                if (trip == null)
                {
                    return NotFound();
                }

                return Ok(trip);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // POST: api/Trips/{trip}
        /// <summary>
        /// Creates new trip in the database
        /// </summary>
        /// <param name="trip"> Trip to create </param>
        /// <response code ="200">Trip was succesfully created</response>
        /// <response code ="400">Model state of Trip is invalid</response>
        /// <response code ="500">There was an error while creating Trip</response>
        public IHttpActionResult PostTrip(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = tripManagement.AddTrip(trip);
            if (result)
            {
                return Ok();
            }

            else
            {
                return InternalServerError();
            }
        }

        // PUT: api/Trips/{trip}
        /// <summary>
        /// Updates existing trip in the database
        /// </summary>
        /// <param name="trip"> Trip to update </param>
        /// <response code ="200">Trip was succesfully updated</response>
        /// <response code ="400">Model state of Trip is invalid</response>
        /// <response code ="500">There was an error while updating Trip</response>
        public IHttpActionResult PutTrip(Trip trip)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = tripManagement.UpdateTrip(trip);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }

        }

        // DELETE: api/Trips/{trip}
        /// <summary>
        /// Deletes existing trip in the database
        /// </summary>
        /// <param name="trip"> Trip to delete </param>
        /// <response code ="200">Trip was succesfully deleted</response>
        /// <response code ="500">There was an error while deleting Trip</response>
        [ResponseType(typeof(Trip))]
        public IHttpActionResult DeleteTrip(Trip trip)
        {
            bool result = tripManagement.DeleteTrip(trip);
            if (result)
            {
                return Ok(trip);
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
