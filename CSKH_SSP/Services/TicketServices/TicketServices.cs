using CSKH_SSP.ViewModels.TicketArea;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using CSKH_SSP.Constant;
using CSKH_SSP.Interfaces.ITicketServices;
using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;

namespace CSKH_SSP.Services.TicketServices
{
    public class TicketServices : ITicketServices
    {
        readonly Helpers.MemberContext _db;

        public TicketServices(MemberContext db)
        {
            _db = db;
        }

        //StringLibrary.UserFollowMetaString
        public List<TicketCustomer> SearchUserFromTicket(string textString)
        {
            if (string.IsNullOrEmpty(textString))
            {
                return null;
            }
            else
            {
                var client = new HttpClient();
                var response = client.GetAsync("http://180.148.0.146/VNTTAPP/api/Customer/SearchCustomer?tukhoa="
                    + textString + "&key=" + StringLibrary.API_Key);
                response.Wait();
                var a = response.Result.Content.ReadAsStringAsync().Result;
                var listTicketCustomer = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TicketCustomer>>(a);
                return listTicketCustomer;
            }

        }

        public List<TicketContract> GetTicketContractInfo(string CustomerCode)
        {
            if (string.IsNullOrEmpty(CustomerCode))
            {
                return null;
            }
            else
            {
                var client = new HttpClient();
                var response = client.GetAsync("http://180.148.0.146/VNTTAPP/api/Customer/SearchContract?makh="
                    + CustomerCode + "&key=" + StringLibrary.API_Key);
                response.Wait();
                var a = response.Result.Content.ReadAsStringAsync().Result;
                var listContract = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TicketContract>>(a);
                return listContract;
            }
        }

        public TicketCustomer GetTicketCustomersInfo(string CustomerID)
        {
            if (string.IsNullOrEmpty(CustomerID))
            {
                return null;
            }
            else
            {
                var client = new HttpClient();
                var response = client.GetAsync("http://180.148.0.146/VNTTAPP/api/Customer/GetCustomerInfor?makh="
                    + CustomerID + "&key=" + StringLibrary.API_Key);
                response.Wait();
                var a = response.Result.Content.ReadAsStringAsync().Result;
                var listTicketCustomer = Newtonsoft.Json.JsonConvert.DeserializeObject<TicketCustomer>(a);
                return listTicketCustomer;
            }
        }

        public MemberVNTT getMemberInfo(string customerId)
        {
            return _db.UserDetails.Where(x => x.CustomerCode == customerId).FirstOrDefault();
        }

        //MemberContext

        public List<TicketContract> ContractsInfo(string ContractId)
        {
            if (string.IsNullOrEmpty(ContractId))
            {
                return null;
            }
            else
            {
                List<TicketContract> res = new List<TicketContract>();
                var ContractCodeArr = ContractId.Split(",");
                foreach (var item in ContractCodeArr)
                {
                    TicketContract Contract = new TicketContract();
                    var client = new HttpClient();
                    var response = client.GetAsync("http://erp.vntt.com.vn/VNTTAPP/api/Customer/GetContractInfor?mahd="
                        + item + "&key=" + StringLibrary.API_Key);
                    response.Wait();
                    var a = response.Result.Content.ReadAsStringAsync().Result;
                    Contract = Newtonsoft.Json.JsonConvert.DeserializeObject<TicketContract>(a);
                    res.Add(Contract);
                }
                return res;
            }
        }

    }
}


