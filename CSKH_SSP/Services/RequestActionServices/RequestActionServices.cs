using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using CSKH_SSP.Constant;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.Interfaces.INotificationsServices;
using CSKH_SSP.Interfaces.IRequestActionServices;
using CSKH_SSP.Interfaces.ISendEmailServices;
using CSKH_SSP.ViewModels.Files;
using CSKH_SSP.ViewModels.RequestPermission;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSKH_SSP.Services.RequestActionServices {
    public class RequestActionServices : IRequestActionServices {
        private readonly DataContext _dataContext;
        private readonly ICheckRequestPermissionServices _checkRequestPermissionServices;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;
        private readonly INotificationServices _setNotificationServices;
        private readonly ISendEmailServices _sendEmailServices;
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IHostingEnvironment _hostingEnv;
        public RequestActionServices (DataContext dataContext,
            ICheckRequestPermissionServices checkReceiveRequestPermissionServices,
            ICheckGroupUserPermissionServices checkGroupUserPermissionServices,
            INotificationServices setNotificationServices,
            ISendEmailServices sendEmailServices,
            IHostingEnvironment hostingEnv, IHttpContextAccessor contextAccessor) {
            _dataContext = dataContext;
            _checkRequestPermissionServices = checkReceiveRequestPermissionServices;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
            _setNotificationServices = setNotificationServices;
            _sendEmailServices = sendEmailServices;
            _hostingEnv = hostingEnv;
            _contextAccessor = contextAccessor;
        }
        public string ChangeStatusRequest (string RequestID, int CategoryID, string Status, User user, int ReasonId, bool isAuto = false) {
            RequestContent requestContent = new RequestContent ();
            Requestinfo Request = new Requestinfo ();
            RequestPermission requestPermission = new RequestPermission ();
            var tempRequest = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
            var IsUserCanReceiveRequest = _checkRequestPermissionServices.CheckReceiveRequestPermission (user.UserName, user.DepartmentID, user.GroupUserID, RequestID, CategoryID);
            var IsUserCanReplyOrViewThisRequest = _checkRequestPermissionServices.CheckFinishOrCloseRequestPermission (RequestID, user.GroupUserID, user.DepartmentID, user.UserName);

            if (Status == StringLibrary.RequestStatusProcessing && ( IsUserCanReceiveRequest || user.GroupUserID == 2)) {
                tempRequest.RequestStatus = Status;
                tempRequest.ReceiverTime = DateTime.Now;    
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = tempRequest.RequestTittle;
                requestContent.ContentRequest = user.FullName + " / " + user.UserName + " đã tiếp nhận yêu cầu <a style='color: #0176ff'>" + tempRequest.RequestTittle + "</a>";
                requestContent.IsTimelinePoint = true;
                requestContent.Status = StringLibrary.ContentRequestStatusShowClient;
                requestContent.DateTime = DateTime.Now;
                requestPermission.RequestID = RequestID;
                requestPermission.UserName = user.UserName;
                _dataContext.RequestPermission.Add (requestPermission);
                _dataContext.RequestContent.Add (requestContent);
                _dataContext.SaveChanges ();
                return "OK";
            } else
            if (Status == StringLibrary.RequestStatusClosed && IsUserCanReplyOrViewThisRequest) {
                tempRequest.FinishBy = user.UserName;
                tempRequest.FinishTime = DateTime.Now;
                tempRequest.RequestStatus = Status;
                tempRequest.ReasonID = ReasonId;
                //var tempRequest = _dataContext.Request.Where(x => x.RequestID == RequestID).FirstOrDefault();
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = tempRequest.RequestTittle;
                requestContent.ContentRequest = user.FullName + " / " + user.UserName + " đã hoàn thành hỗ trợ yêu cầu <a style='color: #0176ff'>" + tempRequest.RequestTittle + "</a>.";
                requestContent.IsTimelinePoint = true;
                requestContent.Status = StringLibrary.ContentRequestStatusHideClient;
                requestContent.DateTime = DateTime.Now;
                requestPermission.RequestID = RequestID;
                requestPermission.UserName = user.UserName;
                //tempRequest.TimeDone = DateTime.Now;
                _dataContext.RequestPermission.Add (requestPermission);
                _dataContext.RequestContent.Add (requestContent);
                _dataContext.SaveChanges ();
                return "OK";
            } else if (Status == StringLibrary.RequestStatusDone && IsUserCanReplyOrViewThisRequest) {
                tempRequest.FinishBy = user.UserName;
                tempRequest.TimeDone = DateTime.Now;
                tempRequest.RequestStatus = Status;
                //var tempRequest = _dataContext.Request.Where(x => x.RequestID == RequestID).FirstOrDefault();
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = tempRequest.RequestTittle;
                requestContent.ContentRequest = user.FullName + " / " + user.UserName + "<a style='color: #f0938c'> XÁC NHẬN hoàn thành và ĐÓNG hỗ trợ yêu cầu</a> <a style='color: #0176ff'>" + tempRequest.RequestTittle + "</a>.";
                requestContent.IsTimelinePoint = true;
                requestContent.Status = StringLibrary.ContentRequestStatusHideClient;
                requestContent.DateTime = DateTime.Now;
                requestPermission.RequestID = RequestID;
                requestPermission.UserName = user.UserName;
                //tempRequest.TimeDone = DateTime.Now;
                _dataContext.RequestPermission.Add (requestPermission);
                _dataContext.RequestContent.Add (requestContent);
                _dataContext.SaveChanges ();
                return "OK";
            }
            else if (Status == StringLibrary.AdminReject && IsUserCanReplyOrViewThisRequest)
            {
                tempRequest.FinishBy = user.UserName;
                tempRequest.TimeDone = DateTime.Now;
                tempRequest.RequestStatus = StringLibrary.RequestStatusProcessing;
                //var tempRequest = _dataContext.Request.Where(x => x.RequestID == RequestID).FirstOrDefault();
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = tempRequest.RequestTittle;
                requestContent.ContentRequest = user.FullName + " / " + user.UserName +"Đã trả lại yêu cầu -" + "<a style='color: #f0938c'> Yêu cầu chưa hoàn thành.</a>.";
                requestContent.IsTimelinePoint = true;
                requestContent.Status = StringLibrary.ContentRequestStatusHideClient;
                requestContent.DateTime = DateTime.Now;
                requestPermission.RequestID = RequestID;
                requestPermission.UserName = user.UserName;
                //tempRequest.TimeDone = DateTime.Now;
                _dataContext.RequestPermission.Add(requestPermission);
                _dataContext.RequestContent.Add(requestContent);
                _dataContext.SaveChanges();
                return "OK";
            }
            else {
                return "False";
            }
        }

        public string RejectStatus (string RequestID, string NoteReject, User userInformation) {
            try {
                var temp = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
                var EmailOfAuthorReq = _dataContext.User.Where (x => x.UserName == temp.createByUserName).Select (x => x.Email).First ();
                string subjectEmail = "Thông báo: Yêu cầu hỗ trợ bị hủy";
                string contentEmail = "<b>Đây là Email tự động, vui lòng không reply lại Email này</b><br><br>Yêu cầu <b>" + temp.RequestTittle + "</b> đã bị từ chối.<br>Lý do: <b>" + temp.RequestNotes + "</b><br><br>Thân mến.<br>VNTT Customer Service Center";
                if (!string.IsNullOrEmpty (EmailOfAuthorReq)) {
                    _sendEmailServices.SendEmail (EmailOfAuthorReq, subjectEmail, contentEmail, null);
                }
                _setNotificationServices.SetNotification (RequestID, StringLibrary.Notification_RejectRequest, temp.createByUserName, userInformation.UserName, DateTime.Now);
                temp.RequestStatus = StringLibrary.RequestStatusReject;
                temp.RequestNotes = NoteReject;
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }
        }

        public string FeedBack(string feedBackToRequestID, string feedBackContent, int rating)
        {
            if(!string.IsNullOrEmpty(feedBackContent))
            {
                var temp = _dataContext.Request.Where(x => x.RequestID == feedBackToRequestID).FirstOrDefault();
                temp.Feedback = feedBackContent;
                temp.Rating = rating;
                _dataContext.SaveChanges();
                return "1";
            } else
            {
                return "0";
            }

           
           
        }
        public string ReplyRequest (string RequestID, string ReplyContent, User UserInfomation, List<IFormFile> files) {
            try {
                RequestContent requestContent = new RequestContent ();
                AttachFile attachFile = new AttachFile ();
                List<AttachmentFileToSendEmail> listFileToSend = new List<AttachmentFileToSendEmail> ();
                var isAdmin = _checkGroupUserPermissionServices.IsAdmin (UserInfomation.GroupUserID);
                var isStaff = _checkGroupUserPermissionServices.IsStaff (UserInfomation.GroupUserID);
                var tempRequest = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
                if (isAdmin || isStaff) {
                    requestContent.IsStaff = "true";
                } else {
                    requestContent.IsStaff = "false";
                }
                var test = _dataContext.RequestPermission.Where (x => x.RequestID == RequestID).ToList ();
                var aa = test;
                var listPermissionUser = _dataContext.RequestPermission.Where (x => x.RequestID == RequestID && x.UserName != null && (x.DepartmentID == null || x.DepartmentID == 0));
                var listPermissionDepartment = _dataContext.RequestPermission.Where (x => x.RequestID == RequestID && x.UserName == null && (x.DepartmentID != null || x.DepartmentID != 0));
                // var listAdmin = _dataContext.User.Where(x => x.GroupUserID == 1).ToList();
                //foreach (var i in listAdmin) {
                //    GlobalVarible.countMessageForUser(i.UserID, KeyRequestID, "NewCmt");
                //}
                tempRequest.LastUpdatedBy = UserInfomation.UserName;
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = tempRequest.RequestTittle;
                requestContent.ContentRequest = ReplyContent;
                requestContent.AuthorFullName = UserInfomation.FullName;
                requestContent.UserName = UserInfomation.UserName;

                if (UserInfomation.Email != null)
                    requestContent.AuthorEmail = UserInfomation.Email;
                requestContent.DateTime = DateTime.Now;
                if (files != null) {
                    requestContent.Status = StringLibrary.RequestContentStatusHasAttachFile;
                    tempRequest.hasAttFile = true;
                }
                _dataContext.RequestContent.Add (requestContent);
                _dataContext.SaveChanges ();

                if (files != null) {
                    var filesPath = $"{this._hostingEnv.WebRootPath}/UploadedFiles";
                    foreach (var file in files) {
                        AttachFile fileAttach = new AttachFile ();
                        string InputFileName = Path.GetFileName (file.FileName); //get filename
                        string[] splitFileName = InputFileName.Split ('.');
                        string fullFilePath = "";
                        if (splitFileName.Length > 2) {
                            var fileNameOnDbAndFolder = splitFileName[0] + DateTime.Now.Ticks + "." + splitFileName[splitFileName.Length - 1];
                            fileAttach.FileNameOriginal = InputFileName;
                            fileAttach.FileNameOnDB = fileNameOnDbAndFolder;
                            fullFilePath = fileNameOnDbAndFolder;
                            fileAttach.Type = splitFileName[splitFileName.Length - 1];
                            listFileToSend.Add (new AttachmentFileToSendEmail { FileNameOriginal = fileAttach.FileNameOriginal, FileNameOnFolder = fileAttach.FileNameOnDB });
                        } else {
                            var fileNameOnDbAndFolder = splitFileName[0] + DateTime.Now.Ticks + "." + splitFileName[splitFileName.Length - 1];
                            fileAttach.FileNameOriginal = InputFileName;
                            fileAttach.FileNameOnDB = fileNameOnDbAndFolder;
                            fullFilePath = fileNameOnDbAndFolder;
                            fileAttach.Type = splitFileName[1];
                            listFileToSend.Add (new AttachmentFileToSendEmail { FileNameOriginal = fileAttach.FileNameOriginal, FileNameOnFolder = fileAttach.FileNameOnDB });

                        }
                        string new_Filename_on_Server = filesPath + "\\" + fullFilePath;
                        fileAttach.IDComment = requestContent.ID;
                        fileAttach.IDRequest = requestContent.RequestID;
                        fileAttach.OwerUserName = UserInfomation.UserName;
                        // using (FileStream stream = new FileStream(new_Filename_on_Server, FileMode.Create))
                        using (var stream = new FileStream (new_Filename_on_Server, FileMode.Create)) {
                            file.CopyTo (stream);
                        }
                        _dataContext.AttachFile.Add (fileAttach);
                        //_dataContext.SaveChanges();
                    }

                }
                var Departmentname = _dataContext.Department.Where (x => x.DepartmentID == UserInfomation.DepartmentID).Select (x => x.DepartmentName).FirstOrDefault ();
                //TRICH TIN NHAN GOC
                var QuoteReplyEmail = _sendEmailServices.QuotereplyEmail (RequestID, ReplyContent, UserInfomation.FullName, UserInfomation.UserName, Departmentname);

                if (listPermissionUser.Count () > 0) {
                    foreach (var item in listPermissionUser.ToList ()) {
                        // Chi them thong bao cho cac ID khac User co ID da dang nhap va thuc hien commetn
                        if (item.UserName != UserInfomation.UserName && !listPermissionDepartment.Any (x => x.DepartmentID == item.DepartmentID)) {
                            _setNotificationServices.SetNotification (RequestID, StringLibrary.Notification_AddNewComment, item.UserName, UserInfomation.UserName, DateTime.Now);
                            //GlobalVarible.countMessageForUser(item.UserID ?? 2, KeyRequestID, "NewCmt");
                            if (item.Meta == StringLibrary.UserAssignMetaString || item.Meta == StringLibrary.UserAssignMetaStringLv2 || item.Meta == StringLibrary.UserAssignMetaStringLv3) {
                                string EmailToSend = "";
                                if (!string.IsNullOrEmpty (item.UserName))
                                    EmailToSend = _dataContext.User.Where (x => x.UserName == item.UserName).Select (x => x.Email).FirstOrDefault ();
                                if (!string.IsNullOrEmpty (EmailToSend))
                                    _sendEmailServices.SendEmail (EmailToSend, "Re: Thông báo xử lý Yêu cầu tại hệ thống Hỗ trợ VNTT - RequestID: ###[" + RequestID + "]###", QuoteReplyEmail, listFileToSend);
                            }
                        }
                    }
                }

                if (listPermissionDepartment.Count () > 0) {
                    foreach (var item in listPermissionDepartment) {
                        if (UserInfomation.DepartmentID != item.DepartmentID) {
                            _setNotificationServices.SetNotificationForDepartment (RequestID, StringLibrary.Notification_AddNewComment, item.DepartmentID ?? 0, UserInfomation.UserName, DateTime.Now);

                            if (item.Meta == StringLibrary.DepartmentAssignMetaString) {
                                var EmailOfDepartment = "";
                                EmailOfDepartment = _dataContext.Department.Where (x => x.DepartmentID == item.DepartmentID).Select (x => x.Email).FirstOrDefault ();
                                _sendEmailServices.SendEmail (EmailOfDepartment, "Thông báo xử lý Yêu cầu tại hệ thống Hỗ trợ VNTT - RequestID: ###[" + RequestID + "]###", QuoteReplyEmail, listFileToSend);
                            }

                        }
                    }
                }
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
                //  Block of code to handle errors
            }

        }

        public string SendPrivateChatOrAdvice (string RequestID, string ContentPrivateChat, User CurrentUser, string ToUserName) {
            Advice advice = new Advice ();
            RequestContent requestContent = new RequestContent ();
            var currentRequest = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
            requestContent.RequestID = RequestID;
            requestContent.Status = StringLibrary.RequestContentStatusAdvice;
            requestContent.TitleRequest = currentRequest.RequestTittle;
            requestContent.ContentRequest = ContentPrivateChat;
            requestContent.AuthorFullName = CurrentUser.FullName;
            //contentTemp.AuthorEmail = Session["EmailUser"].ToString();
            requestContent.IsStaff = "true";
            requestContent.DateTime = DateTime.Now;
            _dataContext.RequestContent.Add (requestContent);
            currentRequest.LastAdviceBy = CurrentUser.UserName;
            _dataContext.SaveChanges ();

            advice.CommentID = requestContent.ID;
            advice.RequestID = RequestID;
            advice.FromUserName = CurrentUser.UserName;
            advice.ToUserUserName = ToUserName;
            _dataContext.Advice.Add (advice);
            _dataContext.SaveChanges ();
            return "OK";

        }
        public string EditRequest (string RequestID, int? CategoryID, DateTime? DateFinish, int? Priority) {
            try {
                var a = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
                if (CategoryID != null)
                    a.Category = CategoryID;
                if (Priority != null)
                    a.Priority = Priority;
                if (DateFinish.HasValue)
                    a.FinishTime = DateFinish;
                _dataContext.SaveChanges ();
                //_dataContext.Dispose();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }

        }
        public string UpdateDepartmentToAssignRequest (string RequestID, string RequestContent, int[] DepartmentID, User user, bool isAutoAdd = false) {
            try {
                RequestContent requestContent = new RequestContent ();
                var request = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
                var currentDepartment = _dataContext.RequestPermission.Where (x => x.RequestID == RequestID && (x.DepartmentID != null || x.DepartmentID != 0) && x.UserName == null && x.Meta == StringLibrary.DepartmentAssignMetaString).ToList ();
                //_dataContext.RequestPermission.RemoveRange(currentDepartment);
                //_dataContext.SaveChanges();
                if (request.RequestStatus == StringLibrary.RequestStatusClosed)
                    return "Fail";
                if (request.RequestStatus == StringLibrary.RequestStatusReject)
                    return "Fail";
                request.RequestStatus = StringLibrary.RequestStatusProcessing;
                RequestContent = _dataContext.RequestContent.Where (x => x.RequestID == RequestID).Select (x => x.ContentRequest).FirstOrDefault();
                string temp = string.Empty;
                foreach (var item in DepartmentID) {
                    if (!currentDepartment.Exists (x => x.DepartmentID == item)) {
                        RequestPermission requestPermission = new RequestPermission ();
                        requestPermission.RequestID = RequestID;
                        requestPermission.DepartmentID = item;
                        requestPermission.Meta = StringLibrary.DepartmentAssignMetaString;
                        var DepartmentObj = _dataContext.Department.Where (x => x.DepartmentID == item).First ();

                        temp += DepartmentObj.DepartmentName + " ";
                        //var ManagerID = _dataContext.DepartmentManager.Where (x => x.DepartmentID == item).Select (x => x.UserName);
                        //if (ManagerID.Any())
                        //{
                        //    foreach (var i in ManagerID)
                        //    {
                        //        RequestPermission requestPermissionForManager = new RequestPermission();
                        //        requestPermissionForManager.RequestID = RequestID;
                        //        requestPermissionForManager.UserName = i;
                        //        requestPermissionForManager.Meta = StringLibrary.UserFollowMetaString;
                        //        _dataContext.RequestPermission.Add(requestPermissionForManager);
                        //    }
                        //}
                        
                        var Url = "RequestContent/RequestContent?RequestID=" + RequestID;
                        var Domain = _contextAccessor.HttpContext.Request.Scheme + "://" + _contextAccessor.HttpContext.Request.Host;
                        string fullDomain = Domain + "/" + Url;

                        _dataContext.RequestPermission.Add (requestPermission);
                        _setNotificationServices.SetNotificationForDepartment (RequestID, StringLibrary.Notification_AddDepartmentAssign, item, user.UserName, DateTime.Now);
                        string contentEmail = @"<b>Đây là Email tự động. Để phản hồi, vui lòng REPLY lại Email này và KHÔNG TẠO EMAIL MỚI hoặc bạn cũng có thể đăng nhập vào hệ thống Ticket Support, đăng nhập và trả lời.</b><br><br>
            Bạn đã được giao xử lý Yêu cầu <b>" + request.RequestTittle + "</b><br><br>Nội dung: <br>" + RequestContent + " <br><br><a target='_blank' href='" + fullDomain + "'>Click vào đây để xem thêm thông tin.</a><br>Thời gian xử lý từ ngày: <b>" + request.RequestDay.ToString ("dd/MM/yyyy") + "</b> tới ngày: <b>" + request.RequestDay.AddDays (1).ToString ("dd/MM/yyyy") +
                            "</b><br><br>Thân mến.<br>VNTT Customer Service Center";
                        _sendEmailServices.SendEmail (DepartmentObj.Email, "Thông báo xử lý Yêu cầu tại hệ thống Hỗ trợ VNTT - RequestID: ###[" + RequestID + "]###", contentEmail, null);
                        //_dataContext.SaveChanges();
                    }
                }
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = request.RequestTittle;
                if (!isAutoAdd)
                    requestContent.ContentRequest = user.UserName + " đã thêm phòng <a style= 'color: #0176ff'> " + temp + "</a> vào xử lý yêu cầu";
                requestContent.IsTimelinePoint = true;
                requestContent.DateTime = DateTime.Now;
                requestContent.Status = StringLibrary.ContentRequestStatusShowClient;
                _dataContext.RequestContent.Add (requestContent);

                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }

        }
        public string UpdateDepartmentFollowRequest (string RequestID, int[] DepartmentID, User user, bool isAutoAdd = false) {
            try {
                RequestContent requestContent = new RequestContent ();
                var request = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
                var currentDepartment = _dataContext.RequestPermission.Where (x => x.RequestID == RequestID && (x.DepartmentID != null || x.DepartmentID != 0) && string.IsNullOrEmpty (x.UserName) && x.Meta == StringLibrary.DepartmentFollowMetaString).ToList ();
                // _dataContext.RequestPermission.RemoveRange(currentDepartment);

                string temp = string.Empty;
                foreach (var item in DepartmentID) {
                    if (!currentDepartment.Exists (x => x.DepartmentID == item)) {
                        RequestPermission requestPermission = new RequestPermission ();
                        requestPermission.RequestID = RequestID;
                        requestPermission.DepartmentID = item;
                        requestPermission.Meta = StringLibrary.DepartmentFollowMetaString;
                        string DepartmentName = _dataContext.Department.Where (x => x.DepartmentID == item).Select (x => x.DepartmentName).First ();
                        temp += DepartmentName + " ";
                        _dataContext.RequestPermission.Add (requestPermission);
                        _dataContext.SaveChanges ();
                    }
                }
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = request.RequestTittle;
                if (!isAutoAdd)
                    requestContent.ContentRequest = user.UserName + " đã thêm phòng <a style= 'color: #0176ff'> " + temp + "</a> vào xử lý yêu cầu";
                requestContent.IsTimelinePoint = true;
                requestContent.DateTime = DateTime.Now;
                requestContent.Status = StringLibrary.ContentRequestStatusShowClient;
                _dataContext.RequestContent.Add (requestContent);
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }

        }
        public string UpdateUserAssignRequest (string RequestID, string ContentRequest, string[] UserNameAsssign, User user, bool isAutoAdd = false, int FormLevel = 1) {
            try {
                RequestContent requestContent = new RequestContent ();

                var request = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
                var currentUserAssign = _dataContext.RequestPermission.Where (x => x.RequestID == RequestID && (x.DepartmentID == null || x.DepartmentID == 0) && !string.IsNullOrEmpty (x.UserName) && (x.Meta == StringLibrary.UserAssignMetaString || x.Meta == StringLibrary.UserAssignMetaStringLv2 || x.Meta == StringLibrary.UserAssignMetaStringLv3)).ToList ();
                //_dataContext.RequestPermission.RemoveRange(currentUserAssign);
                if (request.RequestStatus == StringLibrary.RequestStatusClosed)
                    return "Fail";
                if (request.RequestStatus == StringLibrary.RequestStatusReject)
                    return "Fail";
                request.RequestStatus = StringLibrary.RequestStatusProcessing;
                ContentRequest = _dataContext.RequestContent.Where (x => x.RequestID == RequestID).Select (x => x.ContentRequest).FirstOrDefault ();

                string temp = string.Empty;
                foreach (var item in UserNameAsssign) {
                    //bool attr1_exist = MyList.Exists(s=> s.attr1 == "aaa")
                    if (!currentUserAssign.Exists (x => x.UserName == item)) {
                        RequestPermission requestPermission = new RequestPermission ();
                        requestPermission.RequestID = RequestID;
                        requestPermission.UserName = item;
                        if (FormLevel == 1)
                        {
                            requestPermission.Meta = StringLibrary.UserAssignMetaString;
                            request.ReceiverTime = DateTime.Now;
                        }
                        else if (FormLevel == 2)
                            requestPermission.Meta = StringLibrary.UserAssignMetaStringLv2;
                        else
                            requestPermission.Meta = StringLibrary.UserAssignMetaStringLv3;
                        var UserObject = _dataContext.User.Where(x => x.UserName == item).First();
                        temp += UserObject.UserName + " ";
                        _dataContext.RequestPermission.Add (requestPermission);
                        _setNotificationServices.SetNotification (RequestID, StringLibrary.Notification_AddUserAssign, item, user.UserName, DateTime.Now);
                        _dataContext.SaveChanges ();
                        var Url = "RequestContent/RequestContent?RequestID=" + RequestID;
                        var Domain = _contextAccessor.HttpContext.Request.Scheme + "://" + _contextAccessor.HttpContext.Request.Host;
                        string fullDomain = Domain + "/" + Url;
                        string contentEmail = @"<b>Đây là Email tự động. Để phản hồi, vui lòng REPLY lại Email này và KHÔNG TẠO EMAIL MỚI hoặc bạn cũng có thể đăng nhập vào hệ thống Ticket Support, đăng nhập và trả lời.</b><br><br>
            Bạn đã được " + user.UserName + " giao xử lý Yêu cầu <b>" + request.RequestTittle + "</b><br><br>Nội dung: <br>" + ContentRequest + " <br><br><a target='_blank' href='" + fullDomain + "'>Click vào đây để xem thêm thông tin.</a>Thời gian xử lý từ ngày: <b>" + request.RequestDay.ToString ("dd/MM/yyyy") + "</b> tới ngày: <b>" + request.RequestDay.AddDays (1).ToString ("dd/MM/yyyy") +
                            "</b><br><br>Thân mến.<br>VNTT Customer Service Center";
                        _sendEmailServices.SendEmail (UserObject.Email, "Thông báo xử lý Yêu cầu tại hệ thống Hỗ trợ VNTT - RequestID: ###[" + RequestID + "]###", contentEmail, null);
                    }
                }
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = request.RequestTittle;
                if (!isAutoAdd) {
                    requestContent.ContentRequest = user.UserName + " đã thêm <a style= 'color: #0176ff'>" + temp + "</a> vào xử lý yêu cầu";
                }
                requestContent.IsTimelinePoint = true;
                requestContent.DateTime = DateTime.Now;
                requestContent.Status = StringLibrary.ContentRequestStatusShowClient;
                _dataContext.RequestContent.Add(requestContent);
                _dataContext.SaveChanges();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }

        }
        public string UpdateUserFollowRequest (string RequestID, string RequestContent, string[] UserNameAsssign, User user, bool isAutoAdd = false) {
            try {
                RequestContent requestContent = new RequestContent ();
                var currentUserAssign = _dataContext.RequestPermission.Where (x => x.RequestID == RequestID && (x.DepartmentID == null || x.DepartmentID == 0) && x.UserName != null && x.Meta == StringLibrary.ContentRequestStatusShowClient).ToList ();
                //_dataContext.RequestPermission.RemoveRange(currentUserAssign);

                var request = _dataContext.Request.Where (x => x.RequestID == RequestID).FirstOrDefault ();
                //if (request.RequestStatus == "Closed")
                //    return "Fail";
                //if (request.RequestStatus == "Reject")
                //    return "Fail";
                //request.RequestStatus = "Processing";
                string temp = string.Empty;
                foreach (var item in UserNameAsssign) {
                    if (!currentUserAssign.Exists (x => x.UserName == item)) {
                        RequestPermission requestPermission = new RequestPermission ();
                        requestPermission.RequestID = RequestID;
                        requestPermission.UserName = item;
                        requestPermission.Meta = StringLibrary.UserFollowMetaString;
                        string Username = _dataContext.User.Where (x => x.UserName == item).Select (x => x.UserName).First ();
                        temp += Username + " ";
                        _dataContext.RequestPermission.Add (requestPermission);
                        _dataContext.SaveChanges ();
                    }
                }
                requestContent.RequestID = RequestID;
                requestContent.TitleRequest = request.RequestTittle;
                if (!isAutoAdd)
                    requestContent.ContentRequest = user.UserName + " đã thêm <a style= 'color: #0176ff'>" + temp + "</a> vào theo dõi yêu cầu";
                requestContent.IsTimelinePoint = true;
                requestContent.DateTime = DateTime.Now;
                requestContent.Status = StringLibrary.ContentRequestStatusShowClient;
                _dataContext.RequestContent.Add (requestContent);
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }

        }
        public string DeleteUserAssign (string RequestID, string UserName, string level) {
            try {
                var CurrentUserIDAssign = _dataContext.RequestPermission.Where (x => x.UserName == UserName && x.RequestID == RequestID && (x.DepartmentID == null || x.DepartmentID == 0) && x.Meta == level).FirstOrDefault ();
                if (CurrentUserIDAssign != null)
                    _dataContext.RequestPermission.Remove (CurrentUserIDAssign);
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }

        }
        public string DeleteUserFollow (string RequestID, string UserName) {
            try {
                var CurrentUserIDFollow = _dataContext.RequestPermission.Where (x => x.UserName == UserName && x.RequestID == RequestID && (x.DepartmentID == null || x.DepartmentID == 0) && x.Meta == StringLibrary.UserFollowMetaString).FirstOrDefault ();
                if (CurrentUserIDFollow != null)
                    _dataContext.RequestPermission.Remove (CurrentUserIDFollow);
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }
        }
        public string DeleteDepartmentAssign (string RequestID, int DepartmentID) {
            try {
                var CurrentDepartmentIDAssign = _dataContext.RequestPermission.Where (x => string.IsNullOrEmpty (x.UserName) && x.RequestID == RequestID && x.DepartmentID == DepartmentID && x.Meta == StringLibrary.DepartmentAssignMetaString).FirstOrDefault ();
                if (CurrentDepartmentIDAssign != null)
                    _dataContext.RequestPermission.Remove (CurrentDepartmentIDAssign);
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }
        }
        public string DeleteDepartmentFollow (string RequestID, int DepartmentID) {
            try {
                var CurrentDepartmentIDAssign = _dataContext.RequestPermission.Where (x => string.IsNullOrEmpty (x.UserName) && x.RequestID == RequestID && x.DepartmentID == DepartmentID && x.Meta == StringLibrary.DepartmentFollowMetaString).FirstOrDefault ();
                if (CurrentDepartmentIDAssign != null)
                    _dataContext.RequestPermission.Remove (CurrentDepartmentIDAssign);
                _dataContext.SaveChanges ();
                return "OK";
            } catch (Exception e) {
                var a = e;
                return "OK";
            }
        }
    }
}