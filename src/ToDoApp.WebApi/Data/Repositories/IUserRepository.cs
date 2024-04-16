using ToDoApp.WebApi.Models;

namespace ToDoApp.WebApi.Data.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);

        Task<User> GetById(int id);

        Task<User> GetByEmailAsync(string email);
    }
}
