using System.Threading.Tasks;

namespace Cars.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> EmailExists(string email);

        Task<bool> UsernameExists(string username);

    }
}