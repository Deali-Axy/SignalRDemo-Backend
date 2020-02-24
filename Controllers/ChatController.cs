using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;
using SignalRDemo.Services;

namespace SignalRDemo.Controllers
{
    [Route("api/chat")]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> _context;
        private readonly ChatService _chatService;

        public ChatController(IHubContext<ChatHub> context, ChatService chatService)
        {
            _context = context;
            _chatService = chatService;
        }

        [HttpPost]
        [Route("connect")]
        public async Task<IActionResult> Connect()
        {
            await _context.Clients.All.SendAsync("GetMessages", _chatService.Messages);
            return Accepted(1);
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendMessage()
        {
            await _context.Clients.All.SendAsync("Connected");
            return Accepted(1);
        }
    }
}
