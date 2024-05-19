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
        public async Task<IActionResult> Post(UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                var oldUser = await _userRepository.GetByEmailAsync(userRegistration.Email);

                if (oldUser != null)
                {
                    return BadRequest("This Email exists");
                }

                var passwordHashString = _passwordHasher.Generate(userRegistration.Password);

                var user = new User { Email = userRegistration.Email, PasswordHash = passwordHashString };
                await _userRepository.Create(user);

                var userSessionCash = new UserSessionCash { Email = userRegistration.Email };
                await _userSession.Add(userSessionCash);

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [SessionFilter]
        public async Task<IActionResult> Get()
        {
            var user = await _userSession.GetCurrentUser();

            return Ok(user);

        }
    }
}
