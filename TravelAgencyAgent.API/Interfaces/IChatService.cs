using System;

namespace TravelAgencyAgent.API.Interfaces;

public interface IChatService
{
    Task<string> GetResponseAsync(string userInput);
}
