using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ley22_WebApp_V2.Old_App_Code;
using Ley22_WebApp_V2.Models;

public partial class cierre_caso : System.Web.UI.Page
    {
    ApplicationUser ExistingUser = new ApplicationUser();

    protected void Page_Load(object sender, EventArgs e)
        {
        // valida que se haya buscado el usuario
        // -----------------------------------------------------------------------------
        //if (Session["DataParticipante"] == null)
        //{
        //    Session["TipodeAlerta"] = ConstTipoAlerta.Info;
        //    Session["MensajeError"] = "Por favor seleccione el participante";
        //    Response.Redirect("Mensajes.aspx", false);
        //    return;
        //}
        if (Session["SA_Persona"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Info;
            Session["MensajeError"] = "Por favor seleccione el participante";
            Session["Redirect"] = "Entrada.aspx";
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
        try
        {


            using (Ley22Entities mylib = new Ley22Entities())
            {
                DdlCasoCriminal.DataTextField = "NumeroCasoCriminal";
                DdlCasoCriminal.DataValueField = "Id_CasoCriminal";
                DdlCasoCriminal.DataSource = mylib.ListarCasosCriminalesActivos(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
                DdlCasoCriminal.DataBind();
                DdlCasoCriminal.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language=javascript>alert('"+ex.Message+"');</script>");
        }
    }
    void BindMotivoCierra()
    {
        try
        {
            using ( Ley22Entities mylib = new Ley22Entities() )
            {
            DdlMotivoCierre.DataTextField = "MotivoCierre";
            DdlMotivoCierre.DataValueField = "Id_MotivoCierre";
            DdlMotivoCierre.DataSource = mylib.ListarMotivosCierre();
            DdlMotivoCierre.DataBind();
            DdlMotivoCierre.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
        }
    }

    protected void DdlCasoCriminal_Selected(object sender, EventArgs e)
    {
        if (DdlCasoCriminal.SelectedValue == "0")
        {

            
            DdlMotivoCierre.Enabled = false;
            FileUpload1.Enabled = false;
            TxtCometarios.Enabled = false;

            DdlMotivoCierre.SelectedIndex = 0;
            TxtCometarios.Text = "";        
        }
        else
        {
            DdlMotivoCierre.Enabled = true;
            FileUpload1.Enabled = true;
            TxtCometarios.Enabled = true;
        }       
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        if( FileUpload1.HasFile )
            {
            try
                {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/UploadSoporteCierreCaso/") + DdlCasoCriminal.SelectedValue+"-"+filename);
                //  StatusLabel.Text = "Upload status: File uploaded!";
                ActualizarCierreOrden(DdlCasoCriminal.SelectedValue + "-" + filename);
                }
            catch( Exception ex )
                {
               // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }



        }

    void ActualizarCierreOrden(string FileName)
        {
        ExistingUser = (ApplicationUser)Session["User"];
        using ( Ley22Entities mylib = new Ley22Entities() )
            {

            mylib.CerrarCasoCriminal(Convert.ToInt32(DdlCasoCriminal.SelectedValue),
                Convert.ToInt32(DdlMotivoCierre.SelectedValue),
                TxtCometarios.Text,
                FileName,
                ExistingUser.Id);
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