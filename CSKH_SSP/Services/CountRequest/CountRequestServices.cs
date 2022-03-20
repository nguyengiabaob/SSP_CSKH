using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.Interfaces.ICountRequest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Constant;
using CSKH_SSP.ViewModels.ListRequest;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.CountRequest;

namespace CSKH_SSP.Services.CountRequest {
    public class CountRequestServices : ICountRequestServices {
        private readonly DataContext _dataContext;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;

        public CountRequestServices(DataContext dataContext, ICheckGroupUserPermissionServices checkGroupUserPermissionServices) {
            _dataContext = dataContext;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
        }

        public CountRequestStatus CountNotification(int GroupUserID, string UserName) {
            CountRequestStatus CountObject = new CountRequestStatus();
            int countOpen, countProcessing, countClosed, countReject, countMention, countDone;
            if (_checkGroupUserPermissionServices.IsAdmin(GroupUserID)) {
                countOpen = _dataContext.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusOpen).Count();
                countProcessing = _dataContext.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusProcessing).Count();
                countClosed = _dataContext.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusClosed).Count();
                countDone = _dataContext.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusDone).Count();
                countReject = _dataContext.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusReject).Count();
                //countMention = _dataContext.CountNewMessageForUser.Where(x => x.UserID == UserID).Count();
                countMention = _dataContext.Notification.Where(x => x.UserName == UserName).Select(x => new { temp = x.requestID }).Select(x => x.temp).Distinct().Count();
            }
            else {
                if (_checkGroupUserPermissionServices.IsStaff(GroupUserID)) {
                    var CurrentDepartmentIDOfUser = _dataContext.User.Where(x => x.UserName == UserName).Select(x => x.DepartmentID).FirstOrDefault();

                    var ListRequestPermission = _dataContext.RequestPermission.Where(x => x.DepartmentID == CurrentDepartmentIDOfUser && x.UserName == null).Select(x => x.RequestID);

                    var List_1 = _dataContext.Request.Where(x => x.createByUserName == UserName);

                    var List_2 = _dataContext.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusOpen && ListRequestPermission.Contains(x.RequestID));

                    var ListRequestInCategoryPermission = _dataContext.CategoryPermission.Where(x => x.UserName == UserName || x.UserNameFollow == UserName).Select(x => x.IDCategory);

                    var List_3 = _dataContext.Request.Where(x => ListRequestInCategoryPermission.Contains(x.Category));

                    var ListRequestUserCanView = List_2.Concat(List_3).Concat(List_1).Distinct();
                    //var Categorypermission = _dataContext.CategoryPermission.Where(x => x.IDUser == UserID).ToList();
                    // = ListRequestUserCanView.Where(x => x.RequestStatus == StringLibrary.RequestStatusOpen).Count();
                    //countOpen = (from a in Categorypermission
                    //             from b in _dataContext.Request
                    //             where (a.IDCategory == b.Category && b.RequestStatus == StringLibrary.RequestStatusOpen)
                    //             select new ListRequestTicket { RequestID = b.RequestID }).Count();
                    //countOpen = ListRequestUserCanView.Count();
                    //countOpen = db.Requests.Where(x => x.RequestStatus == "Open").Count();
                    countOpen = _dataContext.Request.Where(x => x.RequestStatus == StringLibrary.RequestStatusOpen).Count();
                    countProcessing = (from a in _dataContext.Request
                                       from b in _dataContext.RequestPermission
                                       where ((b.UserName == UserName || b.DepartmentID == CurrentDepartmentIDOfUser ) && b.RequestID == a.RequestID && a.RequestStatus == StringLibrary.RequestStatusProcessing)
                                       select new ListRequestTicket { RequestID = a.RequestID }).Select(x => x.RequestID).Distinct().Count();
                    

                    countClosed = (from a in _dataContext.Request
                                   from b in _dataContext.RequestPermission
                                   where ((b.UserName == UserName || b.DepartmentID == CurrentDepartmentIDOfUser) && b.RequestID == a.RequestID && a.RequestStatus == StringLibrary.RequestStatusClosed)
                                   select new ListRequestTicket { RequestID = a.RequestID }).Select(x => x.RequestID).Distinct().Count();
                    countDone = (from a in _dataContext.Request
                                   from b in _dataContext.RequestPermission
                                   where ((b.UserName == UserName || b.DepartmentID == CurrentDepartmentIDOfUser) && b.RequestID == a.RequestID && a.RequestStatus == StringLibrary.RequestStatusDone)
                                   select new ListRequestTicket { RequestID = a.RequestID }).Select(x => x.RequestID).Distinct().Count();

                    countReject = (from a in _dataContext.Request
                                   from b in _dataContext.RequestPermission
                                   where ((b.UserName == UserName || b.DepartmentID == CurrentDepartmentIDOfUser) && b.RequestID == a.RequestID && a.RequestStatus == StringLibrary.RequestStatusReject)
                                   select new ListRequestTicket { RequestID = a.RequestID }).Count();
                    //countMention = _dataContext.CountNewMessageForUser.Where(x => x.UserID == UserID).Count();
                    countMention = _dataContext.Notification.Where(x => x.UserName == UserName && x.DepartmentID == 0 ).Select(x => new { temp = x.requestID }).Select(x => x.temp).Distinct().Count();
                    //.Distinct().Count();
                }
                else {
                    IQueryable<Requestinfo> listReqInCategoryFollowByUser = null;
                    var listIDReq = new List<string>();
                    var listReqCreateByUser = _dataContext.Request.Where(x => x.createByUserName == UserName).Select(x => x.RequestID);
                    var listReqFollowByUser = _dataContext.RequestPermission.Where(x => x.UserName == UserName).Select(x => x.RequestID);
                    var listCategoryFollowByUser = _dataContext.CategoryPermission.Where(x => x.UserNameFollow == UserName).Select(x => x.IDCategory);
                    if (listCategoryFollowByUser != null) {
                        listReqInCategoryFollowByUser = _dataContext.Request.Where(x => listCategoryFollowByUser.Contains(x.Category));
                    }
                    if (listReqCreateByUser != null) {
                        foreach (var item in listReqCreateByUser) {
                            listIDReq.Add(item);
                        }
                    }
                    if (listReqFollowByUser != null) {
                        foreach (var item in listReqFollowByUser) {
                            listIDReq.Add(item);
                        }
                    }
                    if (listReqInCategoryFollowByUser != null) {
                        foreach (var i in listReqInCategoryFollowByUser) {
                            listIDReq.Add(i.RequestID);
                        }
                    }
                    var req = _dataContext.Request.Where(t => listIDReq.Contains(t.RequestID));
                    //var a = req.GroupBy(x => x.RequestID);
                    var abc = req.Where(x => x.RequestStatus == StringLibrary.RequestStatusOpen);
                    //if(abc.Any()) {
                    //    countOpen= abc.GroupBy(x => x.RequestID).Count();
                    //} else {
                    //    countOpen = 0;
                    //}
                    countOpen = req.Where(x => x.RequestStatus == StringLibrary.RequestStatusOpen).Select(x => x.RequestID).Distinct().Count();
                    //countOpen = !(req.Where(x => x.RequestStatus == StringLibrary.RequestStatusOpen)).GroupBy(x => x.RequestID).Count();
                    countProcessing = req.Where(x => x.RequestStatus == StringLibrary.RequestStatusProcessing).Select(x => x.RequestID).Distinct().Count();
                    countClosed = req.Where(x => x.RequestStatus == StringLibrary.RequestStatusClosed).Select(x => x.RequestID).Distinct().Count();
                    countDone = req.Where(x => x.RequestStatus == StringLibrary.RequestStatusDone).Select(x => x.RequestID).Distinct().Count();
                    countReject = req.Where(x => x.RequestStatus == StringLibrary.RequestStatusReject).Select(x => x.RequestID).Distinct().Count();
                    countMention = _dataContext.Notification.Where(x => x.UserName == UserName).Select(x => new { temp = x.requestID }).Select(x => x.temp).Distinct().Count();
                }
            }
            
            CountObject.CountOpenStatus = countOpen;
            CountObject.CountProcessingStatus = countProcessing;
            CountObject.CountClosedStatus = countClosed;
            CountObject.CountRejectStatus = countReject;
            CountObject.CountMentionStatus = countMention;
            CountObject.CountDoneStatus = countDone;
            CountObject.CountPinnedRequest = _dataContext.RequestPinned.Count(x => x.UserName == UserName);
            return CountObject;
        }

        public string CountNotificationOfUser(string UserName)
        {
            var temp = _dataContext.User.Where(x => x.UserName == UserName).FirstOrDefault();
           
            if (temp != null)
            {
                var a = CountNotification(temp.GroupUserID, temp.UserName);
                //int countMention = _dataContext.Notification.Where(x => x.UserName == temp.UserName).Select(x => new { temp = x.requestID }).Select(x => x.temp).Distinct().Count();
                //return countMention.ToString();
                return a.CountProcessingStatus.ToString();
            }
            else
            {
                return "Hack by me :))";
            }

        }
    }
}
