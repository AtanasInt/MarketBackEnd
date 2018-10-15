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
    [RoutePrefix("api/UnitType")]
    public class UnitTypeController : ApiController
    {
        private IUnitTypeService _unitTypeService;

        public UnitTypeController(IUnitTypeService unitTypeService)
        {
            _unitTypeService = unitTypeService;
        }

        [HttpGet]
        [Route("GetAllUnitTypes")]
        public IHttpActionResult GetAllUnitTypes()
        {
            DataTable dt = _unitTypeService.GetAllUnitTypes();
            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));
            return Ok(dt);
        }
    }
}
