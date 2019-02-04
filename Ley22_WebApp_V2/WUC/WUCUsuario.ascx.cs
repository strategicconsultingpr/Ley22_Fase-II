using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WUCUsuario : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && Session["NombreParticipante"]!=null)

            LitUsuario.Text = Session["NombreParticipante"].ToString(); 
    }
}