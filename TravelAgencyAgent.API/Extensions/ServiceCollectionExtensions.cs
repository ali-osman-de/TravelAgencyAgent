using TravelAgencyAgent.API.Agents;
using TravelAgencyAgent.API.Interfaces;

namespace TravelAgencyAgent.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
    {
        services.AddScoped<IChatService, BaseAgent>();
        return services;
    }
}
