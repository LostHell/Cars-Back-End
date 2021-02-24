using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.CarsViewModels.Inputs
{
    public class ExtraInputViewModel
    {
        [Required(ErrorMessage = "Name is Required!")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Name must be between 2 and 200 characters long!", MinimumLength = 2)]
        public string Name { get; set; }
    }
}