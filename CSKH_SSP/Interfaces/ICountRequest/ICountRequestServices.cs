using CSKH_SSP.ViewModels.CountRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.ICountRequest {
    public interface ICountRequestServices {
        public CountRequestStatus CountNotification(int GroupUserID, string UserName);
        public string CountNotificationOfUser(string UserName);
    }
}
