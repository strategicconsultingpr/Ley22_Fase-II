using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;

public partial class imprimir_documentos : System.Web.UI.Page
{
    static string prevPage = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            prevPage = Request.UrlReferrer.ToString();
            using (Ley22Entities mylib = new Ley22Entities())
            {
                GvDocumentos.DataSource= mylib.ListarDocumentosActivos();
                GvDocumentos.DataBind();

            }
    }

    protected void lnkImprimir_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string PathNameDocumento = "/Documentos/" + btn.CommandArgument.ToString();


        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + PathNameDocumento);
        Response.TransmitFile(Server.MapPath("~" + PathNameDocumento));
        Response.End();
        Response.Redirect("/");
    }
    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect(prevPage, false);
    }
}