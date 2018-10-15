using IQMarketBackend.Helpers;
using IQMarketBackend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IQMarketBackend.DI.impl
{
    public class ProductService :IProductService
    {
        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        private ErrorHandler errorHandler = new ErrorHandler();

        public DataTable GetProductsByApplicationID(string appId, string userName, string methodName, string formName)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();
            sqlParasList.Add(new sqlTbl("@P_ApplicationID", appId));

            dt = dbConnectionHelper.procedureRequest("GetProductsByApplication", sqlParasList, "iqmarket");

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
        public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            dt = dbConnectionHelper.procedureRequest("GetAllProducts", sqlParasList, "iqmarket");

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

        public DataTable InsertProduct(ProductModel product)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@INUnitType", product.unittypeid));
            sqlParasList.Add(new sqlTbl("@Descr", product.description));
            sqlParasList.Add(new sqlTbl("@MinValue", product.minvalue));
            sqlParasList.Add(new sqlTbl("@ProdName", product.productname));
            sqlParasList.Add(new sqlTbl("@INUnitPrice", product.unitprice));
            sqlParasList.Add(new sqlTbl("@Currency", product.defaultcurrency));
            sqlParasList.Add(new sqlTbl("@Application", product.applicationid));
            sqlParasList.Add(new sqlTbl("@CapUnitPerDay", product.capacityunitperday));
            sqlParasList.Add(new sqlTbl("@Width", product.bannerwidth));
            sqlParasList.Add(new sqlTbl("@Height", product.bannerheight));

            dt = dbConnectionHelper.procedureRequest("InsertNewProduct", sqlParasList, "iqmarket");

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

        public DataTable UpdateProduct(ProductModel product)
        {
            DataTable dt = new DataTable();
            List<sqlTbl> sqlParasList = new List<sqlTbl>();

            sqlParasList.Add(new sqlTbl("@ProdID", product.productid));
            sqlParasList.Add(new sqlTbl("@INUnitType", product.unittypeid));
            sqlParasList.Add(new sqlTbl("@Descr", product.description));
            sqlParasList.Add(new sqlTbl("@MinValue", product.minvalue));
            sqlParasList.Add(new sqlTbl("@ProdName", product.productname));
            sqlParasList.Add(new sqlTbl("@INUnitPrice", product.unitprice));
            sqlParasList.Add(new sqlTbl("@Currency", product.defaultcurrency));
            sqlParasList.Add(new sqlTbl("@ApplicationID", product.applicationid));
            sqlParasList.Add(new sqlTbl("@CapUnitPerDay", product.capacityunitperday));
            sqlParasList.Add(new sqlTbl("@Width", product.bannerwidth));
            sqlParasList.Add(new sqlTbl("@Height", product.bannerheight));

            dt = dbConnectionHelper.procedureRequest("UpdateProduct", sqlParasList, "iqmarket");

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