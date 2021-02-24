using AutoMapper;
using Cars.Data.Models;
using Cars.ViewModels.CarsViewModels.Inputs;
using Cars.ViewModels.CarsViewModels.Outputs;
using Cars.ViewModels.UserViewModels.Inputs;
using Cars.ViewModels.UserViewModels.Outputs;

namespace Cars.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<LoginInputViewModel, ApplicationUser>();

            CreateMap<RegisterInputViewModel, ApplicationUser>();

            CreateMap<ApplicationUser, UserOutputViewModel>();

            CreateMap<CarInputViewModel, Car>();

            CreateMap<Car, CarOutputViewModel>();

            CreateMap<Extra, ExtraOutputViewModel>();

            CreateMap<Image, ImageOutputViewModel>();
        }
    }
}