using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using IQMarketBackend.Helpers;
using IQMarketBackend.Models;

namespace IQMarketBackend.Helpers
{
    public class ErrorHandler
    {
        private DbConnectionHelper _db = new DbConnectionHelper();

        public void logInsert(string logText)
        {
            try
            {
                string systemPath = Environment.SystemDirectory;
                string logPath =
                    systemPath.Substring(0, systemPath.IndexOf("\\")) +
                    "\\eBankaWSLog\\"; //ConfigurationSettings.AppSettings["LogProverka"].ToString();

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }


                var problematicFunction = new StackFrame(1, true).GetMethod().Name;

                logPath += DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                           "BankNetWSLog.txt";
                File.AppendAllText(logPath,
                    DateTime.Now.ToShortTimeString() + " - " + logText + " - In -> " + problematicFunction +
                    Environment.NewLine);

            }
            catch (Exception ex)
            {
                //ne pravi nisto, prodolzi ponatamu
            }

        }

        public void errorLogInsert(ErrorModel err)
        {

            List<sqlTbl> sqlParamsPartiiList = new List<sqlTbl>();
            sqlParamsPartiiList.Add(new sqlTbl("@ProcedureName", err.ProcedureName));
            sqlParamsPartiiList.Add(new sqlTbl("@MethodName", err.metodName));
            sqlParamsPartiiList.Add(new sqlTbl("@ControllerName", err.controlerName));
            sqlParamsPartiiList.Add(new sqlTbl("@ParameterList", err.parametarList));
            sqlParamsPartiiList.Add(new sqlTbl("@date", err.date.ToString()));
            sqlParamsPartiiList.Add(new sqlTbl("@ErrorMessage", err.ErrorMessage));
            sqlParamsPartiiList.Add(new sqlTbl("@UserName", err.username));
            sqlParamsPartiiList.Add(new sqlTbl("@FormName", err.formName));
            _db.procedureRequest("ErrorLogEmailingInsert", sqlParamsPartiiList, "iqmarket");
            if (_db.getError() != "")
            {
                Debug.WriteLine("GRESKA");
            }

        }
    }
}