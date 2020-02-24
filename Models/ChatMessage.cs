using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Models
{
    public class ChatMessage
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime SentTime { get; set; }
        public string SentTimeStr
        {
            get
            {
                var now = DateTime.Now;
                var span = now - SentTime;

                var seconds = Convert.ToInt32(span.TotalSeconds);
                var minutes = Convert.ToInt32(span.TotalMinutes);
                var hours = Convert.ToInt32(span.TotalHours);
                var days = Convert.ToInt32(span.TotalDays);

                var timeStr = $"{seconds}秒之前";

                if (seconds == 0) timeStr = $"刚刚";

                if (span.TotalMinutes >= 1 && span.TotalHours < 1)
                    timeStr = $"{minutes}分钟之前";
                if (span.TotalHours >= 1 && span.TotalDays < 1)
                    timeStr = $"{hours}小时之前";
                if (span.TotalDays >= 1)
                    timeStr = $"{days}天之前";

                return timeStr;
            }
        }
        public string ClientName { get; set; }
    }
}
