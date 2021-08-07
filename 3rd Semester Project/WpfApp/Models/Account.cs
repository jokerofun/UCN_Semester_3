using System.ComponentModel.DataAnnotations;

namespace WpfApp.Models
{
    public class RegisterAccountModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsBusiness { get; set; }

        public RegisterAccountModel(string email, string password, string confirmPassword, bool isBusiness)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            IsBusiness = isBusiness;
        }
        public RegisterAccountModel()
        {

        }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public LoginViewModel()
        {

        }
    }

}