using GatherDinner.Contracts.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace GatherDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}