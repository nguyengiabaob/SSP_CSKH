using CSKH_SSP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Helpers;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ListRequest;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.Constant;
using CSKH_SSP.Interfaces.INotificationsServices;
using Microsoft.EntityFrameworkCore.Internal;

namespace CSKH_SSP.Services
{
    public class RequestListServices : IRequestListServices
    {
        private DataContext _dataContext;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;
        private readonly IRequestContentBodyServices _requestContentBodyServices;
        private readonly INotificationServices _notificationServices;

        public RequestListServices(DataContext dataContext, ICheckGroupUserPermissionServices checkGroupUserPermissionServices, IRequestContentBodyServices requestContentBodyServices, INotificationServices notificationServices)
        {
            _dataContext = dataContext;
            _requestContentBodyServices = requestContentBodyServices;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
            _notificationServices = notificationServices;
        }
        public (List<ListRequestTicket> ListRequestTickets, int TotalRequest, bool isLastItem) GetListRequest(int GroupUserID, string UserName, int? mention, string statusRequest, int pageNumber, string text, string category, string pri)
        {
            int getResolvedTinme(int CategoryId, int pri)
            {
                int result = 0;
                var category = _dataContext.Category.Where(x => x.IDCategory == CategoryId).FirstOrDefault();
                if(category!= null)
                {
                    if(category.ParentId != null)
                    {
                        var Hour_Parent = _dataContext.Category.Where(x => x.IDCategory == category.ParentId).FirstOrDefault();
                        if(Hour_Parent!=null)
                        {
                            result += Hour_Parent.HoursResolve != null ? (int)Hour_Parent.HoursResolve : 16;
                        }
                      
                    }
                    else
                    {
                        result += category.HoursResolve != null ? (int)category.HoursResolve : 16;
                    }
                }
                var c = _dataContext.Priority.Where(x => x.ID == pri).FirstOrDefault();
                if(c!=null)
                {
                    result += c.Hours;
                }
                return result;
            }
            int getReponseTinme(int CategoryId, int pri)
            {
                int result = 0;
                var category = _dataContext.Category.Where(x => x.IDCategory == CategoryId).FirstOrDefault();
                if (category != null)
                {
                    if (category.ParentId != null)
                    {
                        var Hour_Parent = _dataContext.Category.Where(x => x.IDCategory == category.ParentId).FirstOrDefault();
                        if (Hour_Parent != null)
                        {
                            result += Hour_Parent.HoursDeadline != null ? (int)Hour_Parent.HoursDeadline : 16;
                        }

                    }
                    else
                    {
                        result += category.HoursDeadline != null ? (int)category.HoursDeadline : 16;
                    }
                }
                var c = _dataContext.Priority.Where(x => x.ID == pri).FirstOrDefault();
                if (c != null)
                {
                    result += c.Hours;
                }
                return result;
            }
            if (statusRequest == StringLibrary.MyNotification)
                mention = 1;
            if (statusRequest == StringLibrary.MyPinned)
                mention = 2;

            int Size = pageNumber;
            bool isLastItem = false;
            var isAdmin = _checkGroupUserPermissionServices.IsAdmin(GroupUserID);
            var isStaff = _checkGroupUserPermissionServices.IsStaff(GroupUserID);


            List<ListRequestTicket> listTicket = new List<ListRequestTicket>();
            int minPage; int maxPage; int totalRequest;
            IQueryable<ListRequestTicket> listReq;
            if (mention == 1)
            {
                var query = (from a in _dataContext.Request
                             from b in _dataContext.Category
                             from c in _dataContext.Notification
                             where (c.UserName == UserName && c.requestID == a.RequestID && a.Category == b.IDCategory) &&
                             ((a.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (a.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (a.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                             select new ListRequestTicket
                             {
                                 RequestID = a.RequestID,
                                 RequestStatus = a.RequestStatus,
                                 RequestTittle = a.RequestTittle,
                                 RequestAuthor = a.RequestAuthorFullName,
                                 RequestDay = a.RequestDay,
                                 ReceiverTime= a.ReceiverTime,
                                 FinishDay = a.FinishTime,
                                 RequestCategory = b.CategoryName,
                                 CategoryID = b.IDCategory,
                                 RequestPriority = a.Priority ?? 2,
                                 attFile = a.hasAttFile ?? false,
                                 isReadOnChange = c.isRead,
                                 TimeDone = a.TimeDone
                             });
                totalRequest = query.Count();
                //listReq = query.OrderByDescending(x => x.TimeDone).Skip((pageNumber - 1) * Size).Take(Size);
                //var totalPage = (query.Count() + Size - 1) / Size;
                listReq = query.Take(Size);
                //totalRequest = totalPage;
                //minPage = GetPagingRange(pageNumber, totalPage, Size).min;
                //maxPage = GetPagingRange(pageNumber, totalPage, Size).max;

            }
            else if (mention == 2)
            {
                //var RequestPinned = _dataContext.RequestPinned.Where(x => x.UserName == UserName).Select(x => x.RequestID);

                var query = (from a in _dataContext.Request
                             from d in _dataContext.RequestPinned
                             from b in _dataContext.Category
                             where (d.UserName == UserName && d.RequestID == a.RequestID && a.Category == b.IDCategory) &&
                             ((a.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (a.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (a.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                             select new ListRequestTicket
                             {
                                 RequestID = a.RequestID,
                                 RequestStatus = a.RequestStatus,
                                 RequestTittle = a.RequestTittle,
                                 RequestAuthor = a.RequestAuthorFullName,
                                 RequestDay = a.RequestDay,
                                 ReceiverTime = a.ReceiverTime,
                                 FinishDay = a.FinishTime,
                                 RequestCategory = b.CategoryName,
                                 CategoryID = b.IDCategory,
                                 RequestPriority = a.Priority ?? 2,
                                 attFile = a.hasAttFile ?? false,
                                 //isReadOnChange = c.isRead,
                                 TimeDone = a.TimeDone
                             });
                totalRequest = query.Count();
                //listReq = query.OrderByDescending(x => x.TimeDone).Skip((pageNumber - 1) * Size).Take(Size);
                //var totalPage = (query.Count() + Size - 1) / Size;
                listReq = query.Take(Size);
                //totalRequest = totalPage;
                //minPage = GetPagingRange(pageNumber, totalPage, Size).min;
                //maxPage = GetPagingRange(pageNumber, totalPage, Size).max;
            }
            else
            {
                if (statusRequest == null)
                {
                    statusRequest = StringLibrary.RequestStatusOpen;
                }
                if (isAdmin)
                {
                    IQueryable<ListRequestTicket> query;
                    var listReqIncidents = _dataContext.RequestIncident.Select(x => x.RequestId).ToList();
                    if (statusRequest == "incident")
                    {
                        query = (from a in _dataContext.Request.Where(x => listReqIncidents.Contains(x.RequestID))
                                 from b in _dataContext.Category
                                 where a.Category == b.IDCategory &&
                                 ((a.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (a.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (a.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                                 select new ListRequestTicket { RequestID = a.RequestID, RequestStatus = a.RequestStatus, RequestTittle = a.RequestTittle, RequestAuthor = a.RequestAuthorFullName, RequestDay = a.RequestDay, FinishDay = a.FinishTime, CategoryID = b.IDCategory, RequestCategory = b.CategoryName, RequestPriority = a.Priority ?? 2, attFile = a.hasAttFile ?? false, TimeDone = a.TimeDone, ReceiverTime = a.ReceiverTime }); ;
                    }
                    else
                    {
                        query = (from a in _dataContext.Request
                                 from b in _dataContext.Category
                                 where a.RequestStatus == statusRequest && a.Category == b.IDCategory &&
                                 ((a.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (a.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (a.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                                 select new ListRequestTicket { RequestID = a.RequestID, RequestStatus = a.RequestStatus, RequestTittle = a.RequestTittle, RequestAuthor = a.RequestAuthorFullName, RequestDay = a.RequestDay, FinishDay = a.FinishTime, CategoryID = b.IDCategory, RequestCategory = b.CategoryName, RequestPriority = a.Priority ?? 2, attFile = a.hasAttFile ?? false, TimeDone = a.TimeDone, ReceiverTime = a.ReceiverTime });
                    }

                    if (statusRequest == StringLibrary.RequestStatusDone)
                    {
                        listReq = query.OrderByDescending(x => x.TimeDone).Take(Size);
                    }
                    else
                    {
                        listReq = query.Take(Size);
                    }
                    //if (!exportExcel)
                    //    Size = query.Count();
                    totalRequest = query.Count();
                    //var totalPage = (query.Count() + Size - 1) / Size;

                    //totalRequest = totalPage;
                    //minPage = GetPagingRange(pageNumber, totalPage, Size).min;
                    //maxPage = GetPagingRange(pageNumber, totalPage, Size).max;
                    //}
                }
                else if (isStaff)
                {
                    var CurrentUser = _dataContext.User.Where(x => x.UserName == UserName).FirstOrDefault();
                    var ListRequestPermission = _dataContext.RequestPermission.Where(x => (x.DepartmentID == CurrentUser.DepartmentID && x.UserName == null) || (x.UserName == CurrentUser.UserName && (x.DepartmentID == null || x.DepartmentID == 0))).Select(x => x.RequestID);
                    var testlist = ListRequestPermission.ToList();
                    var List_1 = _dataContext.Request.Where(x => x.createByUserName == UserName);
                    var List_2 = _dataContext.Request.Where(x => x.RequestStatus == statusRequest && ListRequestPermission.Contains(x.RequestID));
                    var List_22 = _dataContext.Request.Where(x => x.RequestStatus == statusRequest && ListRequestPermission.Contains(x.RequestID)).ToList();

                    var ListRequestInCategoryPermission = _dataContext.CategoryPermission.Where(x => x.UserName == UserName || x.UserNameFollow == UserName).Select(x => x.IDCategory);
                    var List_3 = _dataContext.Request.Where(x => ListRequestInCategoryPermission.Contains(x.Category));

                    var ListRequestUserCanView = List_2.Concat(List_3).Concat(List_1);

                    if (statusRequest == StringLibrary.RequestStatusOpen)
                    {
                        var query = (from request in ListRequestUserCanView
                                     from c in _dataContext.Category
                                     where request.RequestStatus == statusRequest && request.Category == c.IDCategory &&
                                     ((request.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (request.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (request.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                                     select new ListRequestTicket { RequestID = request.RequestID, RequestStatus = request.RequestStatus, RequestTittle = request.RequestTittle, RequestAuthor = request.RequestAuthorFullName, RequestDay = request.RequestDay, FinishDay = request.FinishTime, CategoryID = c.IDCategory, RequestCategory = c.CategoryName, RequestPriority = request.Priority ?? 2, attFile = request.hasAttFile ?? false, TimeDone = request.TimeDone, ReceiverTime = request.ReceiverTime });
                        totalRequest = query.Count();
                        listReq = query.Take(Size);
                        //var totalPage = (query.Count() + Size - 1) / Size;
                        //totalRequest = totalPage;
                        //minPage = GetPagingRange(pageNumber, totalPage, Size).min;
                        //maxPage = GetPagingRange(pageNumber, totalPage, Size).max;
                    }
                    else if (statusRequest == StringLibrary.RequestStatusClosed)
                    {
                        var query = (from b in ListRequestUserCanView
                                     from c in _dataContext.Category
                                     where b.RequestStatus == statusRequest && b.Category == c.IDCategory &&
                                     ((b.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (b.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (b.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                                     select new ListRequestTicket { RequestID = b.RequestID, RequestStatus = b.RequestStatus, RequestTittle = b.RequestTittle, RequestAuthor = b.RequestAuthorFullName, RequestDay = b.RequestDay, FinishDay = b.FinishTime, CategoryID = c.IDCategory, RequestCategory = c.CategoryName, RequestPriority = b.Priority ?? 2, attFile = b.hasAttFile ?? false, TimeDone = b.TimeDone, ReceiverTime = b.ReceiverTime }).OrderByDescending(x => x.TimeDone);
                        listReq = query.OrderByDescending(x => x.TimeDone).Take(Size);
                        totalRequest = query.Count();
                        //var totalPage = (query.Count() + Size - 1) / Size;
                        //totalRequest = totalPage;
                        //minPage = GetPagingRange(pageNumber, totalPage, Size).min;
                        //maxPage = GetPagingRange(pageNumber, totalPage, Size).max;
                    }
                    else
                    {
                        var query = (from a in _dataContext.Request
                                     join b in _dataContext.RequestPermission on a.RequestID equals b.RequestID
                                     join c in _dataContext.Category on a.Category equals c.IDCategory
                                     where ((b.UserName == UserName || b.DepartmentID == CurrentUser.DepartmentID) && b.RequestID == a.RequestID && c.IDCategory == a.Category && a.RequestStatus == statusRequest) &&
                                     ((a.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (a.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (a.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                                     select new ListRequestTicket { RequestID = a.RequestID, RequestStatus = a.RequestStatus, RequestTittle = a.RequestTittle, RequestAuthor = a.RequestAuthorFullName, RequestDay = a.RequestDay, FinishDay = a.FinishTime, RequestCategory = c.CategoryName, CategoryID = c.IDCategory, RequestPriority = a.Priority ?? 2, attFile = a.hasAttFile ?? false, ReceiverTime = a.ReceiverTime }).Distinct();




                        //listReq = query;
                        //if (statusRequest == StringLibrary.RequestStatusDone)
                        //{
                        //    listReq = query.OrderByDescending(x => x.TimeDone).Take(Size);
                        //}
                        //else
                        //{
                        //    listReq = query.OrderByDescending(x => x.RequestID).Take(Size);
                        //}
                        listReq = query.OrderByDescending(x => x.RequestID).Take(Size);
                        totalRequest = query.Count();
                        //var totalPage = (query.Count() + Size - 1) / Size;
                        //totalRequest = totalPage;
                        //minPage = GetPagingRange(pageNumber, totalPage, Size).min;
                        //maxPage = GetPagingRange(pageNumber, totalPage, Size).max;
                    }
                }
                else
                {
                    IQueryable<Requestinfo> listReqInCategoryFollowByUser = _dataContext.Request;
                    var listReqCreateByUser = _dataContext.Request.Where(x => x.createByUserName == UserName).Select(x => x.RequestID);
                    var listReqFollowByUser = _dataContext.RequestPermission.Where(x => x.UserName == UserName).Select(x => x.RequestID);
                    var listCategoryFollowByUser = _dataContext.CategoryPermission.Where(x => x.UserNameFollow == UserName).Select(x => x.IDCategory);
                    if (listCategoryFollowByUser != null)
                    {
                        listReqInCategoryFollowByUser = _dataContext.Request.Where(x => listCategoryFollowByUser.Contains(x.Category));
                    }

                    List<string> listIDReq = new List<string>();
                    if (listReqCreateByUser != null)
                    {
                        foreach (var item in listReqCreateByUser)
                        {
                            listIDReq.Add(item);
                        }
                    }
                    if (listReqFollowByUser != null)
                    {
                        foreach (var item in listReqFollowByUser)
                        {
                            listIDReq.Add(item);
                        }
                    }
                    if (listReqInCategoryFollowByUser != null)
                    {
                        foreach (var item in listReqInCategoryFollowByUser)
                        {
                            listIDReq.Add(item.RequestID);
                        }
                    }
                    var req = _dataContext.Request.Where(t => listIDReq.Contains(t.RequestID));
                    var query = (from a in req
                                 from b in _dataContext.Category
                                 where a.RequestStatus == statusRequest && a.Category == b.IDCategory &&
                                 ((a.RequestTittle.Contains(text) || string.IsNullOrEmpty(text)) || (a.createByUserName.Contains(text) || string.IsNullOrEmpty(text)) || (a.RequestID.Contains(text) || string.IsNullOrEmpty(text)))
                                 select new ListRequestTicket { RequestID = a.RequestID, RequestStatus = a.RequestStatus, RequestTittle = a.RequestTittle, RequestAuthor = a.RequestAuthorFullName, RequestDay = a.RequestDay, FinishDay = a.FinishTime, CategoryID = b.IDCategory, RequestCategory = b.CategoryName, RequestPriority = a.Priority ?? 2, attFile = a.hasAttFile ?? false, TimeDone = a.TimeDone, ReceiverTime = a.ReceiverTime }).Take(Size);

                    if (statusRequest == StringLibrary.RequestStatusDone)
                    {
                        listReq = query.OrderByDescending(x => x.TimeDone).Take(Size);
                    }
                    else
                    {
                        listReq = query.Take(Size);
                    }

                    //listReq = query.Take(Size);
                    totalRequest = query.Count();
                    //var totalPage = (query.Count() + Size - 1) / Size;
                    //totalRequest = totalPage;
                    //minPage = GetPagingRange(pageNumber, totalPage, Size).min;
                    //maxPage = GetPagingRange(pageNumber, totalPage, Size).max;
                }
            }
            if (!string.IsNullOrEmpty(category) && category != "undefined")
            {
                var temp = int.Parse(category);
                listReq = listReq.Where(x => x.CategoryID == temp);
            }
            if (!string.IsNullOrEmpty(pri) && pri != "undefined")
            {
                var temp = int.Parse(pri);
                listReq = listReq.Where(x => x.RequestPriority == temp);
            }
            var count = (from a in _dataContext.Request
                         from b in _dataContext.Category
                         where a.RequestStatus == statusRequest && a.Category == b.IDCategory
                         select new ListRequestTicket { RequestID = a.RequestID, RequestStatus = a.RequestStatus, RequestTittle = a.RequestTittle, RequestAuthor = a.RequestAuthorFullName, RequestDay = a.RequestDay, FinishDay = a.FinishTime, CategoryID = b.IDCategory, RequestCategory = b.CategoryName, RequestPriority = a.Priority ?? 2 }).OrderByDescending(x => x.RequestPriority).ThenByDescending(x => x.RequestDay).Count();

            //if (statusRequest != StringLibrary.RequestStatusClosed)
            //{
            //    listReq = listReq.OrderByDescending(x => x.RequestPriority).ThenByDescending(x => x.RequestDay);
            //}
            foreach (var i in listReq)
            {
                ListRequestTicket obj = new ListRequestTicket();
                obj.RequestID = i.RequestID;
                obj.RequestStatus = i.RequestStatus;
                obj.RequestTittle = i.RequestTittle;
                obj.RequestAuthor = i.RequestAuthor;
                obj.RequestDay = i.RequestDay;
                obj.FinishDay = i.FinishDay;
               
                if(i.RequestStatus== StringLibrary.RequestStatusProcessing)
                {
                    double t = 0;
                    DateTime recivertemp = i.ReceiverTime ?? DateTime.Now;
                    if(i.ReceiverTime== null && DateTime.Compare(recivertemp, (DateTime)i.FinishDay)>0)
                    {
                        obj.isDeadLine = "HetHan";
                    }
                    else
                    {
                        DateTime tempDay = i.TimeDone ?? DateTime.Now;
                        //TimeSpan t = tempDay - DateTime.Now;
                        t = Helpers.Helpers.GetCountTime(recivertemp, tempDay);
                        //if (t.TotalDays > 0 && t.TotalDays <= 1)
                        //{
                        //    obj.isDeadLine = "SapHetHan";
                        //    obj.daysRemain = t.TotalDays.ToString();
                        //}
                        if ((t / 60) > getResolvedTinme(i.CategoryID, i.RequestPriority))
                        {
                            obj.isDeadLine = "HetHan";
                            //obj.daysRemain = t.TotalDays.ToString();
                        }
                    }
                   
                }
                else
                {
                    if (i.RequestStatus == StringLibrary.RequestStatusOpen)
                    {
                        double t = 0;
                        DateTime tempDay = i.ReceiverTime ?? DateTime.Now;
                        //TimeSpan t = tempDay - DateTime.Now;
                        t = Helpers.Helpers.GetCountTime( (DateTime)i.RequestDay, tempDay);
                        //if (t.TotalDays > 0 && t.TotalDays <= 1)
                        //{
                        //    obj.isDeadLine = "SapHetHan";
                        //    obj.daysRemain = t.TotalDays.ToString();
                        //}
                        if ((t / 60) > getReponseTinme(i.CategoryID, i.RequestPriority))
                        {
                            obj.isDeadLine = "HetHan";
                            //obj.daysRemain = t.TotalDays.ToString();
                        }
                    }
                }

               
                //else
                //{
                //    //obj.daysRemain = Math.Abs(t.Days).ToString();

                //}
                if (_notificationServices.isRequestHasOnchange(i.RequestID, UserName))
                {
                    obj.isReadOnChange = false;
                }
                else
                {
                    obj.isReadOnChange = true;
                }
                obj.CategoryID = i.CategoryID;
                obj.RequestCategory = i.RequestCategory;
                obj.RequestPriority = i.RequestPriority;
                obj.CountNewMess = CountNewMessage(UserName, i.RequestID);
                obj.attFile = i.attFile;
                obj.TimeDone = i.TimeDone;
                obj.UserAssign = _requestContentBodyServices.GetUserAssign(i.RequestID);
                obj.UserFollow = _requestContentBodyServices.GetUserFollow(i.RequestID);
                obj.DepartmentAssign = _requestContentBodyServices.GetDepartmentAssign(i.RequestID);
                listTicket.Add(obj);
            }
            // var countA = listTicket.Count;

            var finalList = listTicket.GroupBy(x => x.RequestID).Select(x => x.First()).OrderByDescending(x => x.isReadOnChange);
            if (Size >= count)
                isLastItem = true;
            else
                isLastItem = false;

            if (statusRequest == StringLibrary.RequestStatusDone)
                return (finalList.OrderByDescending(x => x.RequestID).ThenByDescending(x => x.daysRemain).ThenByDescending(x => x.RequestPriority).ToList(), totalRequest, isLastItem);
            //if (statusRequest == StringLibrary.RequestStatusDone)
            //  return (finalList.OrderByDescending(x => x.TimeDone).ThenByDescending(x => x.RequestID).ThenByDescending(x => x.daysRemain).ThenByDescending(x => x.RequestPriority).ToList(), totalRequest, isLastItem);
            //if (statusRequest == StringLibrary.RequestStatusDone) return (finalList.ToList(), totalRequest, isLastItem);
            return (finalList.OrderByDescending(x => x.isDeadLine).ThenByDescending(x => x.daysRemain).ThenByDescending(x => x.RequestPriority).ToList(), totalRequest, isLastItem);

        }
        public int CountNewMessage(string UserName, string ReqID)
        {
            var count = _dataContext.CountNewMessageForUser.Where(x => x.RequestID == ReqID && x.UserName == UserName).FirstOrDefault();
            if (count != null)
            {
                return count.CountMess;
            }
            else
            {
                return 0;
            }
        }
        public (int min, int max) GetPagingRange(int currentPage, int totalPages, int numbersToShow)
        {
            //if (currentPage < 1 || totalPages < 1 || currentPage > totalPages) throw new ArgumentException();
            //if (numbersToShow < 1) throw new ArgumentException();
            var min = Math.Max(1, currentPage - numbersToShow / 2);
            var max = Math.Min(totalPages, currentPage + numbersToShow / 2 + Math.Max(0, min - currentPage + numbersToShow / 2));
            return (min, max);
        }
    }
}
