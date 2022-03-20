using CSKH_SSP.Constant;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IAddNewRequestServices;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.ITicketServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Controllers.MyVNTT
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IHelpersServices _helpersServices;
        private readonly IAddNewRequestServices _addNewRequestServices;
        private readonly ITicketServices _ticketServices;
        private readonly DataContext _dataContext;

        public RequestsController(IHelpersServices helpersServices, IAddNewRequestServices addNewRequestServices, ITicketServices ticketServices, DataContext dataContext)
        {
            _helpersServices = helpersServices;
            _addNewRequestServices = addNewRequestServices;
            _ticketServices = ticketServices;
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("AddNewRequest")]
        public int AddNewRequest([FromBody] AddRequestFromMobile obj)
        {
            var user = _dataContext.User.Where(x => x.UserName == "MyVNTT").FirstOrDefault();
            List<IFormFile> files = new List<IFormFile>();
            var a = _addNewRequestServices.AddnewRequest(obj.requestTitle, obj.requestContent, user, obj.categoryID, files, 2, null, null, null, 0, null, obj.ticketCustomerCode, null);
            return 1;
        }

        [HttpGet]
        [Route("GetListRequestsByUserId")]
        public List<Requestinfo> GetListRequestsByUserId(string customerId)
        {
            return _dataContext.Request.Where(x => x.TicketCustomerID == customerId && x.RequestAuthorFullName == "MyVNTT").ToList();
        }

        [HttpGet]
        [Route("GetRequestDoneUnSeen")]
        public int GetRequestDoneUnSeen(string customerId)
        {
            return _dataContext.Request.Count(x => x.TicketCustomerID == customerId && x.RequestAuthorFullName == "MyVNTT" && (x.RequestStatus == "Done" || x.RequestStatus == "Reject") && (x.IsSeenWhenDone == false || x.IsSeenWhenDone == null ));
        }

        [HttpGet]
        [Route("GetRequestDetail")]
        public Requestinfo GetRequestDetail(string RequestId, string customerId)
        {
            var requestObj = _dataContext.Request.Where(x => x.RequestID == RequestId).FirstOrDefault();
            if (requestObj != null)
            {
                if (requestObj.RequestAuthorUserName == "MyVNTT" && requestObj.TicketCustomerID == customerId)
                {
                    return requestObj;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Route("CancelRequest")]
        public int CancelRequest([FromBody] CancelRequest obj)
        {
            var requestObj = _dataContext.Request.Where(x => x.RequestID == obj.RequestId).FirstOrDefault();
            if (requestObj != null)
            {
                if (requestObj.RequestAuthorUserName == "MyVNTT" && requestObj.TicketCustomerID == obj.CustomerId)
                {
                    requestObj.RequestStatus = StringLibrary.RequestStatusReject;
                    requestObj.RequestNotes = "MyVNTT Reject";
                    requestObj.FinishBy = obj.CustomerId;
                    _dataContext.SaveChanges();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        [HttpPost]
        [Route("SetIsSeen")]
        public int SetIsSeen([FromBody] CancelRequest obj)
        {
            var requestObj = _dataContext.Request.Where(x => x.RequestID == obj.RequestId).FirstOrDefault();
            if (requestObj != null)
            {
                if (requestObj.RequestAuthorUserName == "MyVNTT" && requestObj.TicketCustomerID == obj.CustomerId)
                {
                    requestObj.IsSeenWhenDone = true;
                    _dataContext.SaveChanges();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
 public class CancelRequest
{
    public string RequestId { get; set; }
    public string CustomerId { get; set; }
}

public class AddRequestFromMobile
{
    public string requestTitle { get; set; }
    public string requestContent { get; set; }
    public int categoryID { get; set; }
    public string ticketCustomerCode { get; set; }
}
