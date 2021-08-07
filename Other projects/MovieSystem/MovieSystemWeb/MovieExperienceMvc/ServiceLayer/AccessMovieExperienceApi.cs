using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using MovieExperienceMvc.Models;

namespace MovieExperienceMvc.ServiceLayer {
    public class AccessMovieExperienceApi {

        readonly string restUrl = "https://localhost:44392/api/movie";
        readonly HttpClient _client;

        public AccessMovieExperienceApi() {
            _client = new HttpClient();
        }

        // https://localhost:44392/api/movie/showing/1/?includeReservations=false

        public async Task<Showing> GetShowing(int showingId, bool includeSeatReservations) {
            Showing retrievedShowing;

            // Create URI
            string useRestUrl = restUrl + $"/showing/{showingId}/?includeReservations={includeSeatReservations}";
            var uri = new Uri(string.Format(useRestUrl));

            //
            try {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    retrievedShowing = JsonConvert.DeserializeObject<Showing>(content);
                } else {
                    throw (new Exception());
                }
            } catch {
                throw;
            }
            return retrievedShowing;
        }


        public async Task<bool> UpdateReservations(int showingId, List<SeatReservation> newReservations) {
            bool changedOk;

            string useRestUrl = null;
            string jsonString = null;
            HttpResponseMessage response = null;

                useRestUrl = restUrl + $"/showing/{showingId}/reservations";

            try {
                var uri = new Uri(string.Format(useRestUrl, string.Empty));
                jsonString = JsonConvert.SerializeObject(newReservations);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode) {
                    changedOk = true;
                } else {
                    changedOk = false;
                }
            } catch {
                changedOk = false;
            }

            return changedOk;
        }

    }
}