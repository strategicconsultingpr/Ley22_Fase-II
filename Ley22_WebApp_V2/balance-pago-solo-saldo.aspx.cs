using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;

public partial class balance_pago_solo_saldo : System.Web.UI.Page
{
    int ContadordeCharlaCitasPorPagar;
    int ContadorCharlasCitasPagadas;
    decimal TotalPagado, BalanceDebido;
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
            ContadordeCharlaCitasPorPagar = 0;
            ContadorCharlasCitasPagadas = 0;
            TotalPagado = 0;
            CargarOrdenesJudiciales();

          //  BidGrid();
        }
    }

   protected void BidGrid(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())

        {
            GvControldePagos.DataSource = mylib.ListarBalancedePagos(Convert.ToInt32(Session["Id_Participante"]),Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue));
            GvControldePagos.DataBind();

        }
    }
    protected void GvControldePagos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             Literal LitColocarEstatus = (Literal)e.Row.FindControl("LitColocarEstatus");
            string NroRecibo, Descripcion, FormadePago, Fecha, Cantidad, NombreCompleto, CantidadAPagar;
            NroRecibo = DataBinder.Eval(e.Row.DataItem, "Id_ControldePagos").ToString();
            Descripcion = "\"" + DataBinder.Eval(e.Row.DataItem, "Descripcion").ToString() + "\"";
            FormadePago = "\"" + DataBinder.Eval(e.Row.DataItem, "FormadePago").ToString() + "\"";
            Fecha = "\"" + "" + "\"";
            Cantidad = DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString();
            NombreCompleto = "\"" + DataBinder.Eval(e.Row.DataItem, "NombreCompleto").ToString() + "\"";


            if (DataBinder.Eval(e.Row.DataItem, "Estatus").ToString() == "1")
            {
                Fecha = "\"" + DataBinder.Eval(e.Row.DataItem, "FechadelPago").ToString() + "\"";
                 LitColocarEstatus.Text = "<div class=\"text-success\">Pagada</div>";
                ContadorCharlasCitasPagadas += 1;
                TotalPagado += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString());
             }
            else
            {
                 LitColocarEstatus.Text = " <span class=\"text-danger\">Por pagar</span>";
                ContadordeCharlaCitasPorPagar += 1;
                TotalPagado += (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString()) - Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString()));

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
            LitInfo.Text =ContadorCharlasCitasPagadas.ToString() + " Charlas/Citas Pagadas por " + TotalPagado.ToString() + " USD - " + ContadordeCharlaCitasPorPagar.ToString() + " Charlas/Citas pendiente por saldar." ;
    }

    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect("seleccion-proximo-paso.aspx", false);
    }

    protected void CargarOrdenesJudiciales()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            DdlNumeroOrdenJudicial.DataTextField = "NumeroOrdenJudicial";
            DdlNumeroOrdenJudicial.DataValueField = "Id_OrdenJudicial";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }

        int Cant = DdlNumeroOrdenJudicial.Items.Count - 1;
        Utilitarios.NumLetra lib = new Utilitarios.NumLetra();

        //LitCantidadOrdenesJudiciales.Text = lib.Convertir(Cant.ToString(), false).Replace("00", "") + " (" + Cant.ToString() + ")";
    }
}                                                                                                                  