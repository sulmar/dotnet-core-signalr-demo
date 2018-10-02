using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Service.Hubs
{
    public class MessagesHub : Hub
    {
        public Task Send(Message message)
        {
            return Clients.All.SendAsync("Send", message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
