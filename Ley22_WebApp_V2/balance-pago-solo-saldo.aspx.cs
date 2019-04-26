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
    decimal TotalPagado, cargos, pagos;
    Ley22Entities dsLey22 = new Ley22Entities();
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

        if (Session["SA_Persona"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Info;
            Session["MensajeError"] = "Por favor seleccione el participante";
            Session["Redirect"] = "Entrada.aspx";
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
            //GvControldePagos.DataSource = mylib.ListarBalancedePagos(Convert.ToInt32(Session["Id_Participante"]),Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue));
            if (DdlNumeroOrdenJudicial.SelectedValue == "0")
            {
                divNav.Visible = false;
              
                LitBalance.Text = "";
                LitInfo.Text = "";
            }
            else
            {
                divNav.Visible = true;
               
            }
            GvCargos.DataSource = mylib.ListarCargosCasosCriminales(Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue));
            GvCargos.DataBind();

            GvPagos.DataSource = mylib.ListarPagosCasosCriminales(Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue));
            GvPagos.DataBind();

        }
    }
    protected void GvHistorial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int caso = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
        cargos = Convert.ToDecimal(dsLey22.CasoCriminals.Where(a => a.Id_CasoCriminal.Equals(caso)).Select(p => p.Cargos).Single());
        pagos = Convert.ToDecimal(dsLey22.CasoCriminals.Where(a => a.Id_CasoCriminal.Equals(caso)).Select(p => p.Pagos).Single());

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Literal LitColocarModal = (Literal)e.Row.FindControl("LitColocarModal");
            //Literal LitColocarEstatus = (Literal)e.Row.FindControl("LitColocarEstatus");
            string NroRecibo, Descripcion, FormadePago, Fecha, NombreCompleto, Id_Pago;
            decimal Cantidad;
            NroRecibo = DataBinder.Eval(e.Row.DataItem, "NumeroRecibo").ToString();
            Id_Pago = DataBinder.Eval(e.Row.DataItem, "PK_ControldePago").ToString();
            Descripcion = "\"" + DataBinder.Eval(e.Row.DataItem, "Descripcion").ToString() + "\"";
            FormadePago = "\"" + DataBinder.Eval(e.Row.DataItem, "FormadePago").ToString() + "\"";
            Fecha = "\"" + "" + "\"";
            Cantidad = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString());
            //CantidadAPagar = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString());
            NombreCompleto = "\"" + DataBinder.Eval(e.Row.DataItem, "NombreCompleto").ToString() + "\"";
          

        }
        if (e.Row.RowType == DataControlRowType.Footer)
            // LitInfo.Text = ContadorCharlasCitasPagadas.ToString() + " Charlas/Citas Pagadas por " + TotalPagado.ToString() + " USD, " + ContadordeCharlaCitasPorPagar.ToString() + " Charlas/Citas pendiente por pago.";
            LitInfo.Text = "Total de Cargos: $ " + cargos.ToString() + " | Cantidad Pagada: $ " + pagos.ToString();
    }

    protected void GvPagar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int caso = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
        cargos = Convert.ToDecimal(dsLey22.CasoCriminals.Where(a => a.Id_CasoCriminal.Equals(caso)).Select(p => p.Cargos).Single());
        pagos = Convert.ToDecimal(dsLey22.CasoCriminals.Where(a => a.Id_CasoCriminal.Equals(caso)).Select(p => p.Pagos).Single());       

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //Literal LitColocarModal = (Literal)e.Row.FindControl("LitColocarModal");
            //Literal LitColocarEstatus = (Literal)e.Row.FindControl("LitColocarEstatus");
            //string NroRecibo, Descripcion, FormadePago, Fecha, NombreCompleto, Id_Pago;
            //decimal Cantidad, CantidadAPagar;
            //NroRecibo = DataBinder.Eval(e.Row.DataItem, "NumeroRecibo").ToString();
            //Id_Pago = DataBinder.Eval(e.Row.DataItem, "Id_ControldePagos").ToString();
            //Descripcion = "\"" + DataBinder.Eval(e.Row.DataItem, "Descripcion").ToString() + "\"";
            //FormadePago = "\"" + DataBinder.Eval(e.Row.DataItem, "FormadePago").ToString() + "\"";
            //Fecha = "\"" + ""+ "\"";
            //Cantidad = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString());
            //CantidadAPagar = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString());
            //NombreCompleto = "\"" + DataBinder.Eval(e.Row.DataItem, "NombreCompleto").ToString() + "\"";


            //if (DataBinder.Eval(e.Row.DataItem, "Estatus").ToString() == "1")
            //{
            //    Fecha = "\"" + DataBinder.Eval(e.Row.DataItem, "FechadelPago").ToString() + "\"";
            //    LitColocarModal.Text = "<a href=\"#\" OnClick='changeDivContent(" + Id_Pago + "," + NroRecibo + ","+ Descripcion +","+FormadePago +","+ Fecha +"," + CantidadAPagar +"," +NombreCompleto + ")' data-toggle=\"modal\" data-target=\"#imprimir-recibo-modal\" data-whatever=\"@getbootstrap\"><span class=\"fas fa-print fa-lg\" data-toggle=\"tooltip\" title=\"Imprimir Recibo\"></span></a>";
            //    LitColocarEstatus.Text = "<div class=\"text-success\">Pagada</div>";
            //    ContadorCharlasCitasPagadas += 1;
            //    TotalPagado += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString());

            //}
            //else
            //{
            //    ContadordeCharlaCitasPorPagar += 1;
            //    TotalPagado += (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CantidadAPagar").ToString()) - Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString()));
            //    BalanceDebido += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString());
            //    LitColocarModal.Text = "<a href=\"#\" OnClick='ActualizarIdCP("+ Id_Pago + ","+Cantidad + "," + Descripcion+ ")' data-toggle=\"modal\" data-target=\"#Pagar-modal\" data-whatever=\"@getbootstrap\"><span class=\"fas fa-money-bill-alt  fa-lg\" data-toggle=\"tooltip\" title=\"Pagar Recibo\"></span></a>";
            //    LitColocarEstatus.Text = " <span class=\"text-danger\">Por pagar</span>";

            //}

        }
        if (e.Row.RowType == DataControlRowType.Footer)
            // LitInfo.Text = ContadorCharlasCitasPagadas.ToString() + " Charlas/Citas Pagadas por " + TotalPagado.ToString() + " USD, " + ContadordeCharlaCitasPorPagar.ToString() + " Charlas/Citas pendiente por pago.";
            LitBalance.Text = "Balance: $ " + (cargos - pagos).ToString();
    }

    protected void BtnCancelar_Click(Object sender, EventArgs e)
    {
        Response.Redirect("seleccion-proximo-paso.aspx", false);
    }

    protected void CargarOrdenesJudiciales()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            //DdlNumeroOrdenJudicial.DataTextField = "NumeroOrdenJudicial";
            //DdlNumeroOrdenJudicial.DataValueField = "Id_OrdenJudicial";
            //DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            //DdlNumeroOrdenJudicial.DataBind();
            //DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            DdlNumeroOrdenJudicial.DataTextField = "NumeroCasoCriminal";
            DdlNumeroOrdenJudicial.DataValueField = "Id_CasoCriminal";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarCasosCriminalesActivos(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }

        int Cant = DdlNumeroOrdenJudicial.Items.Count - 1;
        Utilitarios.NumLetra lib = new Utilitarios.NumLetra();

        //LitCantidadOrdenesJudiciales.Text = lib.Convertir(Cant.ToString(), false).Replace("00", "") + " (" + Cant.ToString() + ")";
    }
}                                                                                                                  