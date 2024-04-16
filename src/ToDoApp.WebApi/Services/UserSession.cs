using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using ToDoApp.WebApi.DTO;
using ToDoApp.WebApi.Models;

namespace ToDoApp.WebApi.Services.Session
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDistributedCache _distributedCache;

        public UserSession(IHttpContextAccessor httpContextAccessor, IDistributedCache distributedCache)
        {
            _httpContextAccessor = httpContextAccessor;
            _distributedCache = distributedCache;
        }

        public async Task Add(UserSessionCash user)
        {
            var sessionId = Guid.NewGuid().ToString();
            _httpContextAccessor.HttpContext!.Session.SetString("UserSessionId", sessionId);

            var userJson = JsonSerializer.Serialize(user);
            await _distributedCache.SetStringAsync(sessionId, userJson);
        }

        public async Task<UserSessionCash> GetCurrentUser()
        {
            var userSessionId = _httpContextAccessor.HttpContext!.Session.GetString("UserSessionId");

            var jsonUserSession = await _distributedCache.GetStringAsync(userSessionId!);

            var userSession = JsonSerializer.Deserialize<UserSessionCash>(jsonUserSession!);

            return userSession!;
        }
    }
}
