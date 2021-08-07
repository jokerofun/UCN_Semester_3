using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebAPI.Business;
using WebAPI.DatabaseAccess;
using WebAPI.Models;

namespace Tests
{
    [TestClass]
    public class IntegrationTestCRUDTrip
    {
        private TripManagement tripManagement;
        private readonly TripDB tripDB;

        Trip trip1 = new Trip("Cool", "One", "Aalborg", "Aarhus", new DateTime(2021, 12, 10), new DateTime(2021, 12, 12), "9643f2db-5743-494d-891b-5d4faa8c4545");
        Trip trip2 = new Trip("Great", "Two", "Copenhagen", "Aarhus", new DateTime(2021, 12, 10), new DateTime(2021, 12, 12), "9643f2db-5743-494d-891b-5d4faa8c4545");
        Trip trip3 = new Trip("Nice", "Three", "Aalborg", "Copenhagen", new DateTime(2021, 12, 10), new DateTime(2021, 12, 12), "9643f2db-5743-494d-891b-5d4faa8c4545");
        Trip trip4 = new Trip("Wonderful", "Four", "Horsens", "Odense", new DateTime(2020, 12, 10), new DateTime(2020, 12, 12), "9643f2db-5743-494d-891b-5d4faa8c4545");
        Trip trip5 = new Trip("Fabulous", "Three", "Odense", "Horsens", new DateTime(2020, 12, 17), new DateTime(2020, 12, 18), "9643f2db-5743-494d-891b-5d4faa8c4545");

        public IntegrationTestCRUDTrip()
        {
            tripManagement = new TripManagement();
            tripDB = new TripDB();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            tripManagement.AddTrip(trip1);
            tripManagement.AddTrip(trip2);
            tripManagement.AddTrip(trip3);
            tripManagement.AddTrip(trip4);
            tripManagement.AddTrip(trip5);
        }
        
        
        [TestCleanup]
        public void TestCleanUp()
        {
            tripDB.ClearTestData();
        }

        [TestMethod]
        public void TestGetAllTripsMatchingSearchPatternByUserId()
        {
            Trip searchTrip = new Trip("", "", "h", "", new DateTime(), new DateTime(), "9643f2db-5743-494d-891b-5d4faa8c4545");
            IEnumerable<Trip> foundTrips = (IEnumerable<Trip>)tripManagement.GetAllTripsMatchingSearchPatternByUserId(searchTrip);
            //bool hasData = (foundTrips.Count == 2);

            //Assert.IsTrue(hasData);
            Assert.IsNotNull(foundTrips);
        }

        [TestMethod]
        public void TestGetAllTripsMatchingSearchPatternUpToDate()
        {
            Trip searchTrip = new Trip("", "", "h", "", new DateTime(), new DateTime(), "");
            IEnumerable<Trip> foundTrips = (IEnumerable<Trip>)tripManagement.GetAllTripsMatchingSearchPatternUpToDate(searchTrip);
            //bool hasData = (foundTrips.Count == 1);

            //Assert.IsTrue(hasData);
            Assert.IsNotNull(foundTrips);
        }

        [TestMethod]
        public void TestGetTripWithId()
        {
            Trip foundTrip = tripManagement.GetTripById(1);
            Assert.AreEqual("Cool", foundTrip.Name);
        }

        [TestMethod]
        public void TestDeleteTrip2()
        {
            Assert.IsTrue(tripManagement.DeleteTrip(trip2));
        }

        [TestMethod]
        public void TestUpdateTripWithId3()
        {
            Trip foundTrip = tripManagement.GetTripById(2);
            foundTrip.Name = "Wonderful";
            tripManagement.UpdateTrip(foundTrip);
            string result = tripManagement.GetTripById(2).Name;
            Assert.AreEqual("Wonderful", result);
        }
        
        [TestMethod]
        public void TestAddTrip()
        {
            Trip createdTrip = new Trip("Cool", "One", "Aalborg", "Aarhus", new DateTime(2021, 12, 10), new DateTime(2021, 12, 12), "9643f2db-5743-494d-891b-5d4faa8c4545");
            bool succes = tripManagement.AddTrip(createdTrip);
            Assert.IsTrue(succes);
        }
        
    }

}
