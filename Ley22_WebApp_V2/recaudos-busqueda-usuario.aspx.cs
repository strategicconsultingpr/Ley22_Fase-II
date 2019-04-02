using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.AppCode;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;

public partial class recaudos_busqueda_usuario : System.Web.UI.Page
{
    ApplicationUser ExistingUser = new ApplicationUser();
    SEPSEntities1 dsPerfil = new SEPSEntities1();
    Ley22Entities dsLey22 = new Ley22Entities();
    static string userId = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("~/Account/Login.aspx", false);
            return;
        }
        if (!Page.IsPostBack)
        {


            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;

            CargarProgramas();
        }
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        /* Session["RBLDocumentos"] = RBLDocumentos.SelectedValue;
         Session["txtDocumentos"] = RBLDocumentos.SelectedItem.Text;
         */
        if ((TxtNroSeguroSocial.Text.Trim() == "" &&
           //TxtIdentificacion.Text.Trim() == "" &&
           TxtFechaNacimiento.Text.Trim() == "" &&
           TxtNombre.Text.Trim() == "" &&
            TxtApellido.Text.Trim() == "")) { Response.Redirect("recaudos-busqueda-usuario.aspx", false); }

        else
        {
            Session["TxtNroSeguroSocial"] = TxtNroSeguroSocial.Text.Trim();
            Session["TxtIdentificacion"] = "";// TxtIdentificacion.Text.Trim();
            Session["TxtFechaNacimiento"] = TxtFechaNacimiento.Text.Trim();
            Session["TxtNombre"] = TxtNombre.Text.Trim();
            Session["TxtApellido"] = TxtApellido.Text.Trim();
            Session["TxtNombreyApellido"] = TxtNombre.Text.Trim() + ' ' + TxtApellido.Text.Trim();


            Response.Redirect("recaudos-resultados-busqueda.aspx", false);
        }
    }

    protected void CargarProgramas()
    {
        var usuarios_programas = new List<string>();
        var programas_usuario = new List<int>();
        programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
        var programas = dsPerfil.SA_PROGRAMA.Where(p => programas_usuario.Contains(p.PK_Programa)).Select(u => new ListItem { Value = u.PK_Programa.ToString(), Text = u.NB_Programa }).ToList();

        if (programas.Count > 1)
        {
            DivPrograma.Visible = true;
            ValidatorPrograma.Enabled = true;
            DdlPrograma.DataValueField = "Value";
            DdlPrograma.DataTextField = "Text";
            DdlPrograma.DataSource = programas;
            DdlPrograma.DataBind();
            DdlPrograma.Items.Insert(0, new ListItem("-Seleccione-", "0"));
        }
        else if (programas.Count == 1)
        {
            ValidatorPrograma.Enabled = false;
            DivPrograma.Visible = false;
            Session["Programa"] = programas[0].Value;            
        }
        else
        {

        }
    }

    protected void DdlPrograma_Changed(object sender, EventArgs e)
    {
        if (DdlPrograma.SelectedValue != "0")
        {
            Session["Programa"] = DdlPrograma.SelectedValue;
            
        }
        else
        {

        }


    }
}