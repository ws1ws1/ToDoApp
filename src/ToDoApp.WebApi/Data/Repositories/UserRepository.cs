using Microsoft.EntityFrameworkCore;
using ToDoApp.WebApi.Data;
using ToDoApp.WebApi.Models;

namespace ToDoApp.WebApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _db;

        public UserRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public User GetById(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id)!;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user!;
        }
    }
}
