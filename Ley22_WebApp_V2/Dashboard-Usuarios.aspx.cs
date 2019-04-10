using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
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
                    Response.Redirect("Account/Login.aspx", false);
                    return;
                }

                ExistingUser = (ApplicationUser)Session["User"];
                LitNombre.Text = ExistingUser.FirstName + " " + ExistingUser.LastName;
                LitEmail.Text = ExistingUser.Email;
                LitPrimerNombre.Text = ExistingUser.FirstName;
                LitPrimerApellido.Text = ExistingUser.LastName;

                
                
                
            }
        }
    }
}