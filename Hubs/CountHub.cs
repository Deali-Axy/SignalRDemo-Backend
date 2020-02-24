using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Services;

namespace SignalRDemo.Hubs
{
    public class CountHub : Hub
    {
        private readonly CountService _countService;

        public CountHub(CountService countService)
        {
            _countService = countService;
        }

        public async Task GetLastestCount(string random)
        {
            int count;
            do
            {
                count = _countService.GetLatestCount();

                Thread.Sleep(1000);

                await Clients.All.SendAsync("ReceiveUpdate", count);
            } while (count < 10);

            await Clients.All.SendAsync("Finished");
        }
    }
}
