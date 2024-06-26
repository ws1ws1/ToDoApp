using ToDoApp.WebApi.DTO;

namespace ToDoApp.WebApi.Services.Session
{
    public interface IUserSession
    {
        public Task Add(UserSessionCash user);

        public Task<UserSessionCash> GetCurrentUser();
    }
}
