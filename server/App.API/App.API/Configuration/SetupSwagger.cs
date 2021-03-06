using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace App.API.Configuration
{
    public static class SetupSwagger
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.API", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerApp(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.API v1"));
            return applicationBuilder;
        }


    }
}
