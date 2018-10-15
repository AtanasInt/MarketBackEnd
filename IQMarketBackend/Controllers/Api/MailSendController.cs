using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IQMarketBackend.ActivationCodeSender;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;

namespace IQMarketBackend.Controllers.Api
{
    
    [RoutePrefix("api/Mail")]
    public class MailSendController : ApiController
    {
        
        [Route("MailSender")]
        [HttpGet]
        public JObject SendMailToUser(string mail)
        {
            JObject data = new JObject();
            Random getRandom = new Random();
            int act = getRandom.Next(111111, 999999);
            ActivationCodeSender.ActivationCodeSender acttivation = new ActivationCodeSender.ActivationCodeSender(mail);
           

            acttivation.setBodyText("Activation Code is" + "\n" + act.ToString());
            acttivation.sendMail();

            data.Add("The code is: " , act.ToString());
            return data;
        }

        
        

    }
}


