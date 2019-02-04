using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ley22_WebApp_V2.Old_App_Code;

public partial class nuevo_usuario : System.Web.UI.Page
{
    static string prevPage = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.UrlReferrer != null)
            {
                prevPage = Request.UrlReferrer.ToString();
            }
           
            LoadDropDownList();
            if (Session["DataParticipante"] != null)
            {
                DataParticipante du = (DataParticipante)Session["DataParticipante"];

                TxtNroSeguroSocial.Text = du.NR_SeguroSocial;
                TxtIdentificacion.Text = du.Identificacion;
                Txtpasaporte.Text = du.Pasaporte;
                TxtLicencia.Text = du.Licencia;
                TxtIUP.Text = du.IUP.ToString();
                TxtExpediente.Text = du.Expediente;
                TxtPrimerNombre.Text = du.NB_Primero;
                TxtSegundoNombre.Text = du.NB_Segundo;
                TxtPrimerApellido.Text = du.AP_Primero;
                TxtSegundoNombre.Text = du.AP_Segundo;
                TxtFechaNacimiento.Text = du.FE_Nacimiento.ToString("MM/dd/yyyy");
                DdlSexo.SelectedValue = du.FK_Sexo.ToString ();
                DdlGrupoEtnico.SelectedValue = du.FK_GrupoEtnico.ToString();
                ChkVeterano.Checked = du.FK_Veterano==1? true:false;
                TxtEmail.Text = du.Correo;
                TxtTelefono1.Text = du.Telefono1;
                TxtTelefono2.Text = du.Telefono2;
                TxtTelefonoFamiliarMasCercano.Text = du.TelefonoFamiliaraMasCercano;
                TxtTelefonoNotificacion.Text = du.TelefonoCitas;
                TxtDireccionLinea1.Text = du.DireccionLinea1;
                TxtDireccionLinea2.Text = du.DireccionLinea2;
                TxtMunicipio.Text = du.Municipio;
                TxtCodigoPostal.Text = du.CodigoPostal;
                BuscarXNroSeguroSocial();




            }
         }
    }
    void LoadDropDownList()
    {
        using (SEPSEntities MyLib = new SEPSEntities())
        {

            DdlSexo.DataValueField = "pk_sexo";
            DdlSexo.DataTextField = "DE_SEXO";
            DdlSexo.DataSource = MyLib.SP_READALL_Sexo();
            DdlSexo.DataBind();
            DdlSexo.Items.Insert(0,new ListItem("-Seleccione-", "0"));


            DdlGrupoEtnico.DataValueField = "PK_GrupoEtnico";
            DdlGrupoEtnico.DataTextField = "DE_GrupoEtnico";

            DdlGrupoEtnico.DataSource = MyLib.SP_READALL_GrupoEtnico();
            DdlGrupoEtnico.DataBind();
            DdlGrupoEtnico.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }

    }

    void LimpiarCampos()
    {
        Txtpasaporte.Text = "";
        TxtLicencia.Text = "";
        TxtIUP.Text = "0";
        TxtExpediente.Text = "";

         // idendificacion
        TxtPrimerNombre.Text = "";
        TxtSegundoNombre.Text = "";
        TxtPrimerApellido.Text = "";
        TxtSegundoApellido.Text = "";
        // otros datos
        TxtFechaNacimiento.Text = "";

        ChkVeterano.Checked = false;
        TxtEmail.Text = "";
        TxtTelefono1.Text = "";
        TxtTelefono2.Text = "";
        TxtTelefonoFamiliarMasCercano.Text = "";
        TxtTelefonoNotificacion.Text = "";

        TxtDireccionLinea1.Text = "";
        TxtDireccionLinea2.Text = "";
        TxtMunicipio.Text = "";
        TxtCodigoPostal.Text = "";
        HyperLink1.Text = "";

        DdlSexo.SelectedIndex  = -1;
        DdlGrupoEtnico.SelectedIndex = -1;


    }

    void BuscarXNroSeguroSocial()
    {
        LimpiarCampos();

        using (Ley22Entities mylib = new Ley22Entities())
        {
            List<BuscarSEPSPersonaXNroSeguroSocial_Result> myresul = mylib.BuscarSEPSPersonaXNroSeguroSocial(TxtNroSeguroSocial.Text).ToList();

            if (myresul.Count > 0)
            {
                TxtIUP.Text = myresul[0].PK_Persona.ToString(); 

                TxtPrimerNombre.Text = myresul[0].NB_Primero;
                TxtSegundoNombre.Text = myresul[0].NB_Segundo;

                TxtPrimerApellido.Text = myresul[0].AP_Primero;
                TxtSegundoApellido.Text = myresul[0].AP_Segundo;

                TxtFechaNacimiento.Text = myresul[0].FE_Nacimiento.ToString("MM/dd/yyyy");

                DdlSexo.SelectedValue = myresul[0].FK_Sexo.ToString();
                DdlGrupoEtnico.SelectedValue = myresul[0].FK_GrupoEtnico.ToString();

                ChkVeterano.Checked = myresul[0].FK_Veterano == 1 ? true : false;

                verificarEpisodiosAnteriores(myresul[0].PK_Persona);
            }
            else
                LimpiarCampos();

        }
    }

 
    void verificarEpisodiosAnteriores( int Pk_Persona)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            List<ConsultarEpisodiosXPersona_Result> myresul = mylib.ConsultarEpisodiosXPersona(Pk_Persona).ToList();

            GVListadeEpisodios.DataSource = myresul;
            GVListadeEpisodios.DataBind();

            HyperLink1.Text = myresul.Count().ToString() + " Episodios";

            if (myresul.Count > 0)
                HyperLink1.Enabled = true;
            else
                HyperLink1.Enabled = false;

        }

    }

    protected void lnkEpisodio_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string episodio = btn.CommandArgument;
        int episodio_num = Convert.ToInt32(episodio);

        //string title = "Episodio = ";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + episodio_num + "');", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyPopup", "$('#MyPopup').modal();", true);
        Response.Redirect("listado_perfiles.aspx?pk_episodio=" + episodio, false);
    }

    protected void BtnCrear_Click(object sender, EventArgs e)
    {
        if (TxtLicencia.Text.Trim() == string.Empty || TxtNroSeguroSocial.Text.Trim() == string.Empty || TxtPrimerApellido.Text.Trim() == string.Empty || TxtPrimerNombre.Text.Trim() == string.Empty
            || TxtSegundoApellido.Text.Trim() == string.Empty || TxtDireccionLinea1.Text.Trim() == string.Empty || TxtCodigoPostal.Text.Trim() == string.Empty || TxtMunicipio.Text.Trim() == string.Empty
            || TxtFechaNacimiento.Text.Trim() == string.Empty || (TxtTelefono1.Text.Trim() == string.Empty && TxtTelefono2.Text.Trim() == string.Empty && TxtTelefonoFamiliarMasCercano.Text.Trim() == string.Empty) || (
            TxtTelefonoNotificacion.Text.Trim() != TxtTelefono1.Text.Trim() && TxtTelefonoNotificacion.Text.Trim() != TxtTelefono2.Text.Trim() && TxtTelefonoNotificacion.Text.Trim() != TxtTelefonoFamiliarMasCercano.Text.Trim()))
        {
            ClientScript.RegisterStartupScript(GetType(), "hwa", "CheckTextBoxes();", true);
          //  return; // return because we don't want to run normal code of buton click
        }
        else
        {
            DataParticipante mydu;
            int Id_Participante;

            TxtIUP.Text = TxtIUP.Text == "" ? "0" : TxtIUP.Text;

            if (Session["DataParticipante"] != null)
            {
                mydu = (DataParticipante)Session["DataParticipante"];
                if (mydu.Id_Participante == 0)
                {
                    Id_Participante = mydu.PK_Persona;
                }
                else
                {
                    Id_Participante = mydu.Id_Participante;
                }

            }
            else
            {
                System.Data.Entity.Core.Objects.ObjectParameter myOutputParamString = new System.Data.Entity.Core.Objects.ObjectParameter("PK_Persona", typeof(int));
                using (SEPSEntities1 mlib = new SEPSEntities1())
                {

                    var spc = mlib.SPC_PERSONA(
                                    TxtNroSeguroSocial.Text,
                                     Convert.ToInt16(61),
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
                                     //Convert.ToInt32(Session["Id_UsuarioApp"])                                    
                                     );
                Id_Participante = Convert.ToInt32(myOutputParamString.Value);

                }
                
            }
            using (Ley22Entities mlib = new Ley22Entities())
            {

                var spc = mlib.SPC_Persona(
                                TxtNroSeguroSocial.Text,
                                 TxtIdentificacion.Text,
                                 Txtpasaporte.Text,
                                 TxtLicencia.Text,
                                 Id_Participante,
                                 TxtExpediente.Text,
                                 TxtPrimerNombre.Text,
                                 TxtSegundoNombre.Text,
                                 TxtPrimerApellido.Text,
                                 TxtSegundoApellido.Text,
                                 Convert.ToDateTime(TxtFechaNacimiento.Text),
                                 Convert.ToByte(DdlSexo.SelectedValue),
                                 Convert.ToByte(DdlGrupoEtnico.SelectedValue),
                                 Convert.ToByte(ChkVeterano.Checked == true ? 1 : 2),
                                 TxtEmail.Text,
                                 TxtTelefono1.Text,
                                 TxtTelefono2.Text,
                                 TxtTelefonoFamiliarMasCercano.Text,
                                 TxtTelefonoNotificacion.Text,
                                 TxtDireccionLinea1.Text,
                                 TxtDireccionLinea2.Text,
                                 TxtMunicipio.Text,
                                 TxtCodigoPostal.Text,
                                 Convert.ToInt32(Session["Id_UsuarioApp"]),
                                 Id_Participante
                                 ).ToList();


                mydu = new DataParticipante()
                {
                    NR_SeguroSocial = TxtNroSeguroSocial.Text,
                    Identificacion = TxtIdentificacion.Text,
                    Pasaporte = Txtpasaporte.Text,
                    Licencia = TxtLicencia.Text,
                    IUP = Id_Participante,
                    Expediente = TxtExpediente.Text,
                    NB_Primero = TxtPrimerNombre.Text,
                    NB_Segundo = TxtSegundoNombre.Text,
                    AP_Primero = TxtPrimerApellido.Text,
                    AP_Segundo = TxtSegundoApellido.Text,
                    FE_Nacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text),
                    FK_Sexo = Convert.ToInt32(DdlSexo.SelectedValue),
                    SexoDescripcion = DdlSexo.SelectedItem.Text,
                    FK_GrupoEtnico = Convert.ToInt32(DdlGrupoEtnico.SelectedValue),
                    GrupoEtnicoDescripcion = DdlGrupoEtnico.SelectedItem.Text,
                    FK_Veterano = Convert.ToInt32(ChkVeterano.Checked),
                    Correo = TxtEmail.Text,
                    Telefono1 = TxtTelefono1.Text,
                    Telefono2 = TxtTelefono2.Text,
                    TelefonoFamiliaraMasCercano = TxtTelefonoFamiliarMasCercano.Text,
                    TelefonoCitas = TxtTelefonoNotificacion.Text,
                    DireccionLinea1 = TxtDireccionLinea1.Text,
                    DireccionLinea2 = TxtDireccionLinea2.Text,
                    Municipio = TxtMunicipio.Text,
                    CodigoPostal = TxtCodigoPostal.Text,
                    Id_Participante = spc[0].Value

                };
                Session["Id_Participante"] = mydu.PK_Persona;
                Session["Id_Participante"] = mydu.Id_Participante;
                Session["NombreParticipante"] = TxtPrimerNombre.Text + " " + TxtPrimerApellido.Text;
                Session["DataParticipante"] = mydu;

            }





            Response.Redirect("nuevo-confirmacion.aspx", false);
        }
    }

    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        if (prevPage == "" || prevPage == null)
        {
            Response.Redirect("Entrada.aspx", false);
        }
        else
        {
            Response.Redirect(prevPage, false);
        }
    }

    protected void lnkBuscar_Click(object sender, EventArgs e)
    {
       // Session["DataParticipante"] = null;
        BuscarXNroSeguroSocial();
    }
}