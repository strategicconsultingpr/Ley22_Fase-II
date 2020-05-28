using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

public partial class asignar_citas_individual : System.Web.UI.Page
{
   
    static string prevPage = String.Empty;
    ApplicationDbContext context = new ApplicationDbContext();
    SEPSEntities1 dsPerfil = new SEPSEntities1();
    Ley22Entities dsley22 = new Ley22Entities();
    ApplicationUser ExistingUser = new ApplicationUser();
    static string userId = String.Empty;
    //DataParticipante du;
    protected Data_SA_Persona du;

    protected void Page_Load(object sender, EventArgs e)
    {

        // valida que se haya buscado el usuario
        // -----------------------------------------------------------------------------
        
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
            prevPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            
            du = (Data_SA_Persona)Session["SA_Persona"];


            var dia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            while (dia.DayOfWeek != DayOfWeek.Sunday)
            {
                dia = dia.AddDays(-1);
            }
            Session["FechaBase"] = new DateTime(dia.Year, dia.Month, dia.Day);

            GenerarCalendario();


            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var usuarios_programas = new List<int>();


            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;
            prevPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

            short PK_Programa = Convert.ToInt16(Session["Programa"]);
            var programas = dsPerfil.SA_PROGRAMA.Where(a => a.PK_Programa.Equals(PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa.Replace("EVALUACIÓN ", "") }).ToList();


            DdlCentro.DataValueField = "Value";
            DdlCentro.DataTextField = "Text";
            DdlCentro.DataSource = programas;
            DdlCentro.DataBind();
            DdlCentro.SelectedValue = Session["Programa"].ToString();
            //DdlCentro.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            using (Ley22Entities mylib = new Ley22Entities())
            {
                var evaluadores = mylib.SP_READ_ListaDeEvaluadores(Convert.ToInt32(Session["Programa"])).DefaultIfEmpty().ToList();

                DdlTrabajadorSocial.DataTextField = "Nombre";
                DdlTrabajadorSocial.DataValueField = "Id";
                DdlTrabajadorSocial.DataSource = evaluadores;
                DdlTrabajadorSocial.DataBind();
                DdlTrabajadorSocial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            }



            CargarOrdenesJudiciales();
            verificarCitas();

            if(prevPage != "nuevo-confirmacion.aspx")
            {
                Hyperlink.Visible = false;
            }
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

        // se obtienen ls charlas del calendario para la fecha
        List<ListarCitasCalendario_Result> ListarCharlasCalendario = null;
        List<ListarExcepcionesTrabajadorSocial_Result> ListarExcepcionesTrabajadorSocial = null;

        if (DdlTrabajadorSocial.SelectedValue != "")
            using (Ley22Entities mylib = new Ley22Entities())
            {
                ListarCharlasCalendario = mylib.ListarCitasCalendario(DdlTrabajadorSocial.SelectedValue, FechaBase, FechaBase.AddDays(35)).ToList();
                ListarExcepcionesTrabajadorSocial = mylib.ListarExcepcionesTrabajadorSocial(DdlTrabajadorSocial.SelectedValue, FechaBase, FechaBase.AddDays(35), Convert.ToInt32(Session["Programa"])).ToList();
            }
        

        for (int i = 0; i <= 34; i++)
        {
            DateTime fecha = FechaBase.AddDays(i);
            LitNumDia[i].Text = fecha.Day.ToString();
            LitContCelda[i].Text = "";

            if (fecha.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                LitNumDia[i].Text = "<span class=\"dia actual\">" + fecha.Day.ToString() + "</span>";
            }

            if (DdlTrabajadorSocial.SelectedValue != "")
            {
                AsignarExcepcionesPorDia(i, fecha, LitContCelda, ListarExcepcionesTrabajadorSocial);
                AsignatCharlaPordia(i, fecha, LitContCelda, ListarCharlasCalendario);
            }

            if (i.ToString() == "14")
            {
                LiMesAno.Text = UppercaseFirst(fecha.ToString("MMMM")) + " " + fecha.Year.ToString();
            }

        }

    }

