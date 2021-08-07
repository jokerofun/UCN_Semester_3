using Foolproof;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CreateTripModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "DeparturePlace")]
        public string DeparturePlace { get; set; }
        [Required]
        [Display(Name = "ArrivalPlace")]
        public string ArrivalPlace { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [CheckDateRange]
        [Display(Name = "DepartureDate")]
        public System.DateTime DepartureDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [GreaterThan("DepartureDate")]
        [Display(Name = "ArrivalDate")]
        public System.DateTime ArrivalDate { get; set; }
        public string UserId { get; set; }
    }
}