using Microsoft.EntityFrameworkCore;
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

        public async Task Create(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);
            return user!;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user!;
        }
    }
}
