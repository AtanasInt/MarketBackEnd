using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQMarketBackend.DI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using IQMarketBackend.Models;

namespace IQMarketBackend.Controllers.Api
{
    //[System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Clients")]
    public class ClientsController : ApiController
    {
        private IClientsService _clientsService;
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;

             
     }

        [HttpGet]
        [Route("GetUserInfoByEmail")]
        public IHttpActionResult GetUserInfoByEmail(string email, string userName, string methodName, string formName)
        {
            DataTable dt = _clientsService.GetClientByEmail(email, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

        [HttpPost]
        [Route("InsertUpdateNewClient")]
        public IHttpActionResult InsertNewClient(ClientModel client)
        {
            DataTable dt = _clientsService.InsertUpdateNewClient(client);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(ClientModel client)
        {
            DataTable dt = _clientsService.Login(client);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

        [HttpGet]
        [Route("CheckMail")]
        public IHttpActionResult CheckMail(string email)
        {
            DataTable dt = _clientsService.CheckMail(email);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpPost]
        [Route("ChangePassword")]
        public IHttpActionResult ChangePassword(ClientModel client)
        {
            DataTable dt = _clientsService.ChangePassword(client);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }





    }

    
}