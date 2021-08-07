using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MovieExperienceMvc.Models;
using MovieExperienceMvc.ServiceLayer;

namespace MovieExperienceMvc.BusinessLayer {
    public class ShowingAccessControl {

        public async Task<Showing> GetShowingById(int showingId, bool includeSeatReservations) {
            Showing retrievedShowing; 
            AccessMovieExperienceApi accApi = new AccessMovieExperienceApi();
            
            try {
                retrievedShowing = await accApi.GetShowing(showingId, includeSeatReservations);
            } catch (Exception) {
                retrievedShowing = null;
            }
            return retrievedShowing;
        }

        public async Task<bool> UpdateShowingReservations(int showingId, string changedSeatRes) {
            bool wasUpdatedOk = false;
            AccessMovieExperienceApi accApi = new AccessMovieExperienceApi();

            List<SeatReservation> newReservations = GetSeatReservations(showingId, changedSeatRes);
            try {
                wasUpdatedOk = await accApi.UpdateReservations(showingId, newReservations);
            } catch (Exception) {
                wasUpdatedOk = false;
            }
            return wasUpdatedOk;
        }

        private List<SeatReservation> GetSeatReservations(int showingId, string resString) {
            List<SeatReservation> seatRes = null;
            SeatReservation tempRes;
            int tempSeatId, rowNo, seatNo;
            bool parseOk;

            if (!string.IsNullOrWhiteSpace(resString)) {
                seatRes = new List<SeatReservation>();
                DateTime resTime = DateTime.Now;
                bool reserve = true;
                string[] seatIds = resString.Split(':');
                foreach(string seatId in seatIds) {
                    parseOk = int.TryParse(seatId, out tempSeatId);
                    if (parseOk) {
                        rowNo = tempSeatId / 1000;
                        seatNo = tempSeatId - (rowNo * 1000);
                        tempRes = new SeatReservation(showingId, rowNo, seatNo, reserve, resTime);
                        seatRes.Add(tempRes);
                    }
                }
            }
            return seatRes;
        }

    }
}