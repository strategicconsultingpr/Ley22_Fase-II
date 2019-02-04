using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;

public partial class nuevo_confirmacion : System.Web.UI.Page
{
    static string prevPage = String.Empty;
    public DataParticipante du ;
    protected void Page_Load(object sender, EventArgs e)
    {
 
        if (!Page.IsPostBack)
        {
            prevPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length-1];


            du = (DataParticipante)Session["DataParticipante"];

            if(prevPage == "seleccion-proximo-paso.aspx")
            {
                Header_Amarillo.Text = "Editar Registro de Usuario: " + du.NB_Primero + " "+ du.AP_Primero;
                Header_Azul.Text = "";
            }

        }
    }

    protected void BtnAsignarCita_Click(object sender, EventArgs e)
    {
        Response.Redirect("asignar-citas-individual.aspx", false);
    }

    protected void BtnCorregir_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevo-usuario.aspx", false);
    }

    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect("seleccion-proximo-paso.aspx",false);
    }
}