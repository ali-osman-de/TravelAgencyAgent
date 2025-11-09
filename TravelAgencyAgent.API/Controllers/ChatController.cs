using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyAgent.API.Interfaces;

namespace TravelAgencyAgent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> Chat(string message)
        {
            var res = await _chatService.GetResponseAsync(message);
            return Ok(res);
        }

    }
}
