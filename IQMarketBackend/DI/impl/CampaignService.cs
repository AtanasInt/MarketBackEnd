using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using IQMarketBackend.Helpers;
using IQMarketBackend.Models;

namespace IQMarketBackend.DI.impl
{
    public class CampaignService : ICampaignService
    {
        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        private ErrorHandler errorHandler = new ErrorHandler();
        private Encryption encryption = new Encryption();

        public DataTable InsertNewCampaign(CampaignModel campaign)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();


            sqlParasList.Add(new sqlTbl("@P_ProductID", campaign.ProductID));
            sqlParasList.Add(new sqlTbl("@P_MediumPartnerID", campaign.MediumPartnerID));
            sqlParasList.Add(new sqlTbl("@P_ClientID", campaign.ClientID));
            sqlParasList.Add(new sqlTbl("@P_ApplicationID", campaign.ApplicationID));
            sqlParasList.Add(new sqlTbl("@P_StartDate", campaign.StartDate));//.ToString("yyyy-MM-dd")));
            sqlParasList.Add(new sqlTbl("@P_PriceNoDiscount", campaign.PriceNoDiscount));
            sqlParasList.Add(new sqlTbl("@P_DiscountPercentage", campaign.DiscountPercentage));
            sqlParasList.Add(new sqlTbl("@P_Discount", campaign.Discount));
            sqlParasList.Add(new sqlTbl("@P_CampaignPrice", campaign.CampaignPrice));
            sqlParasList.Add(new sqlTbl("@P_CampaignTextLong", campaign.CampaignTextLong));
            sqlParasList.Add(new sqlTbl("@P_Status", campaign.Status));
            sqlParasList.Add(new sqlTbl("@P_CampaignTextShort", campaign.CampaignTextShort));
            sqlParasList.Add(new sqlTbl("@P_CampaignImagePath", campaign.CampaignImagePath));
            sqlParasList.Add(new sqlTbl("@P_CampaignLink", campaign.CampaignLink));
            sqlParasList.Add(new sqlTbl("@P_CampaignName", campaign.CampaignName));
            sqlParasList.Add(new sqlTbl("@P_GainedImpressions", campaign.GainedImpressions));
            sqlParasList.Add(new sqlTbl("@P_BoughtImpressions", campaign.BoughtImpressions));
            sqlParasList.Add(new sqlTbl("@P_UserInsert", campaign.UserInsert));
            sqlParasList.Add(new sqlTbl("@P_DateInsert", campaign.DateInsert));
            sqlParasList.Add(new sqlTbl("@P_UserUpdate", campaign.UserUpdate));
            sqlParasList.Add(new sqlTbl("@P_DateUpdate", campaign.DateUpdate));
            sqlParasList.Add(new sqlTbl("@P_DateChangeStatus", campaign.DateChangeStatus));




            dt = dbConnectionHelper.procedureRequest("InsertNewCampaign", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {
                //ErrorModel error = new ErrorModel();
                //error.controlerName = "CampaignController";
                //error.ProcedureName = "InsertNewCampaign";
                //error.metodName = campaign.methodName;
                //error.formName = campaign.formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = campaign.userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {

                dt.TableName = "Table";
                return dt;
            }
        }
        public DataTable GetCampaigns(string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            

            dt = dbConnectionHelper.procedureRequest("GetCampaigns", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }
        public DataTable InsertDateProductReport(DateProductReportModel model)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            sqlParasList.Add(new sqlTbl("@P_DateImpressions", model.DateImpressions));
            sqlParasList.Add(new sqlTbl("@P_OccupiedImpressions", model.OccupiedImpressions));
            sqlParasList.Add(new sqlTbl("@P_CampaignID", model.CampaignID));
            sqlParasList.Add(new sqlTbl("@P_ProductID", model.ProductID));
            sqlParasList.Add(new sqlTbl("@P_UserInsert", model.UserInsert));//.ToString("yyyy-MM-dd")));
            sqlParasList.Add(new sqlTbl("@P_DateInsert", model.DateInsert));
            sqlParasList.Add(new sqlTbl("@P_UserUpdate", model.UserUpdate));
            sqlParasList.Add(new sqlTbl("@P_DateUpdate", model.DateUpdate));
            sqlParasList.Add(new sqlTbl("@P_CapacityPerDay", model.CapacityPerDay));



            dt = dbConnectionHelper.procedureRequest("InsertNewDateProductReport", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }
        public DataTable GetCampaignsByCampaignId(string campaignid, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();


            sqlParasList.Add(new sqlTbl("@P_CampaignID", campaignid));
            dt = dbConnectionHelper.procedureRequest("GetCampaignByCampaignId", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }

        }
        public DataTable GetCampaignsByClientId(string clientid, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();


            sqlParasList.Add(new sqlTbl("@P_ClientID", clientid));
            dt = dbConnectionHelper.procedureRequest("GetCampaignsByClientId", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }

        public DataTable GetCampaignsByStatus(string status, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();


            sqlParasList.Add(new sqlTbl("@P_Status", status));
            dt = dbConnectionHelper.procedureRequest("GetCampaignsByStatus", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }
        public DataTable SelectFutureOccupiedProductDatesByproductID(string productid, string date, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            sqlParasList.Add(new sqlTbl("@INProductID", productid));
            sqlParasList.Add(new sqlTbl("@INToday", date));
            dt = dbConnectionHelper.procedureRequest("SelectFutureOccupiedProductDatesByproductID", sqlParasList, "iqmarket");
            

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }

        }
        public DataTable GetCampaignsOffset(string offset)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INOffset", offset));
            dt = dbConnectionHelper.procedureRequest("GetCampaigns", sqlParasList, "iqmarket");


            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }
        public DataTable SearchCampaignsForClientAdmin(string campaignName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();


            sqlParasList.Add(new sqlTbl("@INCampaignName", campaignName));
            dt = dbConnectionHelper.procedureRequest("SearchCampaignsForClientAdmin", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }

        public DataTable SearchCampaignsForMediumPartner(CampaignModel campaign)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INClientID", campaign.ClientID));
            sqlParasList.Add(new sqlTbl("@INCampaignName", campaign.CampaignName));
            dt = dbConnectionHelper.procedureRequest("SearchCampaignsForMediumPartner", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
                dt.TableName = "Error";
                return dt;
            }
            else
            {
                dt.TableName = "Table";
                return dt;
            }
        }

        public DataTable SetStatusOnCampaign(CampaignModel campaign)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INStatus", campaign.Status));
            sqlParasList.Add(new sqlTbl("@INCampaignID", campaign.CampaignID));
            dt = dbConnectionHelper.procedureRequest("SetStatusOnCampaign", sqlParasList, "iqmarket");

            if (dbConnectionHelper.getError() != "")
            {

                //ErrorModel error = new ErrorModel();
                //error.controlerName = "UserController";
                //error.ProcedureName = "GetUserInfoByEmail";
                //error.metodName = methodName;
                //error.formName = formName;
                //error.date = DateTime.Now;
                //error.ErrorMessage = dbConnectionHelper.getError();
                //error.username = userName;
                //foreach (sqlTbl el in sqlParasList)
                //    error.parametarList += el.name + ": " + el.value + ";";

                //errorHandler.errorLogInsert(error);
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