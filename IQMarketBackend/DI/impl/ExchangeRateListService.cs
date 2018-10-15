using IQMarketBackend.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using IQMarketBackend.Models;

namespace IQMarketBackend.DI.impl
{
    public class ExchangeRateListService : IExchangeRateListService
    {
        private SOAPHelper soapHelper = new SOAPHelper();

        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        private ErrorHandler errorHandler = new ErrorHandler();

        public DataTable GetLastInsertDate()
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            dt = dbConnectionHelper.procedureRequest("GetLastInsertDate", sqlParasList, "iqmarket");

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

        public DataTable GetAllCurrencies(string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            dt = dbConnectionHelper.procedureRequest("GetAllCurrencies", sqlParasList, "iqmarket");

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

        public DataTable GetAllCountries(string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            dt = dbConnectionHelper.procedureRequest("GetAllCountries", sqlParasList, "iqmarket");

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

        public DataTable InsertExchangeRateList(string startDate, string endDate)
        {
            DataTable dt = new DataTable();
            Boolean flagError = false;

            var url = ConfigurationManager.AppSettings["NBRMUrl"];
            var SOAPaction = ConfigurationManager.AppSettings["NBRM_SOAPAction"];
            var action = ConfigurationManager.AppSettings["NBRMAction"];

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("StartDate", startDate);
            parameters.Add("EndDate", endDate);

            string result = soapHelper.CallWebService(url, action, parameters, SOAPaction);

            result = result.Replace("&lt;", "<");
            result = result.Replace("&gt;", ">");

            int from = result.IndexOf("<KursZbir>");
            int to = result.LastIndexOf("</KursZbir>");

            if (from != -1 && to != -1)
            {
                string tmp = "<Root>" + result.Substring(from, to - from + 11) + "</Root>";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(tmp);
                string json = JsonConvert.SerializeXmlNode(doc);

                string array = json.Substring(json.IndexOf("[") + 1, json.Length - json.IndexOf("[") - 3);
                string[] currencies = array.Split('}');

                for (int i = 0; i < currencies.Length - 1; i++)
                {
                    if (i != 0)
                        currencies[i] = currencies[i].Substring(1, currencies[i].Length - 1);
                    currencies[i] = currencies[i] + "}";
                    ExchangeRateListModel currency = JsonConvert.DeserializeObject<ExchangeRateListModel>(currencies[i]);

                    dt = new DataTable();
                    List<sqlTbl> sqlParasList = new List<sqlTbl>();
                    DateTime dF = Convert.ToDateTime(currency.Datum_f);
                    string dateFrom = dF.ToString("yyyy-MM-dd");

                    DateTime dT = Convert.ToDateTime(currency.Datum);
                    string dateTo = dT.ToString("yyyy-MM-dd");

                    sqlParasList.Add(new sqlTbl("@codeIN", currency.Valuta));
                    sqlParasList.Add(new sqlTbl("@currencyShortcutIN", currency.Oznaka));
                    sqlParasList.Add(new sqlTbl("@currencyIN", currency.NazivMak));
                    sqlParasList.Add(new sqlTbl("@dateIN", dateTo));
                    sqlParasList.Add(new sqlTbl("@dateFromIN", dateFrom));
                    sqlParasList.Add(new sqlTbl("@countryEnglishIN", currency.DrzavaAng));
                    sqlParasList.Add(new sqlTbl("@currencyEnglishIN", currency.NazivAng));
                    sqlParasList.Add(new sqlTbl("@middleRateIN", currency.Sreden));
                    sqlParasList.Add(new sqlTbl("@countryIN", currency.Drzava));
                    sqlParasList.Add(new sqlTbl("@countryAlbanianIN", currency.DrzavaAl));
                    sqlParasList.Add(new sqlTbl("@currencyAlbanianIN", currency.ValutaNaziv_AL));
                    sqlParasList.Add(new sqlTbl("@insertDateIN", DateTime.Now.ToString("yyyy-MM-dd")));

                    dt = dbConnectionHelper.procedureRequest("InsertExchangeRateList", sqlParasList, "iqmarket");

                    if (dbConnectionHelper.getError() != "")
                    {
                        flagError = true;

                    }
                    else
                    {
                        flagError = false;
                    }

                }

                dt = new DataTable();
                List<sqlTbl> sqlPList = new List<sqlTbl>();

                DateTime d = Convert.ToDateTime(startDate);
                string date = d.ToString("yyyy-MM-dd");

                //Makedonski denari
                sqlPList.Add(new sqlTbl("@codeIN", "807"));
                sqlPList.Add(new sqlTbl("@currencyShortcutIN", "MKD"));
                sqlPList.Add(new sqlTbl("@currencyIN", "македонски денари"));
                sqlPList.Add(new sqlTbl("@dateIN", date));
                sqlPList.Add(new sqlTbl("@dateFromIN", date));
                sqlPList.Add(new sqlTbl("@countryEnglishIN", "Macedonia"));
                sqlPList.Add(new sqlTbl("@currencyEnglishIN", ""));
                sqlPList.Add(new sqlTbl("@middleRateIN", "1"));
                sqlPList.Add(new sqlTbl("@countryIN", "Македонија"));
                sqlPList.Add(new sqlTbl("@countryAlbanianIN", ""));
                sqlPList.Add(new sqlTbl("@currencyAlbanianIN", ""));
                sqlPList.Add(new sqlTbl("@insertDateIN", DateTime.Now.ToString("yyyy-MM-dd")));

                dt = dbConnectionHelper.procedureRequest("InsertExchangeRateList", sqlPList, "iqmarket");

                if (dbConnectionHelper.getError() != "")
                {
                    flagError = true;
                }
                else
                {
                    flagError = false;
                }
            }
            else
            {
                dt.TableName = "Not inserted";
                return dt;
            }


            if (flagError)
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



        public DataTable GetExchangeRateListForDate(string date, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@dateIN", date));

            dt = dbConnectionHelper.procedureRequest("GetExchangeRateListForDate", sqlParasList, "iqmarket");

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

        public DataTable CalculateAmountInCurrency(string Amount, string Currency, string OldCurrency, string Date, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            DateTime d = Convert.ToDateTime(Date);
            string date = d.ToString("yyyy-MM-dd");

            sqlParasList.Add(new sqlTbl("@Amount", Amount));
            sqlParasList.Add(new sqlTbl("@Currency", Currency));
            sqlParasList.Add(new sqlTbl("@OldCurrency", OldCurrency));
            sqlParasList.Add(new sqlTbl("@DateIN", date));

            dt = dbConnectionHelper.procedureRequest("CalculateAmountInCurrency", sqlParasList, "iqmarket");

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

        public DataTable ChangeTranasctionAmountInDefaultCurrency(string ClientID, string OldCurrencyCode, string NewCurrencyCode, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();


            sqlParasList.Add(new sqlTbl("@ClientID", ClientID));
            sqlParasList.Add(new sqlTbl("@OldCurrencyCode", OldCurrencyCode));
            sqlParasList.Add(new sqlTbl("@NewCurrencyCode", NewCurrencyCode));


            dt = dbConnectionHelper.procedureRequest("ChangeTranasctionAmountInDefaultCurrency", sqlParasList, "iqmarket");

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

        public DataTable ChangeTranasctionAmountInAccountCurrency(string AccountNumber, string OldCurrencyCode, string NewCurrencyCode, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();


            sqlParasList.Add(new sqlTbl("@AccountNumber", AccountNumber));
            sqlParasList.Add(new sqlTbl("@OldCurrencyCode", OldCurrencyCode));
            sqlParasList.Add(new sqlTbl("@NewCurrencyCode", NewCurrencyCode));


            dt = dbConnectionHelper.procedureRequest("ChangeTranasctionAmountInAccountCurrency", sqlParasList, "iqmarket");

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