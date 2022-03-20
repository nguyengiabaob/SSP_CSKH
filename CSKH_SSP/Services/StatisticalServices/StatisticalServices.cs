using CSKH_SSP.Constant;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IStatisticalServices;
using CSKH_SSP.ViewModels.Statistical;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.StatisticalServices
{

    public class StatisticalServices : IStatisticalServices
    {
        private readonly DataContext _dataContext;

        public StatisticalServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static int CompareDate(DateTime? date1, DateTime? date2)
        {
            if (date1.HasValue == false)
                date1 = DateTime.Now;
            if (date2.HasValue == false)
                date2 = DateTime.Now;
            return DateTime.Compare((DateTime)date1, (DateTime)date2);
        }
   
        public bool? CompareDateResponse(string RequestId)
        {
            var req = _dataContext.Request.Where(x => x.RequestID == RequestId).FirstOrDefault();
            if (req.RequestStatus != StringLibrary.RequestStatusClosed && req.RequestStatus != StringLibrary.RequestStatusDone)
                return null;

            DateTime dateTime;
            if (req.FinishTime == null)
                return null;
            else dateTime = (DateTime)req.FinishTime;
            if(req.TimeDone == null)
            {
                return null;
            }
            if (req.ReceiverTime == null)
                return null;

            var hours_Priority = _dataContext.DeadlineConfig.Where(x => x.CategoryId == req.Category && x.PriorityId == req.Priority).FirstOrDefault();
            var hours_Category = _dataContext.Category.Where(x => x.IDCategory == req.Category && x.isActive == true).FirstOrDefault(); 
            int Hour_Deadline = 0;
            if (hours_Priority != null)
            {
                if (hours_Category != null)
                {
                    var hours_Parent = _dataContext.Category.Where(x => x.IDCategory == hours_Category.ParentId && x.isActive == true).FirstOrDefault();
                    if (hours_Parent != null)
                    {
                        Hour_Deadline = (int)hours_Priority.Hours + hours_Parent.HoursResolve!= null? (int)hours_Parent.HoursResolve : 0;
                    }
                    else
                    {
                        Hour_Deadline = (int)hours_Priority.Hours ;
                    }
                }
                //Hour_Deadline = (int)hours_Priority.Hours + (int)hours_Category.HoursResolve;
            }
            else
            {
                if (hours_Category != null)
                {
                    var hours_Parent = _dataContext.Category.Where(x => x.IDCategory == hours_Category.ParentId && x.isActive == true).FirstOrDefault();
                    if (hours_Parent != null)
                    {
                        Hour_Deadline =  hours_Parent.HoursResolve != null ? (int)hours_Parent.HoursResolve : 16;
                    }
                    else
                    {
                        Hour_Deadline =  hours_Category.HoursResolve != null ? (int)hours_Parent.HoursResolve : 16;
                    }
                }
                else
                {
                    Hour_Deadline = 16;
                }
            }

            //var hour_now = Hour_Deadline  -(16 +dateTime.Hour);

            //var hour_now = Hour_Deadline - ( 16  + dateTime.Hour);

            var hour_now = Helpers.Helpers.GetCountTime((DateTime)req.ReceiverTime, (DateTime)req.TimeDone);
            //var days_remain = hour_now / 8;
            //var hour_remain = (hour_now % 8) + 8;

            //var tempDay = DateTime.Now.AddDays((double)days_remain + 1).Date;
            //var dayDone = tempDay.AddHours((double)hour_remain);

            if (hour_now > Hour_Deadline) {
                return false;
            } else
            {
                return true;    
            }
        }
        public List<Statistical> StatisticalRequest(DateTime? startDay, DateTime? endDate, DateTime? startDoneDay, DateTime? endDoneDate, string CustomerId, string TicketID, string ContractID, string UserAssign, string Category, string Status, bool IsPrivate)
        {
            //true false
            List<Statistical> res = new List<Statistical>();
            var aa = _dataContext.Request.Where(req => (req.RequestDay >= startDay || !startDay.HasValue) && (req.RequestDay <= endDate || !endDate.HasValue) &&
                        (startDoneDay <= req.TimeDone || !startDoneDay.HasValue) && (req.TimeDone <= endDoneDate || !endDoneDate.HasValue || req.TimeDone == null) &&
                       (string.IsNullOrEmpty(CustomerId) || req.TicketCustomerID.Contains(CustomerId)) &&
                                                      (string.IsNullOrEmpty(TicketID) || req.TicketID.Contains(TicketID)) &&
                                                      (string.IsNullOrEmpty(Category) || req.Category.ToString() == Category) &&
                                                      (string.IsNullOrEmpty(Status) || req.RequestStatus == Status) &&
                                                      (string.IsNullOrEmpty(ContractID) || req.ContractID.Contains(ContractID)) &&
                                                      (req.IsPrivate == IsPrivate)
            ).ToList();

            if (Status != StringLibrary.RequestStatusOpen)
            {
                var permissionMeta = from req in _dataContext.Request
                                     join
    per in _dataContext.RequestPermission.Where(x => x.Meta == StringLibrary.UserAssignMetaString || x.Meta == StringLibrary.UserAssignMetaStringLv2 || x.Meta == StringLibrary.UserAssignMetaStringLv3) on req.RequestID equals per.RequestID
                                     join user in _dataContext.User on per.UserName equals user.UserName
                                     select new { UserId = user.UserID, UserName = user.UserName, Meta = per.Meta, RequestId = req.RequestID };



                res = (from req in _dataContext.Request
                       join reqContent in _dataContext.RequestContent on req.RequestID equals reqContent.RequestID
                       join category in _dataContext.Category on req.Category equals category.IDCategory
                       join per in permissionMeta on req.RequestID equals per.RequestId
                       where (req.RequestDay >= startDay || !startDay.HasValue) && (req.RequestDay <= endDate || !endDate.HasValue) &&
                        (startDoneDay <= req.TimeDone || !startDoneDay.HasValue) && (req.TimeDone <= endDoneDate || !endDoneDate.HasValue || req.TimeDone == null) &&
                       (string.IsNullOrEmpty(CustomerId) || req.TicketCustomerID.Contains(CustomerId)) &&
                                                      (string.IsNullOrEmpty(TicketID) || req.TicketID.Contains(TicketID)) &&
                                                      (string.IsNullOrEmpty(Category) || req.Category.ToString() == Category) && //ngu nguoi
                                                      (string.IsNullOrEmpty(Status) || req.RequestStatus == Status) &&
                                                      (string.IsNullOrEmpty(ContractID) || req.ContractID.Contains(ContractID))
                       && reqContent.IsTimelinePoint != true
                       select new Statistical
                       {
                           RequestID = req.RequestID,
                           RequestComment = reqContent.ContentRequest,
                           RequestAuthorFullName = req.RequestAuthorFullName,
                           RequestAuthorUserName = req.RequestAuthorUserName,
                           RequestAuthorEmail = req.RequestAuthorEmail,
                           RequestTittle = req.RequestTittle,
                           RequestDay = req.RequestDay,
                           RequestContent = req.RequestContent,
                           RequestStatus = req.RequestStatus,
                           Feedback = req.Feedback,
                           Rating = req.Rating,
                           ReasonNote = req.ReasonNote,
                           TicketID = req.TicketID,
                           TicketCustomerID = req.TicketCustomerID,
                           ContractID = req.ContractID,
                           CategoryName = category.CategoryName,
                           AssignBy = per.Meta == StringLibrary.UserAssignMetaString ? per.UserName : "",
                           AssignLv2 = per.Meta == StringLibrary.UserAssignMetaStringLv2 ? per.UserName : "",
                           AssignLv3 = per.Meta == StringLibrary.UserAssignMetaStringLv3 ? per.UserName : "",
                           TimeDone = req.TimeDone,
                           IsPrivate = req.IsPrivate,
                           SLAResponse = CompareDate(req.ReceiverTime, req.FinishTime) > 0 ? false : true,
                          // SLAResolve = CompareDateResponse(req.RequestID),
                       }).ToList();
                if (!string.IsNullOrEmpty(UserAssign))
                {
                    var list = _dataContext.RequestPermission.Where(x => (x.UserName == UserAssign || string.IsNullOrEmpty(UserAssign)) && x.Meta == StringLibrary.UserAssignMetaString).Select(x => x.RequestID);
                    res = res.Where(x => list.Contains(x.RequestID)).ToList();
                }

            }
            else
            {
                res = (from req in _dataContext.Request
                       join reqContent in _dataContext.RequestContent on req.RequestID equals reqContent.RequestID
                       join category in _dataContext.Category on req.Category equals category.IDCategory
                       where (req.RequestDay >= startDay || !startDay.HasValue) && (req.RequestDay <= endDate || !endDate.HasValue) &&
                       (startDoneDay <= req.TimeDone || !startDoneDay.HasValue) && (req.TimeDone <= endDoneDate || !endDoneDate.HasValue) &&
                       (string.IsNullOrEmpty(CustomerId) || req.TicketCustomerID.Contains(CustomerId)) &&
                                                      (string.IsNullOrEmpty(TicketID) || req.TicketID.Contains(TicketID)) &&
                                                      (string.IsNullOrEmpty(Category) || req.Category.ToString() == Category) &&
                                                      (string.IsNullOrEmpty(Status) || req.RequestStatus == Status) &&
                                                      (string.IsNullOrEmpty(ContractID) || req.ContractID.Contains(ContractID))
                       select new Statistical
                       {
                           RequestID = req.RequestID,
                           RequestComment = reqContent.ContentRequest,
                           RequestAuthorFullName = req.RequestAuthorFullName,
                           RequestAuthorUserName = req.RequestAuthorUserName,
                           RequestAuthorEmail = req.RequestAuthorEmail,
                           RequestTittle = req.RequestTittle,
                           RequestDay = req.RequestDay,
                           RequestContent = req.RequestContent,
                           RequestStatus = req.RequestStatus,
                           Feedback = req.Feedback,
                           Rating = req.Rating,
                           ReasonNote = req.ReasonNote,
                           TicketID = req.TicketID,
                           TicketCustomerID = req.TicketCustomerID,
                           ContractID = req.ContractID,
                           TimeDone = req.TimeDone,
                           CategoryName = category.CategoryName,
                           IsPrivate = req.IsPrivate
                       }).ToList();
            }

            foreach(var i in res)
            {
                i.SLAResolve = CompareDateResponse(i.RequestID);
            }

            res = res.GroupBy(l => new
            {
                l.RequestID,
                l.RequestAuthorFullName,
                l.RequestAuthorUserName,
                l.RequestAuthorEmail,
                l.RequestTittle,
                l.RequestDay,
                l.RequestContent,
                l.RequestStatus,
                l.Feedback,
                l.Rating,
                l.ReasonNote,
                l.TicketID,
                l.TicketCustomerID,
                l.ContractID,
                l.CategoryName,
                l.TimeDone,
                l.RequestComment,
                l.IsPrivate,
                l.SLAResponse,
                l.SLAResolve
            })
             .Where(x => IsPrivate ? (x.Key.IsPrivate == IsPrivate) : (x.Key.IsPrivate == true || x.Key.IsPrivate == false))
             .Select(g => new Statistical
             {
                 IsPrivate = g.Key.IsPrivate,
                 RequestID = g.Key.RequestID,
                 RequestComment = g.Key.RequestComment,
                 RequestAuthorFullName = g.Key.RequestAuthorFullName,
                 RequestAuthorUserName = g.Key.RequestAuthorUserName,
                 RequestAuthorEmail = g.Key.RequestAuthorEmail,
                 RequestTittle = g.Key.RequestTittle,
                 RequestDay = g.Key.RequestDay,
                 RequestContent = g.Key.RequestContent,
                 RequestStatus = g.Key.RequestStatus,
                 Feedback = g.Key.Feedback,
                 Rating = g.Key.Rating,
                 ReasonNote = g.Key.ReasonNote,
                 TicketID = g.Key.TicketID,
                 TimeDone = g.Key.TimeDone,
                 TicketCustomerID = g.Key.TicketCustomerID,
                 ContractID = g.Key.ContractID,
                 CategoryName = g.Key.CategoryName,
                 SLAResponse = g.Key.SLAResponse,
                 SLAResolve = g.Key.SLAResolve,
                 AssignBy = string.Join(",", g.Select(i => i.AssignBy).Distinct())
             }).ToList();

            return res;
        }
    }
}
