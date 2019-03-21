using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

public partial class administrador_charlas_grupales : System.Web.UI.Page
{
    static string prevPage = String.Empty;
    SEPSEntities1 dsPerfil = new SEPSEntities1();
    ApplicationUser ExistingUser = new ApplicationUser();
    static string userId = String.Empty;
    Ley22Entities dsLey22 = new Ley22Entities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.UrlReferrer == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Info;
            Session["MensajeError"] = "Por favor ingrese al sistema";
            Response.Redirect("Account/Login.aspx", false);
            return;
        }
        

        if(!Page.IsPostBack)
        {
            if (Session["User"] == null)
            {
                Session["TipodeAlerta"] = ConstTipoAlerta.Info;
                Session["MensajeError"] = "Por favor ingrese al sistema";
                Response.Redirect("Account/Login.aspx", false);
                return;
            }
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var usuarios_programas = new List<int>();

            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;
            prevPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

            Session["FechaBase"] = new DateTime(2019, 02, 24);

            if (userManager.IsInRole(userId, "SuperAdmin"))
            {
                usuarios_programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Select(p => p.PK_Programa).ToList().Select<short, int>(i => i).ToList();                
            }
            else
            {
                usuarios_programas = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
            }

            var programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Where(p => usuarios_programas.Contains(p.PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

            if (usuarios_programas.Count() == 1)
            {
                DdlCentro.DataValueField = "Value";
                DdlCentro.DataTextField = "Text";
                DdlCentro.DataSource = programas;
                DdlCentro.DataBind();
                DdlCentro.SelectedValue = programas[0].Value;

                DivBtnModalAsignarCita.Disabled = false;
                DivBtnModalAsignarCita.Visible = true;
            }
            else
            {
                DdlCentro.DataValueField = "Value";
                DdlCentro.DataTextField = "Text";
                DdlCentro.DataSource = programas;
                DdlCentro.DataBind();
                DdlCentro.Items.Insert(0, new ListItem("-Seleccione-", "0"));

                DivBtnModalAsignarCita.Disabled = true;
                DivBtnModalAsignarCita.Visible = false;
            }

            GenerarCalendario();

            using (Ley22Entities mylib = new Ley22Entities())
            {
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

        if (Page.Request.Params["__EVENTTARGET"] == "EliminarParticipante")
        {
            EliminarParticipante(Convert.ToInt32(Request["__EVENTARGUMENT"]));
            return;
        }
        else if (Page.Request.Params["__EVENTTARGET"] == "AsistioParticipante")
        {
            AsistioParticipante(Convert.ToInt32(Request["__EVENTARGUMENT"]));
            return;
        }
        else if (Page.Request.Params["__EVENTTARGET"] == "NoAsistioParticipante")
        {
            NoAsistioParticipante(Convert.ToInt32(Request["__EVENTARGUMENT"]));
            return;
        }
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

        List<ListarCharlasCalendario_Result> ListarCharlasCalendario = null;
        List<ListarExcepcionesCharlaGrupal_Result> ListarExcepcionesCharlaGrupal = null;

        if (DdlCentro.SelectedValue != "0" && DdlCentro.SelectedValue != "")
        {
            using (Ley22Entities mylib = new Ley22Entities())
            {
                ListarCharlasCalendario = mylib.ListarCharlasCalendario(Convert.ToInt32(DdlCentro.SelectedValue), FechaBase, FechaBase.AddDays(35)).ToList();
                ListarExcepcionesCharlaGrupal = mylib.ListarExcepcionesCharlaGrupal(Convert.ToInt32(DdlCentro.SelectedValue), FechaBase, FechaBase.AddDays(35)).ToList();
            }
        }


        for (int i = 0; i <= 34; i++)
        {
            DateTime fecha = FechaBase.AddDays(i);
            LitNumDia[i].Text = fecha.Day.ToString();
            LitContCelda[i].Text = "";

            if (fecha.ToShortDateString() == DateTime.Now.ToShortDateString())
                LitNumDia[i].Text = "<span class=\"dia actual\">" + fecha.Day.ToString() + "</span>";

                AsignarExcepcionesPorDia(i, fecha, LitContCelda, ListarExcepcionesCharlaGrupal);
                AsignatCharlaPordia(i, fecha, LitContCelda, ListarCharlasCalendario);
                

            if (i.ToString() == "14")
                LiMesAno.Text = UppercaseFirst(fecha.ToString("MMMM")) + " " + fecha.Year.ToString();

        }

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
                using (Ley22Entities mylib = new Ley22Entities())

                {
                    List<ListarParticipantesPorCharlas_Result> resulParaticipalntes = mylib.ListarParticipantesPorCharlas(element.Id_CharlaGrupal).ToList();
                    List<InfoCharlaGrupal_Result> resultCharla = mylib.InfoCharlaGrupal(element.Id_CharlaGrupal).ToList();
                    var diaActual = mylib.CharlaGrupals.Where(u => u.Id_CharlaGrupal.Equals(element.Id_CharlaGrupal)).Single();

                    //if (diaActual.FechaFinal > DateTime.Today)
                    //{
                        if (resulParaticipalntes.Count > element.NrodeParticipantes || resulParaticipalntes.Count == element.NrodeParticipantes)
                        {
                            LitContCelda[i].Text += " <div class=\"item nohay\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "'); modalModificar('" + resultCharla[0].FechaInicial.ToString("MM/dd/yyyy") + "','" + resultCharla[0].FechaInicial.ToString("HH:mm tt") + "','" + resultCharla[0].FechaFinal.ToString("HH:mm tt") + "','"+ resultCharla[0].Id_TipoCharla.ToString() + "','"+ resultCharla[0].Id_NiveldeCharla.ToString() + "','"+ resultCharla[0].NrodeParticipantes.ToString() + "','"+ resultCharla[0].NumeroCharla.ToString() + "')\"   data-toggle=\"modal\" data-target=\"#modal-Info-Charla\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if(diaActual.NumeroCharla == 1)
                        {
                            LitContCelda[i].Text += " <div class=\"item primera\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "'); modalModificar('" + resultCharla[0].FechaInicial.ToString("MM/dd/yyyy") + "','" + resultCharla[0].FechaInicial.ToString("HH:mm tt") + "','" + resultCharla[0].FechaFinal.ToString("HH:mm tt") + "','" + resultCharla[0].Id_TipoCharla.ToString() + "','" + resultCharla[0].Id_NiveldeCharla.ToString() + "','" + resultCharla[0].NrodeParticipantes.ToString() + "','" + resultCharla[0].NumeroCharla.ToString() + "')\"  data-toggle=\"modal\" data-target=\"#modal-Info-Charla\" data-whatever=\"@getbootstrap\" style=\"color: black\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (diaActual.NumeroCharla == 2)
                        {
                            LitContCelda[i].Text += " <div class=\"item segunda\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "'); modalModificar('" + resultCharla[0].FechaInicial.ToString("MM/dd/yyyy") + "','" + resultCharla[0].FechaInicial.ToString("HH:mm tt") + "','" + resultCharla[0].FechaFinal.ToString("HH:mm tt") + "','" + resultCharla[0].Id_TipoCharla.ToString() + "','" + resultCharla[0].Id_NiveldeCharla.ToString() + "','" + resultCharla[0].NrodeParticipantes.ToString() + "','" + resultCharla[0].NumeroCharla.ToString() + "')\"  data-toggle=\"modal\" data-target=\"#modal-Info-Charla\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (diaActual.NumeroCharla == 3)
                        {
                            LitContCelda[i].Text += " <div class=\"item tercera\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "'); modalModificar('" + resultCharla[0].FechaInicial.ToString("MM/dd/yyyy") + "','" + resultCharla[0].FechaInicial.ToString("HH:mm tt") + "','" + resultCharla[0].FechaFinal.ToString("HH:mm tt") + "','" + resultCharla[0].Id_TipoCharla.ToString() + "','" + resultCharla[0].Id_NiveldeCharla.ToString() + "','" + resultCharla[0].NrodeParticipantes.ToString() + "','" + resultCharla[0].NumeroCharla.ToString() + "')\"  data-toggle=\"modal\" data-target=\"#modal-Info-Charla\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (diaActual.NumeroCharla == 4)
                        {
                            LitContCelda[i].Text += " <div class=\"item cuarta\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "'); modalModificar('" + resultCharla[0].FechaInicial.ToString("MM/dd/yyyy") + "','" + resultCharla[0].FechaInicial.ToString("HH:mm tt") + "','" + resultCharla[0].FechaFinal.ToString("HH:mm tt") + "','" + resultCharla[0].Id_TipoCharla.ToString() + "','" + resultCharla[0].Id_NiveldeCharla.ToString() + "','" + resultCharla[0].NrodeParticipantes.ToString() + "','" + resultCharla[0].NumeroCharla.ToString() + "')\"  data-toggle=\"modal\" data-target=\"#modal-Info-Charla\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                        }
                        else if (diaActual.NumeroCharla == 5)
                        {
                            LitContCelda[i].Text += " <div class=\"item quinta\"><a href='#'  onClick=\"changeDivContent('" + element.Id_CharlaGrupal.ToString() + "'); modalModificar('" + resultCharla[0].FechaInicial.ToString("MM/dd/yyyy") + "','" + resultCharla[0].FechaInicial.ToString("HH:mm tt") + "','" + resultCharla[0].FechaFinal.ToString("HH:mm tt") + "','" + resultCharla[0].Id_TipoCharla.ToString() + "','" + resultCharla[0].Id_NiveldeCharla.ToString() + "','" + resultCharla[0].NrodeParticipantes.ToString() + "','" + resultCharla[0].NumeroCharla.ToString() + "')\"  data-toggle=\"modal\" data-target=\"#modal-Info-Charla\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                        }
                    //}
                    //else
                    //{
                    //    LitContCelda[i].Text += " <div class=\"item nohay\"><a href='#'  onClick='changeDivContent(" + element.Id_CharlaGrupal.ToString() + ")'   data-toggle=\"modal\" data-target=\"#modal-Info-Charla\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + " " + element.TipodeCharla + "</a></div>";
                    //}

                }
            }

        }
        catch (Exception ex)

        { }

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

    protected enum DateComparisonResult
    {
        Earlier = -1,
        Later = 1,
        TheSame = 0
    };

    //protected void BtnAsignarExcepcion_Click(object sender, EventArgs e)
    //{
    //    string FechaInicial = TxtFecha.Text + " " + TxtHoraInicial.Text;
    //    string FechaFinal = TxtFecha.Text + " " + TxtHoraFinal.Text;

    //    DateComparisonResult comparison;

    //    comparison = (DateComparisonResult)Convert.ToDateTime(FechaInicial).CompareTo(DateTime.Now);

    //    if (comparison == DateComparisonResult.Later && Convert.ToDateTime(FechaInicial) < Convert.ToDateTime(FechaFinal))
    //    {

    //        using (Ley22Entities mylib = new Ley22Entities())
    //        {

    //            List<ListarCharlasCalendario_Result> myResult = mylib.ListarCharlasCalendario(17, Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35)).ToList();
    //            List<ListarCharlasCalendario_Result> ListaCharlasXDia = myResult.FindAll(delegate (ListarCharlasCalendario_Result bk)
    //            {
    //                return bk.FechaInicial == Convert.ToDateTime(FechaInicial);
    //            });

    //            if (ListaCharlasXDia.Count > 0)
    //            {
    //                ScriptManager.RegisterClientScriptBlock(BtnAsignarExcepcion, BtnAsignarExcepcion.GetType(), "checkTime", "alert('YA EXISTE UNA CHARLA PARA ESTE MISMO DIA Y HORA!');", true);
    //                return;
    //            }
    //            else
    //            {
    //                mylib.GuardarExcepcionCoordinadorCharlasGrupales(17, Convert.ToDateTime(FechaInicial), Convert.ToDateTime(FechaFinal));

    //                GenerarCalendario();
    //            }

    //        }
    //    }
    //    else if (Convert.ToDateTime(FechaInicial) > Convert.ToDateTime(FechaFinal))
    //    {
    //        ScriptManager.RegisterClientScriptBlock(BtnAsignarExcepcion, BtnAsignarExcepcion.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES DESPUES DE LA HORA FINAL!');", true);
    //        return;
    //    }
    //    else if (Convert.ToDateTime(FechaInicial) == Convert.ToDateTime(FechaFinal))
    //    {
    //        ScriptManager.RegisterClientScriptBlock(BtnAsignarExcepcion, BtnAsignarExcepcion.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES IGUAL A LA HORA FINAL!');", true);
    //        return;
    //    }

    //}

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
                                        Convert.ToDateTime(TxtFechaModCharla.Text + " " + TxtIncialModCharla.Text),
                                        Convert.ToDateTime(TxtFechaModCharla.Text + " " + TxtFinalModCharla.Text),
                                        Convert.ToInt32(DdlTipodeCharla2.SelectedValue),
                                        Convert.ToInt32(DdlNivelCharlas2.SelectedValue),
                                        Convert.ToInt32(TxtMaxCantParticipantes2.Text),
                                        userId,
                                        Convert.ToInt32(DdlNumeroCharla2.SelectedIndex)

               );
        }
        GenerarCalendario();


    }

    protected void BtnELiminarCita_Click(object sender, EventArgs e)
    {
        
    }

    protected void BtnEliminarCharla_Click(object sender, EventArgs e)
    {
        string val = H_Id_CharlaGrupal.Value;
        int Id_CharlaGrupal = Convert.ToInt32(val);

        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.EliminarCharlaGrupal(Convert.ToInt32(Id_CharlaGrupal));
        }
        GenerarCalendario();
    }

    protected void BtnEliminarExcepcion_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnGuardarCharla_Click(object sender, EventArgs e)
    {


        using (Ley22Entities mylib = new Ley22Entities())
        {

            mylib.GuardarCharlaGrupal(Convert.ToInt32(DdlCentro.SelectedValue),
                                        Convert.ToDateTime(TxtFechaCrearCharla.Text + " " + TxtInicialCrearCharla.Text),
                                        Convert.ToDateTime(TxtFechaCrearCharla.Text + " " + TxtFinalCrearCharla.Text),
                                        Convert.ToInt32(DdlTipodeCharla.SelectedValue),
                                        Convert.ToInt32(DdlNivelCharlas.SelectedValue),
                                        Convert.ToInt32(TxtMaxCantParticipantes.Text),
                                        userId,
                                        Convert.ToInt32(DdlNumeroCharla.SelectedIndex)

               );
        }
        GenerarCalendario();

    }
    protected void DdlCentro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlCentro.SelectedValue.ToString() == "0")
        {
            DivBtnModalAsignarCita.Disabled = true;
            DivBtnModalAsignarCita.Visible = false;
        }
        else
        {
            DivBtnModalAsignarCita.Disabled = false;
            DivBtnModalAsignarCita.Visible = true;
        }
        GenerarCalendario();
    }

    void EliminarParticipante(int Id_Participante)
    {
        //int Id_Participante = Convert.ToInt32(Request["__EVENTARGUMENT"]);

        using (Ley22Entities mylib = new Ley22Entities())
            mylib.EliminarParticipanteCharlaGrupal(Convert.ToInt32(Id_CharlaGrupal.Value), Id_Participante);
        GenerarCalendario();

    }

    void AsistioParticipante(int Id_ParticipantePorCharlaGrupal)
    {
        dsLey22.AsistioCharla(Id_ParticipantePorCharlaGrupal);
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El participante cumplió con la charla.');", true);
        GenerarCalendario();
    }

    void NoAsistioParticipante(int Id_ParticipantePorCharlaGrupal)
    {
        dsLey22.NoAsistioCharla(Id_ParticipantePorCharlaGrupal);
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El participante NO cumplió con la charla.');", true);
        GenerarCalendario();
    }


}