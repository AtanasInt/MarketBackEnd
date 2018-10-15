using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using IQMarketBackend.Models;

namespace IQMarketBackend.DI
{
    public interface ICampaignService
    {
        DataTable InsertNewCampaign(CampaignModel campaign);
        DataTable GetCampaigns(string userName, string methodName, string formName);
        DataTable GetCampaignsByCampaignId(string campaignid, string userName, string methodName, string formName);
        DataTable GetCampaignsByClientId(string clientid, string userName, string methodName, string formName);
        DataTable GetCampaignsByStatus(string status, string userName, string methodName, string formName);
        DataTable SelectFutureOccupiedProductDatesByproductID(string productid, string date, string userName, string methodName, string formName);
        DataTable InsertDateProductReport(DateProductReportModel model);
        DataTable GetCampaignsOffset(string offset);
        DataTable SearchCampaignsForClientAdmin(string campaignName);
        DataTable SearchCampaignsForMediumPartner(CampaignModel campaign);
        DataTable SetStatusOnCampaign(CampaignModel campaign);
    }
}