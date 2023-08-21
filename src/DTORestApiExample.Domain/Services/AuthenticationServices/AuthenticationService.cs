using DTORestApiExample.Domain.Models;

namespace DTORestApiExample.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Login(string email, string password)
        {
            User user = await _userService.GetUserByEmail(email);

            if (user == null)
                throw new ArgumentException();

            if (user.Password != password)
                throw new ArgumentException();

            return user;
        }

        public async Task Register(string name, string email, string password, int cardNumber)
        {
            User user = await _userService.GetUserByEmail(email);

            if (user != null)
                throw new ArgumentException();

            user = new User()
            {
                Name = name,
                Email = email,
                Password = password,
                CardNumber = cardNumber
            };

            await _userService.AddUser(user);
        }
    }
}
