using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Services;

namespace SignalRDemo.Hubs
{
    public class OneChatHub : Hub
    {
        private readonly OneChatService _chatService;

        public OneChatHub(OneChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task GetMessages(string connectionId, string channelName = "public", string password = "")
        {
            var data = _chatService.GetMessages(channelName, password);
            await Clients.Client(connectionId).SendAsync("GetMessages", data);
        }

        public async Task SendMessage(string userName, string content, string clientName)
        {

        }

        public override Task OnConnectedAsync()
        {
            GetMessages(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
