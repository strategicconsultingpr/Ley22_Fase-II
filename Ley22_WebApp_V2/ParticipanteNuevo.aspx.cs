using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;

namespace Ley22_WebApp_V2
{
    public partial class ParticipanteNuevo : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        ApplicationUser ExistingUser = new ApplicationUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            ExistingUser = (ApplicationUser)Session["User"];

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
            Data_SA_Persona sa_persona;
            int PK_Persona_out;

            System.Data.Entity.Core.Objects.ObjectParameter myOutputParamString = new System.Data.Entity.Core.Objects.ObjectParameter("PK_Persona", typeof(int));

            using (SEPSEntities1 seps = new SEPSEntities1())
            {
                short programa = Convert.ToInt16(Session["Programa"]);

                var spc = seps.SPC_PERSONA(
                    TxtNroSeguroSocial.Text,
                    programa,
                    TxtExpediente.Text,
                    Convert.ToByte(DdlSexo.SelectedValue.ToString()),
                    TxtPrimerNombre.Text,
                    TxtSegundoNombre.Text,
                    TxtPrimerApellido.Text,
                    TxtSegundoApellido.Text,
                    DateTime.Parse(TxtFechaNacimiento.Text),
                    Convert.ToByte(ChkVeterano.Checked == true ? 1 : 2),
                    Convert.ToByte(DdlGrupoEtnico.SelectedValue),
                    Guid.NewGuid(),
                    myOutputParamString
                    );

                PK_Persona_out = Convert.ToInt32(myOutputParamString.Value);

                sa_persona = new Data_SA_Persona()
                {
                    PK_Persona = PK_Persona_out,
                    NR_SeguroSocial = TxtNroSeguroSocial.Text,
                    FK_Sexo = Convert.ToInt32(DdlSexo.SelectedValue),
                    NB_Primero = TxtPrimerNombre.Text,
                    NB_Segundo = TxtSegundoNombre.Text,
                    AP_Primero = TxtPrimerApellido.Text,
                    AP_Segundo = TxtSegundoApellido.Text,
                    FE_Nacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text),
                    FK_Veterano = Convert.ToInt32(ChkVeterano.Checked),
                    FK_GrupoEtnico = Convert.ToInt32(DdlGrupoEtnico.SelectedValue)

                };

                Session["SA_Persona"] = sa_persona;
                Response.Redirect("OrdenNuevo.aspx", false);

            }

                
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
        }

    }
}