using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CreateShopingTicketsViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "TicketName")]
        public string TicketName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Display(Name = "AmountBought")]
        public Nullable<int> AmountBought { get; set; }

        [Required]
        [Display(Name = "TripId")]
        public Nullable<int> TripId { get; set; }
    }
}