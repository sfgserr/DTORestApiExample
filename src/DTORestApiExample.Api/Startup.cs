using DTORestApiExample.Api.DI;
using DTORestApiExample.Data.Services;
using DTORestApiExample.Domain.Models;
using DTORestApiExample.Domain.Services;

namespace DTORestApiExample.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration["ConnectionStrings:SQLite"];

            services.AddControllers();
            services.AddDbContextServices(connectionString);
            services.AddSingleton<IUserService, UserDataService>();
            services.AddSingleton<NonQueryDataService<User>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
