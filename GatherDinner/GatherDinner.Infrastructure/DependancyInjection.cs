using GatherDinner.Application;
using GatherDinner.Application.Common.Interfaces.Authentication;
using GatherDinner.Application.Common.Interfaces.Presistence;
using GatherDinner.infrastructure.Services;
using GatherDinner.Infrastructure.Authentication;
using GatherDinner.Infrastructure.Presistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using Microsoft.Extensions.Options;
using System.Text;
namespace GatherDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
      
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvidor, DateTimeProvidor>();
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
          var jwtSettings = new jwtSettings();
        configuration.Bind(jwtSettings.sectionName,jwtSettings);
                services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings.Issuer,
          ValidAudience = jwtSettings.Audience,

          IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings.Secret)
          )

            
        });
         
        return services;
    }
}