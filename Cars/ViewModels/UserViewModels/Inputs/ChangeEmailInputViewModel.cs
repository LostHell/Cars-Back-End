using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.UserViewModels.Inputs
{
    public class ChangeEmailInputViewModel
    {
        [Required(ErrorMessage = "Old Email address is Required!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(200, ErrorMessage = "Old Email must be between 5 and 200 characters long!", MinimumLength = 5)]
        public string OldEmail { get; set; }

        [Required(ErrorMessage = "New Email address is Required!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(200, ErrorMessage = "New Email must be between 5 and 200 characters long!", MinimumLength = 5)]
        public string NewEmail { get; set; }
    }
}