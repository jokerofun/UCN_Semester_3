using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebAPI.Business;
using WebAPI.Models;
using WebAPI.DatabaseAccess;

namespace Tests
{
    [TestClass]
    public class IntegrationTestTicket
    {
        private TicketManagement ticketManagement;
        private TripManagement tripManagenemt;
        private TripDB tripDB = new TripDB();

        Trip trip1 = new Trip("Cool", "One", "Aalborg", "Aarhus", new DateTime(2021, 12, 10), new DateTime(2021, 12, 12), "9643f2db-5743-494d-891b-5d4faa8c4545");
        Ticket ticket1 = new Ticket("Test", "Description", 125m, 25,true,1);
        Ticket ticket2 = new Ticket("Test2", "Description", 25m, 25, true, 1);
        Ticket ticket3 = new Ticket("Test3", "Description", 200m, 25, true, 1);
        Ticket ticket4 = new Ticket("Test4", "Description", 150m, 25, true, 1);
        Ticket ticket5 = new Ticket("Test5", "Description", 165m, 25, true, 1);


        public IntegrationTestTicket()
        {
            ticketManagement = new TicketManagement();
            tripManagenemt = new TripManagement();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            tripManagenemt.AddTrip(trip1);
            ticketManagement.AddTicket(ticket1);
            ticketManagement.AddTicket(ticket2);
            ticketManagement.AddTicket(ticket3);
            ticketManagement.AddTicket(ticket4);
            ticketManagement.AddTicket(ticket5);
        }
        
        [TestCleanup]
        public void TestCleanUp()
        {
            tripDB.ClearTestData();
        }
        

        [TestMethod]
        public void TestGetAllTickets()
        {
            List<Ticket> ticketList = (List<Ticket>)ticketManagement.GetAllTickets();
            bool result = (ticketList.Count > 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetTicketById()
        {
            var result = (Ticket)ticketManagement.GetTicketById(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetTicketByName()
        {
            string name = "Test2";
            var result = (Ticket)ticketManagement.GetTicketByName(name);
            Assert.IsNotNull(result);
        }

        
        [TestMethod]
        public void TestUpdateTicket()
        {
            var temp  = ticketManagement.GetTicketByName("Test2");
            Ticket newTicket = new Ticket("Alex", "Description", 125m, 25, true, 1);
            newTicket.Id = temp.Id;
            ticketManagement.UpdateTicket(newTicket);
            var result = (Ticket)ticketManagement.GetTicketById(temp.Id);
            Assert.AreNotEqual(temp, result);
        }
        

        [TestMethod]
        public void TestInsertTicket()
        {
            Ticket temp = new Ticket("AddTest", "Description", 125m, 25, true, 1);
            ticketManagement.AddTicket(temp);
            Ticket result = ticketManagement.GetTicketByName("AddTest");
            Console.WriteLine(result.TicketName);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDeletTicket()
        {
            Ticket temp = new Ticket("DeleteTest", "Description", 125m, 25, true, 1);
            ticketManagement.AddTicket(temp);
            var result = ticketManagement.GetTicketByName("DeleteTest");
            ticketManagement.DeleteTicket(result);
            Ticket deletedTicket = ticketManagement.GetTicketById(result.Id);
            Assert.IsNull(deletedTicket);
        }

      /*
        [TestMethod]
        public void Test()
        {
            CruiseManagement cruiseManagement = new CruiseManagement();
            Cruise cruise = cruiseManagement.GetCruiseById(1);
            Ticket ticket = new Ticket();
            ticket.TicketName = "Test";
            ticket.Price = 10m;
            ticket.MaxTickets = 15;
            //ticket.Cruise = cruise;
            ticket.CruiseId = cruise.ID;

            Console.WriteLine("Cruise ID:");
            Console.WriteLine(cruise.ID);
            Console.WriteLine("Ticket Cruise:");
            Console.WriteLine(ticket.Cruise);
            Console.WriteLine("Ticket CruiseId:");
            Console.WriteLine(ticket.CruiseId);


            ticketManagement.AddTicket(ticket);
        }
        */
        //[TestMethod]
        //public void TestUserTicket()
        //{
        //    TripManagement tripManagement = new TripManagement();
        //    Trip trip = tripManagement.GetTripById(25);
        //    Ticket ticket = new Ticket();
        //    ticket.TicketName = "Test1";
        //    ticket.Price = 10m;
        //    ticket.MaxTickets = 15;
        //    ticket.TripId = trip.ID;

        //    ticketManagement.AddTicket(ticket);

        //    var result = (Ticket)ticketManagement.GetTicketByName("Test1");
        //    UserTicket userTicket = new UserTicket("ec840eb2-9bd7-4415-8665-3c82c67d451e", result.Id, result.TicketName, result.Price, 4, result.TripId);


        //    UserTicketManagement userTicketManagement = new UserTicketManagement();
        //    userTicketManagement.AddUserTicket(userTicket);
        //}

    }
}
