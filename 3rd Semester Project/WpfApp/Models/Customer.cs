using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Customer
    {
        //[Unqiue(ErrorMessage = "Duplicate Id. Id already exists")]
        [Required(ErrorMessage = "Id is Required")]
        public int Id{ get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Name exceeded 50 letters")]
        //[ExcludeChar("/.,!@#$%", ErrorMessage = "Name contains invalid letters")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Age should be between 1 to 100")]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email Address is Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Repeat Email address is required")]
        [Compare("Email", ErrorMessage = "Email Address does not match")]
        public string RepeatEmail { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
