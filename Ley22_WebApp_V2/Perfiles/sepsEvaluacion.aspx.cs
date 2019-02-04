using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class sepsEvaluacion : System.Web.UI.Page
    {
        private int m_PK_Programa, PK_Perfil, m_PK_Persona, m_CO_Tipo;
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;
        protected SA_PROGRAMA sa_programa;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                if (this.Session["dsPerfil"] != null)
                {
                    this.dsPerfil = (SEPSEntities1)this.Session["dsPerfil"];                   
                }

                this.LeerRegistro();
            }
        }

        private void LeerRegistro()
        {
            dsPerfil = new SEPSEntities1();
            int PK_NR_Perfil = Convert.ToInt32(Request.QueryString["pk_perfil"].ToString());
            int PK_Episodio = Convert.ToInt32(Request.QueryString["pk_episodio"].ToString());
            vw_perfil = dsPerfil.VW_PERFIL.Where(u => u.PK_NR_Perfil.Equals(PK_NR_Perfil)).Single();
            int PK_Persona = vw_perfil.FK_Persona;
            //List<VW_PERFIL> vw_perfil3 = new List<VW_PERFIL>(vw_perfil2);

            vw_episodio = dsPerfil.VW_EPISODIO.Where(u => u.PK_Episodio.Equals(PK_Episodio)).Single();
            vw_persona = dsPerfil.VW_PERSONA.Where(u => u.PK_Persona.Equals(PK_Persona)).Single();
            short PK_Programa = vw_episodio.FK_Programa;
            sa_programa = dsPerfil.SA_PROGRAMA.Where(u => u.PK_Programa.Equals(PK_Programa)).Single();
            this.Session["vw_perfil"] = this.vw_perfil;
            this.Session["vw_episodio"] = this.vw_episodio;
            this.Session["vw_persona"] = this.vw_persona;
            this.Session["sa_programa"] = this.sa_programa;
            if (sa_programa.CO_Tipo == 1 || sa_programa.CO_Tipo == 4)
            {
                this.lblTipoPerfil.Text = " : Abuso de Sustancia";
            }
            else
            {
                this.lblTipoPerfil.Text = " : Salud Mental";
            }

            this.wucDatosPersonales.Persona = vw_persona;
            this.wucDatosPersonales.Perfil = vw_perfil;
            this.wucDatosPersonales.setValues();

            

        }
    }
}