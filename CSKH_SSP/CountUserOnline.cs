using CSKH_SSP.Interfaces.ICountUserOnlineService;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP
{
    
    public class CountUserOnline : Hub
    {
        private readonly ICountUserOnlineService _iCountUserOnlineService;

        public CountUserOnline(ICountUserOnlineService iCountUserOnlineService)
        {
            _iCountUserOnlineService = iCountUserOnlineService;
        }

        private static int clientCounter = 0;
        public Task userInfomation(int UserID)
        {
            return Clients.All.SendAsync("UpdateUser", UserID);
        }
        public override Task OnConnectedAsync()
        {
            var httpCtx = Context.GetHttpContext();
            var UserID = httpCtx.Request.Query["UserID"].ToString();
            //userInfomation();
            _iCountUserOnlineService.UpdateWhoIsOnline(Int32.Parse(UserID), true);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var httpCtx = Context.GetHttpContext();
            var UserID = httpCtx.Request.Query["UserID"].ToString();
            //userInfomation();
            _iCountUserOnlineService.UpdateWhoIsOnline(Int32.Parse(UserID), false);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
