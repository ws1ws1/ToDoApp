using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using ToDoApp.WebApi.Data.Repositories;
using ToDoApp.WebApi.Models;
using ToDoApp.WebApi.Filters;


namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IDistributedCache _distributedCache;

        public UserController(IUserRepository userRepository, IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _distributedCache = distributedCache;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Create(user);

                HttpContext.Session.SetInt32("Session_Id", user.Id);

                var userJson = JsonSerializer.Serialize(user);                 
                HttpContext.Session.SetString("Session_Data", userJson);

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [SessionFilter]
        public async Task<IActionResult> Get()
        {
            var str = Content("Id");

            return Ok();

        }
    }
}
