using CSKH_SSP.Constant;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.INotificationsServices;
using CSKH_SSP.Interfaces.IQuestionsService;
using CSKH_SSP.Interfaces.IRequestActionServices;
using CSKH_SSP.ViewModels.Files;
using CSKH_SSP.ViewModels.ListRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.QuestionServices
{
    public class QuestionService : ICommonQuestionService
    {
        private DataContext _dataContext;
        private readonly ICheckGroupUserPermissionServices _checkGroupUserPermissionServices;
        private readonly IRequestContentBodyServices _requestContentBodyServices;
        private readonly INotificationServices _notificationServices;
        private readonly IHelpersServices _helpersServices;
        private readonly IRequestActionServices _requestActionServices;
        private IHostingEnvironment _hostingEnv;
        public QuestionService(DataContext dataContext, ICheckGroupUserPermissionServices checkGroupUserPermissionServices, IHostingEnvironment hostingEnv, IRequestContentBodyServices requestContentBodyServices, INotificationServices notificationServices, IHelpersServices helpersServices, IRequestActionServices requestActionServices)
        {
            _dataContext = dataContext;
            _requestContentBodyServices = requestContentBodyServices;
            _checkGroupUserPermissionServices = checkGroupUserPermissionServices;
            _notificationServices = notificationServices;
            _helpersServices = helpersServices;
            _requestActionServices = requestActionServices;
            _hostingEnv = hostingEnv;
        }

        public int AddnewQuestion(string RequestTittle, string RequestContent,
                                 User UserInfomation, int CategoryID,
                                 List<IFormFile> files, int Priority,
                                 string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID, bool IsQuestion)
        {
            var RequestID = _helpersServices.AutoNumberID();


            var deadlineConfig = _dataContext.DeadlineConfig.Where(x => x.CategoryId == CategoryID && x.PriorityId == Priority).FirstOrDefault();
            var hours_Category = _dataContext.Category.Where(x => x.IDCategory == CategoryID && x.isActive == true).Select(x => x.HoursDeadline).FirstOrDefault();

            int Hour_Deadline = 0;
            int hours_Priority = 16;
            if (deadlineConfig != null) hours_Priority = (int)deadlineConfig.Hours;
            Hour_Deadline = hours_Priority > 0 ? hours_Priority : 16 + (int)hours_Category > 0 ? (int)hours_Category : 16;


            var listAdmin = _dataContext.User.Where(x => x.GroupUserID == 1).Select(x => x.UserName);

            var hour_now = Hour_Deadline - (16 - DateTime.Now.Hour);

            var days_remain = hour_now / 8;
            var hour_remain = (hour_now % 8) + 8;


            Requestinfo reqDetails = new Requestinfo();
            RequestContent content = new RequestContent();
            List<AttachmentFileToSendEmail> listFileToSend = new List<AttachmentFileToSendEmail>();

            if (!string.IsNullOrEmpty(IDTicket))
            {
                reqDetails.TicketID = IDTicket;
            }
            if (!string.IsNullOrEmpty(TicketCustomerCode))
            {
                reqDetails.TicketCustomerID = TicketCustomerCode;
            }
            if (!string.IsNullOrEmpty(TicketContractID))
            {
                reqDetails.ContractID = TicketContractID.ToString();
            }

            //TicketPermission per = new TicketPermission();
            if (!string.IsNullOrEmpty(UserInfomation.Email))
            {
                reqDetails.RequestAuthorEmail = UserInfomation.Email;
            }
            reqDetails.IsQuestion = IsQuestion;
            if (files.Count > 0)
            {
                reqDetails.hasAttFile = true;
                reqDetails.hasAttFile = true;
                content.Status = StringLibrary.RequestContentStatusHasAttachFile;
            }
            reqDetails.RequestAuthorUserName = UserInfomation.UserName;
            reqDetails.RequestDay = DateTime.Now;
            //var tempDay = DateTime.Now.AddDays((double)days_remain + 1).Date;
            //reqDetails.FinishTime = tempDay.AddHours((double)hour_remain);
            reqDetails.RequestContent = RequestContent;
            reqDetails.RequestID = RequestID;
            reqDetails.RequestAuthorFullName = UserInfomation.FullName;
            reqDetails.RequestTittle = RequestTittle;
            // isPrivate == 2 ? :
            //if (isPrivate > 0)
            //{
            //    reqDetails.RequestStatus = StringLibrary.RequestStatusDone;
            //    reqDetails.IsPrivate = true;
            //}
            //else
            //{
            //    reqDetails.IsPrivate = false;
            //    reqDetails.RequestStatus = null;
            //}
            reqDetails.createByUserName = UserInfomation.UserName;
            reqDetails.Category = CategoryID;
            //reqDetails.Priority = Priority;
            reqDetails.IsFromEmail = false;

            content.ContentRequest = RequestContent;
            content.RequestID = RequestID;
            content.TitleRequest = RequestTittle;
            content.DateTime = DateTime.Now;
            content.AuthorEmail = UserInfomation.Email;
            content.AuthorFullName = UserInfomation.FullName;

            //RequestPermission requestPermission_1 = new RequestPermission();
            //requestPermission_1.RequestID = RequestID;
            //requestPermission_1.DepartmentID = 441;
            //requestPermission_1.Meta = StringLibrary.DepartmentFollowMetaString;
            //_dataContext.RequestPermission.Add(requestPermission_1);

            RequestPermission requestPermission_2 = new RequestPermission();
            requestPermission_2.RequestID = RequestID;
            requestPermission_2.UserName = UserInfomation.UserName;
            requestPermission_2.Meta = StringLibrary.UserCreateRequestMetaString;
            _dataContext.RequestPermission.Add(requestPermission_2);

            if (UserInfomation.DepartmentID != 441)
            {
                RequestPermission requestPermission_3 = new RequestPermission();
                requestPermission_3.RequestID = RequestID;
                requestPermission_3.DepartmentID = UserInfomation.DepartmentID;
                requestPermission_3.Meta = StringLibrary.DepartmentFollowMetaString;
                _dataContext.RequestPermission.Add(requestPermission_3);
            }

            //foreach (var item in listAdmin)
            //{
            //    _notificationServices.SetNotification(RequestID, StringLibrary.Notification_NewRequest, item, UserInfomation.UserName, DateTime.Now);
            //}

            _dataContext.Request.Add(reqDetails);
            _dataContext.RequestContent.Add(content);
            _dataContext.SaveChanges();




            //do not delete


            if (files != null)
            {

                var filesPath = $"{this._hostingEnv.WebRootPath}/UploadedFiles";

                foreach (var file in files)
                {
                    AttachFile fileAttach = new AttachFile();
                    string InputFileName = Path.GetFileName(file.FileName);//get filename
                    string[] splitFileName = InputFileName.Split('.');
                    string fullFilePath = "";
                    string FileNameOnDB = "";
                    if (splitFileName.Length > 2)
                    {

                        fileAttach.FileNameOriginal = InputFileName;
                        FileNameOnDB = splitFileName[0] + DateTime.Now.Ticks + "." + splitFileName[splitFileName.Length - 1];
                        fileAttach.FileNameOnDB = FileNameOnDB;
                        fullFilePath = FileNameOnDB;
                        fileAttach.Type = splitFileName[splitFileName.Length - 1];
                        listFileToSend.Add(new AttachmentFileToSendEmail { FileNameOriginal = fileAttach.FileNameOriginal, FileNameOnFolder = fileAttach.FileNameOnDB });
                    }
                    else
                    {
                        fileAttach.FileNameOriginal = InputFileName;
                        FileNameOnDB = splitFileName[0] + DateTime.Now.Ticks + "." + splitFileName[splitFileName.Length - 1];
                        fileAttach.FileNameOnDB = FileNameOnDB;
                        fullFilePath = FileNameOnDB;
                        fileAttach.Type = splitFileName[1];
                        listFileToSend.Add(new AttachmentFileToSendEmail { FileNameOriginal = fileAttach.FileNameOriginal, FileNameOnFolder = fileAttach.FileNameOnDB });

                    }
                    string new_Filename_on_Server = filesPath + "\\" + fullFilePath;
                    fileAttach.IDComment = content.ID;
                    fileAttach.IDRequest = content.RequestID;
                    fileAttach.OwerUserName = UserInfomation.UserName;
                    // using (FileStream stream = new FileStream(new_Filename_on_Server, FileMode.Create))
                    using (var stream = new FileStream(new_Filename_on_Server, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    _dataContext.AttachFile.Add(fileAttach);
                    _dataContext.SaveChanges();
                }
            }


            if (UserAssign != null && UserAssign.Count() > 0)
            {
                _requestActionServices.UpdateUserAssignRequest(RequestID, RequestContent, UserAssign, UserInfomation, true, 1);
            }
            if (UserFollow != null && UserFollow.Count() > 0)
            {
                _requestActionServices.UpdateUserFollowRequest(RequestID, RequestContent, UserFollow, UserInfomation, true);
            }
            if (DepartmentAssign != null && DepartmentAssign.Count() > 0)
            {
                _requestActionServices.UpdateDepartmentToAssignRequest(RequestID, RequestContent, DepartmentAssign, UserInfomation, true);
            }

            return 0;
        }
        public int UpdateQuestion(string RequestTittle, string RequestContent,
                                    User UserInfomation, int CategoryID,
                                    List<IFormFile> files, int Priority,
                                    string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID, string QuestionId)
        {

            var Question = _dataContext.Request.Where(x => x.RequestID == QuestionId).FirstOrDefault();

            //var deadlineConfig = _dataContext.DeadlineConfig.Where(x => x.CategoryId == CategoryID && x.PriorityId == Priority).FirstOrDefault();
            //var hours_Category = _dataContext.Category.Where(x => x.IDCategory == CategoryID && x.isActive == true).Select(x => x.HoursDeadline).FirstOrDefault();

            //int Hour_Deadline = 0;
            //int hours_Priority = 16;
            //if (deadlineConfig != null) hours_Priority = (int)deadlineConfig.Hours;
            //Hour_Deadline = hours_Priority > 0 ? hours_Priority : 16 + (int)hours_Category > 0 ? (int)hours_Category : 16;


            //var listAdmin = _dataContext.User.Where(x => x.GroupUserID == 1).Select(x => x.UserName);

            //var hour_now = Hour_Deadline - (16 - DateTime.Now.Hour);

            //var days_remain = hour_now / 8;
            //var hour_remain = (hour_now % 8) + 8;


            //Requestinfo reqDetails = new Requestinfo();
            RequestContent content =  _dataContext.RequestContent.Where(x=>x.RequestID == QuestionId).FirstOrDefault();
            List<AttachmentFileToSendEmail> listFileToSend = new List<AttachmentFileToSendEmail>();

            if (!string.IsNullOrEmpty(IDTicket))
            {
                Question.TicketID = IDTicket;
            }
            if (!string.IsNullOrEmpty(TicketCustomerCode))
            {
                Question.TicketCustomerID = TicketCustomerCode;
            }
            if (!string.IsNullOrEmpty(TicketContractID))
            {
                Question.ContractID = TicketContractID.ToString();
            }

            //TicketPermission per = new TicketPermission();
            if (!string.IsNullOrEmpty(UserInfomation.Email))
            {
                Question.RequestAuthorEmail = UserInfomation.Email;
            }
            if (files.Count > 0)
            {
                Question.hasAttFile = true;

                content.Status = StringLibrary.RequestContentStatusHasAttachFile;
            }
            else
            {
                var file = _requestContentBodyServices.GetAttachFiles(QuestionId);
                if(file.Count>0)
                {
                    Question.hasAttFile = true;
                    content.Status = StringLibrary.RequestContentStatusHasAttachFile;
                }
                else
                {
                    Question.hasAttFile = null;
                    content.Status = null;
                }
            }
            //var tempDay = DateTime.Now.AddDays((double)days_remain + 1).Date;
            //reqDetails.FinishTime = tempDay.AddHours((double)hour_remain);
            Question.RequestContent = RequestContent;
            Question.RequestTittle = RequestTittle;
            // isPrivate == 2 ? :
            //if (isPrivate > 0)
            //{
            //    reqDetails.RequestStatus = StringLibrary.RequestStatusDone;
            //    reqDetails.IsPrivate = true;
            //}
            //else
            //{
            //    reqDetails.IsPrivate = false;
            //    reqDetails.RequestStatus = null;
            //}
            Question.LastUpdatedBy = UserInfomation.UserName;
            Question.Category = CategoryID;
            //reqDetails.Priority = Priority;
            Question.IsFromEmail = false;

            content.ContentRequest = RequestContent;
            content.TitleRequest = RequestTittle;

            //RequestPermission requestPermission_1 = new RequestPermission();
            //requestPermission_1.RequestID = RequestID;
            //requestPermission_1.DepartmentID = 441;
            //requestPermission_1.Meta = StringLibrary.DepartmentFollowMetaString;
            //_dataContext.RequestPermission.Add(requestPermission_1);

            //RequestPermission requestPermission_2 = new RequestPermission();
            //requestPermission_2.RequestID = RequestID;
            //requestPermission_2.UserName = UserInfomation.UserName;
            //requestPermission_2.Meta = StringLibrary.UserCreateRequestMetaString;
            //_dataContext.RequestPermission.Add(requestPermission_2);

            //if (UserInfomation.DepartmentID != 441)
            //{
            //    RequestPermission requestPermission_3 = new RequestPermission();
            //    requestPermission_3.RequestID = RequestID;
            //    requestPermission_3.DepartmentID = UserInfomation.DepartmentID;
            //    requestPermission_3.Meta = StringLibrary.DepartmentFollowMetaString;
            //    _dataContext.RequestPermission.Add(requestPermission_3);
            //}

            //foreach (var item in listAdmin)
            //{
            //    _notificationServices.SetNotification(RequestID, StringLibrary.Notification_NewRequest, item, UserInfomation.UserName, DateTime.Now);
            //}
            _dataContext.Request.Update(Question);
            _dataContext.RequestContent.Update(content);
            _dataContext.SaveChanges();




            //do not delete


            if (files != null)
            {

                var filesPath = $"{this._hostingEnv.WebRootPath}/UploadedFiles";

                foreach (var file in files)
                {
                    AttachFile fileAttach = new AttachFile();
                    string InputFileName = Path.GetFileName(file.FileName);//get filename
                    string[] splitFileName = InputFileName.Split('.');
                    string fullFilePath = "";
                    string FileNameOnDB = "";
                    if (splitFileName.Length > 2)
                    {

                        fileAttach.FileNameOriginal = InputFileName;
                        FileNameOnDB = splitFileName[0] + DateTime.Now.Ticks + "." + splitFileName[splitFileName.Length - 1];
                        fileAttach.FileNameOnDB = FileNameOnDB;
                        fullFilePath = FileNameOnDB;
                        fileAttach.Type = splitFileName[splitFileName.Length - 1];
                        listFileToSend.Add(new AttachmentFileToSendEmail { FileNameOriginal = fileAttach.FileNameOriginal, FileNameOnFolder = fileAttach.FileNameOnDB });
                    }
                    else
                    {
                        fileAttach.FileNameOriginal = InputFileName;
                        FileNameOnDB = splitFileName[0] + DateTime.Now.Ticks + "." + splitFileName[splitFileName.Length - 1];
                        fileAttach.FileNameOnDB = FileNameOnDB;
                        fullFilePath = FileNameOnDB;
                        fileAttach.Type = splitFileName[1];
                        listFileToSend.Add(new AttachmentFileToSendEmail { FileNameOriginal = fileAttach.FileNameOriginal, FileNameOnFolder = fileAttach.FileNameOnDB });

                    }
                    string new_Filename_on_Server = filesPath + "\\" + fullFilePath;
                    fileAttach.IDComment = content.ID;
                    fileAttach.IDRequest = content.RequestID;
                    fileAttach.OwerUserName = UserInfomation.UserName;
                    // using (FileStream stream = new FileStream(new_Filename_on_Server, FileMode.Create))
                    using (var stream = new FileStream(new_Filename_on_Server, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    _dataContext.AttachFile.Add(fileAttach);
                    _dataContext.SaveChanges();
                }
            }


            if (UserAssign != null && UserAssign.Count() > 0)
            {
                _requestActionServices.UpdateUserAssignRequest(QuestionId, RequestContent, UserAssign, UserInfomation, true, 1);
            }
            if (UserFollow != null && UserFollow.Count() > 0)
            {
                _requestActionServices.UpdateUserFollowRequest(QuestionId, RequestContent, UserFollow, UserInfomation, true);
            }
            if (DepartmentAssign != null && DepartmentAssign.Count() > 0)
            {
                _requestActionServices.UpdateDepartmentToAssignRequest(QuestionId, RequestContent, DepartmentAssign, UserInfomation, true);
            }

            return 0;
        }
        public (List<ListRequestTicket> ListRequestTickets, int TotalQuestion, bool isLastItem) GetListQuestion(int GroupUserID, string UserName, int? mention, int pageNumber, string text, string category, string pri)
        {
              int Size = pageNumber;
            bool isLastItem = false;
            var isAdmin = _checkGroupUserPermissionServices.IsAdmin(GroupUserID);
            var isStaff = _checkGroupUserPermissionServices.IsStaff(GroupUserID);


            List<ListRequestTicket> listTicket = new List<ListRequestTicket>();
            int minPage; int maxPage; int totalRequest;
            IQueryable<ListRequestTicket> listReq;
                var query = (from a in _dataContext.Request
                             from b in _dataContext.Category
                             where (a.Category == b.IDCategory && a.IsQuestion== true) &&
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

            // var countA = listTicket.Count;\
            foreach ( var i in listReq)
            {
                listTicket.Add(i);
            }
            var finalList = listTicket.GroupBy(x => x.RequestID).Select(x => x.First());
            if (Size >= totalRequest)
                isLastItem = true;
            else
                isLastItem = false;

            //if (statusRequest == StringLibrary.RequestStatusDone)
            //    return (finalList.OrderByDescending(x => x.RequestID).ThenByDescending(x => x.daysRemain).ThenByDescending(x => x.RequestPriority).ToList(), totalRequest, isLastItem);
            //if (statusRequest == StringLibrary.RequestStatusDone)
            //  return (finalList.OrderByDescending(x => x.TimeDone).ThenByDescending(x => x.RequestID).ThenByDescending(x => x.daysRemain).ThenByDescending(x => x.RequestPriority).ToList(), totalRequest, isLastItem);
            //if (statusRequest == StringLibrary.RequestStatusDone) return (finalList.ToList(), totalRequest, isLastItem);
            return (finalList.ToList(), totalRequest, isLastItem);

        }
        public string RemoveQuestion(string QuestionId)
        {
            try
            {
                var request = _dataContext.Request.Where(x => x.RequestID == QuestionId && x.IsQuestion == true).FirstOrDefault();
                var requestContent = _dataContext.RequestContent.Where(x => x.RequestID == QuestionId).FirstOrDefault();
                var requestPermission= _dataContext.RequestPermission.Where(x => x.RequestID == QuestionId).ToList();
                for (int i = 0; i< requestPermission.Count; i++)
                {
                    _dataContext.RequestPermission.Remove(requestPermission[i]);
                }
                _dataContext.Request.Remove(request);
                _dataContext.RequestContent.Remove(requestContent);
                _dataContext.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return "0";
            }
        }
    }
}
