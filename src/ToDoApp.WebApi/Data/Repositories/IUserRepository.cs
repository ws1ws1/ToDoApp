using ToDoApp.WebApi.Models;

namespace ToDoApp.WebApi.Data.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);

        User GetById(int id);

        Task<User> GetByEmailAsync(string email);
    }
}
