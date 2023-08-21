using DTORestApiExample.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DTORestApiExample.Data
{
    public class UserDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
