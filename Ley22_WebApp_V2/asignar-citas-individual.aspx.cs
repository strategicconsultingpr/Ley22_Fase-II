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
    DataParticipante du;

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
            prevPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            du = (DataParticipante)Session["DataParticipante"];
            Session["FechaBase"] = new DateTime(2019, 01, 27);
            GenerarCalendario();

            //using (Ley22Entities mylib = new Ley22Entities())
            //{
            //        DdlRegion.DataTextField = "Region";
            //        DdlRegion.DataValueField = "Id_Region";
            //        DdlRegion.DataSource = mylib.sp_READALL_Regiones();
            //        DdlRegion.DataBind();
            //        DdlRegion.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            //}


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
                usuarios_programas = dsley22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
             }

            var programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Where(p => usuarios_programas.Contains(p.PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

         
                DdlCentro.DataValueField = "Value";
                DdlCentro.DataTextField = "Text";
                DdlCentro.DataSource = programas;
                DdlCentro.DataBind();
                DdlCentro.Items.Insert(0, new ListItem("-Seleccione-", "0"));

              
            


           

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
        //List<ListarExcepcionesTrabajadorSocial_Result> ListarExcepcionesTrabajadorSocial = null;

        if (DdlTrabajadorSocial.SelectedValue != "")
            using (Ley22Entities mylib = new Ley22Entities())
            {
                ListarCharlasCalendario = mylib.ListarCitasCalendario(DdlTrabajadorSocial.SelectedValue, FechaBase, FechaBase.AddDays(35)).ToList();
               // ListarExcepcionesTrabajadorSocial = mylib.ListarExcepcionesTrabajadorSocial(Convert.ToInt32(DdlTrabajadorSocial.SelectedValue), FechaBase, FechaBase.AddDays(35)).ToList();
            }
        

        for (int i = 0; i <= 34; i++)
        {
            DateTime fecha = FechaBase.AddDays(i);
            LitNumDia[i].Text = fecha.Day.ToString();
            LitContCelda[i].Text = "";

            if (fecha.ToShortDateString() == DateTime.Now.ToShortDateString())

                LitNumDia[i].Text = "<span class=\"dia actual\">" + fecha.Day.ToString() + "</span>";
            if (DdlCentro.SelectedValue.ToString() != "")
             //   AsignarExcepcionesPorDia(i, fecha, LitContCelda, ListarExcepcionesTrabajadorSocial);
                AsignatCharlaPordia(i, fecha, LitContCelda, ListarCharlasCalendario);

            if (i.ToString() == "14")
                LiMesAno.Text = UppercaseFirst(fecha.ToString("MMMM")) + " " + fecha.Year.ToString();

        }

    }

    void CargarOrdenesJudiciales()
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            DdlNumeroOrdenJudicial.DataTextField = "NumeroOrdenJudicial";
            DdlNumeroOrdenJudicial.DataValueField = "Id_OrdenJudicial";
            DdlNumeroOrdenJudicial.DataSource = mylib.ListarOrdenesJudicialesActivas(Convert.ToInt32(Session["Id_Participante"] ), Convert.ToInt32(Session["Programa"]));
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
        if (DdlNumeroOrdenJudicial.SelectedValue == "0")
        {

            //DdlRegion.Enabled = false;
            DdlCentro.Enabled = false;
            DdlTrabajadorSocial.Enabled = false;

            DdlCentro.SelectedIndex = 0;
            //if (DdlCentro.Items.FindByValue("0") != null)
            //{
            //    DdlCentro.SelectedIndex = 0;
            //}
            if (DdlTrabajadorSocial.Items.FindByValue("0") != null)
            {
                DdlTrabajadorSocial.SelectedIndex = 0;
            }
        }
        else
        {
            //DdlRegion.Enabled = true;
            DdlCentro.Enabled = true;
            DdlTrabajadorSocial.Enabled = false;
            //if(DdlCentro.Items.FindByValue("0") != null)
            //{
            //    DdlCentro.SelectedIndex = 0;
            //}
            if(DdlTrabajadorSocial.Items.FindByValue("0") != null)
            {
                DdlTrabajadorSocial.SelectedIndex = 0;
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

    //        DdlCentro_SelectedIndexChanged(sender, e);

    //    }

    //    if (DdlRegion.SelectedValue.ToString() == "0")
    //    {
    //        DdlCentro.Enabled = false;
    //        DdlTrabajadorSocial.Enabled = false;
    //        DdlCentro.SelectedIndex = 0;
    //        DdlTrabajadorSocial.SelectedIndex = 0;
    //    }
    //    else
    //    {
    //        DdlCentro.Enabled = true;
    //        DdlTrabajadorSocial.Enabled = false;
    //    }

    //    GenerarCalendario();
    //    DivBtnModalAsignarCita.Visible = false;
    //    Session["dataCalendario"] = null;
    //}

    protected void DdlCentro_SelectedIndexChanged(object sender, EventArgs e)
    {

        //using (Ley22Entities mylib = new Ley22Entities())
        //{
        //    DdlTrabajadorSocial.DataTextField = "NB_USUARIO";
        //    DdlTrabajadorSocial.DataValueField = "PK_USUARIO";
        //    DdlTrabajadorSocial.DataSource = mylib.sp_READ_TrabajadorSocialbyCentro(Convert.ToInt32(DdlCentro.SelectedValue)).ToList();
        //    DdlTrabajadorSocial.DataBind();
        //    DdlTrabajadorSocial.Items.Insert(0, new ListItem("-Seleccione-", "0"));


        //}
        var rol_ts = context.Roles.Where(u => u.Name.Equals("TrabajadorSocial")).Select(q => q.Id).Single().ToString();
        //var user = context.Users.Where(u => rol_ts.Contains(u.Id));
        var UserRoles = (from user in context.Users
                         select new
                         {
                             Id = user.Id,
                             Email = user.Email,
                             Role = (from userRoles in user.Roles 
                                     join role in context.Roles on userRoles.RoleId equals role.Id
                                     select userRoles.RoleId).ToList()
                         }).ToList();
        var usuarios = UserRoles.Where(u => u.Role.Contains(rol_ts)).Select(p => p.Id).ToList();

        int centro = Convert.ToInt32(DdlCentro.SelectedValue);

        var us = dsley22.USUARIO_PROGRAMA.Where(u => usuarios.Contains(u.FK_Usuario)).Where(p => p.FK_Programa == centro).ToList();

        var usuarios2 = context.Users.ToList();

        var usuariofinal = (from a in usuarios2 join b in us on a.Id equals b.FK_Usuario select new ListItem { Value = a.Id, Text = a.FirstName +" "+ a.LastName }).ToList();

        DdlTrabajadorSocial.DataTextField = "Text";
        DdlTrabajadorSocial.DataValueField = "Value";
        DdlTrabajadorSocial.DataSource = usuariofinal;
        DdlTrabajadorSocial.DataBind();
        DdlTrabajadorSocial.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        if (DdlCentro.SelectedValue.ToString() == "0")
        {
            DdlTrabajadorSocial.Enabled = false;
            DdlTrabajadorSocial.SelectedIndex = 0;
        }
        else
        {
            DdlTrabajadorSocial.Enabled = true;
        }

        GenerarCalendario();
        DivBtnModalAsignarCita.Visible = false;
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

            

            foreach (ListarCitasCalendario_Result element in ListaCitasXDia)
            {            
                var asistio = dsley22.Calendarios.Where(u => u.Id_Calendario.Equals(element.Id_Calendario)).Single();
                if (asistio.Activo == 1)
                {
                    if (asistio.Asistio == 1)
                    {
                        LitContCelda[i].Text += "<div class=\"" + "item ts-disponible\"" + "><a onClick=\"changeDivContentAsistio('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asistio-cita" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";

                    }
                    else if (asistio.FechaFinal < DateTime.Today && asistio.Asistio == 0)
                    {
                        LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
                    }
                    else
                    {
                        LitContCelda[i].Text += "<div class=\"" + "item proceso\"" + "><a onClick=\"changeDivContent('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "','" + UppercaseFirst(element.AP_Primero) + ", " + UppercaseFirst(element.NB_Primero) + "','" + element.TelefonoCitas + "', '" + element.Id_Calendario.ToString() + "', '" + element.NB_Programa + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-citas-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";

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
                LitContCelda[i].Text += "<div class=\"" + "item nohay\"" + "><a onClick=\"changeDivContent2('" + element.FechaFinal.ToLongDateString() + "','" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + "', '" + element.Id_Excepciones.ToString() + "')\" href =\"" + "\" data-toggle=\"" + "modal" + "\" data-target=\"" + "#asignar-excepcion-confirmacion" + "\" data-whatever=\"@getbootstrap\">" + element.FechaInicial.ToString("HH:mm") + "-" + element.FechaFinal.ToString("HH:mm") + /*"." + element.NB_Primero.Substring(0, 1) + "." + UppercaseFirst(element.AP_Primero) +*/ "</a></div>";
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

        du = (DataParticipante)Session["DataParticipante"];

        DateComparisonResult comparison;

        comparison = (DateComparisonResult) Convert.ToDateTime(FechaInicial).CompareTo(DateTime.Now);

        if (comparison == DateComparisonResult.Later && Convert.ToDateTime(FechaInicial) < Convert.ToDateTime(FechaFinal))
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

                List<ListarExcepcionesTrabajadorSocial_Result> myResult2 = mylib.ListarExcepcionesTrabajadorSocial(DdlTrabajadorSocial.SelectedValue, Convert.ToDateTime(Session["FechaBase"]), Convert.ToDateTime(Session["FechaBase"]).AddDays(35)).ToList();
                List<ListarExcepcionesTrabajadorSocial_Result> ListaExcepcionesXDia = myResult2.FindAll(delegate (ListarExcepcionesTrabajadorSocial_Result bk)
                { 
                    return (bk.FechaInicial == Convert.ToDateTime(FechaInicial) || bk.FechaFinal == Convert.ToDateTime(FechaFinal) || (bk.FechaInicial <= Convert.ToDateTime(FechaInicial) && bk.FechaFinal >= Convert.ToDateTime(FechaFinal)));
                });
                
                if (ListaCharlasXDia.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('YA EXISTE UN CITA PARA ESTE MISMO DIA Y HORA!');", true);
                    TxtHoraFinal.Text = "";
                    TxtHoraInicial.Text = "";
                    TxtFecha.Text = "";
                    return;
                }

                else if (ListaExcepcionesXDia.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(btnAsignarCita, btnAsignarCita.GetType(), "checkTime", "alert('TRABAJADOR SOCIAL NO ESTARA DISPONIBLE A ESTA HORA!');", true);
                    TxtHoraFinal.Text = "";
                    TxtHoraInicial.Text = "";
                    TxtFecha.Text = "";
                    return;
                }

                else
                {
                    mylib.GuardarCitaTrabajadorSocial(DdlTrabajadorSocial.SelectedValue, Convert.ToInt32(Session["Id_Participante"]), Convert.ToDateTime(FechaInicial), Convert.ToDateTime(FechaFinal), Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue), Convert.ToInt32(DdlCentro.SelectedValue));

                    
                    EmailService mail = new EmailService();
                    string body = CreateBody(du.NB_Primero, du.AP_Primero, FechaInicial + " - " + TxtHoraFinal.Text, DdlTrabajadorSocial.SelectedItem.Text, DdlCentro.SelectedItem.Text);
                    mail.SendAsyncCita(du.Correo,"Cita Entrevista Inicial", body);

                    DdlTrabajadorSocial_SelectedIndexChanged(null, null);
                    verificarCitas();
                    GenerarCalendario();
                }
            }
        }
        else if(Convert.ToDateTime(FechaInicial) > Convert.ToDateTime(FechaFinal))
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

        verificarCitas();
        GenerarCalendario();
    }

    protected void BtnDocumentos_Click(object sender, EventArgs e)
    {
        Response.Redirect("imprimir-documentos.aspx", false);
    }

    private string CreateBody(string FirstName, string LastName, string FechaCita, string TrabajadorSocial, string Programa)
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
}