using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Business;
using System.Data.Entity.Infrastructure;

namespace WebAPI.Controllers
{
    public class UserTicketController : ApiController
    {
        private UserTicketManagement userTicketManagement;

        public UserTicketController()
        {
            userTicketManagement = new UserTicketManagement();
        }
        //GET api/UserTicket/GetUserTickets
        /// <summary>
        /// Return all UserTickets in the database
        /// </summary>
        /// <returns>List of UserTickets</returns> 
        /// <response code ="200">The list of UserTickets was succesfully retrieved</response>
        /// <response code ="404">No UserTickets were found</response>
        /// <response code ="500">There was an error while retrieving UserTickets</response>
        public IHttpActionResult GetUserTickets()
        {
            try
            {
                var foundUserTickets = (List<UserTicket>)userTicketManagement.GetAllUserTickets();
                if (foundUserTickets == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(foundUserTickets);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        //GET api/UserTicket/GetUserTicketById
        /// <summary>
        /// Returns a UserTicket by its id
        /// </summary>
        /// <param name="id"> Id of searched UserTicket </param>
        /// <returns>UserTicket</returns> 
        /// <response code ="200">The UserTickets was succesfully retrieved</response>
        /// <response code ="404">UserTicket was not found</response>
        /// <response code ="500">There was an error while retrieving UserTicket</response>
        public IHttpActionResult GetUserTicketById(int id)
        {
            try
            {
                var foundUserTicket = userTicketManagement.GetUserTicketById(id);
                if(foundUserTicket == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(foundUserTicket);
                }
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        //GET api/UserTicket/Get/{userId}
        /// <summary>
        /// Returns all UseerTickets assigned to a user
        /// </summary>
        /// <param name="id">Id of the user to whom are UserTickets assigned</param>
        /// <returns>List of UserTicket</returns> 
        /// <response code ="200">The UserTickets were succesfully retrieved</response>
        /// <response code ="404">UserTickets were not found</response>
        /// <response code ="500">There was an error while retrieving UserTickets</response>
        public IHttpActionResult GetUserTicketsByUserId(string id)
        {
            try
            {
                var foundUserTickets = (List<UserTicket>)userTicketManagement.GetUserTicketsByUserId(id);
                if (foundUserTickets == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(foundUserTickets);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        // POST: api/UserTicket/PostUserTicket/{UserTicket}
        /// <summary>
        /// Inserts a list of UserTickets into the database
        /// </summary>
        /// <param name="userTickets">List of UserTickets</param>
        /// <response code ="200">The UserTickets were succesfully inserted</response>
        /// <response code ="400">Model state of UserTickets is invalid</response>
        /// <response code ="500">There was an error while inserting UserTickets</response>
        /// <response code ="409">Concurrency error occured while inserting tickets</response>
        public IHttpActionResult PostUserTickets(List<UserTicket> userTickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = userTicketManagement.BuyTickets(userTickets);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
        }
        //Put api/UserTicket/Deactivate/{userTicket}
        /// <summary>
        /// Marks UserTicket's parameter active as false
        /// </summary>
        /// <param name="userTicket">UserTicket</param>
        /// <returns>List of UserTicket</returns> 
        /// <response code ="200">The UserTickets were succesfully deactivated</response>
        /// <response code ="400">Model state of UserTicket is invalid</response>
        /// <response code ="500">There was an error while deactivating UserTickets</response>
        [ResponseType(typeof(Ticket))]
        [HttpPut]
        public IHttpActionResult DeactivateUserTicket(UserTicket userTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = userTicketManagement.DeactivateUserTicket(userTicket);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        //GET api/UserTicket/Remaining/{ticketId}
        /// <summary>
        /// Returns amount of remaining tickets
        /// </summary>
        /// <param name="id">Id of Ticket</param>
        /// <returns>int</returns> 
        /// <response code ="200">The amount of remaining tickets was successfuly retrieved</response>
        /// <response code ="500">There was an error while retrieving rhe amount</response>
        [HttpGet]
        public IHttpActionResult GetTicketsRemaining(int id)
        {
            int ticketsRemaining = userTicketManagement.GetTicketsRemaining(id);
            if (ticketsRemaining >= 0)
            {
                return Ok(ticketsRemaining);
            }
            else 
            {
                return InternalServerError();
            }
        }
        //GET api/UserTicket/Put
        /// <summary>
        /// Updates existing UserTicket with new data
        /// </summary>
        /// <param name="userTicket"></param>
        /// <response code ="200">UserTicket was successfuly updated</response>
        /// <response code ="400">Model state of UserTicket is invalid</response>
        /// <response code ="500">There was an error updating UserTicket</response>
        public IHttpActionResult Put(UserTicket userTicket)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = userTicketManagement.UpdateUserTicket(userTicket);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }

        }
    }
}
