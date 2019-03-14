using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ley22_WebApp_V2.Old_App_Code;

public partial class cierre_caso : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
        {
        // valida que se haya buscado el usuario
        // -----------------------------------------------------------------------------
        if (Session["DataParticipante"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Info;
            Session["MensajeError"] = "Por favor seleccione el participante";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }
        // -----------------------------------------------------------------------------


        if ( !Page.IsPostBack )
            {
              BindOrdenJudicial();
              BindMotivoCierra();
            }
        }
    void BindOrdenJudicial()
        {
        using( Ley22Entities mylib = new Ley22Entities() )
            {
            DdlNumeroOrdenJudicial.DataTextField = "NumeroOrdenJudicial";
            DdlNumeroOrdenJudicial.DataValueField = "Id_OrdenJudicial";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            }
        }
    void BindMotivoCierra()
        {
        using( Ley22Entities mylib = new Ley22Entities() )
            {
            DdlMotivoCierre.DataTextField = "MotivoCierre";
            DdlMotivoCierre.DataValueField = "Id_MotivoCierre";
            DdlMotivoCierre.DataSource = mylib.ListarMotivosCierre();
            DdlMotivoCierre.DataBind();
            DdlMotivoCierre.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
        }
    protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        if( FileUpload1.HasFile )
            {
            try
                {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/UploadSoporteCierreCaso/") + DdlNumeroOrdenJudicial.SelectedValue+"-"+filename);
                //  StatusLabel.Text = "Upload status: File uploaded!";
                ActualizarCierreOrden(DdlNumeroOrdenJudicial.SelectedValue + "-" + filename);
                }
            catch( Exception ex )
                {
               // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }



        }

    void ActualizarCierreOrden(string FileName)
        {
        using( Ley22Entities mylib = new Ley22Entities() )
            {

            mylib.CerrarordenJudicial(Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue),
                Convert.ToInt32(DdlMotivoCierre.SelectedValue),
                TxtCometarios.Text,
                FileName,
                Convert.ToInt32(Session["Id_UsuarioApp"]));
            }
        BindOrdenJudicial();
        DdlMotivoCierre.SelectedIndex = -1;
        TxtCometarios.Text = "";
        Mensaje.Visible = true;
        }
    protected void BtnCancelar_Click(object sender, EventArgs e)
        {
        Response.Redirect("seleccion-proximo-paso.aspx", false);
        }
    }