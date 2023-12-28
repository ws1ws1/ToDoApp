using System.Text.Json;
using ToDoApp.WebApi.Models;

namespace ToDoApp.WebApi.Services.Session
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        public void Add(User user)
        {
            var json = JsonSerializer.Serialize(user);
            _httpContextAccessor.HttpContext.Session.SetString("session_data", json);
        }

        public string GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.Session.GetString("session_data");

            return user;
        }
    }
}
