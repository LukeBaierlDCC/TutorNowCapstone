using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TutorMeNow.SignalR.Hubs
{
    public class ChatHub1 : Hub
    {
        //[Authorize]
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");
        //}

        //public override async Task OnDisconnectedAsync(Exception ex)
        //{
        //    await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "left");
        //}

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, message);
        }
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}