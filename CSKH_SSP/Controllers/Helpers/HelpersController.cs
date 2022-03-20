using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces;
using CSKH_SSP.Interfaces.ICategoryServices;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.ViewModels.AddNewRequest;
using CSKH_SSP.ViewModels.Mention;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers.Helpers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpersController : ControllerBase
    {
        private readonly IHelpersServices _helpersServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IRequestContentBodyServices _RequestContentBodyServices;
        public HelpersController(IHelpersServices helpersServices, ICategoryServices categoryServices, IRequestContentBodyServices requestContentBodyServices)
        {
            _helpersServices = helpersServices;
            _categoryServices = categoryServices;
            _RequestContentBodyServices = requestContentBodyServices;
        }

        [HttpGet]
        [Route("GetUserMention")]
        public List<MentionUser> GetUserMention()
        {
            //public List<MentionUser> getListmention();
            return _helpersServices.getListmention();
        }

        [HttpGet]
        [Route("GetChildCategories")]
        public IEnumerable<Category> GetChildCategories(int parentId)
        {
            return _helpersServices.GetChildCategories(parentId);
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public Category GetCategoryById(int Id)
        {
            //public List<MentionUser> getListmention();
            return _helpersServices.GetCategoryById(Id);
        }
        [Route("GetAllCategory")]
        public List<Category> GetAllCategory()
        {
            //public List<MentionUser> getListmention();
            return _helpersServices.GetAllCategories().ToList();
        }
        [Route("GetAllPriority")]
        public List<Priority> GetAllPriority()
        {
            //public List<MentionUser> getListmention();
            return _helpersServices.FilterModel().priorityList.ToList();
        }

        [HttpGet]
        [Route("CategoryPermission")]
        public List<CategoryPermission> CategoryPermission(int Id)
        {
            var categoryDetail = _categoryServices.GetCategoryDetail(Id);
            return categoryDetail.categoryPermission;
        }

        [HttpGet]
        [Route("GetAllUserCanAssignRequest")]
        public IEnumerable<User> GetAllUserCanAssignRequest()
        {
            return _helpersServices.GetAllUserCanAssignRequest();
        }

        [HttpGet]
        [Route("GetAllAdmin")]
        public IEnumerable<User> GetAllAdmin()
        {
            return _helpersServices.GetAllAdmin();
        }

        [HttpGet]
        [Route("GetUserCanConfigPermission")]
        public IEnumerable<User> GetUserCanConfigPermission()
        {
            return _helpersServices.GetUserCanConfigPermission();
        }
        [HttpGet]
        [Route("GetAllCaptain")]
        public IEnumerable<User> GetAllCaptain()
        {
            return _helpersServices.GetAllCaptain();
        }
        [HttpGet]
        [Route("getAttachFileByRequestId")]
        public List<AttachFile> getAttachFileByRequestId(string requestId)
        {
            return _helpersServices.getAttachFileByRequestId(requestId);
        }
        [HttpDelete]
        [Route("deleteAttachFile")]
        public bool deleteAttachFile(int id)
        {
            return _helpersServices.DeleteFiles(id);
        }
        //[HttpPost]
        //[Route("PinRequest")]
        //public string PinRequest(string RequestID, string UserName)
        //{
        //    return _helpersServices.PinRequest(RequestID, UserName);
        //}


    }
}
