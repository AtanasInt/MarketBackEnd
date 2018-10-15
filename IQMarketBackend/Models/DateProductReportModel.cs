using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQMarketBackend.Models;

namespace IQMarketBackend.Models
{
    public class DateProductReportModel
    {
        public string userName { get; set; }
        public string formName { get; set; }
        public string methodName { get; set; }
        public string DateImpressions { get; set; }
        public string OccupiedImpressions { get; set; }
        public string CampaignID { get; set; }
        public string ProductID { get; set; }
        public string UserInsert { get; set; }
        public string DateInsert { get; set; }
        public string UserUpdate { get; set; }
        public string DateUpdate { get; set; }
        public string CapacityPerDay { get; set; }
    }
}
