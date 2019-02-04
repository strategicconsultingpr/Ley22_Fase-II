using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;

public partial class balance_pago : System.Web.UI.Page
{
    int ContadordeCharlaCitasPorPagar;
    int ContadorCharlasCitasPagadas;
    decimal TotalPagado, BalanceDebido;
    static string prevPage = String.Empty;
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
            prevPage = Request.UrlReferrer.ToString();
            ContadordeCharlaCitasPorPagar = 0;
            ContadorCharlasCitasPagadas = 0;
            TotalPagado = 0;
            CargarOrdenesJudiciales();
         //   BidGrid();
        }
    }

    protected void BtnGuardarPago_Click(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.RegistrarPago(Convert.ToInt32( IdCP.Value), Convert.ToDecimal( TxtCantidad.Text), Convert.ToInt32( DdlFormadePago.SelectedValue), Convert.ToInt32(TxtNumeroCheque.Text==""?"0": TxtNumeroCheque.Text), Convert.ToDateTime(TxtFechaDelPago.Text), Convert.ToInt32( Session["Id_UsuarioApp"]));

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
            string NroRecibo, Descripcion, FormadePago, Fecha, Cantidad, NombreCompleto;
            NroRecibo = DataBinder.Eval(e.Row.DataItem, "Id_ControldePagos").ToString();
            Descripcion = "\"" + DataBinder.Eval(e.Row.DataItem, "Descripcion").ToString() + "\"";
            FormadePago = "\"" + DataBinder.Eval(e.Row.DataItem, "FormadePago").ToString() + "\"";
            Fecha = "\"" + ""+ "\"";
            Cantidad = DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString();
            NombreCompleto = "\"" + DataBinder.Eval(e.Row.DataItem, "NombreCompleto").ToString() + "\"";


            if (DataBinder.Eval(e.Row.DataItem, "Estatus").ToString() == "1")
            {
                Fecha = "\"" + DataBinder.Eval(e.Row.DataItem, "FechadelPago").ToString() + "\"";
                LitColocarModal.Text = "<a href=\"#\" OnClick='changeDivContent(" + NroRecibo + ","+ Descripcion +","+FormadePago +","+ Fecha +"," + Cantidad +"," +NombreCompleto + ")' data-toggle=\"modal\" data-target=\"#imprimir-recibo-modal\" data-whatever=\"@getbootstrap\"><span class=\"fas fa-print fa-lg\" data-toggle=\"tooltip\" title=\"Imprimir Recibo\"></span></a>";
                LitColocarEstatus.Text = "<div class=\"text-success\">Pagada</div>";
                ContadorCharlasCitasPagadas += 1;
                TotalPagado += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString());

            }
            else
            {
                ContadordeCharlaCitasPorPagar += 1;
                BalanceDebido += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString());
                LitColocarModal.Text = "<a href=\"#\" OnClick='ActualizarIdCP("+ NroRecibo + ","+Cantidad +")' data-toggle=\"modal\" data-target=\"#Pagar-modal\" data-whatever=\"@getbootstrap\"><span class=\"fas fa-money-bill-alt  fa-lg\" data-toggle=\"tooltip\" title=\"Pagar Recibo\"></span></a>";
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
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }

        int Cant = DdlNumeroOrdenJudicial.Items.Count - 1;
        Utilitarios.NumLetra lib = new Utilitarios.NumLetra();

        //LitCantidadOrdenesJudiciales.Text = lib.Convertir(Cant.ToString(), false).Replace("00", "") + " (" + Cant.ToString() + ")";
    }
    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect(prevPage, false);
    }


}