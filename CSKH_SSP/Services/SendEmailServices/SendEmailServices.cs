using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.ISendEmailServices;
using CSKH_SSP.ViewModels.Files;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.SendEmailServices
{
    public class SendEmailServices : ISendEmailServices
    {
        private readonly DataContext _dataContext;
        public SendEmailServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void SendEmail(string ToEmail, string SubjectEmail, string contentEmail, List<AttachmentFileToSendEmail> listFileToSend)
        {
            var EmailObject = _dataContext.EmailConfig.First();

            if (EmailObject.IsEnable)
            {
                var fromMail = new MailAddress(EmailObject.Email, "VNTT Customer Service Center");
                var toMail = new MailAddress(ToEmail);
                var fromEmailPassword = EmailObject.Password;
                string subject = SubjectEmail;
                string body = contentEmail;
                var smtp = new SmtpClient
                {
                    Host = "client.vntt.com.vn",
                    Port = 25,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromMail.Address, fromEmailPassword)
                    //Ssl = false;
                };
                Attachment attachment;
                using (var message = new MailMessage(fromMail, toMail)
                {

                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    if ((listFileToSend != null) && (!listFileToSend.Any()))
                    {
                        for (var i = 0; i < listFileToSend.Count; i++)
                        {
                            attachment = new Attachment(listFileToSend[i].FileNameOnFolder);
                            attachment.ContentDisposition.FileName = listFileToSend[i].FileNameOriginal;
                            message.Attachments.Add(attachment);
                        }
                    }

                    smtp.Send(message);
                }
            }
        }

        public string QuotereplyEmail(string RequestID, string OriginalBodyContent, string FullName, string UserName, string Department)
        {
            var EmailObject = _dataContext.EmailConfig.First();
            var client = new ImapClient();
            var cancel = new System.Threading.CancellationTokenSource();
            client.Connect("mail.vntt.com.vn", 143, false, cancel.Token);
            client.AuthenticationMechanisms.Remove("XOAUTH");
            client.Authenticate(EmailObject.Email, EmailObject.Password, cancel.Token);
            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadWrite, cancel.Token); // Folder Email
            var items = inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.Flags | MessageSummaryItems.Envelope);
            var listUID = _dataContext.RequestContent.Where(x => x.RequestID == RequestID && x.UID != null).OrderByDescending(x => x.UID).ToList();
            string quoteOriginalEmail = "";
            string body = "";

            if (listUID.Count > 0)
            {
                var IndexOfMail = Int32.Parse(listUID[0].UID);
                var range = new UniqueIdRange(new UniqueId((uint)IndexOfMail), new UniqueId((uint)IndexOfMail));
                foreach (var uida in inbox.Search(range, SearchQuery.All))
                {
                    var message = inbox.GetMessage(uida);

                    quoteOriginalEmail = message.TextBody ?? string.Empty;
                }
                // trích tin nhắn gốc
                using (var quoted = new StringWriter())
                {
                    quoted.WriteLine("Vào lúc {0}, {1} đã viết:", listUID[0].DateTime, listUID[0].AuthorEmail);
                    using (var reader = new StringReader(quoteOriginalEmail))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            quoted.Write("<blockquote style='border: none; border - left:solid black 1.5pt; padding: 0in 0in 0in 4.0pt; margin - left:0pt; margin - top:5.0pt; margin - right:0in; margin - bottom:5.0pt'><p class='MsoNormal'><span style='font - size:14.0pt; font - family:&quot; Times New Roman & quot;,serif; color: black'>");
                            quoted.WriteLine(line);
                            quoted.Write("</blockquote>");
                        }
                    }
                    quoteOriginalEmail = quoted.ToString();
                }

            }
            if (string.IsNullOrEmpty(quoteOriginalEmail))
            {
                body = OriginalBodyContent + "Trân trọng: " + "<br>" + FullName + " / " + UserName + " <br> " + Department;
            }
            else
            {
                body = OriginalBodyContent + "Trân trọng: " + "<br>" + FullName + " / " + UserName + " <br> " + Department + "<br><br>" + quoteOriginalEmail;
            }
            return body;
        }
    }
}
