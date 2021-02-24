using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.UserViewModels.Inputs
{
    public class LoginInputViewModel
    {
        [Required(ErrorMessage = "Username is Required!")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Username must be between 6 and 100 characters long!", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required!")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password must be between 6 and 50 characters long!", MinimumLength = 6)]
        public string Password { get; set; }
    }
}