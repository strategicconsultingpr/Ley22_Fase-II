﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using Ley22_WebApp_V2.Old_App_Code;

public partial class charlas_grupales : System.Web.UI.Page
{
    SEPSEntities1 dsPerfil = new SEPSEntities1();
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
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "Region", "Region()", true);

            Session["FechaBase"] = new DateTime(2019, 01, 27);

 
            GenerarCalendario();
            CargarOrdenesJudiciales();
            var programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

            DdlCentro.DataValueField = "Value";
            DdlCentro.DataTextField = "Text";
            DdlCentro.DataSource = programas;
            DdlCentro.DataBind();
            DdlCentro.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            using (Ley22Entities mylib = new Ley22Entities())
            {
                // Calendar1.VisibleDate = DateTime.Now;

                //DdlRegion.DataTextField = "Region";
                //DdlRegion.DataValueField = "Id_Region";
                //DdlRegion.DataSource = mylib.sp_READALL_Regiones();
                //DdlRegion.DataBind();
                //DdlRegion.Items.Insert(0, new ListItem("-Seleccione-", "0"));
              //  DdlRegion.Items.FindByValue("1").Selected = true;

                //CargarDiasComboCitas(DateTime.DaysInMonth(Calendar1.TodaysDate.Year, Calendar1.TodaysDate.Month));

                //MostrarFechaTexto();
                //Session["FechaActual"] = DateTime.Now;

                //panelCalendarioSemanal.Visible = false;


                DdlNivelCharlas.DataTextField = "Nivel";
                DdlNivelCharlas.DataValueField = "Id_NiveldeCharla";
                DdlNivelCharlas.DataSource = mylib.sp_READALL_NivelesdelasCharlas();
                DdlNivelCharlas.DataBind();
                DdlNivelCharlas.Items.Insert(0, new ListItem("-Seleccione-", "0"));

                DdlNivelCharlas2.DataTextField = "Nivel";
                DdlNivelCharlas2.DataValueField = "Id_NiveldeCharla";
                DdlNivelCharlas2.DataSource = mylib.sp_READALL_NivelesdelasCharlas();
                DdlNivelCharlas2.DataBind();
                DdlNivelCharlas2.Items.Insert(0, new ListItem("-Seleccione-", "0"));


                DdlTipodeCharla.DataTextField = "TipodeCharla";
                DdlTipodeCharla.DataValueField = "Id_TipoCharla";
                DdlTipodeCharla.DataSource = mylib.sp_READALL_TipodeCharlas();
                DdlTipodeCharla.DataBind();
                DdlTipodeCharla.Items.Insert(0, new ListItem("-Seleccione-", "0"));

                DdlTipodeCharla2.DataTextField = "TipodeCharla";
                DdlTipodeCharla2.DataValueField = "Id_TipoCharla";
                DdlTipodeCharla2.DataSource = mylib.sp_READALL_TipodeCharlas();
                DdlTipodeCharla2.DataBind();
                DdlTipodeCharla2.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }

            

        }

   

        if (Page.Request.Params["__EVENTTARGET"] == "AnadirParticipante")
        {
            AnadirParticipante();
            return;
        }
         if (Page.Request.Params["__EVENTTARGET"] == "EliminarParticipante")
        {
            EliminarParticipante();
            return;
        }


    }

    protected void DdlNumeroOrdenJudicial_Selected(object sender, EventArgs e)
    {
        if (DdlNumeroOrdenJudicial.SelectedValue == "0")
        {

            //DdlRegion.Enabled = false;
            DdlCentro.Enabled = false;

            //DdlRegion.SelectedIndex = 0;
            DdlCentro.SelectedIndex = 0;
            
        }
        else
        {
            //DdlRegion.Enabled = true;
            DdlCentro.Enabled = true;
            //DdlRegion.SelectedIndex = 0;
            if(DdlCentro.Items.FindByValue("0") != null)
            {
                DdlCentro.SelectedIndex = 0;
            }
           

        }
        GenerarCalendario();
    }

    //protected void DdlRegion_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    using (Ley22Entities mylib = new Ley22Entities())
    //    {
    //        DdlCentro.DataTextField = "NB_Programa";
    //        DdlCentro.DataValueField = "PK_Programa";
    //        DdlCentro.DataSource = mylib.sp_READ_CentrobyRegion(Convert.ToInt32(DdlRegion.SelectedValue)).ToList();
    //        DdlCentro.DataBind();
    //        DdlCentro.Items.Insert(0, new ListItem("-Seleccione-", "0"));

    //    }
    //    if(DdlRegion.SelectedValue.ToString() == "0")
    //    {
    //        DdlCentro.Enabled = false;
    //        DdlCentro.SelectedIndex = 0;
    //    }
    //    else
    //    {
    //        DdlCentro.Enabled = true;
    //    }
    //    GenerarCalendario();
    //    DivBtnModalAsignarCita.Visible = false;
    //    Session["dataCalendario"] = null;
    //}
    protected void DdlCentro_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DdlCentro.SelectedValue.ToString() == "0")
            DivBtnModalAsignarCita.Visible = false;
        else
        {
            DivBtnModalAsignarCita.Visible = true;
            
        }
        GenerarCalendario();

    }

    protected void btnGuardarCharla_Click(object sender, EventArgs e)
    {
        string FechaInicial = TxtFechaCrearCharla.Text + " " + TxtInicialCrearCharla.Text;
        string FechaFinal = TxtFechaCrearCharla.Text + " " + TxtFinalCrearCharla.Text;

        DateComparisonResult comparison;

        comparison = (DateComparisonResult)Convert.ToDateTime(FechaInicial).CompareTo(DateTime.Now);

        if (comparison == DateComparisonResult.Later && Convert.ToDateTime(FechaInicial) < Convert.ToDateTime(FechaFinal))
        {

            using (Ley22Entities mylib = new Ley22Entities())
            {

                List<ListarCharlasCalendario_Result> myResult = mylib.ListarCharlasCalendario(Convert.ToInt32(DdlCentro.SelectedValue), Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35)).ToList();
                List<ListarCharlasCalendario_Result> ListaCharlasXDia = myResult.FindAll(delegate (ListarCharlasCalendario_Result bk)
                {
                    return bk.FechaInicial == Convert.ToDateTime(FechaInicial);
                });

                List<ListarExcepcionesCharlaGrupal_Result> myResult2 = mylib.ListarExcepcionesCharlaGrupal(Convert.ToInt32(DdlCentro.SelectedValue), Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35)).ToList();
                List<ListarExcepcionesCharlaGrupal_Result> ListaExcepcionesXDia = myResult2.FindAll(delegate (ListarExcepcionesCharlaGrupal_Result bk)
                {
                    return (bk.FechaInicial == Convert.ToDateTime(FechaInicial) || bk.FechaFinal == Convert.ToDateTime(FechaFinal) || (bk.FechaInicial <= Convert.ToDateTime(FechaInicial) && bk.FechaFinal >= Convert.ToDateTime(FechaFinal)));
                });

                if (ListaCharlasXDia.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(btnGuardarCharla, btnGuardarCharla.GetType(), "checkTime", "alert('YA EXISTE UNA CHARLA PARA ESTE MISMO DIA Y HORA!');", true);
                    TxtFechaCrearCharla.Text = "";
                    TxtInicialCrearCharla.Text = "";
                    TxtFinalCrearCharla.Text = "";
                    return;
                }

                else if (ListaExcepcionesXDia.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(btnGuardarCharla, btnGuardarCharla.GetType(), "checkTime", "alert('CHARLA GRUPAL NO DISPONIBLE PARA ESTA HORA!');", true);
                    TxtFechaCrearCharla.Text = "";
                    TxtInicialCrearCharla.Text = "";
                    TxtFinalCrearCharla.Text = "";
                    return;
                }

                else
                {
                    mylib.GuardarCharlaGrupal(Convert.ToInt32(DdlCentro.SelectedValue),
                                            Convert.ToDateTime(TxtFechaCrearCharla.Text + " " + TxtInicialCrearCharla.Text),
                                            Convert.ToDateTime(TxtFechaCrearCharla.Text + " " + TxtFinalCrearCharla.Text),
                                            Convert.ToInt32(DdlTipodeCharla.SelectedValue),
                                            Convert.ToInt32(DdlNivelCharlas.SelectedValue),
                                            Convert.ToInt32(TxtMaxCantParticipantes.Text),
                                            Convert.ToInt32(Session["Id_UsuarioApp"]));

                    GenerarCalendario();
                }

                
            }

        }
        else if (Convert.ToDateTime(FechaInicial) > Convert.ToDateTime(FechaFinal))
        {
            ScriptManager.RegisterClientScriptBlock(btnGuardarCharla, btnGuardarCharla.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES DESPUES DE LA HORA FINAL!');", true);
           
            return;
        }
        else if (Convert.ToDateTime(FechaInicial) == Convert.ToDateTime(FechaFinal))
        {
            ScriptManager.RegisterClientScriptBlock(btnGuardarCharla, btnGuardarCharla.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES IGUAL A LA HORA FINAL!');", true);
            

            return;
        }

    }

    protected enum DateComparisonResult
    {
        Earlier = -1,
        Later = 1,
        TheSame = 0
    };

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        string val = H_Id_CharlaGrupal.Value;
        int Id_CharlaGrupal = Convert.ToInt32(val);

        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.EliminarCharlaGrupal(Convert.ToInt32(Id_CharlaGrupal));
        }
        GenerarCalendario();
    }

    void GenerarCalendario()
    {
        DateTime FechaBase = Convert.ToDateTime(Session["FechaBase"]);

        List<Literal> LitNumDia = LitNumDia = new List<Literal> {
                                            LitNumDia1,LitNumDia2,
                                            LitNumDia3,LitNumDia4,
                                            LitNumDia5,LitNumDia6,
                                            LitNumDia7,LitNumDia8,
                                            LitNumDia9,LitNumDia10,
                                            LitNumDia11,LitNumDia12,
                                            LitNumDia13,LitNumDia14,
                                            LitNumDia15,LitNumDia16,
                                            LitNumDia17,LitNumDia18,
                                            LitNumDia19,LitNumDia20,
                                            LitNumDia21,LitNumDia22,
                                            LitNumDia23,LitNumDia24,
                                            LitNumDia25,LitNumDia26,
                                            LitNumDia27,LitNumDia28,
                                            LitNumDia29,LitNumDia30,
                                            LitNumDia31,LitNumDia32,
                                            LitNumDia33,LitNumDia34,
                                            LitNumDia35,
              };


        List<Literal> LitContCelda = LitContCelda = new List<Literal> {
                                            LitContCelda1,LitContCelda2,
                                            LitContCelda3,LitContCelda4,
                                            LitContCelda5,LitContCelda6,
                                            LitContCelda7,LitContCelda8,
                                            LitContCelda9,LitContCelda10,
                                            LitContCelda11,LitContCelda12,
                                            LitContCelda13,LitContCelda14,
                                            LitContCelda15,LitContCelda16,
                                            LitContCelda17,LitContCelda18,
                                            LitContCelda19,LitContCelda20,
                                            LitContCelda21,LitContCelda22,
                                            LitContCelda23,LitContCelda24,
                                            LitContCelda25,LitContCelda26,
                                            LitContCelda27,LitContCelda28,
                                            LitContCelda29,LitContCelda30,
                                            LitContCelda31,LitContCelda32,
                                            LitContCelda33,LitContCelda34,
                                            LitContCelda35,
              };

        // se obtienen ls charlas del calendario para la fecha
        List<ListarCharlasCalendario_Result> ListarCharlasCalendario = null;
        List<ListarExcepcionesCharlaGrupal_Result> ListarExcepcionesCharlaGrupal = null;

        if (DdlCentro.SelectedValue != "")
            using (Ley22Entities mylib = new Ley22Entities())
            {
                ListarCharlasCalendario = mylib.ListarCharlasCalendario(Convert.ToInt32(DdlCentro.SelectedValue), FechaBase, FechaBase.AddDays(35)).ToList();
                ListarExcepcionesCharlaGrupal = mylib.ListarExcepcionesCharlaGrupal(Convert.ToInt32(DdlCentro.SelectedValue), FechaBase, FechaBase.AddDays(35)).ToList();
            }


        for (int i = 0; i <= 34; i++)
        {
            DateTime fecha = FechaBase.AddDays(i);
            LitNumDia[i].Text = fecha.Day.ToString();
            LitContCelda[i].Text = "";

            if (fecha.ToShortDateString() == DateTime.Now.ToShortDateString())

                LitNumDia[i].Text = "<span class=\"dia actual\">" + fecha.Day.ToString() + "</span>";
            if (DdlCentro.SelectedValue.ToString() != "")
            {
                AsignarExcepcionesPorDia(i, fecha, LitContCelda, ListarExcepcionesCharlaGrupal);
                AsignatCharlaPordia(i, fecha, LitContCelda, ListarCharlasCalendario);
            }

            if (i.ToString() == "14")
                LiMesAno.Text = UppercaseFirst(fecha.ToString("MMMM")) + " " + fecha.Year.ToString();

        }

    }   

    void AsignatCharlaPordia(int i, DateTime Fecha, List<Literal> LitContCelda, List<ListarCharlasCalendario_Result> ListarCharlasCalendario)
    {


        try
        {
            List<ListarCharlasCalendario_Result> ListaCharlasXDia = ListarCharlasCalendario.FindAll(delegate (ListarCharlasCalendario_Result bk)
            {
                return bk.FechaInicial.ToString("dd/MM/yyyy") == Fecha.ToString("dd/MM/yyyy");
            });

           

            foreach (ListarCharlasCalendario_Result element in ListaCharlasXDia)
            {
                //LitContCelda[i].Text += " <div class=\"item ts-disponible\"><a href='#'  onClick='changeDivContent("+ element.Id_CharlaGrupal + ")'  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";

                using (Ley22Entities mylib = new Ley22Entities())

                {
                    List<ListarParticipantesPorCharlas_Result> resulParaticipalntes = mylib.ListarParticipantesPorCharlas(element.Id_CharlaGrupal).ToList();

                    if (resulParaticipalntes.Count > element.NrodeParticipantes || resulParaticipalntes.Count == element.NrodeParticipantes)
                    {
                        LitContCelda[i].Text += " <div class=\"item nohay\"><a href='#'  onClick='changeDivContent(" + element.Id_CharlaGrupal + ")'   data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                    }
                    else
                    {
                        LitContCelda[i].Text += " <div class=\"item ts-disponible\"><a href='#'  onClick='changeDivContent(" + element.Id_CharlaGrupal + ")'  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                    }
                }
            }

        }                                                                                                                                                                            
        catch (Exception ex)

        { }

    }
    protected void btnPrueba(object sender, EventArgs e)
    {
        string charla = Id_CharlaGrupal.Value;
        Id_CharlaGrupal.Value = "Que paso";
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert("+charla+")", true);
    }

    void AsignarExcepcionesPorDia(int i, DateTime Fecha, List<Literal> LitContCelda, List<ListarExcepcionesCharlaGrupal_Result> ListarExcepcionesCharlaGrupal)
    {

        List<ListarExcepcionesCharlaGrupal_Result> ListaExcepcionesXDia = null;
        try
        {
            ListaExcepcionesXDia = ListarExcepcionesCharlaGrupal.FindAll(delegate (ListarExcepcionesCharlaGrupal_Result bk)
            {
                return bk.FechaInicial.ToString("dd/MM/yyyy") == Fecha.ToString("dd/MM/yyyy");
            });

            LitContCelda[i].Text = "";

            foreach (ListarExcepcionesCharlaGrupal_Result element in ListaExcepcionesXDia)
            {
                LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent2('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "', '" + element.PK_CCG_Excepciones.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-excepcion-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
            }

        }
        catch (Exception ex)
        {

        }

    }

    protected void BtnHoy_Click(object sender, EventArgs e)
    {

    }

    protected void BtnLeft_Click(object sender, EventArgs e)
    {
        DateTime fecha = Convert.ToDateTime(Session["FechaBase"]);
        fecha = fecha.AddDays(-35);
        Session["FechaBase"] = fecha;

        GenerarCalendario();
    }

    protected void BtnRight_Click(object sender, EventArgs e)
    {
        DateTime fecha = Convert.ToDateTime(Session["FechaBase"]);
        fecha = fecha.AddDays(35);
        Session["FechaBase"] = fecha;

        GenerarCalendario();
    }

    static string UppercaseFirst(string s)
    {
        s = s.ToLower();
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

    protected void BtnGuardarOrdenJudicial_Click(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())
            mylib.GuardarOrdenJudicial(Convert.ToInt32(Session["Id_Participante"]), TxtNumeroOrdenJudicial.Text, Convert.ToInt32(Session["Id_UsuarioApp"]));

        CargarOrdenesJudiciales();
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

        int Cant = DdlNumeroOrdenJudicial.Items.Count - 1;
        Utilitarios.NumLetra lib = new Utilitarios.NumLetra();

        //DdlRegion.Enabled = false;
        DdlCentro.Enabled = false;

        LitCantidadOrdenesJudiciales.Text = lib.Convertir(Cant.ToString(), false).Replace("00", "") + " (" + Cant.ToString() + ")";
    }


     protected void BtnDocumentos_Click(object sender, EventArgs e)
    {
        Response.Redirect("imprimir-documentos.aspx", false);
    }

    void EliminarParticipante()
    {
       int Id_Participante = Convert.ToInt32(Session["Id_Participante"]);

        using (Ley22Entities mylib = new Ley22Entities())
            mylib.EliminarParticipanteCharlaGrupal(Convert.ToInt32(Id_CharlaGrupal.Value), Id_Participante);
        GenerarCalendario();

    }

    void AnadirParticipante()
    {
         int Id_Participante = Convert.ToInt32(Session["Id_Participante"]);

        using (Ley22Entities mylib = new Ley22Entities())
            mylib.GuardarParticipantePorCharlas(Convert.ToInt32(Id_CharlaGrupal.Value), Id_Participante, Convert.ToInt32(Session["Id_UsuarioApp"]), Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue));
        GenerarCalendario();

    }

    protected void BtnModificarCharla(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string val = H_Id_CharlaGrupal.Value;
        int Id_CharlaGrupal = Convert.ToInt32(val);
        

    }

    protected void BtnModificarCharla_2(object sender, EventArgs e)
    {
        string val = H_Id_CharlaGrupal.Value;
        int Id_CharlaGrupal = Convert.ToInt32(val);

        using (Ley22Entities mylib = new Ley22Entities())
        {

            mylib.ModificarCharlaGrupal(Convert.ToInt32(Id_CharlaGrupal),
                                        Convert.ToDateTime(TxtFecha2.Text + " " + TxtHoraInicial2.Text),
                                        Convert.ToDateTime(TxtFecha2.Text + " " + TxtHoraFinal2.Text),
                                        Convert.ToInt32(DdlTipodeCharla2.SelectedValue),
                                        Convert.ToInt32(DdlNivelCharlas2.SelectedValue),
                                        Convert.ToInt32(TxtMaxCantParticipantes2.Text),
                                        Convert.ToInt32(Session["Id_UsuarioApp"])

               );
        }
        GenerarCalendario();


    }

 
}