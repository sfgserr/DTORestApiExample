using DTORestApiExample.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DTORestApiExample.Data.Services
{
    public class NonQueryDataService<TDomainEntity> where TDomainEntity : DomainEntity
    {
        private readonly UserDataContextFactory _factory;

        public NonQueryDataService(UserDataContextFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<TDomainEntity>> GetAll()
        {
            using (UserDataContext context = _factory.Create())
            {
                return await context.Set<TDomainEntity>().ToListAsync();
            }
        }

        public async Task AddEntity(TDomainEntity entity)
        {
            using (UserDataContext context = _factory.Create())
            {
                context.Set<TDomainEntity>().Add(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
