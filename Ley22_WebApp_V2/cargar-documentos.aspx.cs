﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ley22_WebApp_V2.Old_App_Code;

public partial class cargar_documentos : System.Web.UI.Page
{
    protected DataParticipante du;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            this.du = (DataParticipante)Session["DataParticipante"];
            BidGrid();
            CargarOrdenesJudiciales();
            DdlDocumento.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }
    }
    void BidGrid()

    {
        using (Ley22Entities mylib = new Ley22Entities())

        {
            GvRecepcionDocumentos.DataSource = mylib.ListarDocumentosRecibidos(Convert.ToInt32(Session["Id_Participante"]));
            GvRecepcionDocumentos.DataBind();

           
                //var list = new List<int>();
                //list.Add(1);
                //list.Add(7);
                //list.Add(10);
                //list.Add(18);
                //list.Add(6);
                //list.Add(8);

                //var DocNecesarios = list.AsQueryable();

                //var orden = mylib.OrdenesJudiciales.Where(u => u.Id_Participante.Equals(this.du.Id_Participante)).Where(a => a.Activa.Equals(1)).Select(q => q.Id_OrdenJudicial);
                //var docs = mylib.DocumentosPorParticipantes.Where(u => orden.Contains(u.Id_OrdenJudicial)).Select(p => p.Id_Documento);

                //if ((docs.Contains(1) && docs.Contains(7) && docs.Contains(10) && docs.Contains(18) && (docs.Contains(6) || docs.Contains(8))))
                //{

                //}
                //else
                //{
                //    var DocNec = mylib.Documentos.Where(u => DocNecesarios.Contains(u.Id_Documento));
                //    // var DocEntregar = mylib.Documentos.Where(u => !DocNecesarios.Contains(u.Id_Documento)).Select(p => p.Id_Documento);



                //    var DocumentosFaltantes = DocNec.Where(u => !docs.Contains(u.Id_Documento)).ToList();
                //    // var DocumentosFaltantes = mylib.Documentos.Where(u => DocEntregar.Contains(u.Id_Documento)).ToList();

                //    GridView1.DataSource = DocumentosFaltantes;
                //    GridView1.DataBind();

                //}
            

        }
    }

    void CargarDocumentosFaltantes()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(7);
            list.Add(10);
            list.Add(18);
            list.Add(6);
            list.Add(8);

            var DocNecesarios = list.AsQueryable();

            int Participante = Convert.ToInt32(Session["Id_Participante"]);

            var ordens = mylib.OrdenesJudiciales.Where(u => u.Id_Participante.Equals(Participante)).Where(a => a.Activa.Equals(1));

            int OrdenJudicial = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
            var orden = ordens.Where(u => u.Id_OrdenJudicial.Equals(OrdenJudicial)).Select(p => p.Id_OrdenJudicial);

            if (orden.Count() > 0)
            {
                var docs = mylib.DocumentosPorParticipantes.Where(u => orden.Contains(u.Id_OrdenJudicial)).Select(p => p.Id_Documento);

                if ((docs.Contains(1) && docs.Contains(7) && docs.Contains(10) && docs.Contains(18) && (docs.Contains(6) || docs.Contains(8))))
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                else
                {
                    var DocNec = mylib.Documentos.Where(u => DocNecesarios.Contains(u.Id_Documento));
                    // var DocEntregar = mylib.Documentos.Where(u => !DocNecesarios.Contains(u.Id_Documento)).Select(p => p.Id_Documento);



                    var DocumentosFaltantes = DocNec.Where(u => !docs.Contains(u.Id_Documento)).ToList();
                    // var DocumentosFaltantes = mylib.Documentos.Where(u => DocEntregar.Contains(u.Id_Documento)).ToList();

                    GridView1.DataSource = DocumentosFaltantes;
                    GridView1.DataBind();

                }
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
    }


    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        int Id_DocumentoPorParticipante = Convert.ToInt32(btn.CommandArgument);

        string Id = Session["Id_Participante"].ToString();
        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.EliminarDocuemntoPorParticipante(Id_DocumentoPorParticipante);
        }
        foreach (GridViewRow item in GvRecepcionDocumentos.Rows)
        {
            if (GvRecepcionDocumentos.DataKeys[item.RowIndex].Values[0].ToString() == Id_DocumentoPorParticipante.ToString())
            {
                File.Delete(Server.MapPath("~/DocumentosPorParticipantes/"+ Id +"/" + GvRecepcionDocumentos.DataKeys[item.RowIndex].Values[1].ToString()));
            }
        } 

        
        
       
        BidGrid();
        CargarDocumentosFaltantes();
    }
    protected void lnkImprimir_Click(object sender, EventArgs e)
    {
        string Id = Session["Id_Participante"].ToString();
        LinkButton btn = (LinkButton)(sender);       
        string PathNameDocumento = "/DocumentosPorParticipantes/" + Id +"/" + btn.CommandArgument.ToString();


        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + PathNameDocumento);
        Response.TransmitFile(Server.MapPath("~" + PathNameDocumento));
        Response.End();
        Response.Redirect("/");
    }


    void CargarOrdenesJudiciales()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            DdlNumeroOrdenJudicial.DataTextField = "NumeroOrdenJudicial";
            DdlNumeroOrdenJudicial.DataValueField = "Id_OrdenJudicial";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));
         }
     }


    protected void DdlNumeroOrdenJudicial_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            DdlDocumento.DataTextField = "Documento";
            DdlDocumento.DataValueField = "Id_Documento";
            DdlDocumento.DataSource = mylib.ListarTipodeDocumentosPorParticipanteOrdenJudicial(Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue), Convert.ToInt32(Session["Id_Participante"]));
            DdlDocumento.DataBind();
            DdlDocumento.Items.Insert(0, new ListItem("-Seleccione-", "0"));           

        }
        CargarDocumentosFaltantes();
    }

    protected void BtnSubirDocumento_Click(object sender, EventArgs e)
    {    

        if (FileUpload1.HasFile)
        { 
            try
            {
                string filename = DdlNumeroOrdenJudicial.SelectedValue + "-" + Path.GetFileName(FileUpload1.FileName);
                string Id = Session["Id_Participante"].ToString();
                if (!Directory.Exists(Server.MapPath("~/DocumentosPorParticipantes/"+Id)))
                {
                    Directory.CreateDirectory(Server.MapPath("~/DocumentosPorParticipantes/" + Id+"/"));
                }
                FileUpload1.SaveAs(Server.MapPath("~/DocumentosPorParticipantes/"+Id+"/") + filename);
                //  StatusLabel.Text = "Upload status: File uploaded!";
                GuardarDocumento(Convert.ToInt32(DdlDocumento.SelectedValue), Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue), filename, Convert.ToInt32(Session["Id_UsuarioApp"]));
                BidGrid();
                CargarDocumentosFaltantes();
            }
            catch (Exception ex)
            {
                // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }

    }

   protected void GuardarDocumento(int Id_Documento, int Id_Participante, int Id_OrdenJudicial, string PathNameDocumento, int Id_UsuarioRecibe)
    {
        using (Ley22Entities mylib = new Ley22Entities())
             mylib.GuardarDocumentoPorParticipante(Id_Documento, Id_Participante, Id_OrdenJudicial, PathNameDocumento, Id_UsuarioRecibe);
 
    }

    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect("seleccion-proximo-paso.aspx", false);
    }
}