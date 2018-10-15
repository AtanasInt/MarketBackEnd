using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml;
using System.IO;
namespace IQMarketBackend.Helpers
{
    public class SOAPHelper
    {
        public string CallWebService(string url, string action, Dictionary<string, string> parameters, string soapAction, bool useSOAP12 = false)
        {


            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(parameters, action, url, soapAction);
            HttpWebRequest webRequest = CreateWebRequest(url, soapAction);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }

            return soapResult;
        }

        public static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public static XmlDocument CreateSoapEnvelope(Dictionary<string, string> parameters, string action, string url, string soapAction)
        {
            XmlDocument soapEnvelopeXml = new XmlDocument();
            var xmlStr =
                 @"<soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' 
                    xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
                        <soap:Body>
                           <{0} xmlns=""{1}"">{2}</{0}>
                        </soap:Body>
                    </soap:Envelope>";

            string soap = url.Substring(0, url.LastIndexOf("/")) + "/";
            string parms = string.Join(string.Empty, parameters.Select(kv => String.Format("<{0}>{1}</{0}>", kv.Key, kv.Value)).ToArray());
            var s = String.Format(xmlStr, action, soap, parms);
            s = s.Replace("\r\n", "").Replace("\"", "'").Replace("  ", "");

            soapEnvelopeXml.LoadXml(s);
            return soapEnvelopeXml;
        }

        public static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

    }
}