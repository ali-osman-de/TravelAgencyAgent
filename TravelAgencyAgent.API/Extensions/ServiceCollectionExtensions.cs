using TravelAgencyAgent.API.Agents;
using TravelAgencyAgent.API.Agents.Interface;
using TravelAgencyAgent.API.Interfaces;
using TravelAgencyAgent.API.Services.ChatService;

namespace TravelAgencyAgent.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
    {
        services.AddSingleton<IBaseAgent, BaseAgent>();
        services.AddSingleton<IChatService, ChatService>();
        return services;
    }
}
