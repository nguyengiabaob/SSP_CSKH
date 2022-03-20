using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Constant {
    //
    public class StringLibrary {
        public static string UserFollowMetaString = "UserFollow";
        public static string UserAssignMetaString = "UserAssign";
        public static string UserAssignMetaStringLv2 = "UserAssignLv2";
        public static string UserAssignMetaStringLv3 = "UserAssignLv3";

        public static string AdminFollowMetaString = "adminFollow";
        public static string DepartmentFollowMetaString = "departmentFollow";
        public static string DepartmentAssignMetaString = "departmentAssign";
        public static string UserCreateRequestMetaString = "CreateRequest";
        
        public static string RequestStatusProcessing = "Processing";
        public static string RequestStatusClosed = "Closed";
        public static string RequestStatusOpen = "Open";
        public static string RequestStatusReject = "Reject";
        public static string RequestStatusDone = "Done";
        public static string AdminReject = "AdminReject";
        
        
        public static string ContentRequestStatusShowClient = "showClient";
        public static string ContentRequestStatusHideClient = "hideClient";

        public static string RequestContentStatusAdvice = "advice";
        public static string RequestContentStatusHasAttachFile = "hasAttachFile";


        public static string Notification_RejectRequest = "Reject_Request";
        public static string Notification_AddUserAssign = "Add_User_Assign";
        public static string Notification_NewRequest = "New_Request";
        public static string Notification_AddDepartmentAssign = "Add_Department_Assign";
        public static string Notification_AddNewComment = "Comment_request";

        public static string MyNotification = "MyNotification";
        public static string MyPinned = "MyPinned";

        //Ticket System
        public static string CONNECTION_TICKET_STRING = @"Server=database.vntt.com.vn;Database=CustomerDB;User Id=sspcskh;password=cskh@123;Trusted_Connection=False;MultipleActiveResultSets=true;";
        public static string API_Key = "sdiht3478hytfguwrih78r3yt!32875843rW234234fdgdfgGRFG";





    }
}
