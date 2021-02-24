using System.Threading.Tasks;
using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmailExists(string email)
            => await this._dbContext.Users.AnyAsync(x => x.Email == email);


        public async Task<bool> UsernameExists(string username)
            => await this._dbContext.Users.AnyAsync(x => x.UserName == username);

    }
}