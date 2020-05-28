using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
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
    public partial class Dashboard_Usuarios : System.Web.UI.Page
    {
        ApplicationUser ExistingUser = new ApplicationUser();
        ApplicationDbContext context = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["User"] == null)
                {
                    Session["TipodeAlerta"] = ConstTipoAlerta.Info;
                    Session["MensajeError"] = "Por favor ingrese al sistema";
                    Session["Redirect"] = "Account/Login.aspx";
                    Response.Redirect("Mensajes.aspx", false);
                    return;
                }

                ExistingUser = (ApplicationUser)Session["User"];
                string userId = ExistingUser.Id;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var roles = userManager.GetRoles(userId);

                foreach (var rol in roles)
                {
                    LitRoles.Text += rol + " ";
                }

                LitNombre.Text = ExistingUser.FirstName + " " + ExistingUser.LastName;
                LitEmail.Text = ExistingUser.Email;
                LitPrimerNombre.Text = ExistingUser.FirstName;
                LitPrimerApellido.Text = ExistingUser.LastName;

                if(userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "TrabajadorSocial") 
                   || userManager.IsInRole(userId, "Recepcion") || userManager.IsInRole(userId, "CoordinadorCharlas"))                   
                {
                    divExpediente.Visible = true;
                }
                if(userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "TrabajadorSocial"))
                {
                    divCitas.Visible = true;
                }
                if(userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "CoordinadorCharlas"))
                {
                    divCharlas.Visible = true;
                }
                if(userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor") || userManager.IsInRole(userId, "Recaudador"))
                {
                    divRecaudos.Visible = true;
                    divReportes.Visible = true;
                }
                if(userManager.IsInRole(userId, "TrabajadorSocial"))
                {
                    divReportes.Visible = true;
                }

                string url = Server.MapPath("~/images/editar-usuario-registrado.png");
                //imgEditar.ImageUrl = ResolveClientUrl("~/images/editar-usuario-registrado.png");
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}