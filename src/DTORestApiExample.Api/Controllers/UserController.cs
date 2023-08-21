using DTORestApiExample.Api.DTOs;
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

        [HttpGet("getUsers")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            List<User> users = await _userService.GetUsers();

            List<UserDTO> userDTOs = users.Select(u => u.ConvertUserToUserDTO()).ToList();

            return Ok(userDTOs);
        }

        [HttpPost("addUser")]
        public async Task<ActionResult> AddUser(string jsonUser)
        {
            User? user = JsonConvert.DeserializeObject<User>(jsonUser);

            if (user is null)
                return BadRequest();

            await _userService.AddUser(user);
            return Ok();
        }
    }
}
