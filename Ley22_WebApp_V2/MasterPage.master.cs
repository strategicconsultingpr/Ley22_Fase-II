using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Security.Claims;
using System.Security.Principal;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.AppCode;

namespace Ley22_WebApp_V2
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated && ((ApplicationUser)Session["User"] != null))
            {
                ApplicationUser ExistingUser = (ApplicationUser)Session["User"];
                Usuario.Text = ExistingUser.UserName + "<br/><small>"+ Session["Role_Usuario"].ToString() + "</small>";
               
            }
            else
            {
                Response.Redirect("~/Account/Login");
            }
                
        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
