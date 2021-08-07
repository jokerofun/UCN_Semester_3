using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Business;
using WebAPI.Models;
using WebAPI.DatabaseAccess;

namespace Tests
{
    /// <summary>
    /// Summary description for IntegrationTestUserTicket
    /// </summary>
    [TestClass]
    public class IntegrationTestUserTicket
    {

        private UserTicketManagement userTicketManagement;
        private TicketManagement ticketManagement;
        private TripManagement tripManagenemt;
        private TripDB tripDB = new TripDB();

        Trip trip1 = new Trip("Cool", "One", "Aalborg", "Aarhus", new DateTime(2021, 12, 10), new DateTime(2021, 12, 12), "9643f2db-5743-494d-891b-5d4faa8c4545");
        Ticket ticket1 = new Ticket("Test", "Description", 125m, 25, true, 1);
        Ticket ticket2 = new Ticket("Test2", "Description", 25m, 25, true, 1);
        Ticket ticket3 = new Ticket("Test3", "Description", 200m, 25, true, 1);
        Ticket ticket4 = new Ticket("Test4", "Description", 150m, 25, true, 1);
        Ticket ticket5 = new Ticket("Test5", "Description", 165m, 25, true, 1);
        UserTicket userTicket1 = new UserTicket("Alex","K. Stefan", 1, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
        UserTicket userTicket2 = new UserTicket("Alex", "K. Nicola", 2, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
        UserTicket userTicket3 = new UserTicket("Alex", "S George", 3, "9643f2db-5743-494d-891b-5d4faa8c4545", true);

        public IntegrationTestUserTicket()
        {
            userTicketManagement = new UserTicketManagement();
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
            List<UserTicket> userTickets = new List<UserTicket>();
            userTickets.Add(userTicket1);
            userTickets.Add(userTicket2);
            userTickets.Add(userTicket3);
            userTicketManagement.BuyTickets(userTickets);
        }
        
        [TestCleanup]
        public void TestCleanUp()
        {
            tripDB.ClearTestData();
        }
       
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAllUserTicketsTest()
        {
            IEnumerable<UserTicket> result = userTicketManagement.GetAllUserTickets();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUserTicketByIdTest()
        {
            UserTicket temp = userTicketManagement.GetUserTicketById(1);
            bool result;
            if(temp.FirstName == "Alex" && temp.LastName == "K. Stefan")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void buyUserTicketTest()
        {
            UserTicket TestUserTicket = new UserTicket("Alex", "N. Peter", 4, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            List<UserTicket> tempList = new List<UserTicket>();
            tempList.Add(TestUserTicket);
            userTicketManagement.BuyTickets(tempList);
            tempList = userTicketManagement.GetUserTicketsByUserId("9643f2db-5743-494d-891b-5d4faa8c4545");
            bool result = false;
            foreach(var item in tempList)
            {
                if(item.FirstName == "Alex" && item.LastName == "N. Peter" && item.TicketId == 4)
                {
                    result = true;
                }
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeactivateUserTicketTest()
        {
            userTicketManagement.DeactivateUserTicket(userTicket3);
            var temp = userTicketManagement.GetUserTicketById(3);
            bool result = (bool)temp.Active;
            Assert.IsFalse(result);
       }

        [TestMethod]
        public void UpdateUserTicketTest()
        {
            var initalFirstName = userTicket3.FirstName;
            UserTicket newUserTicket = new UserTicket("George", "K. Stefan", 1, "9643f2db-5743-494d-891b-5d4faa8c4545", true);
            newUserTicket.Id = userTicket3.Id;
            userTicketManagement.UpdateUserTicket(newUserTicket);
            var result  = userTicketManagement.GetUserTicketById(newUserTicket.Id);
            Assert.AreNotEqual(initalFirstName, result.FirstName);
        }

    }
}
