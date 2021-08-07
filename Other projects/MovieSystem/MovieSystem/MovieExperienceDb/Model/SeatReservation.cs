using System;

namespace MovieExperienceDb.Model {

    public class SeatReservation {

        public int ShowingId { get; set; }
        public int SeatRow { get; set; }
        public int SeatNo { get; set; }
        public bool Reserved { get; set; }
        public DateTime ChangeDate { get; set; }

        public SeatReservation() { }

    }
}