    void CargarOrdenesJudiciales()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            //DdlNumeroOrdenJudicial.DataTextField = "NumeroOrdenJudicial";
            //DdlNumeroOrdenJudicial.DataValueField = "Id_OrdenJudicial";
            //DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"] ), Convert.ToInt32(Session["Programa"]));
            //DdlNumeroOrdenJudicial.DataBind();
            //DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            DdlNumeroOrdenJudicial.DataTextField = "NumeroCasoCriminal";
            DdlNumeroOrdenJudicial.DataValueField = "Id_CasoCriminal";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarCasosCriminalesActivos(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
            DdlNumeroOrdenJudicial.DataBind();
            DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }

        int Cant = DdlNumeroOrdenJudicial.Items.Count-1;
        Utilitarios.NumLetra lib = new Utilitarios.NumLetra();

        //DdlRegion.Enabled = false;
        DdlCentro.Enabled = false;
        DdlTrabajadorSocial.Enabled = false;

        LitCantidadOrdenesJudiciales.Text = lib.Convertir(Cant.ToString(), false).Replace("00","") + " (" + Cant.ToString()+")";
    }

    protected void DdlNumeroOrdenJudicial_Selected(object sender, EventArgs e)
    {
        du = (Data_SA_Persona)Session["SA_Persona"];
        int PK_Programa = Convert.ToInt32(Session["Programa"]);

        if (DdlNumeroOrdenJudicial.SelectedValue == "0")
        {

            
            //DdlCentro.Enabled = false;
            DdlTrabajadorSocial.Enabled = false;

            if (DdlTrabajadorSocial.Items.FindByValue("0") != null)
            {
                DdlTrabajadorSocial.SelectedIndex = 0;
            }
        }
        else
        {
            List<ListItem> tipo;
            int Caso = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
            var Citas = dsley22.Calendarios.Where(a => a.Id_Participante.Equals(du.PK_Persona)).Where(b => b.Id_OrdenJudicial == Caso)
                .Where(f => f.Id_Programa == PK_Programa).Where(c => c.Activo.Equals(1)).Where(d => d.Asistio.Equals(1)).Count();

            if(Citas == 0)
            {
                tipo = dsley22.Precios.Where(a => a.Descripcion.Contains("Cita")).Where(o => !o.Descripcion.Contains("Ubicacion")).Select(r => new ListItem { Value = r.Id_Precio.ToString(), Text = r.Descripcion }).ToList();
            }
            else
            {
                tipo = dsley22.Precios.Where(a => a.Descripcion.Contains("Cita Ubicacion")).Select(r => new ListItem { Value = r.Id_Precio.ToString(), Text = r.Descripcion }).ToList();
            }
           
                

            DdlTipo.DataValueField = "Value";
            DdlTipo.DataTextField = "Text";
            DdlTipo.DataSource = tipo;
            DdlTipo.DataBind();
            DdlTipo.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            //DdlCentro.Enabled = true;
            DdlTrabajadorSocial.Enabled = true;
           
            if(DdlTrabajadorSocial.Items.FindByValue("0") != null)
            {
                DdlTrabajadorSocial.SelectedIndex = 0;
            }
        }
        GenerarCalendario();
    }

    void AsignatCharlaPordia(int i, DateTime Fecha, List<Literal> LitContCelda, List<ListarCitasCalendario_Result> ListarCitasCalendario)
    {

        List<ListarCitasCalendario_Result> ListaCitasXDia = null;
        try
        {
            ListaCitasXDia = ListarCitasCalendario.FindAll(delegate (ListarCitasCalendario_Result bk)
            {
                return bk.FechaInicial.ToString("dd/MM/yyyy") == Fecha.ToString("dd/MM/yyyy");
            });


            du = (Data_SA_Persona)Session["SA_Persona"];

            foreach (ListarCitasCalendario_Result element in ListaCitasXDia)
            {            
                var asistio = dsley22.Calendarios.Where(u => u.Id_Calendario.Equals(element.Id_Calendario)).Single();
                string Desc = dsley22.ControldePagoes.Where(u => u.FK_Calendario == element.Id_Calendario).Select(a => a.Descripcion).Single();
                if (asistio.Activo == 1)
                {
                    bool eliminar = false;
                    

                    if (asistio.Id_Participante == du.PK_Persona)
                    {
                        eliminar = true;
                    }

                    if (asistio.Asistio == 1)
                    {
                        LitContCelda[i].Text += "<div class=\"" + "item ts-disponible\"" + "><a onClick=\"changeDivContentAsistio('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "', '" + eliminar + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asistio-cita" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";

                    }
                    else if (asistio.FechaFinal < DateTime.Today && asistio.Asistio == 0)
                    {
                        LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "', '" + eliminar + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                    }
                    else
                    {
                        LitContCelda[i].Text += "<div class=\"" + "item proceso\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "', '" + eliminar + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";

                    }
                }
            }
        }
        catch (Exception ex)

        { }

    }

    void AsignarExcepcionesPorDia(int i, DateTime Fecha, List<Literal> LitContCelda, List<ListarExcepcionesTrabajadorSocial_Result> ListarExcepcionesTrabajadorSocial)
    {
        List<ListarExcepcionesTrabajadorSocial_Result> ListaExcepcionesXDia = null;
        try
        {
            ListaExcepcionesXDia = ListarExcepcionesTrabajadorSocial.FindAll(delegate (ListarExcepcionesTrabajadorSocial_Result bk)
            {
                return bk.FechaInicial.ToString("dd/MM/yyyy") == Fecha.ToString("dd/MM/yyyy");
            });

            LitContCelda[i].Text = "";

            foreach (ListarExcepcionesTrabajadorSocial_Result element in ListaExcepcionesXDia)
            {
                LitContCelda[i].Text += "<div class=\"" + "item tercera\"" + "><a onClick=\"changeDivContent2('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm tt") + "-" + element.FechaFinal.ToString("hh:mm tt") + "', '" + element.Id_Excepciones.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-excepcion-confirmacion" + "\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
            }

        }
        catch (Exception ex)
        {

        }
    }


    protected void DdlTrabajadorSocial_SelectedIndexChanged(object sender, EventArgs e)
    {

        GenerarCalendario();
        DivBtnModalAsignarCita.Visible = true;
        TxtHoraFinal.Text = "";
        TxtHoraInicial.Text = "";
        TxtFecha.Text = "";
        TxtNumeroOrdenJudicial.Text = "";
    }

    /// <summary>
    /// Returns the input string with the first character converted to uppercase
    /// </summary>
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

    protected void BtnHoy_Click(object sender, EventArgs e)
    {

        var dia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        while (dia.DayOfWeek != DayOfWeek.Sunday)
        {
            dia = dia.AddDays(-1);
        }
        Session["FechaBase"] = new DateTime(dia.Year, dia.Month, dia.Day);
        GenerarCalendario();
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


    protected void btnAsignarCita_Click(object sender, EventArgs e)
    {
        string FechaInicial = TxtFecha.Text + " " + TxtHoraInicial.Text;
        string FechaFinal = TxtFecha.Text + " " + TxtHoraFinal.Text;

        //du = (DataParticipante)Session["DataParticipante"];
        du = (Data_SA_Persona)Session["SA_Persona"];
        int centro = Convert.ToInt32(DdlCentro.SelectedValue);

        int Caso = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
        var Citas = dsley22.Calendarios.Where(a => a.Id_Participante.Equals(du.PK_Persona)).Where(b => b.Id_OrdenJudicial == Caso)
            .Where(f => f.Id_Programa == centro).Where(c => c.Activo.Equals(1)).Where(d => d.Asistio.Equals(1)).Count();

        if (Citas > 1)
        {
            string mensaje = "El participante ya asistió a dos(2) citas de evaluación ó ubicación.";
            ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "No Disponible", "sweetAlert('No Disponible','" + mensaje + "','error')", true);

            TxtHoraFinal.Text = "";
            TxtHoraInicial.Text = "";
            TxtFecha.Text = "";
            return;
        }
        else
        {

            DateComparisonResult comparison;

            comparison = (DateComparisonResult)Convert.ToDateTime(FechaInicial).CompareTo(DateTime.Now);
            //comparison == DateComparisonResult.Later &&
            if ( Convert.ToDateTime(FechaInicial) < Convert.ToDateTime(FechaFinal))
            {

                using (Ley22Entities mylib = new Ley22Entities())
                {

                    List<ListarCitasCalendario_Result> myResult = mylib.ListarCitasCalendario(DdlTrabajadorSocial.SelectedValue, Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35)).ToList();
                    var filtro = myResult.Select(u => u.Id_Calendario).ToList();
                    var filtro2 = mylib.Calendarios.Where(u => filtro.Contains(u.Id_Calendario) && u.Activo.Equals(1)).Select(p => p.Id_Calendario).ToList();
                    List<ListarCitasCalendario_Result> myResultFiltro = myResult.Where(u => filtro2.Contains(u.Id_Calendario)).ToList();


                    List<ListarCitasCalendario_Result> ListaCharlasXDia = myResultFiltro.FindAll(delegate (ListarCitasCalendario_Result bk)
                    {
                        return bk.FechaInicial == Convert.ToDateTime(FechaInicial);
                    });

                    List<ListarExcepcionesTrabajadorSocial_Result> myResult2 = mylib.ListarExcepcionesTrabajadorSocial(DdlTrabajadorSocial.SelectedValue, Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35), Convert.ToInt32(Session["Programa"])).ToList();
                    List<ListarExcepcionesTrabajadorSocial_Result> ListaExcepcionesXDia = myResult2.FindAll(delegate (ListarExcepcionesTrabajadorSocial_Result bk)
                    {
                        return (bk.FechaInicial == Convert.ToDateTime(FechaInicial) || bk.FechaFinal == Convert.ToDateTime(FechaFinal) || (bk.FechaInicial <= Convert.ToDateTime(FechaInicial) && bk.FechaFinal >= Convert.ToDateTime(FechaFinal)));
                    });

                    if (ListaCharlasXDia.Count > 0)
                    {
                        //ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('YA EXISTE UN CITA PARA ESTE MISMO DIA Y HORA!');", true);
                        string mensaje = "El trabajador social " + DdlTrabajadorSocial.SelectedItem.Text + " tiene una cita para esta misma fecha.";
                        ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "Cita Exisitente", "sweetAlert('Cita Exisitente','" + mensaje + "','error')", true);

                        TxtHoraFinal.Text = "";
                        TxtHoraInicial.Text = "";
                        TxtFecha.Text = "";
                        return;
                    }

                    else if (ListaExcepcionesXDia.Count > 0)
                    {
                        //ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('TRABAJADOR SOCIAL NO ESTARA DISPONIBLE A ESTA HORA!');", true);
                        string mensaje = "El trabajador social " + DdlTrabajadorSocial.SelectedItem.Text + " no disponible para esta fecha.";
                        ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "No Disponible", "sweetAlert('No Disponible','" + mensaje + "','error')", true);

                        TxtHoraFinal.Text = "";
                        TxtHoraInicial.Text = "";
                        TxtFecha.Text = "";
                        return;
                    }

                    else
                    {
                        try
                        {
                            mylib.GuardarCitaTrabajadorSocial(DdlTrabajadorSocial.SelectedValue, Convert.ToInt32(Session["Id_Participante"]), Convert.ToDateTime(FechaInicial), Convert.ToDateTime(FechaFinal), Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue), Convert.ToInt32(DdlCentro.SelectedValue), userId, Convert.ToInt32(DdlTipo.SelectedValue));

                            string mensaje = "La cita fue creada correctamente.";
                            ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "Cita Creada", "sweetAlert('Cita Creada','" + mensaje + "','success')", true);

                            int casoCriminal = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
                            var email = dsley22.CasoCriminals.Where(p => p.Id_CasoCriminal.Equals(casoCriminal)).Select(a => a.Email).SingleOrDefault();

                            if (email.Count() > 0)
                            {
                                EmailService mail = new EmailService();
                                string body = string.Empty;

                                if (DdlTipo.SelectedItem.Text.Contains("Ubicacion"))
                                {
                                    body = CreateBodyUbicacion(du.NB_Primero, du.AP_Primero, FechaInicial + " - " + TxtHoraFinal.Text, DdlTrabajadorSocial.SelectedItem.Text, DdlCentro.SelectedItem.Text);
                                    mail.SendAsyncCita(email, "Cita para Ubicación", body);
                                }
                                else
                                {
                                    body = CreateBodySentencia(du.NB_Primero, du.AP_Primero, FechaInicial + " - " + TxtHoraFinal.Text, DdlTrabajadorSocial.SelectedItem.Text, DdlCentro.SelectedItem.Text);
                                    mail.SendAsyncCita(email, "Cita Entrevista Inicial", body);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        DdlTrabajadorSocial_SelectedIndexChanged(null, null);
                        verificarCitas();
                        GenerarCalendario();
                    }
                }
            }
            else if (Convert.ToDateTime(FechaInicial) > Convert.ToDateTime(FechaFinal))
            {
                //ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES DESPUES DE LA HORA FINAL!');", true);
                string mensaje = "Hora inicial insertada es despues de la hora final.";
                ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "Error", "sweetAlert('Error','" + mensaje + "','error')", true);
                return;
            }
            else if (Convert.ToDateTime(FechaInicial) == Convert.ToDateTime(FechaFinal))
            {
                //ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES IGUAL A LA HORA FINAL!');", true);
                string mensaje = "Hora inicial insertada es igual a la hora final.";
                ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "Error", "sweetAlert('Error','" + mensaje + "','error')", true);
                return;
            }
        }
    }

  
    protected void LnkDia_Click(object sender, EventArgs e)
    {
 


    }

   
    protected void BtnGuardarOrdenJudicial_Click(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())
             mylib.GuardarOrdenJudicial(Convert.ToInt32(Session["Id_Participante"]), TxtNumeroOrdenJudicial.Text, Convert.ToInt32(Session["Id_UsuarioApp"]), Convert.ToInt32(Session["Programa"]));
 
        CargarOrdenesJudiciales();
    }

    void verificarCitas( )
    {
       int  Pk_Persona = Convert.ToInt32(Session["Id_Participante"]);

        using (Ley22Entities mylib = new Ley22Entities())
        {
            List<Sp_Read_CalendariobyId_Result> myresul = mylib.Sp_Read_CalendariobyId(Pk_Persona).ToList();

            GVListadeCitas.DataSource = myresul;
            GVListadeCitas.DataBind();

            var ListaCitasXDia = myresul.FindAll(delegate (Sp_Read_CalendariobyId_Result bk)
            {
                return bk.Asistio == 1;
            });


            int TotaldeCitas = myresul.Count();
            int TotalAsistencias = ListaCitasXDia.Count();
            HLCitas.Text = TotaldeCitas.ToString() + " Citas: " + TotalAsistencias.ToString() + " Asistencias, " + (TotaldeCitas - TotalAsistencias).ToString() + " Inasistencias.";
            LitResumenCitas.Text = TotaldeCitas.ToString() + " Citas: " + TotalAsistencias.ToString() + " Asistencias, " + (TotaldeCitas - TotalAsistencias).ToString() + " Inasistencias.";
        }

    }


    protected void BtnELiminarCita_Click(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.GuardarObservaciones(Convert.ToInt32(HNroCita.Value), textObservacion.InnerText);
            mylib.EliminarCitaTrabajadorSocial(Convert.ToInt32(HNroCita.Value));
        }

        textObservacion.InnerText = "";
        verificarCitas();
        GenerarCalendario();
    }

    protected void BtnDocumentos_Click(object sender, EventArgs e)
    {
        Response.Redirect("imprimir-documentos.aspx", false);
    }

    private string CreateBodySentencia(string FirstName, string LastName, string FechaCita, string TrabajadorSocial, string Programa)
    {
        string body = string.Empty;
       
        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailCitaParticipante.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{NombreCompleto}", FirstName + " " + LastName);
        body = body.Replace("{FechaCitaHeader}", FechaCita);
        body = body.Replace("{FechaCita}", FechaCita);
        body = body.Replace("{TrabajadorSocial}", TrabajadorSocial);
        body = body.Replace("{Programa}", Programa);

        return body;

    }

    private string CreateBodyUbicacion(string FirstName, string LastName, string FechaCita, string TrabajadorSocial, string Programa)
    {
        string body = string.Empty;

        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailCitaUbicacion.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{NombreCompleto}", FirstName + " " + LastName);
        body = body.Replace("{FechaCitaHeader}", FechaCita);
        body = body.Replace("{FechaCita}", FechaCita);
        body = body.Replace("{TrabajadorSocial}", TrabajadorSocial);
        body = body.Replace("{Programa}", Programa);

        return body;

    }

}