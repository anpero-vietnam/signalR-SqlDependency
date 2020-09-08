using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubService
{
    [HubName("userTrackingHub")]
    //[Authorize]
    public class UserHub : Hub
    {
        private readonly UserTrackingService _userTrackingService;
        public UserHub() : this(UserTrackingService.Instance)
        {         
        }
        public UserHub(UserTrackingService userTrackingService)
        {
           
            _userTrackingService = userTrackingService;
        }
     
     
        
    }

}
