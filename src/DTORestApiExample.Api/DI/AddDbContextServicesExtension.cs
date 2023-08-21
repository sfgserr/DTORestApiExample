using DTORestApiExample.Data;
using DTORestApiExample.Data.Services;
using DTORestApiExample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DTORestApiExample.Api.DI
{
    public static class AddDbContextServicesExtension
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, string connectionString)
        {
            Action<DbContextOptionsBuilder> configureDb = o => o.UseSqlite(connectionString);

            services.AddSingleton<UserDataContextFactory>(s => new UserDataContextFactory(configureDb));
            services.AddDbContext<UserDataContext>(configureDb);

            return services;
        }
    }
}
