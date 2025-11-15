using Microsoft.Agents.AI;
using OpenAI;
using TravelAgencyAgent.API.Agents.Interface;

namespace TravelAgencyAgent.API.Agents;

public class BaseAgent : IBaseAgent
{
    private readonly IConfiguration _configuration;
    private readonly OpenAIClient _client;
    private readonly string _defaultModel;

    private readonly Lazy<AIAgent> _travelAgent;
    private readonly Lazy<AIAgent> _bookingAgent;
    public BaseAgent(IConfiguration configuration)
    {
        _configuration = configuration;
        var apiKey = _configuration.GetValue<string>("Agent:ApiKey")!;
        _defaultModel = _configuration.GetValue<string>("Agent:Model")!;
        _client = new OpenAIClient(apiKey);

        _travelAgent = new Lazy<AIAgent>(() => CreateAgent(
            name: "TravelAgent",
            instructions: "You are a helpful travel agency assistant."
        ));

        _bookingAgent = new Lazy<AIAgent>(() => CreateAgent(
            name: "BookingAgent",
            instructions: "You help with hotel and flight bookings."
        ));
    }

    public AIAgent CreateAgent(string name, string instructions, string? model = null)
    {
    #pragma warning disable OPENAI001
        var aiAgent = _client
            .GetOpenAIResponseClient(model ?? _defaultModel)
            .CreateAIAgent(
                instructions: instructions,
                name: name);
    #pragma warning restore OPENAI001

        return aiAgent;
    }

    public AgentThread CreateAgentThread(AIAgent agent)
    {
        return agent.GetNewThread();
    }
    public AIAgent GetTravelAgent() => _travelAgent.Value;
    public AIAgent GetBookingAgent() => _bookingAgent.Value;
}
