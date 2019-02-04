using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class wucOtrosDatosPerfil : System.Web.UI.UserControl
    {
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dsPerfil = new SEPSEntities1();
                this.vw_perfil = (VW_PERFIL)Session["vw_perfil"];
                this.vw_episodio = (VW_EPISODIO)Session["vw_episodio"];
                this.vw_persona = (VW_PERSONA)Session["vw_persona"];

                this.lblEpisodio.Text = this.vw_episodio.PK_Episodio.ToString();
                this.lblPerfil.Text = this.vw_perfil.PK_NR_Perfil.ToString();
                this.lblAdministracion.Text = this.vw_episodio.NB_Administracion;
                this.lblCentro.Text = this.vw_episodio.NB_Programa;
                this.lblFechaPerfil.Text = DateTime.Parse(this.vw_perfil.FE_Perfil.ToString()).ToShortDateString();
                this.lblFechaContacto.Text = DateTime.Parse(this.vw_perfil.FE_Contacto.ToString()).ToShortDateString();
            }

        }
    }
}