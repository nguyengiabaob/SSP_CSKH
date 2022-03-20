using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace CSKH_SSP.Controllers.Error
{
    public class ErrorController : Controller
    {
        public IActionResult Index(string TextNote)
        {
            ViewBag.Message = TextNote;
            return View();
        }

        [Route("Error/{statusCode}")]
        public IActionResult CodeError(/*int statusCode*/)
        {
            //switch (statusCode)
            //{
            //    case 404:
            //        ViewBag.ErrorMess = "404";
            //        break;
            //}
            string reqID = "";
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionRequestID") as string))
            {
                reqID = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("SessionRequestID"));
            }
            if (reqID == "")
                return Ok("");
            return RedirectToAction("RequestContent", "RequestContent", new { RequestID = reqID });
            //return Redirect("RequestContent/RequestContent?RequestID=" + ViewData["RequestID"]);
        }
    }
}