using CSKH_SSP.Constant;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IAdminServices;
using CSKH_SSP.ViewModels.ListRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.AdminServices
{
    public class StatisticServices : IStatisticServices
    {
        private DataContext _context;
        public StatisticServices(DataContext context)
        {
            _context = context;
        }
        public int countProcessingTaskOfUser(int UserID)
        {
            var ProcessingRequest = _context.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusProcessing);
            var UserObject = _context.User.Where(x => x.UserID == UserID).FirstOrDefault();
            List<string> listRequest = new List<string>();

            foreach (var i in ProcessingRequest)
            {
                var a = _context.RequestPermission
                    .Where(x =>
                    ((x.DepartmentID == UserObject.DepartmentID && x.Meta == StringLibrary.DepartmentAssignMetaString) ||
                      (x.UserName == UserObject.UserName && (x.Meta == StringLibrary.UserAssignMetaString || x.Meta == StringLibrary.UserAssignMetaStringLv2 || x.Meta == StringLibrary.UserAssignMetaStringLv3))) && x.RequestID == i.RequestID);
                foreach (var item in a)
                {
                    listRequest.Add(item.RequestID);
                }
            }
            return listRequest.Count;
        }

        public List<ListRequestTicket> ListRequestOfUser(int UserID)
        {
            List<ListRequestTicket> listRequest = new List<ListRequestTicket>();

            try
            {
                var UserObject = _context.User.Where(x => x.UserID == UserID).FirstOrDefault();
                var listRequestPermissionOfUser = _context.RequestPermission.Where(x =>
                       ((x.DepartmentID == UserObject.DepartmentID && x.Meta == StringLibrary.DepartmentAssignMetaString) ||
                         (x.UserName == UserObject.UserName && (x.Meta == StringLibrary.UserAssignMetaString || x.Meta == StringLibrary.UserAssignMetaStringLv2 || x.Meta == StringLibrary.UserAssignMetaStringLv3)))).Select(x => x.RequestID).Distinct();

                foreach (var item in listRequestPermissionOfUser)
                {
                    ListRequestTicket temp = new ListRequestTicket();
                    var b = _context.Request.Where(x => x.RequestID == item).FirstOrDefault();
                    if(b != null)
                    {
                        temp.RequestID = b.RequestID;
                        temp.RequestTittle = b.RequestTittle;
                        temp.RequestStatus = b.RequestStatus;
                        temp.FinishDay = b.FinishTime;
                        temp.RequestDay = b.RequestDay;
                        listRequest.Add(temp);
                    }
                }
                return listRequest;
            } catch (Exception e) {
                var a = e;
                return listRequest;
            }
            
        }
    }
}
