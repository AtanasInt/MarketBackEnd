using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IQFinance.Services
{
    public class MailService
    {
        public string receiver { get; set; }

        private SmtpClient smtp;
        private MailMessage email;

        public MailService(string receiver, string sender = "contact@myiqfinance.com", string mailServer = "win.mk-host.mk", int port = 25, string passphrase = "Interway1102")
        {
            string sentFrom, pass, sentTo, mailServ;
            int portNo;

            if (mailServer != null)
                mailServ = mailServer;
            else
                mailServ = "win.mk-host.mk";//primer

            if (port > 0)
                portNo = port;
            else
                portNo = 587;

            if (sender != null)
                sentFrom = sender;
            else
                sentFrom = "contact@myiqfinance.com";

            sentTo = receiver;

            if (passphrase != "")
                pass = passphrase;
            else
                pass = "Interway1102"; // 

            smtp = new SmtpClient(mailServ, portNo);
            smtp.Credentials = new NetworkCredential(sentFrom, pass);
            smtp.EnableSsl = true;

            email = new MailMessage(sentFrom, sentTo, "Activation Code", "");
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.SubjectEncoding = System.Text.Encoding.UTF8;
        }

        public void attach(Attachment item)
        {
            email.Attachments.Add(item);
        }

        public void removeAllAttachments()
        {
            email.Attachments.Clear();
        }

        public void removeAttachment(Attachment target)
        {
            email.Attachments.Remove(target);

        }
        public void AlternativeViews(AlternateView filepath)
        {
            email.AlternateViews.Add(filepath);

        }


        public void setBodyText(string text = "Body", bool IsHTML = false)
        {
            email.IsBodyHtml = IsHTML;
            email.Body = text;
        }

        public void setSubject(string subject = "proben email")
        {
            email.Subject = subject;
        }

        [RequireHttps()]
        public void sendMail()
        {
            try
            {
                smtp.EnableSsl = false;
                smtp.Send(email);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }
    }
}