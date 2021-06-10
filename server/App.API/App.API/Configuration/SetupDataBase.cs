
using App.Context.Infra.Data;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.API.Configuration
{
    public static class SetupDataBase
    {
        public static IServiceCollection ConfigureAppDatabase(this IServiceCollection services)
        {
            SqlMapper.AddTypeHandler(new SqlGuidTypeHandler());

            services.AddDbContext<AppDataContext>();
            return services;
        }

        public static IApplicationBuilder BootstrapDb(this IApplicationBuilder applicationBuilder,IConfiguration configuration)
        {
            DataBootstrap.Bootstrap(configuration);

            return applicationBuilder;
        }

    }
}
