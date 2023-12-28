using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using ToDoApp.WebApi.Data.Repositories;
using ToDoApp.WebApi.Models;
using ToDoApp.WebApi.Filters;
using ToDoApp.WebApi.Services.Session;

namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private readonly IUserSession _userSession;

        public UserController(IUserRepository userRepository, IUserSession userSession)
        {
            _userRepository = userRepository;
            _userSession = userSession;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Create(user);
                _userSession.Add(user);

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [SessionFilter]
        public async Task<IActionResult> Get()
        {
            var user = _userSession.GetCurrentUser();

            return Ok(user);

        }
    }
}
