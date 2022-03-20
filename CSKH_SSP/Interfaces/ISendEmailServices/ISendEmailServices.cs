using CSKH_SSP.ViewModels.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.ISendEmailServices {
    public interface ISendEmailServices {
        public void SendEmail(string ToEmail, string SubjectEmail, string contentEmail, List<AttachmentFileToSendEmail> listFileToSend);
        public string QuotereplyEmail(string RequestID, string OriginalBodyContent, string FullName, string UserName, string Department);
    }
}
