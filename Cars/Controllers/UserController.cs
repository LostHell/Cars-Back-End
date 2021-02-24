using System.Threading.Tasks;
using AutoMapper;
using Cars.Data.Models;
using Cars.Services.UserServices;
using Cars.ViewModels.UserViewModels.Inputs;
using Cars.ViewModels.UserViewModels.Outputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [ApiController]
    [Route("")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterInputViewModel register)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new {Message = "Ooopppsss! Something wrong!", this.ModelState, register});
            }

            if (await this._userService.EmailExists(register.Email))
            {
                return this.BadRequest(new {Message = "Email is already exists!", register});
            }

            if (await this._userService.UsernameExists(register.Username))
            {
                return this.BadRequest(new {Message = "Username is already exists!", register});
            }

            var newUser = this._mapper.Map<ApplicationUser>(register);

            var data = await this._userManager.CreateAsync(newUser, register.Password);

            if (!data.Succeeded)
            {
                return this.BadRequest(new {Message = "User is NOT create!", register});
            }

            var user = this._mapper.Map<UserOutputViewModel>(newUser);

            return this.Created("Login", new {Message = "User is created!", user});
        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordInputViewModel resetPassword)
        {
            var user = await this._userManager.FindByEmailAsync(resetPassword.Email);

            if (user != null &&
                user.UserName == resetPassword.Username &&
                this.ModelState.IsValid)
            {
                var token = await this._userManager.GeneratePasswordResetTokenAsync(user);
                var result = await this._userManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);

                if (!result.Succeeded)
                {
                    return this.BadRequest(new {Message = "Reset Password failed!", resetPassword});
                }

                return this.Ok(new {Message="Reset Password successful!"});
            }

            return this.BadRequest(new {Message = "Reset Password failed!", resetPassword});
        }

        [Authorize]
        [HttpPut("changePassword/{id}")]
        public async Task<ActionResult> ChangePassword(string id, ChangePasswordInputViewModel changePassword)
        {
            var user = await this._userManager.FindByIdAsync(id);

            if (user != null &&
                this.ModelState.IsValid)
            {
                var result = await this._userManager.ChangePasswordAsync(user, changePassword.OldPassword,
                    changePassword.NewPassword);

                if (!result.Succeeded)
                {
                    return this.BadRequest(new {Message="Change password failed!"});
                }

                return this.Ok(new {Message="Successful changed password!"});
            }

            return this.BadRequest(new {Message="Change password failed!"});
        }

        [Authorize]
        [HttpPut("changeEmail/{id}")]
        public async Task<ActionResult> ChangeEmail(string id, ChangeEmailInputViewModel changeEmail)
        {
            var user = await this._userManager.FindByIdAsync(id);

            if (user != null &&
                this.ModelState.IsValid &&
                user.Email == changeEmail.OldEmail)
            {
                var token = await this._userManager.GenerateChangeEmailTokenAsync(user, changeEmail.NewEmail);
                var result = await this._userManager.ChangeEmailAsync(user, changeEmail.NewEmail, token);

                if (!result.Succeeded)
                {
                    return this.BadRequest(new {Message="Change Email failed!"});
                }

                return this.Ok(new {Message="Successful changed Email!"});
            }

            return this.BadRequest(new {Message="Change Email failed!"});
        }

        [Authorize]
        [HttpPut("changePhone/{id}")]
        public async Task<ActionResult> ChangePhone(string id, ChangePhoneInputViewModel changePhone)
        {
            var user = await this._userManager.FindByIdAsync(id);

            if (user != null &&
                user.PhoneNumber == changePhone.OldPhone &&
                this.ModelState.IsValid)
            {
                var token = await this._userManager.GenerateChangePhoneNumberTokenAsync(user, changePhone.NewPhone);
                var result = await this._userManager.ChangePhoneNumberAsync(user, changePhone.NewPhone, token);

                if (!result.Succeeded)
                {
                    return this.BadRequest(new {Message="Change Phone Number failed!"});
                }

                return this.Ok(new {Message="Successful changed Phone Number!"});
            }

            return this.BadRequest(new {Message="Change Phone Number failed!"});
        }
    }
}