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

public partial class trabajor_excepciones : System.Web.UI.Page
{
    static string prevPage = String.Empty;
    ApplicationUser ExistingUser = new ApplicationUser();
    SEPSEntities1 dsPerfil = new SEPSEntities1();
    Ley22Entities dsLey22 = new Ley22Entities();
    static string userId = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Info;
            Session["MensajeError"] = "Por favor ingrese al sistema";
            Response.Redirect("../Account/Login.aspx", false);
            return;
        }

        if (!Page.IsPostBack)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var usuarios_programas = new List<int>();

            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;
            prevPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            Session["FechaBase"] = new DateTime(2019, 01, 27);

            if(userManager.IsInRole(userId, "SuperAdmin"))
            {
                 usuarios_programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Select(p => p.PK_Programa).ToList().Select<short,int>(i => i).ToList();
                
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

            LitNombre.Text = ExistingUser.Email;
            GenerarCalendario();
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
        List<ListarCitasCalendarioUsuario_Result> ListarCharlasCalendario = null;
        List<ListarExcepcionesTrabajadorSocial_Result> ListarExcepcionesTrabajadorSocial = null;

        // if (DdlTrabajadorSocial.SelectedValue != "")
        using (Ley22Entities mylib = new Ley22Entities())
        {
            //ListarCharlasCalendario = mylib.ListarCitasCalendarioUsuario(ExistingUser.Id, FechaBase, FechaBase.AddDays(35)).ToList();
            ListarCharlasCalendario = mylib.ListarCitasCalendarioUsuario(userId, FechaBase, FechaBase.AddDays(35),Convert.ToInt32(DdlCentro.SelectedValue)).ToList();
            ListarExcepcionesTrabajadorSocial = mylib.ListarExcepcionesTrabajadorSocial(userId, FechaBase, FechaBase.AddDays(35)).ToList();

        }

        for (int i = 0; i <= 34; i++)
        {
            DateTime fecha = FechaBase.AddDays(i);
            LitNumDia[i].Text = fecha.Day.ToString();
            LitContCelda[i].Text = "";

            if (fecha.ToShortDateString() == DateTime.Now.ToShortDateString())

                LitNumDia[i].Text = "<span class=\"dia actual\">" + fecha.Day.ToString() + "</span>";
           // if (DdlCentro.SelectedValue.ToString() != "")               
                AsignarExcepcionesPorDia(i, fecha, LitContCelda, ListarExcepcionesTrabajadorSocial);
                AsignatCharlaPordia(i, fecha, LitContCelda, ListarCharlasCalendario);
                      
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
                if (asistio.Asistio == 1)
                {
                    LitContCelda[i].Text += "<div class=\"" + "item ts-disponible\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                }
                else if (asistio.FechaFinal.Hour < DateTime.Today.Hour && asistio.Asistio == 0)
                {
                    LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                }
                else
                {
                    LitContCelda[i].Text += "<div class=\"" + "item proceso\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
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
                LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent2('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "', '" + element.Id_Excepciones.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-excepcion-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
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

                List<ListarCitasCalendario_Result> myResult = mylib.ListarCitasCalendario("1213asf", Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35)).ToList();
                List<ListarCitasCalendario_Result> ListaCharlasXDia = myResult.FindAll(delegate (ListarCitasCalendario_Result bk)
                {
                    return bk.FechaInicial == Convert.ToDateTime(FechaInicial);
                });

                if (ListaCharlasXDia.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('YA EXISTE UN CITA PARA ESTE MISMO DIA Y HORA!');", true);
                    return;
                }
                else
                {
                    mylib.GuardarExcepcionTrabajadorSocial(userId, Convert.ToDateTime(FechaInicial), Convert.ToDateTime(FechaFinal));

                    GenerarCalendario();
                }

            }
        }
        else if (Convert.ToDateTime(FechaInicial) > Convert.ToDateTime(FechaFinal))
        {
            ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES DESPUES DE LA HORA FINAL!');", true);
            return;
        }
        else if (Convert.ToDateTime(FechaInicial) == Convert.ToDateTime(FechaFinal))
        {
            ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('LA HORA INICIAL INSERTADA ES IGUAL A LA HORA FINAL!');", true);
            return;
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

    protected void BtnELiminarCita_Click(object sender, EventArgs e)
    {
        using (Ley22Entities mylib = new Ley22Entities())
            mylib.EliminarCitaTrabajadorSocial(Convert.ToInt32(HNroCita.Value));
        
        GenerarCalendario();
    }

    protected void BtnAsistioCita_Click(object sender, EventArgs e)
    {
        dsLey22.AsistioCitaTrabajadorSocial(Convert.ToInt32(HNroCita.Value));
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
        GenerarCalendario();
    }

}