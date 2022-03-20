using CSKH_SSP.ViewModels.ContentRequest;
using CSKH_SSP.ViewModels.ContentRequest.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces {
    public interface IRequestContentHeaderServices {
        public ContentRequestHeader GetInfoRequest(string ReqID, string UserName);
        public RenderButton RenderButton(string RequestID, int GroupUserID, string UserName);
    }
}
