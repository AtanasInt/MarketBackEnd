using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IQMarketBackend.ActivationCodeSender
{
    public class ActivationCodeSender
    {
        
        public string reciever { get; set; }
        private SmtpClient smtp;
        private MailMessage email;
        public ActivationCodeSender(string reciever , string sender = "contact@myiqfinance.com", string mailServer = "win.mk-host.mk", int port = 25, string passphrase = "Interway1102")
        {

            
           
            smtp = new SmtpClient(mailServer, port);
            smtp.Credentials = new NetworkCredential(sender, passphrase);
            smtp.EnableSsl = true;
            smtp.Port = port;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Host = mailServer;

            email = new MailMessage(sender, reciever, "Activation Code","");
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.IsBodyHtml = true;
        }
        public void setBodyText(string text = "Body", bool IsHTML = false)
        {
            email.IsBodyHtml = IsHTML;
            email.Body = text;
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