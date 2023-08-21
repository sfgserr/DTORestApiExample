using DTORestApiExample.Domain.Models;
using DTORestApiExample.Domain.Services;

namespace DTORestApiExample.Data.Services
{
    public class UserDataService : IUserService
    {
        private readonly NonQueryDataService<User> _dataService;

        public UserDataService(NonQueryDataService<User> dataService)
        {
            _dataService = dataService;
        }

        public async Task AddUser(User user)
        {
            await _dataService.AddEntity(user);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dataService.GetAll();
        }
    }
}
