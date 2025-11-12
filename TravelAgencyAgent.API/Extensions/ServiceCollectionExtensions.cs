using TravelAgencyAgent.API.Agents;
using TravelAgencyAgent.API.Agents.Interface;
using TravelAgencyAgent.API.Interfaces;
using TravelAgencyAgent.API.Services.ChatService;

namespace TravelAgencyAgent.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
    {
        services.AddScoped<IBaseAgent, BaseAgent>();
        services.AddScoped<IChatService, ChatService>();
        return services;
    }
}
