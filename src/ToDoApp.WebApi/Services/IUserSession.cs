using ToDoApp.WebApi.Models;

namespace ToDoApp.WebApi.Services.Session
{
    public interface IUserSession
    {
        public void Add(User user);

        public string GetCurrentUser();
    }
}
