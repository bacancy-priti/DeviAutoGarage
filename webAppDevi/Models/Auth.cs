using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
        if (AuthorizeRequest(actionContext))
        {
            return;
        }
        HandleUnauthorizedRequest(actionContext);
    }

    protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
        //Code to handle unauthorized request
        actionContext.Response = actionContext.Request
                .CreateErrorResponse(HttpStatusCode.Unauthorized, "You are not authorise to call API");
    }

    private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
        //Write your code here to perform authorization
        if (AuthorizeRequestForIPAddress() == true)
            return true;
        else
            return true;
    }
    private bool AuthorizeRequestForIPAddress()
    {
        string clientIPAddress = GetClientIpaddress();

        if (!string.IsNullOrEmpty(clientIPAddress))
        {
            string isCheckIP = WebConfigurationManager.AppSettings["IsCheckIP"];
            if (isCheckIP == "1")
            {
                string sequrityIPAddress = Convert.ToString(WebConfigurationManager.AppSettings["SecurityIPAddress"]);
                var addresses = sequrityIPAddress.Split(',');
                if (addresses.Length > 0)
                {
                    return addresses.Contains(clientIPAddress);
                }
            }
            else
            {
                return true;
            }
        }
        return false;
    }
    private string GetClientIpaddress()
    {
        string ipAddress = string.Empty;
        //ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        ipAddress = HttpContext.Current.Request.UserHostAddress;
        if (ipAddress == "" || ipAddress == null)
        {
            ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return ipAddress;
        }
        else
        {
            //
            return ipAddress;
        }
    }
}
