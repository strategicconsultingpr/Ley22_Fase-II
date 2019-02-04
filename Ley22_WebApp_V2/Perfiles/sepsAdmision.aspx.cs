using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Ley22_WebApp_V2.Old_App_Code;



    public partial class sespAdmision : System.Web.UI.Page
    {
        private int m_PK_Programa, PK_Perfil, m_PK_Persona, m_CO_Tipo;
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;

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
            this.Session["vw_perfil"] = this.vw_perfil;
            this.Session["vw_episodio"] = this.vw_episodio;
            this.Session["vw_persona"] = this.vw_persona;
             
            this.wucDatosPersonales.Persona = vw_persona;
            this.wucDatosPersonales.Perfil = vw_perfil;
            this.wucDatosPersonales.setValues();

    }
    }
