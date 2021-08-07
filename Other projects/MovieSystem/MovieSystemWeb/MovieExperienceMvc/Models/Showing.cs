using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieExperienceMvc.Models {
    public class Showing {

        public int ShowingId { get; set; }
        public string Title { get; set; }
        public string Room { get; set; }
        public DateTime ShowTime { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }

        public List<int> GetRoomRows() {
            List<int> roomRows = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            return roomRows;
         }

        public List<SeatReservation> GetSeatResRow(int targetRow) {
            List<SeatReservation> SeatsInRow = new List<SeatReservation>();
            foreach(SeatReservation sr in SeatReservations) {
                if (sr.SeatRow == targetRow) {
                    SeatsInRow.Add(sr);
                }
            }
            return SeatsInRow;
        }

    }

}