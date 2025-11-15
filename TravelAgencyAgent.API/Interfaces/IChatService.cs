using System;

namespace TravelAgencyAgent.API.Interfaces;

public interface IChatService
{
    Task<string> GetResponseChatHistoryObjectAsync(string userInput);
    Task<string> GetResponseThreadAsync(string userInput);
}
