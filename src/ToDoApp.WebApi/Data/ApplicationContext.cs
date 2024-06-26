using Microsoft.EntityFrameworkCore;
using ToDoApp.WebApi.Models;

namespace ToDoApp.WebApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
