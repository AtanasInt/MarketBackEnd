using IQMarketBackend.Helpers;
using IQMarketBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IQMarketBackend.DI.impl
{
    public class ApplicationService : IApplicationService
    {
        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        private ErrorHandler errorHandler = new ErrorHandler();

        public DataTable GetAllApplications(string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            dt = dbConnectionHelper.procedureRequest("GetAllApplications", sqlParasList, "iqmarket");

            if(dbConnectionHelper.getError() != "")
            {
               
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }

        }
        public DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            dt = dbConnectionHelper.procedureRequest("GetAllApplicationTypes", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }

        }

        public DataTable InsertApplication(ApplicationModel application)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            sqlParasList.Add(new sqlTbl("@AppName", application.applicationname));
            sqlParasList.Add(new sqlTbl("@AppType", application.applicationtype));
            sqlParasList.Add(new sqlTbl("@MedPartnerID", application.mediumpartnerid));
            sqlParasList.Add(new sqlTbl("@LogoUrl", application.logourl));

            dt = dbConnectionHelper.procedureRequest("InsertApplication", sqlParasList, "iqmarket");

            if(dbConnectionHelper.getError() != "")
            {
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }

        public DataTable UpdateApplication(ApplicationModel application)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            sqlParasList.Add(new sqlTbl("@AppID", application.applicationid));
            sqlParasList.Add(new sqlTbl("@AppName", application.applicationname));
            sqlParasList.Add(new sqlTbl("@AppType", application.applicationtype));
            sqlParasList.Add(new sqlTbl("@MedPartnerID", application.mediumpartnerid));
            sqlParasList.Add(new sqlTbl("@LogoUrl", application.logourl));

            dt = dbConnectionHelper.procedureRequest("UpdateApplication", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }
    }
}