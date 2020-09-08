using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
         

            return View();
        }
        public void CallHelloWordService()
        {
            var hubContex = GlobalHost.ConnectionManager.GetHubContext<MyHub1>();
            hubContex.Clients.All.helloWord("hello word from HomeController!");
        }
        /// <summary>
        /// see Startup Config current user login, in this example default user is "1"
        /// to change get userId in Startup.cs file
        /// </summary>
       
    }
}