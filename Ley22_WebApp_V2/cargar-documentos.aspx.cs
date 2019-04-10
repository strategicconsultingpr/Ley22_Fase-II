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
    //protected DataParticipante du;
    protected Data_SA_Persona du;
    int Programa;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["SA_Persona"] == null)
            {
                Session["TipodeAlerta"] = ConstTipoAlerta.Info;
                Session["MensajeError"] = "Por favor seleccione el participante";
                Response.Redirect("Mensajes.aspx", false);
                return;
            }

            // this.du = (DataParticipante)Session["DataParticipante"];

            this.du = (Data_SA_Persona)Session["SA_Persona"];
            Programa = Convert.ToInt32(Session["Programa"].ToString());
            // BidGrid();
             CargarOrdenesJudiciales();
            DivDocumentos.Visible = false;
            DdlDocumento.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }
    }
    void BidGrid()

    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            GvRecepcionDocumentos.DataSource = mylib.ListarDocumentosRecibidosCasoCriminal(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
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
            //var list = new List<int>();
            //list.Add(1);
            //list.Add(7);
            //list.Add(10);
            //list.Add(18);
            //list.Add(6);
            //list.Add(8);

            Programa = Convert.ToInt32(Session["Programa"].ToString());

            var DocNecesarios = mylib.Documentos.Where(p => p.Importante == 1).Select(a => a.Id_Documento).ToList();

            int Participante = Convert.ToInt32(Session["Id_Participante"]);

            var ordens = mylib.CasoCriminals.Where(u => u.Id_Participante.Equals(Participante)).Where(a => a.Activa.Equals(1)).Where(p => p.FK_Programa == Programa);

            int OrdenJudicial = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
            var orden = ordens.Where(u => u.Id_CasoCriminal.Equals(OrdenJudicial)).Select(p => p.Id_CasoCriminal);

            if (orden.Count() > 0)
            {
                var docs = mylib.DocumentosPorParticipantes.Where(u => orden.Contains(u.Id_OrdenJudicial)).Where(a => a.Id_Programa == Programa).Select(p => p.Id_Documento);
                var docsFaltante = mylib.Documentos.Where(u => !docs.Contains(u.Id_Documento)).Where(a => a.Importante == 1).Select(p => p.Id_Documento).ToList();

                if (docsFaltante.Count() < 1)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    DivDocumentos.Visible = false;
                }
                else
                {
                    var DocNec = mylib.Documentos.Where(u => DocNecesarios.Contains(u.Id_Documento));
                    // var DocEntregar = mylib.Documentos.Where(u => !DocNecesarios.Contains(u.Id_Documento)).Select(p => p.Id_Documento);



                    var DocumentosFaltantes = DocNec.Where(u => !docs.Contains(u.Id_Documento)).ToList();
                    // var DocumentosFaltantes = mylib.Documentos.Where(u => DocEntregar.Contains(u.Id_Documento)).ToList();

                    GridView1.DataSource = DocumentosFaltantes;
                    GridView1.DataBind();
                    DivDocumentos.Visible = true;

                }
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                DivDocumentos.Visible = false;
            }
        }
    }


    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        int Id_DocumentoPorParticipante = Convert.ToInt32(btn.CommandArgument);
        Programa = Convert.ToInt32(Session["Programa"].ToString());

        string Id = Session["Id_Participante"].ToString();
        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.EliminarDocuemntoPorParticipante(Id_DocumentoPorParticipante);
        }
        foreach (GridViewRow item in GvRecepcionDocumentos.Rows)
        {
            if (GvRecepcionDocumentos.DataKeys[item.RowIndex].Values[0].ToString() == Id_DocumentoPorParticipante.ToString())
            {
                File.Delete("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + DdlNumeroOrdenJudicial.SelectedValue + "/" + GvRecepcionDocumentos.DataKeys[item.RowIndex].Values[1].ToString());
            }
        }



        ActualizarDocumentosDdl();
        BidGrid();
        CargarDocumentosFaltantes();
    }
    protected void lnkImprimir_Click(object sender, EventArgs e)
    {
        string Id = Session["Id_Participante"].ToString();
        Programa = Convert.ToInt32(Session["Programa"].ToString());
        LinkButton btn = (LinkButton)(sender);       
        string PathNameDocumento = "//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + DdlNumeroOrdenJudicial.SelectedValue + "/" + btn.CommandArgument.ToString();


        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + PathNameDocumento);
        Response.TransmitFile(PathNameDocumento);
        Response.End();
        Response.Redirect("/");
    }


    void CargarOrdenesJudiciales()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            DdlNumeroOrdenJudicial.DataTextField = "NumeroCasoCriminal";
            DdlNumeroOrdenJudicial.DataValueField = "Id_CasoCriminal";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarCasosCriminalesActivos(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));
         }
     }


    protected void DdlNumeroOrdenJudicial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DdlNumeroOrdenJudicial.SelectedValue != "0")
        {
            ActualizarDocumentosDdl();
            BidGrid();
        }
        else
        {
            DdlDocumento.DataSource = null;
            DdlDocumento.DataBind();
            DdlDocumento.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            GvRecepcionDocumentos.DataSource = null;
            GvRecepcionDocumentos.DataBind();

        }
       
        CargarDocumentosFaltantes();
    }

    protected void ActualizarDocumentosDdl()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            DdlDocumento.DataTextField = "Documento";
            DdlDocumento.DataValueField = "Id_Documento";
            DdlDocumento.DataSource = mylib.ListarTipodeDocumentosPorParticipanteOrdenJudicial(Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue), Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            DdlDocumento.DataBind();
            DdlDocumento.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }
    }

    protected void BtnSubirDocumento_Click(object sender, EventArgs e)
    {    

        if (FileUpload1.HasFile)
        { 
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                string Id = Session["Id_Participante"].ToString();
                Programa = Convert.ToInt32(Session["Programa"].ToString());
                if (!Directory.Exists("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + DdlNumeroOrdenJudicial.SelectedValue))
                {
                    Directory.CreateDirectory("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + DdlNumeroOrdenJudicial.SelectedValue + "/");
                }
                FileUpload1.SaveAs("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + DdlNumeroOrdenJudicial.SelectedValue + "/" + filename);
                //  StatusLabel.Text = "Upload status: File uploaded!";
                GuardarDocumento(Convert.ToInt32(DdlDocumento.SelectedValue), Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue), filename, Convert.ToInt32(Session["Id_UsuarioApp"]));
                BidGrid();
                CargarDocumentosFaltantes();
                ActualizarDocumentosDdl();
            }
            catch (Exception ex)
            {
                // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }

    }

   protected void GuardarDocumento(int Id_Documento, int Id_Participante, int Id_OrdenJudicial, string PathNameDocumento, int Id_UsuarioRecibe)
    {
        Programa = Convert.ToInt32(Session["Programa"].ToString());
        using (Ley22Entities mylib = new Ley22Entities())
             mylib.GuardarDocumentoPorParticipante(Id_Documento, Id_Participante, Id_OrdenJudicial, PathNameDocumento, Id_UsuarioRecibe,Programa);
 
    }

    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect("seleccion-proximo-paso.aspx", false);
    }
}