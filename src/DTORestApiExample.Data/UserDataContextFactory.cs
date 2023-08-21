using Microsoft.EntityFrameworkCore;

namespace DTORestApiExample.Data
{
    public class UserDataContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDb;

        public UserDataContextFactory(Action<DbContextOptionsBuilder> configureDb)
        {
            _configureDb = configureDb;
        }

        public UserDataContext Create()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

            _configureDb(optionsBuilder);

            return new UserDataContext(optionsBuilder.Options);
        }
    }
}
