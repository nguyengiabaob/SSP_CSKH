using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.ViewModels.ContentRequest;
using CSKH_SSP.ViewModels.UserInfomation;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ContentRequest.Header;

namespace CSKH_SSP.ViewModels.ContentRequest
{
    public class ContentRequest
    {
        public RequestIncident RequestIncident { get; set; }
        public ContentRequestHeader ContentRequestHeader { get; set; }
        public List<ContentRequestBody> ContentRequestBody { get; set; }
        public List<AttachFile> AttachFile { get; set; }
        public List<PrivateChat> PrivateChat { get; set; }
        public UserCreateRequestInfomation UserCreateRequestInfomation { get; set; }
        public List<Department> ListDepartmentsAssign { get; set; }
        public List<Department> ListDepartmentsFollow { get; set; }
        public List<User> ListUsersAssign { get; set; }
        public List<User> ListUsersFollow { get; set; }
        public GroupUserPermission GroupUserPermission { get; set; }
        public RenderButton RenderButton { get; set; }
        public string TicketID { get; set; }
        public string TicketCustomerID { get; set; }
        public string ContractID { get; set; }
        public bool IsPinned { get; set; }

    }
}
