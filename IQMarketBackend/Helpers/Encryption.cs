using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQMarketBackend.Helpers
{
    public class Encryption
    {
        public string EncryptPassword(string password)
        {
            Byte[] b = (new System.Security.Cryptography.MD5CryptoServiceProvider())
                .ComputeHash((new System.Text.UnicodeEncoding()).GetBytes(password));
            return (new System.Text.ASCIIEncoding()).GetString(b);
        }
    }
}