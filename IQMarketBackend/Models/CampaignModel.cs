using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQMarketBackend.Models;

namespace IQMarketBackend.Models
{
    public class CampaignModel
    {
        
            public string userName { get; set; }
            public string formName { get; set; }
            public string methodName { get; set; }
            public string CampaignID { get; set; }
            public string ProductID { get; set; }
            public string MediumPartnerID { get; set; }
            public string ClientID { get; set; }
            public string ApplicationID { get; set; }
            public string StartDate { get; set; }
            public string PriceNoDiscount { get; set; }
            public string DiscountPercentage { set; get; }
            public string Discount { set; get; }
            public string CampaignPrice { get; set; }
            public string CampaignTextLong { get; set; }
            public string Status { get; set; }
            public string CampaignTextShort { get; set; }
            public string CampaignImagePath { get; set; }
            public string CampaignLink { get; set; }
            public string CampaignName { get; set; }
            public string GainedImpressions { get; set; }
            public string BoughtImpressions { get; set; }
            public string UserInsert { get; set; }
            public string DateInsert { get; set; }
            public string UserUpdate { get; set; }
            public string DateUpdate { get; set; }
            public string DateChangeStatus { get; set; }
            

        
    }
}