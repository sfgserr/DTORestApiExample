using DTORestApiExample.Domain.Models;

namespace DTORestApiExample.Domain.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task AddUser(User user);
    }
}
