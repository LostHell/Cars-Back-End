using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.UserViewModels.Inputs
{
    public class ChangePasswordInputViewModel
    {
        [Required(ErrorMessage = "Old Password is Required!")]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Old Password must be between 6 and 50 characters long!", MinimumLength = 6)]
        public string OldPassword { get; set; }
        
        [Required(ErrorMessage = "New Password is Required!")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "New Password must be between 6 and 50 characters long!", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Repeat New Password is Required!")]
        [Display(Name = "Repeat New password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords mismatch!")]
        public string RepeatNewPassword { get; set; }
    }
}