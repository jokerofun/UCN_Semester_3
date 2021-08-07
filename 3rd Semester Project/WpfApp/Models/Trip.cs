using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Trip
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DeparturePlace { get; set; }
        [Required]
        public string ArrivalPlace { get; set; }
        [Required]
        [Display(Name = "DepartureDate")]
        [CheckDateRange]
        public System.DateTime DepartureDate { get; set; }
        [Required]
        [Display(Name = "ArrivalDate")]
        [GreaterThan("DepartureDate")]
        public System.DateTime ArrivalDate { get; set; }

        public string UserId { get; set; }

        public Trip(string name, string description, string departurePlace, string arrivalPlace, DateTime departureDate, DateTime arrivalDate)
        {
            Name = name;
            Description = description;
            DeparturePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        public Trip(int id, string name, string description, string departurePlace, string arrivalPlace, DateTime departureDate, DateTime arrivalDate, string userId)
        {
            ID = id;
            Name = name;
            Description = description;
            DeparturePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            UserId = userId;
        }
        public Trip()
        {
        }
    }
}
