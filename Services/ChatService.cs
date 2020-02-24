using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;
using SignalRDemo.Models;

namespace SignalRDemo.Services
{
    public class ChatService
    {
        private readonly List<ChatMessage> _messages;
        private readonly IHubContext<ChatHub> _context;

        public List<ChatMessage> Messages { get => _messages; }

        public ChatService(IHubContext<ChatHub> context)
        {
            _context = context;
            _messages = new List<ChatMessage>();
        }
    }
}
