using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App06.Hubs
{
    public class MyHub : Hub
    {
        public override  Task OnConnectedAsync()
        {
           // await Clients.All.SendAsync("ReceiveMessage", user, message);
            return  base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
