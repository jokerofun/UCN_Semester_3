using System;
using System.Collections.Generic;
using MovieExperienceDb.Model;

namespace MovieExperienceDb.Data {

    public interface IAccessShowing {

        Showing GetShowingById(int showingId);

        List<SeatReservation> GetSeatReservationByShowingId(int showingId);

        bool UpdateShowingReservations(int showingId, List<SeatReservation> updateReservations);

    }

}
