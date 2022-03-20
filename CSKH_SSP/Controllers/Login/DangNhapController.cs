using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces;
using CSKH_SSP.Interfaces.IAdminServices;
using Microsoft.AspNetCore.Mvc;
using CSKH_SSP.DataModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Routing;

namespace CSKH_SSP.Controllers.Login
{
    public class DangNhapController : Controller
    {
        readonly DataContext _dataContext;
        private ILoginServices _loginServices;
        private readonly IUserManagementServices _userManagementServices;

        public DangNhapController(DataContext dataContext, ILoginServices loginServices, IUserManagementServices userManagementServices)
        {
            _dataContext = dataContext;
            _loginServices = loginServices;
            _userManagementServices = userManagementServices;
        }
        public IActionResult SSPLogin(string Email, string Key, string idcate)
        {
            string Compare = Email + "VNTT@13524";
            bool validPassword = BCrypt.Net.BCrypt.Verify(Compare, Key);
            var userDetail = _dataContext.User.Where(x => x.Email == Email).FirstOrDefault();
            //var userDetail = _loginServices.Authorize(getUser.UserName, getUser.Password);
            if (userDetail == null)
            {
                if (validPassword)
                {
                    var user = new User();
                    user.UserName = Email.ToLower().Trim();
                    user.FullName = Email.ToLower().Trim();
                    user.GroupUserID = 3;
                    user.Email = Email.ToLower().Trim();
                    user.DepartmentID = 999;
                    _userManagementServices.AddNewUser(user);

                var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, userDetail.FullName),
                //new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Sid, userDetail.UserName.ToString()),
                 };
                    HttpContext.Session.SetString("SessionCurrentUser", JsonConvert.SerializeObject(user));

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    ViewBag.Username = user.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "Error", action = "Index", TextNote = "Sai thông tin đăng nhập" }));
                }
            }
            else
            {
                if (validPassword)
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
                    ViewBag.Username = userDetail.UserName;
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Index", "DanhSachYeuCau", new { noMenu = 1 });
                }
                else
                {
                    //return View("DangNhap");
                    //return "DangNhap";
                    return RedirectToAction("Index", "DangNhap");
                }
            }
        }
    }
}
