using CSKH_SSP.ViewModels.UserInfomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.ICountUserOnlineService
{
    public interface ICountUserOnlineService
    {
        public List<WhoIsOnline> UpdateWhoIsOnline(int UserID, bool isConnect);
    }
}
