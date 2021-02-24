using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.UserViewModels.Inputs    
{
    public class RegisterInputViewModel
    {
        [Required(ErrorMessage = "Username is Required!")]
        [StringLength(100, ErrorMessage = "Username must be between 6 and 100 characters long!", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(100, ErrorMessage = "Name must be between 3 and 100 characters long!", MinimumLength = 3)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Phone number is Required!")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "Phone must be between 3 and 20 characters long!", MinimumLength = 3)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address number is Required!")] 
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Address must be between 3 and 200 characters long!", MinimumLength = 3)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City number is Required!")] 
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "City must be between 3 and 200 characters long!", MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage = "Email address is Required!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(200, ErrorMessage = "Email must be between 5 and 200 characters long!", MinimumLength = 5)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required!")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password must be between 6 and 50 characters long!", MinimumLength = 6)]
        public string Password { get; set; }

        /*
          [Required(ErrorMessage = "Repeat Password is Required.")]
          [Display(Name = "Repeat password")]
          [DataType(DataType.Password)]
          [Compare("Password", ErrorMessage = "Passwords mismatch!")]
         */
        /*
        public string RepeatPassword { get; set; }
        */
    }
}