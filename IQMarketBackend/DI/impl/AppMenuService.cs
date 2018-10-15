using IQMarketBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IQMarketBackend.DI.impl
{
    public class AppMenuService : IAppMenuService
    {
        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        private ErrorHandler errorHandler = new ErrorHandler();

        public DataTable GetAllAppMenusForUserGroup(string clientgroupid)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            sqlParasList.Add(new sqlTbl("@Id", clientgroupid));

            dt = dbConnectionHelper.procedureRequest("GetAppMenusForUserGroup", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table1";
                return dt;
            }
        }
    }
}