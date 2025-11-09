using Microsoft.Agents.AI;
using OpenAI;
using TravelAgencyAgent.API.Interfaces;

namespace TravelAgencyAgent.API.Agents;

public class BaseAgent : IChatService
{
    private readonly IConfiguration _configuration;
    private readonly string _apiKey;
    private readonly string _model;
    private readonly AIAgent agent;

    public BaseAgent(IConfiguration configuration)
    {
        _configuration = configuration;
        _apiKey = _configuration.GetValue<string>("Agent:ApiKey")!;
        _model = _configuration.GetValue<string>("Agent:Model")!;

#pragma warning disable OPENAI001 
        agent = new OpenAIClient(
            _apiKey)
            .GetOpenAIResponseClient(_model)
#pragma warning restore OPENAI001
            .CreateAIAgent(instructions: "You are good at telling jokes.", name: "Joker");
    }

    public async Task<string> GetResponseAsync(string userInput)
    {
        var result = await agent.RunAsync(userInput);
        return result.ToString();
    }
}
