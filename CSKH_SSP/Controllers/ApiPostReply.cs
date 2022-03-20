using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.IRequestActionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CSKH_SSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPostReply : ControllerBase
    {
        private readonly IRequestActionServices _requestActionServices;
        private readonly IHelpersServices _helpersServices;

        public ApiPostReply(IRequestActionServices requestActionServices, IHelpersServices helpersServices)
        {
            _requestActionServices = requestActionServices;
            _helpersServices = helpersServices;
        }

        [HttpGet]
        [Route("a")]
        public string a()
        {
            return "1";
        }

        [HttpPost]
        [Route("ReplyRequest")]
        //Get all Customer
        public string ReplyRequest(string RequestID, string ReplyContent, List<IFormFile> files)
        {
            if (ReplyContent == null)
            {
                return "Vui lòng nhập nội dung trả lời";
            }
            CSKH_SSP.DataModels.User UserInfomation;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionCurrentUser") as string))
            {
                UserInfomation = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionCurrentUser"));
            }
            else
            {
                UserInfomation = _helpersServices.getUserForTest();
            }

            var result = _requestActionServices.ReplyRequest(RequestID, ReplyContent, UserInfomation, files);

            if (result == "OK")
                return "Thành công";
            else
                return "Lỗi";
        }

    }

}
