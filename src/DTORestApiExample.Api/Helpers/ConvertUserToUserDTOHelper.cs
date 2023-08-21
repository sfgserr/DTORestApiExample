using DTORestApiExample.Api.DTOS;
using DTORestApiExample.Domain.Models;

namespace DTORestApiExample.Api.Helpers
{
    public static class ConvertUserToUserDTOHelper
    {
        public static UserDTO ConvertUserToUserDTO(this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
