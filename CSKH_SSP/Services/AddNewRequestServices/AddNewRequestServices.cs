using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IAddNewRequestServices;
using CSKH_SSP.Interfaces.IHelpersServices;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using Microsoft.AspNetCore.Http;
using CSKH_SSP.Constant;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using CSKH_SSP.Interfaces.IRequestActionServices;
using CSKH_SSP.ViewModels.Files;
using CSKH_SSP.Interfaces.INotificationsServices;

namespace CSKH_SSP.Services.AddNewRequestServices
{
    public class AddNewRequestServices : IAddNewRequestServices
    {
        readonly DataContext _dataContext;
        private IHostingEnvironment _hostingEnv;
        private IHelpersServices _helpersServices;
        private IRequestActionServices _requestActionServices;
        private INotificationServices _notificationServices;

        public AddNewRequestServices(DataContext dataContext, IHostingEnvironment hostingEnv, IHelpersServices helpersServices, IRequestActionServices requestActionServices, INotificationServices notificationServices)
        {
            _dataContext = dataContext;
            _hostingEnv = hostingEnv;
            _helpersServices = helpersServices;
            _requestActionServices = requestActionServices;
            _notificationServices = notificationServices;
        }
        [HttpPost]
        public int AddnewRequest(string RequestTittle, string RequestContent,
                                  User UserInfomation, int CategoryID,
                                  List<IFormFile> files, int Priority,
                                  string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID)
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
            if (files.Count > 0)
            {
                reqDetails.hasAttFile = true;
                reqDetails.hasAttFile = true;
                content.Status = StringLibrary.RequestContentStatusHasAttachFile;
            }
            reqDetails.RequestAuthorUserName = UserInfomation.UserName;
            reqDetails.RequestDay = DateTime.Now;
            var tempDay = DateTime.Now.AddDays((double)days_remain + 1).Date;
            reqDetails.FinishTime = tempDay.AddHours((double)hour_remain);
            reqDetails.RequestContent = RequestContent;
            reqDetails.RequestID = RequestID;
            reqDetails.RequestAuthorFullName = UserInfomation.FullName;
            reqDetails.RequestTittle = RequestTittle;
            //isPrivate == 2 ? :
            if (isPrivate > 0)
            {
                reqDetails.RequestStatus = StringLibrary.RequestStatusDone;
                reqDetails.IsPrivate = true;
            }
            else
            {
                reqDetails.IsPrivate = false;
                reqDetails.RequestStatus = null;
            }
            reqDetails.createByUserName = UserInfomation.UserName;
            reqDetails.Category = CategoryID;
            reqDetails.Priority = Priority;
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

            foreach (var item in listAdmin)
            {
                _notificationServices.SetNotification(RequestID, StringLibrary.Notification_NewRequest, item, UserInfomation.UserName, DateTime.Now);
            }

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
    }
}
