using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using Ley22_WebApp_V2;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

public partial class balance_pago : System.Web.UI.Page
{
    int ContadordeCharlaCitasPorPagar;
    int ContadorCharlasCitasPagadas;
    decimal TotalPagado, BalanceDebido;
    static string prevPage = String.Empty;
    ApplicationUser ExistingUser = new ApplicationUser();
    SEPSEntities1 dsPerfil = new SEPSEntities1();
    Ley22Entities dsLey22 = new Ley22Entities();
    static string userId = String.Empty;
    DataParticipante du;
    int Programa;

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



        if (!Page.IsPostBack)
        {
            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;

            prevPage = Request.UrlReferrer.ToString();
            NombrePrograma.Text = Session["NombrePrograma"].ToString();
            ContadordeCharlaCitasPorPagar = 0;
            ContadorCharlasCitasPagadas = 0;
            TotalPagado = 0;
           // CargarProgramas();
            CargarOrdenesJudiciales();
         //   BidGrid();
        }
    }

    


    protected void BtnGuardarPago_Click(object sender, EventArgs e)
    {
        du = (DataParticipante)Session["DataParticipante"];

        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.RegistrarPago(Convert.ToInt32( IdCP.Value), Convert.ToDecimal( TxtCantidad.Text), Convert.ToInt32( DdlFormadePago.SelectedValue), Convert.ToInt32(TxtNumeroCheque.Text==""?"0": TxtNumeroCheque.Text), Convert.ToDateTime(TxtFechaDelPago.Text),userId,TxtNumeroRecibo.Text);
            int Orden = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
            var a = mylib.Calendarios.Where(u => u.Id_OrdenJudicial.Equals(Orden)).Select(p => p.Id_Programa).First();
            short aa = Convert.ToInt16(a);
            var NB_Programa = dsPerfil.SA_PROGRAMA.Where(u => u.PK_Programa.Equals(aa)).Select(p => p.NB_Programa).First();

            EmailService mail = new EmailService();
            string body = CreateBody(du.NB_Primero, du.AP_Primero, TxtFechaDelPago.Text, TxtCantidad.Text, TxtCantidad.Text, DdlFormadePago.SelectedItem.Text,DdlNumeroOrdenJudicial.SelectedItem.Text, NB_Programa ,IdDesc.Value, TxtNumeroRecibo.Text);
            mail.SendAsyncCita(du.Correo, "Recibo de Pago", body);

            string Id = Session["Id_Participante"].ToString();
            Programa = Convert.ToInt32(Session["Programa"].ToString());
            if (!Directory.Exists(Server.MapPath("~/DocumentosPorParticipantes/" + Programa + "/" + Id + "/Pagos/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/DocumentosPorParticipantes/" + Programa + "/" + Id + "/Pagos/"));
            }

            // FileStream fs = new FileStream("C:/Users/alexie.ortiz/source/repos/Ley22_Fase-II/Ley22_WebApp_V2/DocumentosPorParticipantes/" + Programa + "/" + Id + "/Pagos/" + IdCP.Value+".pdf",FileMode.Create);
            // Document document = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            // PdfWriter pw = PdfWriter.GetInstance(document, fs);

            //StringBuilder sbHtmlText = new StringBuilder();
            //sbHtmlText.Append(body);

            //Document document = new Document();
            //PdfWriter.GetInstance(document, fs);

            //document.Open();
            //HTMLWorker hw = new HTMLWorker(document);
            //hw.Parse(new StringReader(sbHtmlText.ToString()));
            // document.Add(new Paragraph(body));
            //document.Close();
            
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            WebKitConverterSettings webKitSettings = new WebKitConverterSettings();

            //string baseUrl = "C:/Users/alexie.ortiz/source/repos/Ley22_Fase-II/Ley22_WebApp_V2/DocumentosPorParticipantes/" + Programa + "/" + Id + "/Pagos/";
            string baseUrl = "C:/Users/alexie.ortiz/source/repos/Ley22_Fase-II/Ley22_WebApp_V2/images/";

            webKitSettings.WebKitPath = "C:/Users/alexie.ortiz/source/repos/Ley22_Fase-II/Ley22_WebApp_V2/bin/QtBinaries/";

            string bodyPDF = CreateBodyPDF(du.NB_Primero, du.AP_Primero, TxtFechaDelPago.Text, TxtCantidad.Text, TxtCantidad.Text, DdlFormadePago.SelectedItem.Text, DdlNumeroOrdenJudicial.SelectedItem.Text, NB_Programa, IdDesc.Value, TxtNumeroRecibo.Text);


            htmlConverter.ConverterSettings = webKitSettings;

            PdfDocument document = htmlConverter.Convert(bodyPDF, baseUrl);

            document.Save(Server.MapPath("~/DocumentosPorParticipantes/" + Programa + "/" + Id + "/Pagos/" + IdCP.Value + ".pdf"));
            
            document.Close(true);
            

        }
        BidGrid(sender, e);
    }

    protected void DdlFormadePago_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlFormadePago.SelectedValue == "1")
        {
            TxtNumeroCheque.Enabled = false;
            TxtNumeroCheque.ReadOnly = true;
            RFVNumeroCheque.Enabled = false;
        }
        else
        {
            TxtNumeroCheque.Enabled = true;
            RFVNumeroCheque.Enabled = true;
            TxtNumeroCheque.ReadOnly = false;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    }

    protected void BidGrid(object sender, EventArgs e)

    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            GvControldePagos.DataSource = mylib.ListarBalancedePagos( Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue));
            GvControldePagos.DataBind();

        }
    }
     
    protected void GvControldePagos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal LitColocarModal = (Literal)e.Row.FindControl("LitColocarModal");
            Literal LitColocarEstatus = (Literal)e.Row.FindControl("LitColocarEstatus");
            string NroRecibo, Descripcion, FormadePago, Fecha, NombreCompleto, Id_Pago;
            decimal Cantidad, CantidadAPagar;
            NroRecibo = DataBinder.Eval(e.Row.DataItem, "NumeroRecibo").ToString();
            Id_Pago = DataBinder.Eval(e.Row.DataItem, "Id_ControldePagos").ToString();
            Descripcion = "\"" + DataBinder.Eval(e.Row.DataItem, "Descripcion").ToString() + "\"";
            FormadePago = "\"" + DataBinder.Eval(e.Row.DataItem, "FormadePago").ToString() + "\"";
            Fecha = "\"" + ""+ "\"";
            Cantidad = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString());
            CantidadAPagar = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString());
            NombreCompleto = "\"" + DataBinder.Eval(e.Row.DataItem, "NombreCompleto").ToString() + "\"";


            if (DataBinder.Eval(e.Row.DataItem, "Estatus").ToString() == "1")
            {
                Fecha = "\"" + DataBinder.Eval(e.Row.DataItem, "FechadelPago").ToString() + "\"";
                LitColocarModal.Text = "<a href=\"#\" OnClick='changeDivContent(" + NroRecibo + ","+ Descripcion +","+FormadePago +","+ Fecha +"," + CantidadAPagar +"," +NombreCompleto + ")' data-toggle=\"modal\" data-target=\"#imprimir-recibo-modal\" data-whatever=\"@getbootstrap\"><span class=\"fas fa-print fa-lg\" data-toggle=\"tooltip\" title=\"Imprimir Recibo\"></span></a>";
                LitColocarEstatus.Text = "<div class=\"text-success\">Pagada</div>";
                ContadorCharlasCitasPagadas += 1;
                TotalPagado += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString());

            }
            else
            {
                ContadordeCharlaCitasPorPagar += 1;
                TotalPagado += (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString()) - Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString()));
                BalanceDebido += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString());
                LitColocarModal.Text = "<a href=\"#\" OnClick='ActualizarIdCP("+ Id_Pago + ","+Cantidad + "," + Descripcion+ ")' data-toggle=\"modal\" data-target=\"#Pagar-modal\" data-whatever=\"@getbootstrap\"><span class=\"fas fa-money-bill-alt  fa-lg\" data-toggle=\"tooltip\" title=\"Pagar Recibo\"></span></a>";
                LitColocarEstatus.Text = " <span class=\"text-danger\">Por pagar</span>";

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
            // LitInfo.Text = ContadorCharlasCitasPagadas.ToString() + " Charlas/Citas Pagadas por " + TotalPagado.ToString() + " USD, " + ContadordeCharlaCitasPorPagar.ToString() + " Charlas/Citas pendiente por pago.";
            LitInfo.Text = "Balance: $ " + BalanceDebido.ToString() + " | Cantidad Pagada: $ " + TotalPagado.ToString();
    }
   protected void CargarOrdenesJudiciales()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            DdlNumeroOrdenJudicial.DataTextField = "NumeroOrdenJudicial";
            DdlNumeroOrdenJudicial.DataValueField = "Id_OrdenJudicial";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Seleccione-", "0"));

        }

        int Cant = DdlNumeroOrdenJudicial.Items.Count - 1;
        Utilitarios.NumLetra lib = new Utilitarios.NumLetra();

        //LitCantidadOrdenesJudiciales.Text = lib.Convertir(Cant.ToString(), false).Replace("00", "") + " (" + Cant.ToString() + ")";
    }
    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect(prevPage, false);
    }

    private string CreateBody(string FirstName, string LastName, string Fecha, string CantidadPagada, string Cantidad, string Metodo, string Order, string Programa, string Descripcion, string Recibo)
    {
        string body = string.Empty;

        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailReciboPago.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Participante}", FirstName + " " + LastName);
        body = body.Replace("{Fecha}", Fecha);
        body = body.Replace("{CantidadPagada}", "$" + CantidadPagada);
        body = body.Replace("{Metodo}", Metodo);
        body = body.Replace("{Programa}", Programa);
        body = body.Replace("{Descripcion}", Descripcion);
        body = body.Replace("{Order}", Order);
        body = body.Replace("{Cantidad}", "$" + Cantidad);
        body = body.Replace("{Recibo}", Recibo);

        return body;

    }

    private string CreateBodyPDF(string FirstName, string LastName, string Fecha, string CantidadPagada, string Cantidad, string Metodo, string Order, string Programa, string Descripcion, string Recibo)
    {
        string body = string.Empty;

        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailReciboPago_PDF.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Participante}", FirstName + " " + LastName);
        body = body.Replace("{Fecha}", Fecha);
        body = body.Replace("{CantidadPagada}", "$" + CantidadPagada);
        body = body.Replace("{Metodo}", Metodo);
        body = body.Replace("{Programa}", Programa);
        body = body.Replace("{Descripcion}", Descripcion);
        body = body.Replace("{Order}", Order);
        body = body.Replace("{Cantidad}", "$" + Cantidad);
        body = body.Replace("{Recibo}", Recibo);

        return body;

    }

    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=print.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);

        //panelPDF.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
        //HTMLWorker htmlParse = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc,Response.OutputStream);
         
        //pdfDoc.Open();
        //htmlParse.Parse(sr);
        //pdfDoc.Close();

        //Response.Write(pdfDoc);
        //Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

}