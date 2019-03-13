using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.Sql;
using Ley22_WebApp_V2.Old_App_Code;

public partial class recaudos_resultados_busqueda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TxtNroSeguroSocial"] == null)
        {
            Response.Redirect("recaudos-busqueda-usuario.aspx", false);
            return;
        }



        if (!Page.IsPostBack)
        {

            StringBuilder strParametroBusqueda = new StringBuilder();

            if (Session["TxtNroSeguroSocial"].ToString() != "")
                strParametroBusqueda.Append("Número de seguro social =" + Session["TxtNroSeguroSocial"].ToString() + ", ");

            if (Session["TxtIdentificacion"].ToString() != "")
                strParametroBusqueda.Append("Identificación=" + Session["TxtIdentificacion"].ToString() + ",  ");

            if (Session["TxtFechaNacimiento"].ToString() != "")
                strParametroBusqueda.Append("Fecha de nacimiento =" + Session["TxtFechaNacimiento"].ToString() + ", ");

            if (Session["TxtNombreyApellido"].ToString() != "")
                strParametroBusqueda.Append("Nombre y Apellido =" + Session["TxtNombreyApellido"].ToString());

            LitParametrodeBusqueda.Text = strParametroBusqueda.ToString();

      //      LitBusquedaCon.Text = Session["txtDocumentos"].ToString();
            int TotalReg = BindGridView(1);
            this.FillJumpToList(TotalReg);
            //

            TxtNroSeguroSocial.Attributes["placeholder"] = "Ej. 999-99-9999";
            TxtIdentificacion.Attributes["placeholder"] = "Ej. 22222";
            TxtFechaNacimiento.Attributes["placeholder"] = "Ej. mm/dd/yyyy";
            TxtNombreyApellido.Attributes["placeholder"] = "Ej. John Doe";



        }

    }

    int BindGridView(int pagina)
    {
        DateTime FechaNac;
        if (Session["TxtFechaNacimiento"].ToString() == "")
            FechaNac = Convert.ToDateTime("01-01-1900");
        else
            FechaNac = Convert.ToDateTime(Session["TxtFechaNacimiento"].ToString());

        using (Ley22Entities ml22e = new Ley22Entities())
        {

            List<BusquedaSencilladePersonas_Result> Resultado = ml22e.BusquedaSencilladePersonas(Session["TxtNroSeguroSocial"].ToString(),
                                                     Session["TxtIdentificacion"].ToString(),
                                                     FechaNac,
                                                     Session["TxtNombreyApellido"].ToString()).ToList()
                                                     ;
            var Resul = Resultado.Where(u => u.Identificacion.Equals("")).ToList();
            LitCantidadUsuarios.Text = Resul.Count.ToString();

            GridView1.PageIndex = pagina - 1;
            GridView1.DataSource = Resul;
            GridView1.DataBind();
            return Resul.Count();
        }

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        //  BindGridView();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)

        {
            ViewState["SortDirection"] = "ASC";
            GridView1.PageIndex = 0;
        }

        else if (ViewState["SortDirection"].ToString() == "ASC")
        {
            ViewState["SortDirection"] = "DESC";
        }

        else if (ViewState["SortDirection"].ToString() == "DESC")
        {
            ViewState["SortDirection"] = "ASC";
        }

        ViewState["SortExpression"] = e.SortExpression;
        //  BindGridView();
    }



    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        /* Session["RBLDocumentos"] = RBLDocumentos.SelectedValue;
         Session["txtDocumentos"] = RBLDocumentos.SelectedItem.Text;
         */

        if (!(TxtNroSeguroSocial.Text.Trim() == "" &&
            TxtIdentificacion.Text.Trim() == "" &&
            TxtFechaNacimiento.Text.Trim() == "" &&
            TxtNombreyApellido.Text.Trim() == ""))
        {
            Session["TxtNroSeguroSocial"] = TxtNroSeguroSocial.Text.Trim();
            Session["TxtIdentificacion"] = TxtIdentificacion.Text.Trim();
            Session["TxtFechaNacimiento"] = TxtFechaNacimiento.Text.Trim();
            Session["TxtNombreyApellido"] = TxtNombreyApellido.Text.Trim();
        }

        Response.Redirect("recaudos-resultados-busqueda.aspx", false);

    }

    protected void BtnCrearNuevaCuenta_Click(object sender, EventArgs e)
    {
        Session["DataParticipante"] = null;
        Response.Redirect("nuevo-usuario.aspx", false);
    }



    private void FillJumpToList(int TotalRows)

    {
        int PageCount = this.CalculateTotalPages(TotalRows);
        for (int i = 1; i <= PageCount; i++)
        {
            ddlJumpTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }




    protected void PageNumberChanged(object sender, EventArgs e)
    {
        int PageNo = Convert.ToInt32(ddlJumpTo.SelectedItem.Value);
        this.BindGridView(PageNo);
    }

    private int CalculateTotalPages(int intTotalRows)
    {
        int intPageCount = 1;
        double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                / Convert.ToDecimal(GridView1.PageSize));

        intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
        return intPageCount;
    }




    protected void lnkNombre_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string valores = btn.CommandArgument;
        int Id_Participante = Convert.ToInt32(valores.Split(',')[0]);
        int Pk_Persona = Convert.ToInt32(valores.Split(',')[1]);
        string expediente;

        using (SEPSEntities1 mlib = new SEPSEntities1())
        {
           
            short idPrograma = Convert.ToInt16(Session["Programa"]);
            Session["NombrePrograma"] = mlib.SA_PROGRAMA.Where(p => p.PK_Programa.Equals(idPrograma)).Select(u => u.NB_Programa).Single();

            expediente = mlib.SA_PERSONA_PROGRAMA.Where(p => p.FK_Programa.Equals(idPrograma)).Where(a => a.FK_Persona.Equals(Id_Participante)).Select(u => u.NR_Expediente).SingleOrDefault();
        }
        using (Ley22Entities mylib = new Ley22Entities())
        {
            List<sp_READ_SA_PERSONAxId_Result> resul = mylib.sp_READ_SA_PERSONAxId(Id_Participante, Pk_Persona).ToList();

            DataParticipante du = new DataParticipante()
            {
                PK_Persona = resul[0].Pk_Persona,
                NR_SeguroSocial = resul[0].NR_SeguroSocial,
                Identificacion = resul[0].Identificacion,
                Pasaporte = resul[0].Pasaporte,
                Licencia = resul[0].Licencia,
                IUP = (int)resul[0].IUP,
                Expediente = expediente,
                NB_Primero = resul[0].NB_Primero,
                NB_Segundo = resul[0].NB_Segundo,
                AP_Primero = resul[0].AP_Primero,
                AP_Segundo = resul[0].AP_Segundo,
                FE_Nacimiento = resul[0].FE_Nacimiento,
                FK_Sexo = resul[0].FK_Sexo,
                SexoDescripcion = resul[0].DE_Sexo,
                FK_GrupoEtnico = resul[0].FK_GrupoEtnico,
                GrupoEtnicoDescripcion = resul[0].DE_GrupoEtnico,
                FK_Veterano = resul[0].FK_Veterano,
                Correo = resul[0].Correo,
                Telefono1 = resul[0].Telefono1,
                Telefono2 = resul[0].Telefono2,
                TelefonoFamiliaraMasCercano = resul[0].TelefonoFamiliarMasCercano,
                TelefonoCitas = resul[0].TelefonoCitas,
                DireccionLinea1 = resul[0].DireccionLinea1,
                DireccionLinea2 = resul[0].DireccionLinea2,
                Municipio = resul[0].Municipio,
                CodigoPostal = resul[0].CodigoPostal,
                Id_Participante = Id_Participante
            };

 
            Session["Id_Participante"] = du.PK_Persona;
            Session["Id_Participante"] = du.Id_Participante;
            Session["NombreParticipante"] = resul[0].NB_Primero + " " + resul[0].AP_Primero;
            Session["DataParticipante"] = du;

            if (du.Id_Participante > 0)
                Response.Redirect("balance-pago.aspx", false);
            else
                Response.Redirect("nuevo-usuario.aspx", false);
        }


    }
}
