namespace WebApp.Models
{
    using Foolproof;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Trip
    {
        public Trip()
        { 
        }

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
        [DataType(DataType.DateTime)]
        [CheckDateRange]
        public System.DateTime DepartureDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [GreaterThan("DepartureDate")]
        public System.DateTime ArrivalDate { get; set; }
        [Required]
        public string UserId { get; set; }


        public Trip(string name, string description, string departurePlace, string arrivalPlace, DateTime departureDate, DateTime arrivalDate, string userId)
        {
            Name = name;
            Description = description;
            DeparturePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            UserId = userId;
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
    }
}