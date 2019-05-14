using Ley22_WebApp_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class MasterPerfil : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ApplicationUser ExistingUser = (ApplicationUser)Session["User"];
                string userId = ExistingUser.Id;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                Usuario.Text = ExistingUser.UserName + "<br/><small>" + Session["Role_Usuario"].ToString() + "</small>";

                if (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "TrabajadorSocial")
                  || userManager.IsInRole(userId, "Recepcion") || userManager.IsInRole(userId, "CoordinadorCharlas"))
                {
                    liExpediente.Visible = true;
                    liDocumentos.Visible = true;
                }
                if (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "TrabajadorSocial"))
                {
                    liCitas.Visible = true;
                }
                if (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "CoordinadorCharlas"))
                {
                    liCharlas.Visible = true;
                }
                if (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "Recaudador"))
                {
                    liRecaudo.Visible = true;
                    liReportes.Visible = true;
                }

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