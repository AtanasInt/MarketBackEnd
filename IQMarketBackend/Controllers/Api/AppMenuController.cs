using IQMarketBackend.DI;
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
    [RoutePrefix("api/AppMenu")]
    public class AppMenuController : ApiController
    {
        IAppMenuService _appMenuService;
        public AppMenuController(IAppMenuService appMenuService)
        {
            _appMenuService = appMenuService;
        }

        [HttpGet]
        [Route("GetAllAppMenusForUserGroup")]
        public IHttpActionResult GetAllAppMenusForUserGroup(string clientgroupid)
        {
            DataTable dt = _appMenuService.GetAllAppMenusForUserGroup(clientgroupid);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));
            return Ok(dt);
        }
    }
}
