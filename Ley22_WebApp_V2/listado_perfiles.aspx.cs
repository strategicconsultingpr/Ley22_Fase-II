using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;


public partial class listado_perfiles : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["DataParticipante"] != null)
            {
                DataParticipante du = (DataParticipante)Session["DataParticipante"];

                LitIUP.Text = du.IUP.ToString();
                LitLicencia.Text = du.Licencia;
                LitEpisodio.Text = Request.QueryString["pk_episodio"].ToString();
            }
            LoadPerfiles();
            //int TotalReg = BindGridView(1);
            //this.FillJumpToList(TotalReg);
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

