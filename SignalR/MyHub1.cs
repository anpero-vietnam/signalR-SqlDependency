using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR
{
    [HubName("SampleHubName")]
    public class MyHub1 : Hub
    {
        public void HelloServerFunction()
        {
            Clients.All.helloWord("hello word triger from server!");
        }
        public void SendMessengeToUser(string userId,string messenge)
        {
            
            Clients.User(userId).helloWord(messenge);
        }
        //public override Task OnConnected()
        //{

        //    return base.OnConnected();

        //}
        //// turning on user refresh page
        //public override Task OnDisconnected(bool stopCalled)
        //{            
        //    return base.OnDisconnected(stopCalled);
        //}
        //public override Task OnReconnected()
        //{
        //    return base.OnReconnected();
        //}

    }
}