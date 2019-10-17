using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using Ley22_WebApp_V2.Old_App_Code;
using Ley22_WebApp_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text;
using System.IO;
using Ley22_WebApp_V2;

public partial class charlas_grupales : System.Web.UI.Page
{
    SEPSEntities1 dsPerfil = new SEPSEntities1();
    ApplicationUser ExistingUser = new ApplicationUser();
    Ley22Entities dsley22 = new Ley22Entities();
    static string userId = String.Empty;

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
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "Region", "Region()", true);
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var usuarios_programas = new List<int>();
            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;

            var dia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            while (dia.DayOfWeek != DayOfWeek.Sunday)
            {
                dia = dia.AddDays(-1);
            }
            Session["FechaBase"] = new DateTime(dia.Year, dia.Month, dia.Day);


            GenerarCalendario();
            CargarOrdenesJudiciales();


            //if (userManager.IsInRole(userId, "SuperAdmin"))
            //{
            //    usuarios_programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Select(p => p.PK_Programa).ToList().Select<short, int>(i => i).ToList();
            //}
            //else
            //{
            //    usuarios_programas = dsley22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
            //}

            //var programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Where(p => usuarios_programas.Contains(p.PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa.Replace("EVALUACIÓN ", "") }).ToList();
            short PK_Programa = Convert.ToInt16(Session["Programa"]);
            var programas = dsPerfil.SA_PROGRAMA.Where(a => a.PK_Programa.Equals(PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa.Replace("EVALUACIÓN ", "") }).ToList();


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
                                            userId,
                                            Convert.ToInt32(DdlNumeroCharla.SelectedIndex));

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
                    var asistio = mylib.CharlaGrupals.Where(u => u.Id_CharlaGrupal.Equals(element.Id_CharlaGrupal)).Single();
                    //if (asistio.FechaFinal > DateTime.Today)
                    //{
                        if (resulParaticipalntes.Count > element.NrodeParticipantes || resulParaticipalntes.Count == element.NrodeParticipantes)
                        {
                            LitContCelda[i].Text += " <div class=\"item nohay\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"   data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 1)
                        {
                            LitContCelda[i].Text += " <div class=\"item primera\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: black\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 2)
                        {
                            LitContCelda[i].Text += " <div class=\"item segunda\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 3)
                        {
                            LitContCelda[i].Text += " <div class=\"item tercera\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 4)
                        {
                            LitContCelda[i].Text += " <div class=\"item cuarta\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 5)
                        {
                            LitContCelda[i].Text += " <div class=\"item quinta\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 6)
                        {
                            LitContCelda[i].Text += " <div class=\"item sexta\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 7)
                        {
                            LitContCelda[i].Text += " <div class=\"item septima\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 8)
                        {
                            LitContCelda[i].Text += " <div class=\"item octava\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 9)
                        {
                            LitContCelda[i].Text += " <div class=\"item novena\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (asistio.NumeroCharla == 10)
                        {
                            LitContCelda[i].Text += " <div class=\"item decima\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "','" + DdlNumeroOrdenJudicial.SelectedValue + "')\"  data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + " " + element.TipodeCharla + "</a></div>";
                        }

                    //}
                    //else
                    //{
                    //    LitContCelda[i].Text += " <div class=\"item nohay\"><a href='#'  onClick='changeDivContent(" + element.Id_CharlaGrupal + ")'   data-toggle=\"modal\" data-target=\"#modal-asistencia\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                    //}
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
                LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent2('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "', '" + element.PK_CCG_Excepciones.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-excepcion-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
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
            mylib.GuardarOrdenJudicial(Convert.ToInt32(Session["Id_Participante"]), TxtNumeroOrdenJudicial.Text, Convert.ToInt32(Session["Id_UsuarioApp"]), Convert.ToInt32(Session["Programa"]));

        CargarOrdenesJudiciales();
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
       int Id_Charla = Convert.ToInt32(Id_CharlaGrupal.Value);
        int casoCriminal = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);

        try
        {
            using (Ley22Entities mylib = new Ley22Entities())
            {
                
                

                //mylib.EliminarParticipanteCharlaGrupal(Convert.ToInt32(Id_CharlaGrupal.Value), Id_Participante);
                mylib.EliminarParticipanteCharlaGrupalCasoCriminal(Convert.ToInt32(Id_CharlaGrupal.Value), Id_Participante,casoCriminal);

                string mensaje = "Se eliminó correctamente el participante de la charla";


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Participante fuera de Charla", "sweetAlert('Participante fuera de Charla','" + mensaje + "','success')", true);

                var email = mylib.CasoCriminals.Where(p => p.Id_CasoCriminal.Equals(casoCriminal)).Select(r => r.Email).SingleOrDefault();

                if (email.Count() > 0)
                {

                    string charla = mylib.CharlaGrupals.Where(a => a.Id_CharlaGrupal.Equals(Id_Charla)).Select(p => p.FechaInicial).Single().ToString();

                    Data_SA_Persona du = (Data_SA_Persona)Session["SA_Persona"];

                    string evento = "Se elimino charla con fecha " + charla;
                    GridView gv = new GridView();
                    gv.DataSource = mylib.ConsultarCharlasParaTarjeta(Id_Participante, Convert.ToInt32(DdlCentro.SelectedValue));

                    gv.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
                    gv.EmptyDataText = "No hay charlas asignadas para este caso criminal";
                    gv.HeaderStyle.ForeColor = System.Drawing.Color.Gray;
                    gv.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    gv.RowStyle.Font.Size = 10;
                    gv.RowStyle.ForeColor = System.Drawing.Color.Gray;
                    gv.RowStyle.HorizontalAlign = HorizontalAlign.Center;
                    gv.CellPadding = 7;

                    gv.RowStyle.Wrap = false;
                    gv.DataBind();

                    EmailService mail = new EmailService();
                    string body = CreateBody(gv, du.NB_Primero + " " + du.AP_Primero, DdlNumeroOrdenJudicial.SelectedItem.Text, DdlCentro.SelectedItem.Text, evento);
                    mail.SendAsyncCita(email, "Tarjeta de Charlas", body);
                }
            }
            GenerarCalendario();
        }
        catch (Exception ex)
        {

            string mensaje = ex.InnerException.Message;


            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
        }



    }

    void AnadirParticipante()
    {
         int Id_Participante = Convert.ToInt32(Session["Id_Participante"]);
        int Id_Charla = Convert.ToInt32(Id_CharlaGrupal.Value);
        try
        {
            using (Ley22Entities mylib = new Ley22Entities())
            {
                int casoCriminal = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
                var email = mylib.CasoCriminals.Where(p => p.Id_CasoCriminal.Equals(casoCriminal)).Select(r => r.Email).SingleOrDefault();

                var NumeroCharla = mylib.CharlaGrupals.Where(p => p.Id_CharlaGrupal.Equals(Id_Charla)).Select(u => u.NumeroCharla).Single();
                mylib.GuardarParticipantePorCharlas(Id_Charla, Id_Participante, userId, Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue), NumeroCharla);

                string mensaje = "Se agregó correctamente el participante a la charla";


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Participante en Charla", "sweetAlert('Participante en Charla','" + mensaje + "','success')", true);

                if (email.Count() > 0)
                {

                    string charla = mylib.CharlaGrupals.Where(a => a.Id_CharlaGrupal.Equals(Id_Charla)).Select(p => p.FechaInicial).Single().ToString();

                    Data_SA_Persona du = (Data_SA_Persona)Session["SA_Persona"];

                    string evento = "Se agrego una charla el " + charla;
                    GridView gv = new GridView();
                    gv.DataSource = mylib.ConsultarCharlasParaTarjeta(Id_Participante, Convert.ToInt32(DdlCentro.SelectedValue));

                    gv.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
                    gv.EmptyDataText = "No hay charlas asignadas para este caso criminal";
                    gv.HeaderStyle.ForeColor = System.Drawing.Color.Gray;
                    gv.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    gv.RowStyle.Font.Size = 10;
                    gv.RowStyle.ForeColor = System.Drawing.Color.Gray;
                    gv.RowStyle.HorizontalAlign = HorizontalAlign.Center;
                    gv.CellPadding = 7;

                    gv.RowStyle.Wrap = false;
                    gv.DataBind();

                    EmailService mail = new EmailService();
                    string body = CreateBody(gv, du.NB_Primero + " " + du.AP_Primero, DdlNumeroOrdenJudicial.SelectedItem.Text, DdlCentro.SelectedItem.Text, evento);
                    mail.SendAsyncCita(email, "Tarjeta de Charlas", body);
                }
            }
            GenerarCalendario();
        }
        catch (Exception ex)
        {

            string mensaje = ex.InnerException.Message;


            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
        }

       

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
                                        userId,
                                        Convert.ToInt32(DdlNumeroCharla2.SelectedIndex)

               );

        }
        GenerarCalendario();


    }

    private string CreateBody(GridView gv, string Nombre, string Caso, string Programa, string Evento)
    {
        string body = string.Empty;

        StringBuilder strBuilder = new StringBuilder();
        StringWriter strWriter = new StringWriter(strBuilder);
        HtmlTextWriter htw = new HtmlTextWriter(strWriter);

        gv.RenderControl(htw);

        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTarjetaCharlas.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{GridView}", strBuilder.ToString());
        body = body.Replace("{Nombre}", Nombre);
        body = body.Replace("{Caso}", Caso);
        body = body.Replace("{Centro}", Programa);
        body = body.Replace("{Evento}", Evento);


        return body;
    }
}