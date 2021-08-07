using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieExperienceMvc.Models {

    public class SeatReservation {

        public int ShowingId { get; set; }
        public int SeatRow { get; set; }
        public int SeatNo { get; set; }
        public bool Reserved { get; set; }
        public DateTime ChangeDate { get; set; }

        public SeatReservation() { }

        public SeatReservation(int showingId, int seatRow, int seatNo, bool reserved, DateTime changeDate) {
            ShowingId = showingId;
            SeatRow = seatRow;
            SeatNo = seatNo;
            Reserved = reserved;
            ChangeDate = changeDate;
        }

        public int GetReservedValue() {
            int resAsInt = Convert.ToInt32(Reserved);
            return resAsInt;
        }
    }

}