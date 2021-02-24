using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.UserViewModels.Inputs
{
    public class ChangePhoneInputViewModel
    {
        [Required(ErrorMessage = "Old Phone number is Required!")]
        [Display(Name = "Old Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "Old Phone number must be between 3 and 20 characters long!", MinimumLength = 3)]
        public string OldPhone { get; set; }

        [Required(ErrorMessage = "New Phone number is Required!")]
        [Display(Name = "New Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "New Phone number must be between 3 and 20 characters long!", MinimumLength = 3)]
        public string NewPhone { get; set; }
    }
}