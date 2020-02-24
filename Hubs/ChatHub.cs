using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Services;

namespace SignalRDemo.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatService _chatService;

        public ChatHub(ChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task GetMessages(string connectionId)
        {
            var data = _chatService.Messages;
            await Clients.Client(connectionId).SendAsync("GetMessages", data);
        }

        public async Task SendMessage(string userName, string content, string clientName)
        {
            var msg = new Models.ChatMessage
            {
                UserName = userName,
                Content = content,
                SentTime = DateTime.Now,
                ClientName = clientName
            };
            _chatService.Messages.Add(msg);

            await Clients.All.SendAsync("SendMessage", msg);
        }

        public override Task OnConnectedAsync()
        {
            GetMessages(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
