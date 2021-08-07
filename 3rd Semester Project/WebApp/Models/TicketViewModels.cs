using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CreateTicketModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "TicketName")]
        public string TicketName { get; set; }
        [Required]
        [Display(Name = "TicketDescription")]
        public string TicketDescription { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "MaxTickets")]
        public int MaxTickets { get; set; }
        [Required]
        [Display(Name = "TicketsRemaining")]
        public int TicketsRemaining { get; set; }
        [Required]
        [Display(Name = "TripId")]
        public int TripId { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}