using DTORestApiExample.Domain.Models;

namespace DTORestApiExample.Domain.Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);

        Task AddUser(User user);
    }
}
