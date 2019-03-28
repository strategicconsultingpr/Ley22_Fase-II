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
    public partial class OrdenNuevo : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        ApplicationUser ExistingUser = new ApplicationUser();
        Data_SA_Persona sa_persona = new Data_SA_Persona();

        protected void Page_Load(object sender, EventArgs e)
        {
            ExistingUser = (ApplicationUser)Session["User"];
            sa_persona = (Data_SA_Persona)Session["SA_Persona"];
            
            if (Request.UrlReferrer != null)
            {
                prevPage = Request.UrlReferrer.ToString();
            }

            LoadDropDownList();
        }

        void LoadDropDownList()
        {
            using (SEPSEntities MyLib = new SEPSEntities())
            {

                DdlSexo.DataValueField = "pk_sexo";
                DdlSexo.DataTextField = "DE_SEXO";
                DdlSexo.DataSource = MyLib.SP_READALL_Sexo();
                DdlSexo.DataBind();
                DdlSexo.Items.Insert(0, new ListItem("-Seleccione-", "0"));


                DdlGrupoEtnico.DataValueField = "PK_GrupoEtnico";
                DdlGrupoEtnico.DataTextField = "DE_GrupoEtnico";

                DdlGrupoEtnico.DataSource = MyLib.SP_READALL_GrupoEtnico();
                DdlGrupoEtnico.DataBind();
                DdlGrupoEtnico.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            }

        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}