using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.DataModels;
using CSKH_SSP.ViewModels.ListRequest;
using Microsoft.AspNetCore.Http;

namespace CSKH_SSP.Interfaces.IQuestionsService
{
    public interface ICommonQuestionService
    {
        public (List<ListRequestTicket> ListRequestTickets, int TotalQuestion, bool isLastItem) GetListQuestion(int GroupUserID, string UserName, int? mention, int pageNumber, string text, string category, string pri);
        public int AddnewQuestion(string RequestTittle, string RequestContent, User UserInfomation, int CategoryID, List<IFormFile> files, int Priority, string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID, bool IsQuestion);

        public string RemoveQuestion(string  QuestionId);
        public int UpdateQuestion(string RequestTittle, string RequestContent, User UserInfomation, int CategoryID, List<IFormFile> files, int Priority, string[] UserAssign, int[] DepartmentAssign, string[] UserFollow, int isPrivate, string IDTicket, string TicketCustomerCode, string TicketContractID, string QuestionId);

    }
}
