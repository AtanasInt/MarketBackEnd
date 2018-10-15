using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using IQMarketBackend.Helpers;
using IQMarketBackend.Models;

namespace IQMarketBackend.DI.impl
{
    public class ClientsService : IClientsService
    {
        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        private ErrorHandler errorHandler = new ErrorHandler();
        private Encryption encryption = new Encryption();
        public DataTable GetClientByEmail(string email, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            sqlParasList.Add(new sqlTbl("@email", email));

            dt = dbConnectionHelper.procedureRequest("GetClientInfoByEmail", sqlParasList, "iqmarket");

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
        public DataTable InsertUpdateNewClient(ClientModel client)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INClientGroupID", client.CliendGroupID));
            sqlParasList.Add(new sqlTbl("@INFirstName", client.Name));
            sqlParasList.Add(new sqlTbl("@INLastName", client.LastName));
            sqlParasList.Add(new sqlTbl("@INEmal", client.Email));
            sqlParasList.Add(new sqlTbl("@INPassword", client.Password));
            sqlParasList.Add(new sqlTbl("@INDateInsert", DateTime.Now.ToString("yyyy-MM-dd")));

            dt = dbConnectionHelper.procedureRequest("InsertUpdateNewClient", sqlParasList, "iqmarket");

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
        public DataTable Login(ClientModel client)
        {

            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INEmail", client.Email));
            sqlParasList.Add(new sqlTbl("@Pass", client.Password));

            dt = dbConnectionHelper.procedureRequest("Login", sqlParasList, "iqmarket");

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
        public DataTable CheckMail(string email)
        {

            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INEmail", email));
            dt = dbConnectionHelper.procedureRequest("CheckMail", sqlParasList, "iqmarket");

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
        public DataTable ChangePassword(ClientModel client)
        {

            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INEmail", client.Email));
            sqlParasList.Add(new sqlTbl("@INPassword", client.Password));


            dt = dbConnectionHelper.procedureRequest("ChangePassword", sqlParasList, "iqmarket");

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