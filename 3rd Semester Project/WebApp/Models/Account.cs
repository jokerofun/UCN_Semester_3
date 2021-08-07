namespace WebApp.Models
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
}