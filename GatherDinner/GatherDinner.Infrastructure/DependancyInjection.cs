using GatherDinner.Application;
using GatherDinner.Application.Common.Interfaces.Authentication;
using GatherDinner.Application.Common.Interfaces.Presistence;
using GatherDinner.infrastructure.Services;
using GatherDinner.Infrastructure.Authentication;
using GatherDinner.Infrastructure.Presistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GatherDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<jwtSettings>(configuration.GetSection(jwtSettings.sectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvidor, DateTimeProvidor>();
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
}