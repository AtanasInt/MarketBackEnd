using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using IQMarketBackend.Models;


namespace IQMarketBackend.DI
{
    public interface IProductService
    {
        DataTable GetProductsByApplicationID(string appId, string userName, string methodName, string formName);
        DataTable GetAllProducts();
        DataTable InsertProduct(ProductModel product);
        DataTable UpdateProduct(ProductModel product);
    }
}