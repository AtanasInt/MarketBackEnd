
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace IQMarketBackend.Helpers
{
    public class DbConnectionHelper
    {

        string errMessage = "";
        public dynamic procedureRequest(string nameProcedure, List<sqlTbl> parameters, string database, string dataType = "DT")
        {


            MySqlConnection conn = null;
            if (database.Equals("iqmarket"))
            {
                conn = new MySqlConnection(
                    ConfigurationManager.AppSettings["ExecuteStoreProcedureConnectionString"]);
            }

            dynamic dt;
            if (dataType == "DT")
            {
                dt = new DataTable();
            }
            else
            {
                dt = new DataSet();
            }

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(nameProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (sqlTbl param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.name, MySqlDbType.VarChar)).Value = param.value;
                    }
                }
                //cmd.CommandTimeout = 0;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                setError(errMessage);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public void setError(string error)
        {
            errMessage = error;
        }

        public string getError()
        {
            return errMessage;
        }
    }
}

public class sqlTbl
{
    public string value { get; set; }
    public string name { get; set; }
    //public string tt { get; set; }
    public MySqlDbType pp { get; set; }

    public sqlTbl(string name, string value)
    {
        this.name = name;
        this.value = value;
    }

    public sqlTbl(string name, string value, MySqlDbType type)
    {
        this.name = name;
        this.value = value;
        this.pp = type;
    }


}



