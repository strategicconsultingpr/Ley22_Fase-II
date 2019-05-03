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
    ApplicationDbContext context;
    UserManager<ApplicationUser> userManager;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Info;
            Session["MensajeError"] = "Por favor ingrese al sistema";
            Session["Redirect"] = "Account/Login.aspx";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }

        ExistingUser = (ApplicationUser)Session["User"];
        if (!Page.IsPostBack)
        {
            prevPage = Request.UrlReferrer.ToString();

            context = new ApplicationDbContext();
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.IsInRole(ExistingUser.Id, "SuperAdmin"))
            {
                divUpload.Visible = true;
            }
            ListarDocumentos();
        }      
    }

    void ListarDocumentos()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            
            GvDocumentos.DataSource = mylib.ListarDocumentosActivos();
            GvDocumentos.DataBind();           
        }
    }

    protected void GvDocumentos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[3].Visible = false;           
        //}
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!userManager.IsInRole(ExistingUser.Id, "SuperAdmin"))
            {
                e.Row.Cells[3].Visible = false;
            }
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
        LinkButton btn = (LinkButton)(sender);
        int Id_Documento = Convert.ToInt32(btn.CommandArgument);

        try
        {
            using (Ley22Entities mylib = new Ley22Entities())
            {
                mylib.EliminarDocumentoActivo(Id_Documento);
            }
            foreach (GridViewRow item in GvDocumentos.Rows)
            {
                if (GvDocumentos.DataKeys[item.RowIndex].Values[0].ToString() == Id_Documento.ToString())
                {
                    File.Delete(MapPath("~/Documentos/" + GvDocumentos.DataKeys[item.RowIndex].Values[1].ToString()));
                }
            }
           // ListarDocumentos();
        }
        catch (Exception ex)
        {
            
        }
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

                //    ListarDocumentos();
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