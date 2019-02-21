using Ley22_WebApp_V2.Models;
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
                ExistingUser = (ApplicationUser)Session["User"];
                LitNombre.Text = ExistingUser.Email;
                LitEmail.Text = ExistingUser.Email;
                
            }
        }
    }
}