using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.AppCode;

public partial class recaudos_busqueda_usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        /* Session["RBLDocumentos"] = RBLDocumentos.SelectedValue;
         Session["txtDocumentos"] = RBLDocumentos.SelectedItem.Text;
         */
        if ((TxtNroSeguroSocial.Text.Trim() == "" &&
           TxtIdentificacion.Text.Trim() == "" &&
           TxtFechaNacimiento.Text.Trim() == "" &&
           TxtNombreyApellido.Text.Trim() == "")) { Response.Redirect("recaudos-busqueda-usuario.aspx", false); }

        else
        {
            Session["TxtNroSeguroSocial"] = TxtNroSeguroSocial.Text.Trim();
            Session["TxtIdentificacion"] = TxtIdentificacion.Text.Trim();
            Session["TxtFechaNacimiento"] = TxtFechaNacimiento.Text.Trim();
            Session["TxtNombreyApellido"] = TxtNombreyApellido.Text.Trim();


            Response.Redirect("recaudos-resultados-busqueda.aspx", false);
        }
    }
}