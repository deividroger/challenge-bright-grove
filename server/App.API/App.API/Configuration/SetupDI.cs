using App.Context.Domain.Repository;
using App.Context.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.API.Configuration
{
    public static class SetupDI
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            //Repository
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            //Services
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }


    }
}
