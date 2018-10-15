using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQMarketBackend.DI;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using IQMarketBackend.Models;

namespace IQMarketBackend.Controllers.Api
{
    //[System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Campaign")]
    public class CampaignController : ApiController
    {
        private ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;


        }
        [HttpPost]
        [Route("InsertNewCampaign")]
        public IHttpActionResult InsertNewCampaigns(CampaignModel campaign)
        {
            //campaign.AgentID = "4";
            DataTable dt = _campaignService.InsertNewCampaign(campaign);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpPost]
        [Route("InsertDateProductReport")]
        public IHttpActionResult InsertDateProductReport(DateProductReportModel model)
        {
            //campaign.AgentID = "4";
            DataTable dt = _campaignService.InsertDateProductReport(model);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpGet]
        [Route("GetCampaigns")]
        public IHttpActionResult GetCampaigns(string userName, string methodName, string formName)
        {
            DataTable dt = _campaignService.GetCampaigns( userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpGet]
        [Route("GetCampaignByCampaignId")]
        public IHttpActionResult GetCampaignByCampaignId(string campaignid, string userName, string methodName, string formName)
        {
            DataTable dt = _campaignService.GetCampaignsByCampaignId(campaignid, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpGet]
        [Route("GetCampaignByClientId")]
        public IHttpActionResult GetCampaignByClientId(string clientid, string userName, string methodName, string formName)
        {
            DataTable dt = _campaignService.GetCampaignsByClientId(clientid, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpGet]
        [Route("GetCampaignByStatus")]
        public IHttpActionResult GetCampaignByStatus(string status, string userName, string methodName, string formName)
        {
            DataTable dt = _campaignService.GetCampaignsByStatus(status, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

        [HttpGet]
        [Route("SelectFutureOccupiedProductDatesByProductID")]
        public IHttpActionResult SelectFutureOccupiedProductDatesByProductID(string productid, string date, string userName, string methodName, string formName)
        {
            DataTable dt = _campaignService.SelectFutureOccupiedProductDatesByproductID(productid, date, userName, methodName, formName);

            if(dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }


        [HttpPost]
        [Route("uploadFile")]

        public IHttpActionResult UploadFile()

        {



            try

            {

                var outPutDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase));
                var iconPath = Path.Combine(outPutDirectory);
                string icon_path = new Uri(iconPath).LocalPath;


                var httpRequest = HttpContext.Current.Request;



                foreach (string file in httpRequest.Files)

                {

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);



                    var postedFile = httpRequest.Files[file];

                    if (postedFile != null && postedFile.ContentLength > 0)

                    {



                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB



                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };

                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));

                        var extension = ext.ToLower();

                        if (!AllowedFileExtensions.Contains(extension))

                        {



                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError(message + "ne e dozvolena ekstenzija")));



                        }

                        else if (postedFile.ContentLength > MaxContentLength)

                        {



                            var message = string.Format("Please Upload a file upto 1 mb.");

                            return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError(message + "pregolema slika !")));



                        }

                        else

                        {



                            // YourModelProperty.imageurl = userInfo.email_id + extension;

                            //  where you want to attach your imageurl



                            //if needed write the code to update the table



                            //var filePath = HttpContext.Current.Server.MapPath("~/Images/" + postedFile.FileName);
                            var filePath = HttpContext.Current.Server.MapPath("~/Images/" + postedFile.FileName);

                            //Userimage myfolder name where i want to save my image

                            postedFile.SaveAs(filePath);

                            return Ok(filePath);

                        }

                    }



                }

                var res = string.Format("Please Upload a image.");

                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError(res)));



            }



            catch (Exception ex)

            {

                var res = string.Format("some Message");

                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError(res)));



            }

        }
        [HttpGet]
        [Route("GetCampaigns")]
        public IHttpActionResult GetCampaignsOffset(string offset)
        {
            DataTable dt = _campaignService.GetCampaignsOffset(offset);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpGet]
        [Route("SearchCampaignsForClientAdmin")]
        public IHttpActionResult SearchCampaignsForClientAdmin(string campaignName)
        {
            DataTable dt = _campaignService.SearchCampaignsForClientAdmin(campaignName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

        [HttpPost]
        [Route("SearchCampaignsForMediumPartner")]
        public IHttpActionResult SearchCampaignsForMediumPartner(CampaignModel campaign)
        {
            DataTable dt = _campaignService.SearchCampaignsForMediumPartner(campaign);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpPost]
        [Route("SetStatusOnCampaign")]
        public IHttpActionResult SetStatusOnCampaign(CampaignModel campaign)
        {
            DataTable dt = _campaignService.SetStatusOnCampaign(campaign);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

    }
}

