using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

public partial class imprimir_documentos : System.Web.UI.Page
{
    static string prevPage = String.Empty;
    ApplicationUser ExistingUser = new ApplicationUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        ExistingUser = (ApplicationUser)Session["User"];
        if (!Page.IsPostBack)
        {
            //prevPage = Request.UrlReferrer.ToString();

            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.IsInRole(ExistingUser.Id, "SuperAdmin"))
            {
                divUpload.Visible = true;
            }
            ListarDocumentos();
        }

            
    }

    private void ListarDocumentos()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            GvDocumentos.DataSource = mylib.ListarDocumentosActivos();
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

    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
        //LinkButton btn = (LinkButton)(sender);
        //int Id_DocumentoPorParticipante = Convert.ToInt32(btn.CommandArgument);
       

        //string Id = Session["Id_Participante"].ToString();
        //using (Ley22Entities mylib = new Ley22Entities())
        //{
        //    mylib.EliminarDocuemntoPorParticipante(Id_DocumentoPorParticipante);
        //}
        //foreach (GridViewRow item in GvRecepcionDocumentos.Rows)
        //{
        //    if (GvRecepcionDocumentos.DataKeys[item.RowIndex].Values[0].ToString() == Id_DocumentoPorParticipante.ToString())
        //    {
        //        File.Delete("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + DdlNumeroOrdenJudicial.SelectedValue + "/" + GvRecepcionDocumentos.DataKeys[item.RowIndex].Values[1].ToString());
        //    }
        //}
       
    }

    protected void BtnSubirDocumento_Click(object sender, EventArgs e)
    {

        if (FileUpload1.HasFile)
        {
            try
            {
                string Archivo = Path.GetFileName(FileUpload1.FileName);
                string tipo = Path.GetExtension(FileUpload1.FileName);
                
                if ((!File.Exists(MapPath("~/Documentos/" + Archivo))) && tipo == ".pdf")
                {
                    string Documento = Archivo.Substring(0, Archivo.LastIndexOf(".pdf"));
                    FileUpload1.SaveAs(MapPath("~/Documentos/" + Archivo));

                    using (Ley22Entities mylib = new Ley22Entities())
                    {
                        mylib.GuardarDocumento(Documento, Archivo, ChkImportante.Checked == true ? 1 : 0, ChkRecurrente.Checked == true ? 1 : 0);
                    }

                    ListarDocumentos();
               }
            }
            catch (Exception ex)
            {
                // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }

    }


    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect(prevPage, false);
    }
}