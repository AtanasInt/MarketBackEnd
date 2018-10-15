using IQMarketBackend.DI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IQMarketBackend.Controllers.Api
{
    //[System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ExchangeRateList")]
    public class ExchangeRateListController : ApiController
    {
        private IExchangeRateListService _exchangeRateListService;

        public ExchangeRateListController(IExchangeRateListService exchangeRateListService)
        {
            _exchangeRateListService = exchangeRateListService;
        }

        [HttpGet]
        [Route("GetLastInsertDate")]
        public IHttpActionResult GetLastInsertDate()
        {
            DataTable dt = _exchangeRateListService.GetLastInsertDate();

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }

        [HttpGet]
        [Route("InsertExchangeRateListForDate")]
        public IHttpActionResult InsertExchangeRateListForDate(string startDate, string endDate, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            dt = _exchangeRateListService.InsertExchangeRateList(startDate, endDate);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));
            else if (dt.TableName == "Not inserted")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)200, new HttpError("Exchange rate list for today was not inserted yet")));

            return Ok(dt);

        }
        [HttpGet]
        [Route("InsertExchangeRateList")]
        public IHttpActionResult InsertExchangeRateList()
        {
            String lastDate = HttpContext.Current.Application["lastDate"] as String;
            DataTable dt = new DataTable();
            string today = DateTime.Now.ToShortDateString();

            DateTime startDate;
            DateTime endDate = DateTime.Now;

            if (lastDate != null)
            {
                if (lastDate == today)
                {
                    return Ok();
                }
                else
                {
                    startDate = Convert.ToDateTime(lastDate);

                    for (int i = 1; i < (endDate - startDate).TotalDays; i++)
                    {
                        dt = _exchangeRateListService.InsertExchangeRateList(startDate.AddDays(i).ToShortDateString(), startDate.AddDays(i).ToShortDateString());
                    }

                    if (dt.TableName == "Table")
                        HttpContext.Current.Application["lastDate"] = today;
                }
            }
            else
            {
                //Application first start
                dt = _exchangeRateListService.GetLastInsertDate();
                string lastInsertDate = dt.Rows[0][0].ToString();


                if (lastInsertDate.Substring(0, 10) == today)
                {
                    return Ok();
                }
                else
                {
                    startDate = Convert.ToDateTime(lastInsertDate);
                    for (int i = 1; i < (endDate - startDate).TotalDays; i++)
                    {
                        dt = _exchangeRateListService.InsertExchangeRateList(startDate.AddDays(i).ToShortDateString(), startDate.AddDays(i).ToShortDateString());
                    }

                    if (dt.TableName == "Table")
                        HttpContext.Current.Application["lastDate"] = today;
                }



            }


            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));
            else if (dt.TableName == "Not inserted")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)200, new HttpError("Exchange rate list for today was not inserted yet")));

            return Ok(dt);
        }


        [HttpGet]
        [Route("GetAllCurrencies")]
        public IHttpActionResult GetAllCurrencies(string userName, string methodName, string formName)
        {
            DataTable dt = _exchangeRateListService.GetAllCurrencies(userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }


        [HttpGet]
        [Route("GetAllCountries")]
        public IHttpActionResult GetAllCountries(string userName, string methodName, string formName)
        {
            DataTable dt = _exchangeRateListService.GetAllCountries(userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }


        [HttpGet]
        [Route("GetExchangeRateListForDate")]
        public IHttpActionResult GetExchangeRateListForDate(string date, string userName, string methodName, string formName)
        {
            DataTable dt = _exchangeRateListService.GetExchangeRateListForDate(date, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }


        [HttpGet]
        [Route("CalculateAmountInCurrency")]
        public IHttpActionResult CalculateAmountInCurrency(string Amount, string Currency, string OldCurrency, string Date, string userName, string methodName, string formName)
        {
            DataTable dt = _exchangeRateListService.CalculateAmountInCurrency(Amount, Currency, OldCurrency, Date, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }


        [HttpGet]
        [Route("ChangeTranasctionAmountInDefaultCurrency")]
        public IHttpActionResult ChangeTranasctionAmountInDefaultCurrency(string ClientID, string OldCurrencyCode, string NewCurrencyCode, string userName, string methodName, string formName)
        {
            DataTable dt = _exchangeRateListService.ChangeTranasctionAmountInDefaultCurrency(ClientID, OldCurrencyCode, NewCurrencyCode, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }


        [HttpGet]
        [Route("ChangeTranasctionAmountInAccountCurrency")]
        public IHttpActionResult ChangeTranasctionsCurrencyByAccountNumber(string AccountNumber, string OldCurrencyCode, string NewCurrencyCode, string userName, string methodName, string formName)
        {
            DataTable dt = _exchangeRateListService.ChangeTranasctionAmountInAccountCurrency(AccountNumber, OldCurrencyCode, NewCurrencyCode, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
    }
}
