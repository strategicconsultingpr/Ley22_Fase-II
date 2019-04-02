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
        Ley22Entities dsLey22 = new Ley22Entities();
        SEPSEntities1 dsPerfil = new SEPSEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            ExistingUser = (ApplicationUser)Session["User"];
            sa_persona = (Data_SA_Persona)Session["SA_Persona"];

            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }

                TxtIUP.Text = sa_persona.PK_Persona.ToString();

                if(Session["Expediente"] != null)
                {
                    TxtExpediente.Text = Session["Expediente"].ToString();
                    
                }
                else
                {
                    Response.Redirect("ParticipanteNuevo.aspx", false);
                }

                LoadDropDownList();
            }
        }

        void LoadDropDownList()
        {           
            var tribunales = dsLey22.Tribunals.Select(r => new ListItem { Value = r.Id_Tribunal.ToString(), Text = r.NB_Tribunal }).ToList();

            DdlTribunal.DataValueField = "Value";
            DdlTribunal.DataTextField = "Text";
            DdlTribunal.DataSource = tribunales;
            DdlTribunal.DataBind();
            DdlTribunal.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var estados_civiles = dsPerfil.SA_LKP_TEDS_ESTADO_MARITAL.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_EstadoMarital.ToString(), Text = r.DE_EstadoMarital }).ToList();

            DdlEstadoCivil.DataValueField = "Value";
            DdlEstadoCivil.DataTextField = "Text";
            DdlEstadoCivil.DataSource = estados_civiles;
            DdlEstadoCivil.DataBind();
            DdlEstadoCivil.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var pueblos = dsPerfil.SA_LKP_MUNICIPIO_RESIDENCIA.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_Municipio.ToString(), Text = r.DE_Municipio }).ToList();

            DdlPueblo.DataValueField = "Value";
            DdlPueblo.DataTextField = "Text";
            DdlPueblo.DataSource = pueblos;
            DdlPueblo.DataBind();
            DdlPueblo.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            DdlPuebloPostal.DataValueField = "Value";
            DdlPuebloPostal.DataTextField = "Text";
            DdlPuebloPostal.DataSource = pueblos;
            DdlPuebloPostal.DataBind();
            DdlPuebloPostal.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var planesmedicos = dsPerfil.SA_LKP_TEDS_SEGURO_SALUD.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_SeguroSalud.ToString(), Text = r.DE_SeguroSalud }).ToList();

            DdlPlanMedico.DataValueField = "Value";
            DdlPlanMedico.DataTextField = "Text";
            DdlPlanMedico.DataSource = planesmedicos;
            DdlPlanMedico.DataBind();
            DdlPlanMedico.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var grados = dsPerfil.SA_LKP_TEDS_GRADO.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_Grado.ToString(), Text = r.DE_Grado}).ToList();

            DdlGrado.DataValueField = "Value";
            DdlGrado.DataTextField = "Text";
            DdlGrado.DataSource = grados;
            DdlGrado.DataBind();
            DdlGrado.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var desempleorazon = dsLey22.DesempleoRazons.Select(r => new ListItem { Value = r.Id_DesempleoRazon.ToString(), Text = r.NB_DesempleoRazon }).ToList();

            DdlDesempleado.DataValueField = "Value";
            DdlDesempleado.DataTextField = "Text";
            DdlDesempleado.DataSource = desempleorazon;
            DdlDesempleado.DataBind();
            DdlDesempleado.Items.Insert(0, new ListItem("-Seleccione-", "0"));
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            using (Ley22Entities mylib = new Ley22Entities())
                mylib.GuardarCasoCriminal(Convert.ToInt32(sa_persona.PK_Persona), TxtNroCasoCriminal.Text, Convert.ToDateTime(TxtFechaOrden.Text), 
                    Convert.ToDateTime(TxtSentencia.Text),Txtalcohol.Text,Convert.ToInt32(DdlTribunal.SelectedValue), TxtJuez.Text,
                    ExistingUser.Id, Convert.ToInt32(Session["Programa"]), Convert.ToInt32(TxtLicencia.Text),
                    Convert.ToInt32(DdlEstadoCivil.SelectedValue), TxtEmail.Text, TxtCelular.Text,TxtTelHogar.Text, 
                    TxtTelefonoFamiliarMasCercano.Text,TxtDireccionLinea1.Text, TxtDireccionLinea2.Text,Convert.ToInt32(DdlPueblo.SelectedValue),TxtCodigoPostal.Text, 
                    TxtPostalLinea1.Text, TxtPostalLinea2.Text, Convert.ToInt32(DdlPuebloPostal.SelectedValue), TxtCodigoPostalPostal.Text,
                    Convert.ToInt32(DdlPlanMedico.SelectedValue), DdlTratamiento.SelectedValue, DdlImpedimento.SelectedValue, Convert.ToInt32(DdlGrado.SelectedValue), 
                    TxtTrabajo.Text,TxtOcupacion.Text, ChkNoTrabajo.Checked == true ? Convert.ToByte(1) : Convert.ToByte(2), Convert.ToInt32(DdlDesempleado.SelectedValue), Convert.ToInt32(TxtFamiliar.Text),
                    TxtPareja.Text, TxtPadre.Text,TxtMadre.Text);

            string mensaje = "El caso criminal #" + TxtNroCasoCriminal.Text + " se añadió correctamente.";
            string script = "window.onload = function(){ alert('";
            script += mensaje;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Registrado", script, true);

            Response.Redirect("seleccion-proximo-paso.aspx", false);
            // mylib.GuardarOrdenJudicial(Convert.ToInt32(Session["Id_Participante"]), TxtNroCasoCriminal.Text, Convert.ToDateTime(TxtFechaOrden.Text), Convert.ToInt32(Session["Id_UsuarioApp"]), Convert.ToInt32(Session["Programa"]));
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            if(prevPage != "ParticipanteNuevo.aspx")
            {
                Response.Redirect(prevPage, false);
            }
            
        }
    }
}