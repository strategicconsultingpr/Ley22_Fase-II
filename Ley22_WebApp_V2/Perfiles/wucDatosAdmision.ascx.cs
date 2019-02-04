using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class wucDatosAdmision : System.Web.UI.UserControl
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
               
                LeerRegistro();

            }
        }

        private void LeerRegistro()
        {
            if (this.vw_perfil.DE_Comentario != "")
            {
                
                this.lblComentario.Visible = true;
                this.lblComentario.Text = this.vw_perfil.DE_Comentario;
            }
            else
            {
                divComentarios.Visible = false;
            }
        }
    }
}