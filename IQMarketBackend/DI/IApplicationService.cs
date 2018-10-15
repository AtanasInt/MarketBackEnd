using IQMarketBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMarketBackend.DI
{
    public interface IApplicationService
    {
        DataTable GetAllApplications(string userName, string methodName, string formName);
        DataTable GetAllApplicationTypes();
        DataTable InsertApplication(ApplicationModel application);
        DataTable UpdateApplication(ApplicationModel application);
    } 
}
