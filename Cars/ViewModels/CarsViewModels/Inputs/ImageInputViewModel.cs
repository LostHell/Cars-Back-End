using System.ComponentModel.DataAnnotations;


namespace Cars.ViewModels.CarsViewModels.Inputs
{
    public class ImageInputViewModel
    {
        [Required] public string ImageSrc { get; set; }
    }
}