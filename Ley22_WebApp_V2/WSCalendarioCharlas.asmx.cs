using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Ley22_WebApp_V2
{
    /// <summary>
    /// Summary description for WSCalendarioCharlas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WSCalendarioCharlas : System.Web.Services.WebService
    {

        [WebMethod]
       // [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Hello()
        {
            return "Hello";
        }
    }
}
