using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.UserViewModels.Inputs
{
    public class ResetPasswordInputViewModel
    {
        [Required(ErrorMessage = "Username is Required!")]
        [StringLength(100, ErrorMessage = "Username must be between 6 and 100 characters long!", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is Required!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(200, ErrorMessage = "Email must be between 5 and 200 characters long!", MinimumLength = 5)]
        public string Email { get; set; }

        [Required(ErrorMessage = "New Password is Required!")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "New Password must be between 6 and 50 characters long!", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}