using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRDemo.Models;

namespace SignalRDemo.Services
{
    public class OneChatService
    {
        private readonly Dictionary<string, Channel> _channels;

        public OneChatService()
        {

        }

        public Channel GetOrCreate(string channelName, string userName = "", string password = "")
        {
            if (_channels.ContainsKey(channelName))
                return _channels[channelName];
            else
            {
                var channel = new Channel
                {
                    Creator = userName,
                    Name = channelName,
                    Password = password,
                    Messages = new List<ChatMessage>()
                };
                _channels.Add(channelName, channel);
                return channel;
            }
        }        

        public List<ChatMessage> GetMessages(string channelName,string password = "")
        {
            var emptyData = new List<ChatMessage>();

            if (_channels.ContainsKey(channelName))
            {
                var channel = _channels[channelName];
                if (password == channel.Password)
                    return channel.Messages;
            }

            return emptyData;
        }
    }
}
