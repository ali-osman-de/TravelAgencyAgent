using Microsoft.Agents.AI;

namespace TravelAgencyAgent.API.Agents.Interface
{
    public interface IBaseAgent
    {
        AIAgent CreateAgent(string name, string instructions, string? model = null);

        AgentThread CreateAgentThread(AIAgent agent);
    }
}
