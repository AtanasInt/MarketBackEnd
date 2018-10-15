using IQMarketBackend.DI;
using IQMarketBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IQMarketBackend.Controllers.Api
{
    //[System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Application")]
    public class ApplicationController : ApiController
    {
        private IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Route("GetAllApplications")]
        public IHttpActionResult GetAllApplications(string userName, string methodName, string formName)
        {
            DataTable dt = _applicationService.GetAllApplications(userName, methodName, formName);

            if(dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));
            return Ok(dt);
        }

        [HttpGet]
        [Route("GetAllApplicationTypes")]
        public IHttpActionResult GetAllApplicationTypes()
        {
            DataTable dt = _applicationService.GetAllApplicationTypes();
            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));
            return Ok(dt);
        }

        [HttpPost]
        [Route("InsertApplication")]
        public IHttpActionResult InsertApplication(ApplicationModel application)
        {
            DataTable dt = _applicationService.InsertApplication(application);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

        [HttpPost]
        [Route("UpdateApplication")]
        public IHttpActionResult UpdateApplication(ApplicationModel application)
        {
            DataTable dt = _applicationService.UpdateApplication(application);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
    }
}
