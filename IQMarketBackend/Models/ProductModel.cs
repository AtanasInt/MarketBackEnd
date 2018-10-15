using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQMarketBackend.Models
{
    public class ProductModel
    {
        public string productid { get; set; }
        public string unittypeid { get; set; }
        public string description { get; set; }
        public string minvalue { get; set; }
        public string productname { get; set; }
        public string unitprice { get; set; }
        public string defaultcurrency { get; set; }
        public string applicationid { get; set; }
        public string capacityunitperday { get; set; }
        public string bannerwidth { get; set; }
        public string bannerheight { get; set; }
    }
}