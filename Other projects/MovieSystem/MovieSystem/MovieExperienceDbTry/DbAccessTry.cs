using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieExperienceDb.Model;
using MovieExperienceDb.Data;

namespace MovieSystem {
    public class DbAccessTry {

        static void Main() {

            DbAccessShowing showingData = new DbAccessShowing();
            int showingId = 1;

            // Get showing  
            Showing foundShowing = showingData.GetShowingById(showingId);
            if (foundShowing != null) {
                string auctionText = $"{foundShowing.ShowingId} - {foundShowing.Title} - {foundShowing.Room} - {foundShowing.ShowTime}";
                Console.WriteLine("Before" + Environment.NewLine + auctionText);
            }

            Console.WriteLine();

            // Get showings reservations
            List<SeatReservation> foundReservations = showingData.GetSeatReservationByShowingId(showingId);
            string tempRes;
            if (foundReservations != null) {
                foreach(SeatReservation sr in foundReservations) {
                    tempRes = $"{sr.ShowingId} - {sr.SeatRow} - {sr.SeatNo} - {sr.Reserved} - {sr.ChangeDate}";
                    Console.WriteLine(tempRes);
                }
            }

            // Update 
            // Choose seat currently not reserved
            SeatReservation aSeatRes = new SeatReservation() {
                ShowingId = showingId,
                SeatRow = 7,
                SeatNo = 7,
                Reserved = true,
                ChangeDate = DateTime.Now
            };
            List<SeatReservation> seatResList = new List<SeatReservation>() { aSeatRes };
            bool updatedOk = showingData.UpdateShowingReservations(showingId, seatResList);
            Console.WriteLine("Reservation completed " + updatedOk);
            updatedOk = showingData.UpdateShowingReservations(showingId, seatResList);     // Should fail
            Console.WriteLine("Reservation completed " + updatedOk);
            Console.ReadKey();
        }

    }
}
