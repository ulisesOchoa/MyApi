using Microsoft.EntityFrameworkCore;
using MyApi.Domain.Entities;

namespace MyApi.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
