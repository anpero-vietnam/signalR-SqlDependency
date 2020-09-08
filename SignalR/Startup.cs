using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR.Startup))]

namespace SignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var idProvider = new CustomUserIdProvider();
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);
            app.MapSignalR();
            
        }
        //private string CustomUserIdProvider()
        //{
        //    return "1";
        //}
    }
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            // can be get token data from cookie
            return "1";
        }
    }
}
