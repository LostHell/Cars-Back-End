using System.Collections.Generic;
using System.Threading.Tasks;
using Cars.ViewModels.CarsViewModels.Inputs;
using Cars.ViewModels.CarsViewModels.Outputs;

namespace Cars.Services.CarServices
{
    public interface ICarService
    {
        Task<IList<CarOutputViewModel>> GetAllCars();

        Task<CarOutputViewModel> GetCarById(string carId);

        Task<IList<CarOutputViewModel>> GetOwnCars(string userId);

        Task<CarOutputViewModel> CreateNewCar(CarInputViewModel car, string userId);

        Task<CarOutputViewModel> EditCar(string carId, CarInputViewModel car);

        Task<CarOutputViewModel> RemoveCar(string carId);
    }
}