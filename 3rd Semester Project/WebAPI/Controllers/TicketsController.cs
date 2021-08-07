using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Business;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TicketsController : ApiController
    {
        private TicketManagement ticketManagement;

        public TicketsController()
        {
            ticketManagement = new TicketManagement();
        }

        //GET api/Tickets
        /// <summary>
        /// Returns a list of all Tickets
        /// </summary>
        /// <returns>List of Tickets</returns> 
        /// <response code ="200">Tickets were succesfully retrieved</response>
        /// <response code ="404">No Tickets found</response>
        /// <response code ="500">There was an error while retrieving Tickets</response>
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Ticket> foundTickets = ticketManagement.GetAllTickets();
                if (foundTickets == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(foundTickets);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //GET api/Tickets
        /// <summary>
        /// Returns a list of all active Tickets
        /// </summary>
        /// <returns>List of active Tickets</returns> 
        /// <response code ="200">Tickets were succesfully retrieved</response>
        /// <response code ="404">No active Tickets found</response>
        /// <response code ="500">There was an error while retrieving active Tickets</response>
        public IHttpActionResult GetActive()
        {
            try
            {
                IEnumerable<Ticket> foundTickets = ticketManagement.GetActiveTickets();
                if (foundTickets == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(foundTickets);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //GET api/Tickets/{id}
        /// <summary>
        /// Returns a Ticket with specific id
        /// </summary>
        /// <param name="id"> Id of searched Ticket </param>
        /// <returns>Ticket</returns> 
        /// <response code ="200">Ticket was succesfully retrieved</response>
        /// <response code ="404">Ticket was not found</response>
        /// <response code ="500">There was an error while retrieving Ticket</response>
        [ResponseType(typeof(Ticket))]
        public IHttpActionResult GetTicketById(int id)
        {
            try
            {
                Ticket ticket = ticketManagement.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //GET api/Tickets/{name}
        /// <summary>
        /// Returns a Ticket with specific name
        /// </summary>
        /// <param name="name"> Name of searched Ticket </param>
        /// <returns>Ticket</returns> 
        /// <response code ="200">Ticket was succesfully retrieved</response>
        /// <response code ="404">Ticket was not found</response>
        /// <response code ="500">There was an error while retrieving Ticket</response>
        [ResponseType(typeof(Ticket))]
        public IHttpActionResult GetTicketByName(String name)
        {
            try
            {
                Ticket ticket = ticketManagement.GetTicketByName(name);
                if (ticket == null)
                {
                    return NotFound();
                }

                return Ok(ticket);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //GET: api/Tickets/{id}
        /// <summary>
        /// Returns a Ticket tied to specific trip
        /// </summary>
        /// <param name="id"> Id of cruise with tied Tickets </param>
        /// <returns>List of Tickets</returns> 
        /// <response code ="200">Tickets were succesfully retrieved</response>
        /// <response code ="404">No tickets were found</response>
        /// <response code ="500">There was an error while retrieving Tickets</response>
        [ResponseType(typeof(List<Ticket>))]
        public IHttpActionResult GetTicketsByTripId(int id)
        {
            try
            {
                var ticket = (List<Ticket>)ticketManagement.GetTicketsByTripId(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // POST: api/Tickets/PostTicket/{Ticket}
        /// <summary>
        /// Creates new ticket in the database
        /// </summary>
        /// <param name="ticket"> Ticket to create </param>
        /// <response code ="200">Ticket was succesfully added to the database</response>
        /// <response code ="400">Model state of Ticket is invalid</response>
        /// <response code ="500">There was an error while adding Ticket</response>
        public IHttpActionResult PostTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = ticketManagement.AddTicket(ticket);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT: api/Tickets/{id}
        /// <summary>
        /// Updates existing ticket in the database
        /// </summary>
        /// <param name="ticket"> Ticket to update </param>
        /// <response code ="200">Ticket was succesfully updated in the database</response>
        /// <response code ="400">Model state of Ticket is invalid</response>
        /// <response code ="500">There was an error while updating Ticket</response>
        public IHttpActionResult PutTicket(Ticket ticket)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = ticketManagement.UpdateTicket(ticket);
            if (result)
                return Ok();
            else
                return InternalServerError();


        }

        // DELETE: api/Tickets/Delete/{Ticket}
        /// <summary>
        /// Deletes existing ticket in the database
        /// </summary>
        /// <param name="ticket"> Ticket to delete </param>
        /// <response code ="200">Ticket was succesfully deleted in the database</response>
        /// <response code ="400">Model state of Ticket is invalid</response>
        /// <response code ="500">There was an error while deleting Ticket</response>
        public IHttpActionResult DeleteTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = ticketManagement.DeleteTicket(ticket);
            if (result)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT: api/Tickets/Deactivate/{Ticket}
        /// <summary>
        /// Marks existing ticket as inactive
        /// </summary>
        /// <param name="ticket"> Ticket to deactivate </param>
        /// <response code ="200">Ticket was succesfully deactivated</response>
        /// <response code ="400">Model state of Ticket is invalid</response>
        /// <response code ="500">There was an error while deactivating Ticket</response>
        [HttpPut]
        public IHttpActionResult DeactivateTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = ticketManagement.DeactivateTicket(ticket);
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

