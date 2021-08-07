using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using MovieExperienceDb.Model;

namespace MovieExperienceDb.Data {

    // Access DB using Dapper
    public class DbAccessShowing : IAccessShowing {

        private readonly string _connectionString;

        public DbAccessShowing() {
            _connectionString = ConfigurationManager.ConnectionStrings["MovieExperienceConnection"].ConnectionString;
        }

         //Get Showing by id
        public Showing GetShowingById(int showingNo) {
            string sqlSelectOne = "SELECT Title, Room, showTime, ShowingId FROM Showing WHERE ShowingId = @ShowingId";
            Showing foundShowing = null;
            using (SqlConnection movieConnection = new SqlConnection(_connectionString))
                // Dapper used - with parameter list
                foundShowing = movieConnection.QueryFirstOrDefault<Showing>(sqlSelectOne, new { ShowingId = showingNo });
            return foundShowing;
        }

        public List<SeatReservation> GetSeatReservationByShowingId(int showingNo) {
            string sqlSelectOne = "SELECT showing_id, seatRow, seatNo, reserved, changeDate FROM SeatReservation WHERE showing_id = @ShowingId";
            List<SeatReservation> foundReservations = null;
            using (SqlConnection movieConnection = new SqlConnection(_connectionString))
                // Dapper used - with parameter list
                foundReservations = movieConnection.Query<SeatReservation>(sqlSelectOne, new { ShowingId = showingNo }).ToList();
            return foundReservations;

        }

        // Consider applying a transaction
        public bool UpdateShowingReservations(int showingId, List<SeatReservation> newReservations) {
            int numRowsUpdated = 0;
            int numReservations = (newReservations != null) ? newReservations.Count : -1;
            string sqlUpdate = "UPDATE SeatReservation set reserved = 1, changeDate = @ResDate WHERE reserved = 0 AND showing_id = @ShowingId AND seatRow = @SeatRow AND seatNo = @SeatNo";

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                foreach (SeatReservation sr in newReservations) {
                    // Dapper used - with parameter list
                    numRowsUpdated += connection.Execute(sqlUpdate,
                            new {
                                ResDate = sr.ChangeDate,
                                ShowingId = showingId,
                                SeatRow = sr.SeatRow,
                                SeatNo = sr.SeatNo
                            });
                }
            }
            return (numRowsUpdated == numReservations);     // All reservations must be saved ok
        }

    }
}
