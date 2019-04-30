﻿using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Microsoft.AspNet.Identity;
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
                LitNombre.Text = ExistingUser.FirstName + " " + ExistingUser.LastName;
                LitEmail.Text = ExistingUser.Email;
                LitPrimerNombre.Text = ExistingUser.FirstName;
                LitPrimerApellido.Text = ExistingUser.LastName;

                
                
                
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}