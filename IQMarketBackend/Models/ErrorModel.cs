using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQMarketBackend.Models
{
    public class ErrorModel
    {
        public string ProcedureName { set; get; }
        public string ErrorMessage { set; get; }
        public string username { set; get; }
        public string ipAddress { set; get; }
        public string metodName { set; get; }
        public string controlerName { set; get; }
        public DateTime date { set; get; }
        public string parametarList { set; get; }
        public string formName { set; get; }
    }
}