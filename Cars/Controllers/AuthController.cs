using System.Threading.Tasks;
using AutoMapper;
using Cars.Data.Models;
using Cars.ViewModels.UserViewModels.Inputs;
using Cars.ViewModels.UserViewModels.Outputs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginInputViewModel login)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new {Message = "Ooopppsss! Something wrong!", this.ModelState, login});
            }

            // Sign in
            var userLogin = await this._signInManager
                .PasswordSignInAsync(login.Username, login.Password, true, false);

            if (!userLogin.Succeeded)
            {
                return this.BadRequest(new {Message = "Login failed!", login});
            }

            var currentUser = await this._userManager.FindByNameAsync(login.Username);

            var data = this._mapper.Map<UserOutputViewModel>(currentUser);

            return this.Ok(new {Message = "Login successful!", data});
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();
            return this.Ok(new {Message = "Logout successful!"});
        }
    }
}