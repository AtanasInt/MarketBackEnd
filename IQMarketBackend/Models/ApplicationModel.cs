using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQMarketBackend.Models
{
    public class ApplicationModel
    {
        public string applicationid { get; set; }
        public string applicationname { get; set; }
        public string applicationtype { get; set; }
        public string mediumpartnerid { get; set; }
        public string logourl { get; set; }
    }
}