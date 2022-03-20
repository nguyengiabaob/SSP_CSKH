using CSKH_SSP.Interfaces.ICountUserOnlineService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.UserInfomation;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IAdminServices;

namespace CSKH_SSP.Services.CountUserOnline
{
    public class CountUserOnlineService : ICountUserOnlineService
    {
        private DataContext _context;
        private readonly IStatisticServices _iStatisticServices;
        public CountUserOnlineService(DataContext context, IStatisticServices iStatisticServices)
        {
            _context = context;
            _iStatisticServices = iStatisticServices;
        }
        public List<WhoIsOnline> ListUserAndTask()
        {
            var listUser = _context.User.Where(x => x.DepartmentID == 433 || x.DepartmentID == 434).ToList();
            List<WhoIsOnline> result = new List<WhoIsOnline>();

            foreach (var item in listUser)
            {
                var Obj = new WhoIsOnline();
                var countProcessingTaskOfUser = _iStatisticServices.countProcessingTaskOfUser(item.UserID);
                Obj.UserID = item.UserID;
                Obj.UserName = item.UserName;
                Obj.GroupUserID = item.GroupUserID;
                Obj.FullName = item.FullName;
                Obj.countAllTask = countProcessingTaskOfUser;
                if (countProcessingTaskOfUser > 0)
                { Obj.isReady = false; item.IsReady = false; }
                else { Obj.isReady = true; item.IsReady = true; }
                //if (isConnect)
                //    Obj.isOnline = true;
                Obj.isOnline = (bool)(item.IsOnline.HasValue ? item.IsOnline : false);
                result.Add(Obj);
            }
            return result;
        }
        public List<WhoIsOnline> UpdateWhoIsOnline (int UserID, bool isConnect)
        {
            var tempUserObj = _context.User.Where(x => x.UserID == UserID).FirstOrDefault();
            tempUserObj.IsOnline = isConnect;
            _context.SaveChanges();

            var temp = ListUserAndTask();
            foreach (var item in temp)
            {
                if(item.UserID == UserID)
                {
                    item.isOnline = isConnect;
                }
            }
            return temp;
        }

    }
}
