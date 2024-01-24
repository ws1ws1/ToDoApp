using Microsoft.AspNetCore.Mvc;
using ToDoApp.WebApi.Data.Repositories;
using ToDoApp.WebApi.Models;
using ToDoApp.WebApi.Filters;
using ToDoApp.WebApi.Services.Session;
using ToDoApp.WebApi.Services;
using ToDoApp.WebApi.DTO;

namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _userSession;
        private readonly IPasswordHasher _passwordHasher;

        public UserController(IUserRepository userRepository, IUserSession userSession, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _userSession = userSession;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRegistrationDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var passwordHashString = _passwordHasher.Generate(userDTO.Password);

                var user = new User { Email = userDTO.Email, PasswordHash = passwordHashString };

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
