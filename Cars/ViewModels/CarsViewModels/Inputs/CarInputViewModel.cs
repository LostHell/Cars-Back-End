using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.CarsViewModels.Inputs
{
    public class CarInputViewModel
    {
        [Required(ErrorMessage = "Make is Required!")]
        [Display(Name = "Make")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Make must be between 2 and 100 characters long!", MinimumLength = 2)]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model is Required!")]
        [Display(Name = "Model")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Model must be between 2 and 200 characters long!", MinimumLength = 2)]
        public string Model { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(10000, ErrorMessage = "Description must be maximum 10 000 characters long!")]
        public string Description { get; set; }

        [Range(typeof(decimal), "0", "100000000")]
        public decimal Price { get; set; }

        [Required]
        public string UserId { get; set; }

        public  List<ExtraInputViewModel> Extras { get; set; }
        
        public  List<ImageInputViewModel> Images { get; set; }
    }
}