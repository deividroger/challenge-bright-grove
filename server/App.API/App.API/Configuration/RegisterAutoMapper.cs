using App.API.Dto;
using App.Context.Domain.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.API.Configuration
{
    public static class RegisterAutoMapper
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.Roles))
                .ReverseMap();

                cfg.CreateMap<OfficeDto, Office>().ReverseMap();

                cfg.CreateMap<RoleDto, Role>()
                    .ReverseMap();

            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
