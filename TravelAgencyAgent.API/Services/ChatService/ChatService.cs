using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using System.Threading;
using TravelAgencyAgent.API.Agents.Interface;
using TravelAgencyAgent.API.Interfaces;

namespace TravelAgencyAgent.API.Services.ChatService;

public class ChatService : IChatService
{
    private readonly AIAgent _chatAgent;
    private readonly List<ChatMessage> _history = [];
    private readonly AgentThread _thread;


    public ChatService(IBaseAgent baseAgent)
    {
        _chatAgent = baseAgent.CreateAgent(
            name: "ChatAgent",
            instructions: "You are a helpful travel agency assistant."
        );

        _history.Add(new ChatMessage(
            ChatRole.System,
            "You are a helpful travel agency assistant."
        ));

        _thread = _chatAgent.GetNewThread();

    }

    public async Task<string> GetResponseChatHistoryObjectAsync(string userInput)
    {
        _history.Add(new ChatMessage(ChatRole.User, userInput));

        AgentRunResponse runResponse = await _chatAgent.RunAsync(_history);

        _history.AddRange(runResponse.Messages);

        return runResponse.Text;
    }

    public async Task<string> GetResponseThreadAsync(string userInput)
    {
        AgentRunResponse runResponse = await _chatAgent.RunAsync(userInput, _thread);

        return runResponse.Text;
    }
}
