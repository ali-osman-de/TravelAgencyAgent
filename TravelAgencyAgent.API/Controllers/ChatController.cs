using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyAgent.API.Interfaces;

namespace TravelAgencyAgent.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetResponseChatHistoryObjectAsync(string message)
        {
            var res = await _chatService.GetResponseChatHistoryObjectAsync(message);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetResponseThreadAsync(string message)
        {
            var res = await _chatService.GetResponseThreadAsync(message);
            return Ok(res);
        }
    }
}
