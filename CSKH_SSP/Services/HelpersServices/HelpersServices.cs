using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.ViewModels.AddNewRequest;
using CSKH_SSP.ViewModels.Helper;
using CSKH_SSP.ViewModels.Mention;
using Microsoft.Data.SqlClient;

namespace CSKH_SSP.Services.HelpersServices {
    public class HelpersServices : IHelpersServices {
        private DataContext _dataContext;
        private static string CONNECTION_STRING = @"Server=database.vntt.com.vn;Database=TICKETSYSTEM;User Id=sspcskh;password=cskh@123;Trusted_Connection=False;MultipleActiveResultSets=true;";

        public HelpersServices(DataContext dataContext) {
            _dataContext = dataContext;

        }

        public CategoryAndPriority FilterModel() {
            CategoryAndPriority categoryAndPriorityModels = new CategoryAndPriority();
            categoryAndPriorityModels.categoryList = _dataContext.Category.Where(x => x.isActive != false).ToList();
            categoryAndPriorityModels.priorityList = _dataContext.Priority.ToList();
            return categoryAndPriorityModels;
        }
        public IEnumerable<Category> GetCategories() {
            return _dataContext.Category.Where(x => x.isActive != false && x.ParentId == null);
        }
        public IEnumerable<Category> GetChildCategories(int parentId)
        {
            return _dataContext.Category.Where(x => x.isActive != false && x.ParentId == parentId);
        }


        public IEnumerable<Category> GetAllCategories() {
            return _dataContext.Category;
        }
        public Category GetCategoryById(int Id)
        {
            return _dataContext.Category.Where(x => x.isActive != false && x.IDCategory == Id).FirstOrDefault();
        }
        public IEnumerable<User> GetAllUserCanAssignRequest() {
            return _dataContext.User.Where(x => x.GroupUserID == 2);
        }
        public IEnumerable<User> GetAllAdmin() {
            return _dataContext.User.Where(x => x.GroupUserID == 1);
        }
        public IEnumerable<User> GetAllCaptain()
        {
            return _dataContext.User.Where(x => x.GroupUserID == 4);
        }
        public IEnumerable<User> GetUserCanConfigPermission()
        {
            return _dataContext.User.Where(x => x.DepartmentID == 447);
        }

        public List<Department> GetListDepartments() {
            return _dataContext.Department.ToList();
        }
        public List<UserInDepartment> getListUserInDepartments() {
            return (from a in _dataContext.Department
                    from b in _dataContext.User
                    where a.DepartmentID == b.DepartmentID
                    select new UserInDepartment {
                        DepartmentCode = a.DepartmentCode,
                        DepartmentName = a.DepartmentName,
                        DepartmentID = a.DepartmentID,
                        FullName = b.FullName,
                        UserId = b.UserID,
                        UserName = b.UserName
                    }).ToList();
        }

        

        public List<MentionUser> getListmention() {
            List<MentionUser> listResult = new List<MentionUser>();
            var temp = (from a in _dataContext.Department
                        from b in _dataContext.User
                        where a.DepartmentID == b.DepartmentID
                        select new MentionUser {
                            id = b.UserID,
                            username = b.UserName,
                            fullname = b.FullName,
                            department = a.DepartmentName
                        }).ToList();
            //for(int i = 0; i <= temp.Count; i++)
            //{
            //    MentionUser obj = new MentionUser();
            //    obj.id = i;
            //    obj.username = temp[i].UserName;
            //    obj.fullname = temp[i].FullName;
            //    obj.department = temp[i].DepartmentName;
            //    listResult.Add(obj);
            //}
            return temp;
        }
        public string AutoNumberID() {
            RequestAutoID IDThre = _dataContext.RequestAutoID.First(c => c.TypeRequest == "TicketEO");
            Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
            Match result = re.Match(IDThre.IDNumberRequest);
            string alphaPart = result.Groups[1].Value;
            int newnumberID = Convert.ToInt32(result.Groups[2].Value) + 1;
            string newIDThread = alphaPart + newnumberID.ToString();
            IDThre.IDNumberRequest = newIDThread;
            _dataContext.SaveChanges();
            return newIDThread;
        }

        public CSKH_SSP.DataModels.User getUserForTest() {
            var a = _dataContext.User.Where(x => x.UserName == "dunght").FirstOrDefault();
           // return a;
            return null;
        }

        public List<Reason> getListReason() {
            return _dataContext.Reason.ToList();
        }

        public bool checkTicketIdIsAvailable(string TicketID) {
            //string conStr = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;

            string sqlCommand = @"SELECT [TicketID] from [dbo].[REQUESTLIST] where [TicketID] = @TicketID";
            string sqlCommand2 = @"SELECT [TicketID] from [dbo].[PROBLEMLEVEL1] where [TicketID] = @TicketID";
            string sqlCommand3 = @"SELECT [TicketID] from [dbo].[CHANGESERVICETICKET] where [TicketID] = @TicketID";

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING)) {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                SqlCommand cmd2 = new SqlCommand(sqlCommand2, con);
                SqlCommand cmd3 = new SqlCommand(sqlCommand3, con);

                cmd.Parameters.AddWithValue("@TicketID", TicketID);
                cmd2.Parameters.AddWithValue("@TicketID", TicketID);
                cmd3.Parameters.AddWithValue("@TicketID", TicketID);

                if (con.State != System.Data.ConnectionState.Open) {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader.HasRows || reader2.HasRows || reader3.HasRows) {
                    return true;
                } else {
                    return false;
                }

            }
        }

        public string PinRequest(string RequestID, string UserName) {
            var obj = new RequestPinned();
            var temp = _dataContext.RequestPinned.Where(x => x.RequestID == RequestID && x.UserName == UserName).FirstOrDefault();
            
            if (temp == null)
            {
                obj.RequestID = RequestID;
                obj.UserName = UserName;
                _dataContext.RequestPinned.Add(obj);
            }
            else {
                _dataContext.RequestPinned.Remove(temp);
            }
            _dataContext.SaveChanges();
            return "OK";
        }
        public bool checkReqeustIdPinned (string RequestID, string UserName)
        {
            var temp = _dataContext.RequestPinned.Where(x => x.RequestID == RequestID && x.UserName == UserName).FirstOrDefault();
            if (temp == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Requestinfo getRequestById(string requestId)
        {
            return _dataContext.Request.Where(x => x.RequestID == requestId).FirstOrDefault();
        }
        public List<AttachFile> getAttachFileByRequestId(string requestId)
        {
            return _dataContext.AttachFile.Where(x => x.IDRequest == requestId).ToList();
        }
        public bool DeleteFiles(int id)
        {
            try
            {
                var file = _dataContext.AttachFile.Where(x => x.ID == id).FirstOrDefault();
                _dataContext.AttachFile.Remove(file);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool IsTicketAvailable(string TicketID)
        //{
        //    var a = _ticketDataContext.problemsupport.Where(x => x.TicketID == TicketID).FirstOrDefault();
        //    if(a != null)
        //    {
        //        return true;
        //    } else
        //    {
        //        return false;
        //    }
        //}
    }
}