using System;
using System.Collections.Generic;

namespace MovieExperienceDb.Model {

    public class Showing {

        public int ShowingId { get; set; }
        public string Title { get; set; }
        public string Room { get; set; }
        public DateTime ShowTime { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }

        public Showing() { }

    }
}
