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
        Ley22Entities dsLey22 = new Ley22Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            ExistingUser = (ApplicationUser)Session["User"];

            if (!Page.IsPostBack)
            {

                if (Request.UrlReferrer != null)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }

                LoadDropDownList();

                if (Session["SA_Persona"] != null)
                {
                    if (Session["Expediente"] != null)
                    {
                        TxtExpediente.Text = Session["Expediente"].ToString();
                        TxtExpediente.ReadOnly = true;
                    }
                    
                    Data_SA_Persona sa_persona = (Data_SA_Persona)Session["SA_Persona"];
                    TxtIUP.Text = sa_persona.PK_Persona.ToString();
                    TxtNroSeguroSocial.Text = sa_persona.NR_SeguroSocial;
                    DdlSexo.SelectedValue = sa_persona.FK_Sexo.ToString();
                    TxtPrimerNombre.Text = sa_persona.NB_Primero;
                    TxtSegundoNombre.Text = sa_persona.NB_Segundo;
                    TxtPrimerApellido.Text = sa_persona.AP_Primero;
                    TxtSegundoApellido.Text = sa_persona.AP_Segundo;
                    TxtFechaNacimiento.Text = sa_persona.FE_Nacimiento.ToString("MM/dd/yyyy");
                    ChkVeterano.Checked = sa_persona.FK_Veterano == 1 ? true : false;
                    DdlGrupoEtnico.SelectedValue = sa_persona.FK_GrupoEtnico.ToString();

                    TxtNroSeguroSocial.ReadOnly = true;
                    DdlSexo.Enabled = false;
                    TxtPrimerNombre.ReadOnly = true;
                    TxtSegundoNombre.ReadOnly = true;
                    TxtPrimerApellido.ReadOnly = true;
                    TxtSegundoApellido.ReadOnly = true;
                    TxtFechaNacimiento.ReadOnly = true;
                    ChkVeterano.Enabled = false;
                    DdlGrupoEtnico.Enabled = false;

                    BtnCrear.Visible = false;
                    BtnActualizar.Visible = true;
                }
            }
        }

        void LoadDropDownList()
        {
            using (SEPSEntities MyLib = new SEPSEntities())
            {

                DdlSexo.DataValueField = "PK_SEXO";
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
                    TxtPrimerApellido.Text,
                    TxtSegundoApellido.Text,
                    TxtPrimerNombre.Text,
                    TxtSegundoNombre.Text,              
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
                Session["Expediente"] = TxtExpediente.Text;

                string mensaje = "El participante " + TxtPrimerNombre.Text+ " "+ TxtPrimerApellido.Text + " se añadió correctamente.";
                string script = "window.onload = function(){ alert('";
                script += mensaje;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "Participante Registrado", script, true);

                Response.Redirect("OrdenNuevo.aspx", false);

            }

                
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            Data_SA_Persona sa_persona;
            short programa = Convert.ToInt16(Session["Programa"]);

            using (SEPSEntities1 seps = new SEPSEntities1())
            {
                

                var sa_personas = seps.SPU_PERSONA(
                    Convert.ToInt32(TxtIUP.Text),
                    programa,
                    TxtNroSeguroSocial.Text,
                    TxtExpediente.Text,
                    Convert.ToByte(DdlSexo.SelectedValue.ToString()),
                    TxtPrimerApellido.Text,
                    TxtSegundoApellido.Text,
                    TxtPrimerNombre.Text,
                    TxtSegundoNombre.Text,
                    DateTime.Parse(TxtFechaNacimiento.Text),
                    ChkVeterano.Checked == true ? "1" : "2",
                    DdlGrupoEtnico.SelectedValue,
                    Guid.NewGuid()
                    );

                sa_persona = new Data_SA_Persona()
                {
                    PK_Persona = Convert.ToInt32(TxtIUP.Text),
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
            }

                Session["SA_Persona"] = sa_persona;
                Session["Expediente"] = TxtExpediente.Text;

                string mensaje = "El participante " + TxtPrimerNombre.Text + " " + TxtPrimerApellido.Text + " se actualizo correctamente.";
                string script = "window.onload = function(){ alert('";
                script += mensaje;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "Participante Registrado", script, true);

                var casos = dsLey22.OrdenesJudiciales.Where(u => u.Id_Participante.Equals(sa_persona.PK_Persona)).Where(a => a.Activa.Equals(1)).Where(p => p.Id_Programa == programa);
                if (casos.Count() > 0)
                {
                    Response.Redirect("seleccion-proximo-paso.aspx", false);
                }
                else
                {
                    Response.Redirect("OrdenNuevo.aspx", false);
                }

                

            

            

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage, false);
        }

    }
}