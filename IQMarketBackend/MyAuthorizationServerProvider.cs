using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using IQMarketBackend.Helpers;

namespace IQMarketBackend
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private DbConnectionHelper dbConnectionHelper = new DbConnectionHelper();
        //public string EncryptPassword(string password)
        //{
        //    Byte[] b = (new System.Security.Cryptography.MD5CryptoServiceProvider()).ComputeHash((new System.Text.UnicodeEncoding()).GetBytes(password));
        //    return (new System.Text.ASCIIEncoding()).GetString(b);
        //}
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "@dminTok" && context.Password == "@dminTok")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Sourav Mondal"));
                context.Validated(identity);
            }
            else
            {

                System.Data.DataTable dt = new System.Data.DataTable();
                List<sqlTbl> sqlParasList = new List<sqlTbl>();
                sqlParasList.Add(new sqlTbl("@INEmail", context.UserName));
                sqlParasList.Add(new sqlTbl("@Pass", context.Password)); //EncryptPassword(context.Password)));
                


                dt = dbConnectionHelper.procedureRequest("Login", sqlParasList, "iqmarket");
                if (dbConnectionHelper.getError() != "" || dt.Rows.Count == 0)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                else
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    identity.AddClaim(new Claim("username", "user"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
                    context.Validated(identity);
                }

                //Debug.WriteLine("EEE"+ e);
                //Debug.WriteLine("EEE");
                //context.SetError("invalid_grant", "Provided username and password is incorrect");
                //    return;
                //if (context.UserName == "user" && context.Password == "user")
                //{
                //    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                //    identity.AddClaim(new Claim("username", "user"));
                //    identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
                //    context.Validated(identity);
                //}
                //else
                //{
                //    context.SetError("invalid_grant", "Provided username and password is incorrect");
                //    return;
                //}
            }

        }


    }
}