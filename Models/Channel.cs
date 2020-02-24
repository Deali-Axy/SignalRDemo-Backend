using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Models
{
    public class Channel
    {
        public string Creator { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
