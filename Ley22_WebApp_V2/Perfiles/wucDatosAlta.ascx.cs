using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class wucDatosAlta : System.Web.UI.UserControl
    {
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;
        protected SA_PROGRAMA sa_programa;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dsPerfil = new SEPSEntities1();
                this.vw_perfil = (VW_PERFIL)Session["vw_perfil"];
                this.vw_episodio = (VW_EPISODIO)Session["vw_episodio"];
                this.vw_persona = (VW_PERSONA)Session["vw_persona"];
                this.sa_programa = (SA_PROGRAMA)Session["sa_programa"];

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

            var categoria = this.dsPerfil.VW_PERFIL.Where(u => u.PK_NR_Perfil.Equals(vw_perfil.PK_NR_Perfil)).Select(p => p.FK_CategoriaCentroPrivado);
            var Dref = this.dsPerfil.SA_LKP_CATEGORIAS_CENTROS_PRIVADOS.Where(p => categoria.Contains(p.PK_CategoriaCentroPrivado)).Select(u => new ListItem { Value = u.PK_CategoriaCentroPrivado.ToString(), Text = u.DE_CategoriaCentroPrivado }).ToList();
            if(Dref.Count > 0)
            {
                lblCategoriaDeCentroPrivado.Text = Dref[0].Text;
            }
            
            
            this.lblRazonAlta.Text = this.vw_perfil.DE_Alta;
            
            if (this.vw_perfil.FK_Alta.ToString() == "3")
            {
                this.lblCentroReferido.Text = this.sa_programa.NB_Programa;
            }
            else
            {
                this.lblCentroReferido.Text = "(NO APLICA)";
            }
        }
    }
}