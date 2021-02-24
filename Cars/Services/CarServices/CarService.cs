using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Data;
using Cars.Data.Models;
using Cars.ViewModels.CarsViewModels.Inputs;
using Cars.ViewModels.CarsViewModels.Outputs;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services.CarServices
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarService(
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<CarOutputViewModel>> GetAllCars()
        {
            await this._dbContext.Extras.ToListAsync();
            await this._dbContext.Images.ToListAsync();
            var cars = await this._dbContext.Cars.ToListAsync();

            return this._mapper.Map<List<CarOutputViewModel>>(cars);
        }


        public async Task<CarOutputViewModel> GetCarById(string carId)
        {
            await this._dbContext.Extras.ToListAsync();
            await this._dbContext.Images.ToListAsync();
            var car = await this._dbContext.Cars.FirstOrDefaultAsync(x => x.Id == carId);

            return this._mapper.Map<CarOutputViewModel>(car);
        }

        public async Task<IList<CarOutputViewModel>> GetOwnCars(string userId)
        {
            await this._dbContext.Extras.ToListAsync();
            await this._dbContext.Images.ToListAsync();
            var cars = await this._dbContext.Cars.Where(x => x.UserId == userId).ToListAsync();

            return this._mapper.Map<List<CarOutputViewModel>>(cars);
        }

        public async Task<CarOutputViewModel> CreateNewCar(CarInputViewModel car, string userId)
        {
            var newCar = new Car
            {
                Make = car.Make,
                Model = car.Model,
                Description = car.Description,
                Price = car.Price,
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
            };

            foreach (var extra in car.Extras)
            {
                newCar.Extras.Add(new Extra
                {
                    Name = extra.Name,
                    CarId = newCar.Id,
                });
            }

            foreach (var image in car.Images)
            {
                newCar.Images.Add(new Image
                {
                    ImageSrc = image.ImageSrc,
                    CarId = newCar.Id,
                });
            }

            await this._dbContext.Cars.AddAsync(newCar);
            await this._dbContext.SaveChangesAsync();

            return this._mapper.Map<CarOutputViewModel>(newCar);
        }

        public async Task<CarOutputViewModel> EditCar(string carId, CarInputViewModel car)
        {
            var currentCar = await this._dbContext.Cars.FirstOrDefaultAsync(x => x.Id == carId);

            if (currentCar != null)
            {
                var extras = await this._dbContext.Extras.Where(x => x.CarId == currentCar.Id).ToListAsync();
                var images = await this._dbContext.Images.Where(x => x.CarId == currentCar.Id).ToListAsync();

                this._dbContext.Extras.RemoveRange(extras);
                this._dbContext.Images.RemoveRange(images);
                this._dbContext.Cars.Remove(currentCar);

                currentCar = new Car
                {
                    Id = carId,
                    Make = car.Make,
                    Model = car.Model,
                    Description = car.Description,
                    Price = car.Price,
                    CreatedOn = DateTime.UtcNow,
                    UserId = car.UserId,
                };

                foreach (var extra in car.Extras)
                {
                    extras.Add(new Extra
                    {
                        Name = extra.Name,
                        CarId = currentCar.Id,
                    });
                }

                foreach (var image in car.Images)
                {
                    images.Add(new Image
                    {
                        ImageSrc = image.ImageSrc,
                        CarId = currentCar.Id,
                    });
                }

                currentCar.Extras = extras;

                await this._dbContext.Cars.AddAsync(currentCar);
                await this._dbContext.SaveChangesAsync();
            }

            return this._mapper.Map<CarOutputViewModel>(currentCar);
        }

        public async Task<CarOutputViewModel> RemoveCar(string carId)
        {
            var car = await this._dbContext.Cars.FirstOrDefaultAsync(x => x.Id == carId);
            var extras = await this._dbContext.Extras.Where(x => x.CarId == car.Id).ToListAsync();
            var images = await this._dbContext.Images.Where(x => x.CarId == car.Id).ToListAsync();

            this._dbContext.Extras.RemoveRange(extras);
            this._dbContext.Images.RemoveRange(images);
            this._dbContext.Cars.Remove(car);

            await this._dbContext.SaveChangesAsync();

            return this._mapper.Map<CarOutputViewModel>(car);
        }
    }
}