using DTORestApiExample.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DTORestApiExample.Data
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
    }
}
