using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using IQMarketBackend.Models;
 
namespace IQMarketBackend.DI
{
    public interface IClientsService
    {
        DataTable GetClientByEmail(string email, string userName, string methodName, string formName);
        DataTable InsertUpdateNewClient(ClientModel client);
        DataTable Login(ClientModel client);
        DataTable CheckMail(string email);
        DataTable ChangePassword(ClientModel client);

    }
}
