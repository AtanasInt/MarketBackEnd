using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMarketBackend.DI
{
    public interface IExchangeRateListService
    {
        DataTable GetLastInsertDate();

        DataTable InsertExchangeRateList(string startDate, string endDate);

        DataTable GetExchangeRateListForDate(string date, string userName, string methodName, string formName);

        DataTable GetAllCurrencies(string userName, string methodName, string formName);

        DataTable GetAllCountries(string userName, string methodName, string formName);

        DataTable CalculateAmountInCurrency(string Amount, string Currency, string OldCurrency, string Date, string userName, string methodName, string formName);

        DataTable ChangeTranasctionAmountInDefaultCurrency(string ClientID, string OldCurrencyCode, string NewCurrencyCode, string userName, string methodName, string formName);
        DataTable ChangeTranasctionAmountInAccountCurrency(string AccountNumber, string OldCurrencyCode, string NewCurrencyCode, string userName, string methodName, string formName);
    }
}
