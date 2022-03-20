using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSKH_SSP.Interfaces;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Routing;

namespace CSKH_SSP.Controllers.Login {
    public class LoginController : Controller {
        private ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices) {
            _loginServices = loginServices;
        }
        public IActionResult Login(string ReturnUrl) {
            if(!string.IsNullOrEmpty(ReturnUrl))
            {
                ViewData["ReturnUrl"] = ReturnUrl;
            } else
            {
                ViewData["ReturnUrl"] = "";
            }
            return View();
        }

        public IActionResult CSKHLogin(string user, string Key)
        {
            var userDetail = _loginServices.SSPLogin(user, Key);
            if(userDetail != null)
            { 
                var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, userDetail.FullName),
                //new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Sid, userDetail.UserName.ToString()),
            };

                HttpContext.Session.SetString("SessionCurrentUser", JsonConvert.SerializeObject(userDetail));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return RedirectToAction("Index", "RequestList", new { statusRequest = "MyNotification" });
            } else {
                return RedirectToAction("Index", new RouteValueDictionary(
  new { controller = "Error", action = "Index", TextNote = "Sai thông tin đăng nhập" }));
            }
           
        }
        public IActionResult Authorize(string UserName, string Password, string ReturnUrl) {
            var userDetail = _loginServices.Authorize(UserName, Password);
            
            if (userDetail == null)
                return RedirectToAction("Index", new RouteValueDictionary(
    new { controller = "Error", action = "Index", TextNote = "Sai thông tin đăng nhập" }));
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, userDetail.FullName),
                //new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Sid, userDetail.UserName.ToString()),
            };

            HttpContext.Session.SetString("SessionCurrentUser", JsonConvert.SerializeObject(userDetail));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
            //return RedirectToAction("Index", "RequestList");
            ViewBag.Username = userDetail.UserName;
            return RedirectToAction("Index", "Home");
            //return Redirect(ReturnUrl);
        }

    }
}