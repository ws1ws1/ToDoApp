using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserRepository
    {
        void Create(User user);

        User GetById(int id);

        Task<User> GetByEmailAsync(string email);
    }
}
