using DTORestApiExample.Domain.Models;

namespace DTORestApiExample.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<User> Login(string email, string password);

        Task Register(string name, string email, string password, int cardNumber);
    }
}
