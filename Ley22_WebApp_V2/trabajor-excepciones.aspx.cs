﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

public partial class trabajor_excepciones : System.Web.UI.Page
{
    static string prevPage = String.Empty;
    ApplicationUser ExistingUser = new ApplicationUser();
    SEPSEntities1 dsPerfil = new SEPSEntities1();
    Ley22Entities dsLey22 = new Ley22Entities();
    static string userId = String.Empty;
    ApplicationDbContext context = new ApplicationDbContext();
    UserManager<ApplicationUser> userManager;

    protected void Page_Load(object sender, EventArgs e)
    {
        string alerta = "¿Está seguro que el participante asistió?";
        //ClientScript.RegisterOnSubmitStatement(this.GetType(), "confirm", "return confirm('" + alerta + "');");
        if (Session["User"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
            Session["MensajeError"] = "Por favor ingrese al sistema";
            Session["Redirect"] = "Account/Login.aspx";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }

        if (!Page.IsPostBack)
        {
            
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var usuarios_programas = new List<int>();
            
            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;
            prevPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

            var dia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            while (dia.DayOfWeek != DayOfWeek.Sunday)
            {
                dia = dia.AddDays(-1);
            }
            Session["FechaBase"] = new DateTime(dia.Year, dia.Month, dia.Day);

            if (userManager.IsInRole(userId, "SuperAdmin"))
            {
                 usuarios_programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Select(p => p.PK_Programa).ToList().Select<short,int>(i => i).ToList();                
            }
            else
            {
                usuarios_programas = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
            }

            if(!userManager.IsInRole(userId, "TrabajadorSocial"))
            {
                DivBtnModalAsignarCita.Visible = false;
            }
            else
            {
                DivBtnModalAsignarCita.Visible = true;
            }
            


            var programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Where(p => usuarios_programas.Contains(p.PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa.Replace("EVALUACIÓN ", "") }).ToList();
            if (usuarios_programas.Count() == 1)
            {
                DdlCentro.DataValueField = "Value";
                DdlCentro.DataTextField = "Text";
                DdlCentro.DataSource = programas;
                DdlCentro.DataBind();
                DdlCentro.SelectedValue = programas[0].Value;
                // DdlCentro.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
            else
            {
                DdlCentro.DataValueField = "Value";
                DdlCentro.DataTextField = "Text";
                DdlCentro.DataSource = programas;
                DdlCentro.DataBind();
                DdlCentro.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }

            LitNombre.Text = ExistingUser.FirstName + " " + ExistingUser.LastName;
            GenerarCalendario();
        }
    }

    void GenerarCalendario()
    {
        DateTime FechaBase = Convert.ToDateTime(Session["FechaBase"]);
        userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

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
        List<ListarCitasCalendarioUsuario_Result> ListarCharlasCalendario = null;
        List<ListarExcepcionesTrabajadorSocial_Result> ListarExcepcionesTrabajadorSocial = null;

        List<ListarCitasCalendarioAdministrador_Result> ListarCitasCalendarioAdministrador = null;
        List<ListarExcepcionesTrabajadorSocialAdmin_Result> ListarExcepcionesTrabajadorSocialAdmin = null;

        // if (DdlTrabajadorSocial.SelectedValue != "")
        using (Ley22Entities mylib = new Ley22Entities())
        {
            //ListarCharlasCalendario = mylib.ListarCitasCalendarioUsuario(ExistingUser.Id, FechaBase, FechaBase.AddDays(35)).ToList();
            if (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor"))
            {
                ListarCitasCalendarioAdministrador = mylib.ListarCitasCalendarioAdministrador(FechaBase, FechaBase.AddDays(35), Convert.ToInt32(DdlCentro.SelectedValue)).ToList();
                ListarExcepcionesTrabajadorSocialAdmin = mylib.ListarExcepcionesTrabajadorSocialAdmin(FechaBase, FechaBase.AddDays(35), Convert.ToInt32(DdlCentro.SelectedValue)).ToList();
            }
            else
            {
                ListarCharlasCalendario = mylib.ListarCitasCalendarioUsuario(userId, FechaBase, FechaBase.AddDays(35), Convert.ToInt32(DdlCentro.SelectedValue)).ToList();
                ListarExcepcionesTrabajadorSocial = mylib.ListarExcepcionesTrabajadorSocial(userId, FechaBase, FechaBase.AddDays(35), Convert.ToInt32(DdlCentro.SelectedValue)).ToList();
            }
        }

        for (int i = 0; i <= 34; i++)
        {
            DateTime fecha = FechaBase.AddDays(i);
            LitNumDia[i].Text = fecha.Day.ToString();
            LitContCelda[i].Text = "";

            if (fecha.ToShortDateString() == DateTime.Now.ToShortDateString())

                LitNumDia[i].Text = "<span class=\"dia actual\">" + fecha.Day.ToString() + "</span>";
           // if (DdlCentro.SelectedValue.ToString() != "")               
               
            if (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor"))
            {
                AsignarExcepcionesPorDiaAdmin(i, fecha, LitContCelda, ListarExcepcionesTrabajadorSocialAdmin);
                AsignatCitasPordiaAdministrador(i, fecha, LitContCelda, ListarCitasCalendarioAdministrador);
            }
            else
            {
                AsignarExcepcionesPorDia(i, fecha, LitContCelda, ListarExcepcionesTrabajadorSocial);
                AsignatCharlaPordia(i, fecha, LitContCelda, ListarCharlasCalendario);
            }
                      
            if (i.ToString() == "14")
                LiMesAno.Text = UppercaseFirst(fecha.ToString("MMMM")) + " " + fecha.Year.ToString();

        }

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


    void AsignatCharlaPordia(int i, DateTime Fecha, List<Literal> LitContCelda, List<ListarCitasCalendarioUsuario_Result> ListarCharlasCalendario)
    {

        List<ListarCitasCalendarioUsuario_Result> ListaCharlasXDia = null;
        try
        {
            ListaCharlasXDia = ListarCharlasCalendario.FindAll(delegate (ListarCitasCalendarioUsuario_Result bk)
            {
                return bk.FechaInicial.ToString("dd/MM/yyyy") == Fecha.ToString("dd/MM/yyyy");
            });

         //   LitContCelda[i].Text = "";

            foreach (ListarCitasCalendarioUsuario_Result element in ListaCharlasXDia)
            {
                var asistio = dsLey22.Calendarios.Where(u => u.Id_Calendario.Equals(element.Id_Calendario)).Single();
                string Desc = dsLey22.ControldePagoes.Where(u => u.FK_Calendario == element.Id_Calendario).Select(p => p.Descripcion).Single();

                var a = userManager.FindById(asistio.Id_TrabajadorSocial);
                var TS = a.FirstName + " " + a.LastName;

                bool activa = true;

                int caso = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal.Equals(asistio.Id_OrdenJudicial)).Select(r => r.Activa).Single();
                if(caso == 0)
                {
                    activa = false;
                }

                if (asistio.Asistio == 1)
                {
                    LitContCelda[i].Text += "<div class=\"" + "item ts-disponible\"" + "><a onClick=\"changeDivContentAsistio('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString()+ "', '" + element.NB_Programa + "', '" + TS + "','" + activa + "','" + asistio.Id_Participante + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asistio-cita" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                }
                else if (asistio.FechaFinal < DateTime.Today && asistio.Asistio == 0)
                {
                    LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "', '" + TS + "','" + activa + "','" + asistio.Id_Participante + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                }
                else
                {
                    LitContCelda[i].Text += "<div class=\"" + "item proceso\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() +  "', '" + element.NB_Programa + "', '" + TS + "','" + activa + "','" + asistio.Id_Participante + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                }
            }
            
        }
        catch (Exception ex)

        { }

    }

    void AsignatCitasPordiaAdministrador(int i, DateTime Fecha, List<Literal> LitContCelda, List<ListarCitasCalendarioAdministrador_Result> ListarCharlasCalendario)
    {

        List<ListarCitasCalendarioAdministrador_Result> ListaCharlasXDia = null;
        try
        {
            ListaCharlasXDia = ListarCharlasCalendario.FindAll(delegate (ListarCitasCalendarioAdministrador_Result bk)
            {
                return bk.FechaInicial.ToString("dd/MM/yyyy") == Fecha.ToString("dd/MM/yyyy");
            });

            //   LitContCelda[i].Text = "";

            foreach (ListarCitasCalendarioAdministrador_Result element in ListaCharlasXDia)
            {
                var asistio = dsLey22.Calendarios.Where(u => u.Id_Calendario.Equals(element.Id_Calendario)).Single();
                string Desc = dsLey22.ControldePagoes.Where(u => u.FK_Calendario == element.Id_Calendario).Select(p => p.Descripcion).Single();

                var a = userManager.FindById(asistio.Id_TrabajadorSocial);
                var TS = a.FirstName + " " + a.LastName;

                bool activa = false;

                int caso = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal.Equals(asistio.Id_OrdenJudicial)).Select(r => r.Activa).Single();
                if (caso == 1)
                {
                    activa = true;
                }

                if (asistio.Asistio == 1)
                {
                    LitContCelda[i].Text += "<div class=\"" + "item ts-disponible\"" + "><a onClick=\"changeDivContentAsistio('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "', '" + TS + "','" + activa + "','" + asistio.Id_Participante + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asistio-cita" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                }
                else if (asistio.FechaFinal < DateTime.Today && asistio.Asistio == 0)
                {
                    LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "', '" + TS + "','" + activa + "','" + asistio.Id_Participante + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                }
                else
                {
                    LitContCelda[i].Text += "<div class=\"" + "item proceso\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "', '" + TS + "','" + activa + "','" + asistio.Id_Participante + "', '" + Desc + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
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
                bool activa = true;

                DateTime Activa = Convert.ToDateTime(element.FechaFinal.ToString());
                TimeSpan ts = DateTime.Now.Subtract(Activa);

                if (ts.Days > 7)
                {
                    activa = false;
                }

                LitContCelda[i].Text += "<div class=\"" + "item tercera\"" + "><a onClick=\"changeDivContent2('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "', '" + element.Id_Excepciones.ToString() + "','" + activa + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-excepcion-confirmacion" + "\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
            }

        }
        catch (Exception ex)
        {

        }
    }

    void AsignarExcepcionesPorDiaAdmin(int i, DateTime Fecha, List<Literal> LitContCelda, List<ListarExcepcionesTrabajadorSocialAdmin_Result> ListarExcepcionesTrabajadorSocial)
    {
        List<ListarExcepcionesTrabajadorSocialAdmin_Result> ListaExcepcionesXDia = null;
        try
        {
            ListaExcepcionesXDia = ListarExcepcionesTrabajadorSocial.FindAll(delegate (ListarExcepcionesTrabajadorSocialAdmin_Result bk)
            {
                return bk.FechaInicial.ToString("dd/MM/yyyy") == Fecha.ToString("dd/MM/yyyy");
            });

            LitContCelda[i].Text = "";
           


            foreach (ListarExcepcionesTrabajadorSocialAdmin_Result element in ListaExcepcionesXDia)
            {
                LitContCelda[i].Text += "<div class=\"" + "item tercera\"" + "><a onClick=\"excepcionInfo('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + "', '" + element.NombreCompleto + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#excepciones-info" + "\" data-whatever=\"@getbootstrap\" style=\"color: white\">" + element.FechaInicial.ToString("hh:mm") + "-" + element.FechaFinal.ToString("hh:mm tt") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
            }

        }
        catch (Exception ex)
        {

        }
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

        DateComparisonResult comparison;

        comparison = (DateComparisonResult)Convert.ToDateTime(FechaInicial).CompareTo(DateTime.Now);

        if (comparison == DateComparisonResult.Later && Convert.ToDateTime(FechaInicial) < Convert.ToDateTime(FechaFinal))
        {

            using (Ley22Entities mylib = new Ley22Entities())
            {

                List<ListarCitasCalendarioUsuario_Result> myResult = mylib.ListarCitasCalendarioUsuario(userId, Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35), Convert.ToInt32(DdlCentro.SelectedValue)).ToList();
                List<ListarCitasCalendarioUsuario_Result> ListaCharlasXDia = myResult.FindAll(delegate (ListarCitasCalendarioUsuario_Result bk)
                {
                    return bk.FechaInicial == Convert.ToDateTime(FechaInicial);
                });

                if (ListaCharlasXDia.Count > 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('YA EXISTE UN CITA PARA ESTE MISMO DIA Y HORA!');", true);
                    string mensaje = "Ya existe una cita para esta fecha.";
                    ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "Cita Existente", "sweetAlert('Cita Existente','" + mensaje + "','error')", true);
                    return;
                }
                else
                {
                    mylib.GuardarExcepcionTrabajadorSocial(userId, Convert.ToDateTime(FechaInicial), Convert.ToDateTime(FechaFinal), Convert.ToInt32(DdlCentro.SelectedValue));

                    GenerarCalendario();
                }

            }
        }
        else if (Convert.ToDateTime(FechaInicial) > Convert.ToDateTime(FechaFinal))
        {
            //ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES DESPUES DE LA HORA FINAL!');", true);
            string mensaje = "La hora inicial insertada es despues de la hora final.";
            ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "Hora Incorrecta", "sweetAlert('Hora Incorrecta','" + mensaje + "','error')", true);
            return;
        }
        else if (Convert.ToDateTime(FechaInicial) == Convert.ToDateTime(FechaFinal))
        {
            //ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES IGUAL A LA HORA FINAL!');", true);
            string mensaje = "La hora inicial insertada es igual de la hora final.";
            ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "Hora Incorrecta", "sweetAlert('Hora Incorrecta','" + mensaje + "','error')", true);
            return;
        }

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

    protected void BtnELiminarCita_Click(object sender, EventArgs e)
    {

        using (Ley22Entities mylib = new Ley22Entities())
        {
            mylib.GuardarObservaciones(Convert.ToInt32(HNroCita.Value), textObservacion.InnerText);
            mylib.EliminarCitaTrabajadorSocial(Convert.ToInt32(HNroCita.Value));
        }
        GenerarCalendario();
    }

    protected void BtnAsistioCita_Click(object sender, EventArgs e)
    {
        //string alerta = "¿Está seguro que el participante asistió?";
        //ClientScript.RegisterOnSubmitStatement(this.GetType(), "confirm", "return confirm('" + alerta + "');");
        
        dsLey22.AsistioCitaTrabajadorSocial(Convert.ToInt32(HNroCita.Value));
        
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El participante cumplió con la cita.');", true);
        string mensaje = "El participante cumplió con la cita.";
        ClientScript.RegisterStartupScript(this.GetType(), "Cumplió", "sweetAlert('Cumplió','" + mensaje + "','success')", true);
        

        GenerarCalendario();
    }

    protected void BtnNoAsistioCita_Click(object sender, EventArgs e)
    {
        dsLey22.NoAsistioCitaTrabajadorSocial(Convert.ToInt32(HNroCita.Value));
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El participante NO cumplió con la cita.');", true);
        string mensaje = "El participante NO cumplió con la cita.";
        ClientScript.RegisterStartupScript(this.GetType(), "No Cumplió", "sweetAlert('No Cumplió','" + mensaje + "','error')", true);

        GenerarCalendario();
    }

    protected void BtnEliminarExcepcion_Click(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())
            mylib.EliminarExcepcionesTrabajadorSocial(Convert.ToInt32(HNroExcepcion.Value));
        
        GenerarCalendario();
    }

    protected void DdlCentro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DdlCentro.SelectedValue.ToString() == "0")
        {

        }
        GenerarCalendario();
    }

    protected void ExpedienteParticipante(object sender, EventArgs e)
    {

        int Id_Participante = Convert.ToInt32(HIdParticipante.Value);

        string expediente;

        using (SEPSEntities1 mlib = new SEPSEntities1())
        {

            short idPrograma = Convert.ToInt16(DdlCentro.SelectedValue.ToString());
            Session["Programa"] = DdlCentro.SelectedValue;
            Session["NombrePrograma"] = DdlCentro.SelectedItem.Text;

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
                FK_GrupoEtnico = Convert.ToInt32(sa_personas.FK_GrupoEtnico),
                FE_Edicion = Convert.ToDateTime(sa_personas.FE_Edicion),
                TI_Edicion = Convert.ToChar(sa_personas.TI_Edicion)

            };

            Session["Id_Participante"] = sa_persona.PK_Persona;
            Session["NombreParticipante"] = sa_persona.NB_Primero + " " + sa_persona.AP_Primero + " " + sa_persona.AP_Segundo;
            //Session["NombreParticipante2"] = 9;
            Session["SA_Persona"] = sa_persona;
            Session["Expediente"] = expediente;

            Response.Redirect("seleccion-proximo-paso.aspx", false);
        }
    }

}