using System.Linq;
using System.Threading.Tasks;
using Cars.Data.Models;
using Cars.Services.CarServices;
using Cars.ViewModels.CarsViewModels.Inputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [ApiController]
    [Route("car")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarController(
            ICarService carService,
            UserManager<ApplicationUser> userManager
        )
        {
            _carService = carService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCars()
        {
            var cars = await this._carService.GetAllCars();

            return this.Ok(new {Message = "Successful!", cars});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCarById(string id)
        {
            var car = await this._carService.GetCarById(id);

            return this.Ok(new {Message = "Successful!", car});
        }

        [HttpGet("own/{ownerId}")]
        public async Task<ActionResult> GetOwnCars(string ownerId)
        {
            var cars = await this._carService.GetOwnCars(ownerId);

            return this.Ok(new {Message = "Successful!", cars});
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateNewCar(CarInputViewModel car)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new {Message = "Ooopppsss! Something wrong!", this.ModelState, car});
            }

            //  var userId = this._userManager.GetUserAsync(this.User).Id.ToString();

            var newCar = await this._carService.CreateNewCar(car, car.UserId);

            return this.Created("", new {Message = "Car created!", newCar});
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> EditCar(string id, [FromBody] CarInputViewModel car)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new {Message = "Ooopppsss! Something wrong!", this.ModelState, car});
            }

            var editCar = await this._carService.EditCar(id, car);

            return this.Created("", new {Message = "Car edited!", editCar});
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteCar(string id)
        {
            var car = await this._carService.GetCarById(id);

            if (car == null)
            {
                return this.NotFound();
            }

            var carToDelete = await this._carService.RemoveCar(car.Id);

            return this.Created("", new {Message = "Car deleted!", carToDelete});
        }
    }
}