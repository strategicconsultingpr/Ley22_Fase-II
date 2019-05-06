using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;


public partial class listado_perfiles : System.Web.UI.Page
{
    protected Data_SA_Persona du;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
            Session["MensajeError"] = "Por favor ingrese al sistema";
            Session["Redirect"] = "Account/Login.aspx";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }
        if (Session["SA_Persona"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
            Session["MensajeError"] = "Por favor seleccione el participante";
            Session["Redirect"] = "Entrada.aspx";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }

        if (!Page.IsPostBack)
        {
          
                du = (Data_SA_Persona)Session["SA_Persona"];

                LitIUP.Text = du.PK_Persona.ToString();
                
                LitEpisodio.Text = Request.QueryString["pk_episodio"].ToString();
            
                LoadPerfiles();
           
        }
    }

    protected void LoadPerfiles()
    {
        int PK_Episodio = Convert.ToInt32(Request.QueryString["pk_episodio"].ToString());

        using (SEPSEntities1 dsPerfil = new SEPSEntities1())
        {
            List<SPR_PERFILES_LEY22_Result> Result = dsPerfil.SPR_PERFILES_LEY22(PK_Episodio).ToList();
            
            LitEstatus.Text = Result[0].ES_Episodio;
            
            gvPerfiles.DataSource = Result;
            gvPerfiles.DataBind();

        }
    }
}

