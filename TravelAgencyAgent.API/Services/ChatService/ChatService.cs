using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using System.Threading;
using TravelAgencyAgent.API.Agents.Interface;
using TravelAgencyAgent.API.Interfaces;

namespace TravelAgencyAgent.API.Services.ChatService;

public class ChatService : IChatService
{
    private readonly AIAgent _travelAgent;
    private readonly AIAgent _bookingAgent;
    private readonly List<ChatMessage> _history = [];
    private readonly AgentThread _thread;


    public ChatService(IBaseAgent baseAgent)
    {
        _travelAgent = baseAgent.GetTravelAgent();
        
        _bookingAgent = baseAgent.GetBookingAgent();

        _history.Add(new ChatMessage(
            ChatRole.System,
            "You are a helpful travel agency assistant."
        ));

        _thread = baseAgent.CreateAgentThread(_travelAgent);

    }

    public async Task<string> GetResponseChatHistoryObjectAsync(string userInput)
    {
        _history.Add(new ChatMessage(ChatRole.User, userInput));

        AgentRunResponse runResponse = await _travelAgent.RunAsync(userInput);

        _history.AddRange(runResponse.Messages);

        return runResponse.Text;
    }

    public async Task<string> GetResponseThreadAsync(string userInput)
    {
        AgentRunResponse runResponse = await _bookingAgent.RunAsync(userInput, _thread);

        return runResponse.Text;
    }
}
