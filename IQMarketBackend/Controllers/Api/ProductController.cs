using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQMarketBackend.DI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using IQMarketBackend.Models;

namespace IQMarketBackend.Controllers.Api
{
    //[System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;


        }

        [HttpGet]
        [Route("GetProductsByApplicationID")]
        public IHttpActionResult GetProductsByApplicationID(string appId, string userName, string methodName, string formName)
        {
            DataTable dt = _productService.GetProductsByApplicationID(appId, userName, methodName, formName);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));

            return Ok(dt);
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            DataTable dt = _productService.GetAllProducts();

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Something went wrong")));
            return Ok(dt);

        }

        [HttpPost]
        [Route("InsertProduct")]
        public IHttpActionResult InsertProduct(ProductModel product)
        {
            DataTable dt = _productService.InsertProduct(product);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Someting went wrong")));
            return Ok(dt);

        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IHttpActionResult UpdateProduct(ProductModel product)
        {
            DataTable dt = _productService.UpdateProduct(product);

            if (dt.TableName == "Error")
                return ResponseMessage(Request.CreateErrorResponse((HttpStatusCode)500, new HttpError("Someting went wrong")));
            return Ok(dt);

        }
    }
}