using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;
using TravelAgencyAgent.API.Agents.Interface;
using TravelAgencyAgent.API.Interfaces;

namespace TravelAgencyAgent.API.Services.ChatService;

public class ChatService : IChatService
{
    private readonly IBaseAgent _baseAgent;
    public ChatService(IBaseAgent baseAgent)
    {
        _baseAgent = baseAgent;
    }

    public async Task<string> GetResponseAsync(string userInput)
    {
        var ChatAgent = _baseAgent.CreateAgent("ChatAgent", "You are a helpful travel agency assistant.");
        var chat = ChatAgent.RunAsync(userInput);
        return chat.Result.ToString();
    }
}
