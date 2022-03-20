using CSKH_SSP.ViewModels.ContentRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.UserInfomation;

namespace CSKH_SSP.Interfaces {
    public interface IRequestContentBodyServices {
        public List<ContentRequestBody> GetRequestComment(string RequestID);
        public List<AttachFile> GetAttachFiles(string RequestID);
        public List<PrivateChat> GetPrivateChat(string RequestID);
        public UserCreateRequestInfomation GetUserInfomation(string RequestID);
        public IEnumerable<Department> GetDepartmentAssign(string RequestID);
        public IEnumerable<Department> GetDepartmentFollow(string RequestID);
        public IEnumerable<User> GetUserAssign(string RequestID);
        public IEnumerable<User> GetUserFollow(string RequestID);
        public string GetTicketID(string RequestID);
        public string GeTicketCustomerID(string RequestID);
        public string GeTicketContractID(string RequestID);
    }
}
