using IQMarketBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IQMarketBackend.DI.impl
{
    public class UnitTypeService : IUnitTypeService
    {
        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        private ErrorHandler errorHandler = new ErrorHandler();

        public DataTable GetAllUnitTypes()
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            dt = dbConnectionHelper.procedureRequest("GetAllUnitTypes", sqlParasList, "iqmarket");

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