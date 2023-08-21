using DTORestApiExample.Api.DTOS;
using DTORestApiExample.Api.Helpers;
using DTORestApiExample.Domain.Models;
using DTORestApiExample.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DTORestApiExample.Api.Controllers
{
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("getUsers")]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUsers()
        {
            List<User> users = await _userService.GetUsers();

            List<UserDTO> userDTOs = users.Select(u => u.ConvertUserToUserDTO()).ToList();

            return Ok(userDTOs);
        }

        [Route("addUser")]
        [HttpPost]
        public async Task<ActionResult> AddUser(string jsonUser)
        {
            User? user = JsonConvert.DeserializeObject<User?>(jsonUser);

            if (user is null)
                return BadRequest();

            await _userService.AddUser(user);
            return Ok();
        }
    }
}
