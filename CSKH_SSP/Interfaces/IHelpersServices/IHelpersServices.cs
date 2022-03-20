using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.AddNewRequest;
using CSKH_SSP.ViewModels.Helper;
using CSKH_SSP.ViewModels.Mention;

namespace CSKH_SSP.Interfaces.IHelpersServices {
    public interface IHelpersServices {
        public CategoryAndPriority FilterModel ();
        public IEnumerable<Category> GetCategories ();
        public IEnumerable<Category> GetChildCategories(int parentId);
        public IEnumerable<Category> GetAllCategories();
        public Category GetCategoryById(int Id); 
        public string AutoNumberID ();
        public List<Department> GetListDepartments ();
        public List<UserInDepartment> getListUserInDepartments ();
        public CSKH_SSP.DataModels.User getUserForTest ();
        public bool checkTicketIdIsAvailable (string TicketID);
        public List<MentionUser> getListmention ();
        public List<Reason> getListReason ();
        public IEnumerable<User> GetAllUserCanAssignRequest();
        public IEnumerable<User> GetAllAdmin();
        public IEnumerable<User> GetAllCaptain();
        public IEnumerable<User> GetUserCanConfigPermission();
        public string PinRequest(string RequestID, string UserName);
        public bool checkReqeustIdPinned(string RequestID, string UserName);
        public Requestinfo getRequestById(string requestId);
        public List <AttachFile> getAttachFileByRequestId(string requestId);
        public bool DeleteFiles(int id);

    }
}