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
    SEPSEntities1 dsPerfil = new SEPSEntities1();

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

            //if (Session["TxtIdentificacion"].ToString() != "")
            //    strParametroBusqueda.Append("Identificación=" + Session["TxtIdentificacion"].ToString() + ",  ");

            if (Session["TxtFechaNacimiento"].ToString() != "")
                strParametroBusqueda.Append("Fecha de nacimiento =" + Session["TxtFechaNacimiento"].ToString() + ", ");

            if (Session["TxtNombre"].ToString() != "")
                strParametroBusqueda.Append("Nombre =" + Session["TxtNombre"].ToString());

            if (Session["TxtApellido"].ToString() != "")
                strParametroBusqueda.Append("Apellido =" + Session["TxtApellido"].ToString());

            LitParametrodeBusqueda.Text = strParametroBusqueda.ToString();

      //      LitBusquedaCon.Text = Session["txtDocumentos"].ToString();
            int TotalReg = BindGridView(1);
            this.FillJumpToList(TotalReg);
            //

            TxtNroSeguroSocial.Attributes["placeholder"] = "Ej. 999-99-9999";
            //TxtIdentificacion.Attributes["placeholder"] = "Ej. 22222";
            TxtFechaNacimiento.Attributes["placeholder"] = "Ej. mm/dd/yyyy";
           // TxtNombreyApellido.Attributes["placeholder"] = "Ej. John Doe";



        }

    }

    int BindGridView(int pagina)
    {
        DateTime FechaNac;
        short idPrograma = Convert.ToInt16(Session["Programa"]);
        if (Session["TxtFechaNacimiento"].ToString() == "")
            FechaNac = Convert.ToDateTime("01-01-1900");
        else
            FechaNac = Convert.ToDateTime(Session["TxtFechaNacimiento"].ToString());

        using (Ley22Entities ml22e = new Ley22Entities())
        {

            List<BusquedaSencilladePersonasRecepcion_Result> Resultado = ml22e.BusquedaSencilladePersonasRecepcion(Session["TxtNroSeguroSocial"].ToString(),
                                                                     Session["TxtIdentificacion"].ToString(), FechaNac,
                                                                     Session["TxtNombre"].ToString(), Session["TxtApellido"].ToString(),
                                                                     Session["TxtSegundoApellido"].ToString(),idPrograma).ToList();

            var Result = Resultado.Where(u => u.Identificacion.Equals("LEY 22")).ToList();
            var Expedientes = dsPerfil.SA_PERSONA_PROGRAMA.Where(a => a.FK_Programa.Equals(idPrograma)).Select(p => p.FK_Persona).Cast<int?>().ToList();
            var Resul = Result.Where(a => Expedientes.Contains(a.PK_Persona)).ToList();
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
            TxtFechaNacimiento.Text.Trim() == "" &&
            TxtNombre.Text.Trim() == "" &&
            TxtApellido.Text.Trim() == "" &&
            TxtSegundoApellido.Text.Trim() == ""))
        {
            Session["TxtNroSeguroSocial"] = TxtNroSeguroSocial.Text.Trim();          
            Session["TxtFechaNacimiento"] = TxtFechaNacimiento.Text.Trim();
            Session["TxtNombre"] = TxtNombre.Text.Trim();
            Session["TxtApellido"] = TxtApellido.Text.Trim();
            Session["TxtSegundoApellido"] = TxtSegundoApellido.Text.Trim();
            Session["TxtNombreyApellido"] = TxtNombre.Text.Trim() + ' ' + TxtApellido.Text.Trim();
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

            var sa_personas = mlib.SA_PERSONA.Where(a => a.PK_Persona.Equals(Id_Participante)).Single();

            Data_SA_Persona sa_persona = new Data_SA_Persona()
            {
                PK_Persona = sa_personas.PK_Persona,
                NR_SeguroSocial = sa_personas.NR_SeguroSocial,
                FK_Sexo = Convert.ToInt32(sa_personas.FK_Sexo),
                NB_Primero = sa_personas.NB_Primero,
                NB_Segundo = sa_personas.NB_Segundo,
                AP_Primero = sa_personas.AP_Primero,
                AP_Segundo = sa_personas.AP_Segundo,
                FE_Nacimiento = Convert.ToDateTime(sa_personas.FE_Nacimiento),
                FK_Veterano = Convert.ToInt32(sa_personas.FK_Veterano),
                FK_GrupoEtnico = Convert.ToInt32(sa_personas.FK_GrupoEtnico)

            };

            Session["Id_Participante"] = sa_persona.PK_Persona;
            Session["NombreParticipante"] = sa_persona.NB_Primero + " " + sa_persona.AP_Primero;
            Session["NombreParticipante2"] = 9;
            Session["SA_Persona"] = sa_persona;
            Session["Expediente"] = expediente;

            Response.Redirect("balance-pago.aspx", false);
        }
        //using (Ley22Entities mylib = new Ley22Entities())
        //{
        //    List<sp_READ_SA_PERSONAxId_Result> resul = mylib.sp_READ_SA_PERSONAxId(Id_Participante, Pk_Persona).ToList();

        //    DataParticipante du = new DataParticipante()
        //    {
        //        PK_Persona = resul[0].Pk_Persona,
        //        NR_SeguroSocial = resul[0].NR_SeguroSocial,
        //        Identificacion = resul[0].Identificacion,
        //        Pasaporte = resul[0].Pasaporte,
        //        Licencia = resul[0].Licencia,
        //        IUP = (int)resul[0].IUP,
        //        Expediente = expediente,
        //        NB_Primero = resul[0].NB_Primero,
        //        NB_Segundo = resul[0].NB_Segundo,
        //        AP_Primero = resul[0].AP_Primero,
        //        AP_Segundo = resul[0].AP_Segundo,
        //        FE_Nacimiento = resul[0].FE_Nacimiento,
        //        FK_Sexo = resul[0].FK_Sexo,
        //        SexoDescripcion = resul[0].DE_Sexo,
        //        FK_GrupoEtnico = resul[0].FK_GrupoEtnico,
        //        GrupoEtnicoDescripcion = resul[0].DE_GrupoEtnico,
        //        FK_Veterano = resul[0].FK_Veterano,
        //        Correo = resul[0].Correo,
        //        Telefono1 = resul[0].Telefono1,
        //        Telefono2 = resul[0].Telefono2,
        //        TelefonoFamiliaraMasCercano = resul[0].TelefonoFamiliarMasCercano,
        //        TelefonoCitas = resul[0].TelefonoCitas,
        //        DireccionLinea1 = resul[0].DireccionLinea1,
        //        DireccionLinea2 = resul[0].DireccionLinea2,
        //        Municipio = resul[0].Municipio,
        //        CodigoPostal = resul[0].CodigoPostal,
        //        Id_Participante = Id_Participante
        //    };

 
        //    Session["Id_Participante"] = du.PK_Persona;
        //    Session["Id_Participante"] = du.Id_Participante;
        //    Session["NombreParticipante"] = resul[0].NB_Primero + " " + resul[0].AP_Primero;
        //    Session["DataParticipante"] = du;

        //    if (du.Id_Participante > 0)
        //        Response.Redirect("balance-pago.aspx", false);
        //    else
        //        Response.Redirect("nuevo-usuario.aspx", false);
        //}


    }
}
