using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Globalization;
using Ley22_WebApp_V2.Old_App_Code;
using Ley22_WebApp_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ley22_WebApp_V2
{
    public class DataCharla
    {
        public string TipoCharlaNivel;
        public string FechaHoraCharla;
        public string Participantes;
        public string AdcionarParticipante;
        public string NroCharla;
    }

    public class InfoCharla
    {
        public int Id_CharlaGrupal;
        public DateTime FechaInicial;
        public DateTime FechaFinal;
        public int Id_TipoCharla;
        public int Id_Nivel;
        public int NrodeParticipantes;
        public int NroCharla;

    }

    /// <summary>
    /// Summary description for WSCalendarioGrupal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WSCalendarioGrupal : System.Web.Services.WebService
    {
        Ley22Entities dsLey22 = new Ley22Entities();
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser ExistingUser = new ApplicationUser();

        public WSCalendarioGrupal()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public DataCharla BindModalAsistencia(int Id_CharlaGrupal, string Id_Participante, string NombreParticipante)
        //  public DataCharla BindModalAsistencia()

        {

            //int Id_CharlaGrupal = 1;
            //int Id_Participante= 1;
            //string NombreParticipante = "aaa";
            DataCharla mydata = new DataCharla();

            CultureInfo ci = new CultureInfo("en-US");
            using (Ley22Entities mylib = new Ley22Entities())

            {
                List<ListarParticipantesPorCharlas_Result> resulParaticipalntes = mylib.ListarParticipantesPorCharlas(Id_CharlaGrupal).ToList();
                List<DetalleCharlaGrupal_Result> resulDetalle = mylib.DetalleCharlaGrupal(Id_CharlaGrupal).ToList();
                var asistio = mylib.CharlaGrupals.Where(u => u.Id_CharlaGrupal.Equals(Id_CharlaGrupal)).Single();

                mydata.NroCharla = resulDetalle[0].NumeroCharla.ToString();
                mydata.TipoCharlaNivel = resulDetalle[0].TipodeCharla + ",  " + resulDetalle[0].Nivel + " - Numero de Charla:#"+ mydata.NroCharla;
                // derale de la charla
                DateTime TheDate = resulDetalle[0].FechaInicial;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PR");
                mydata.FechaHoraCharla = TheDate.ToLongDateString() + ", " + resulDetalle[0].Horas;

                // se cargan los participante 

                string Parti = string.Empty;
                string HrefRemover = string.Empty;
                string HreAdicionar = string.Empty;
                bool swEstaenLaCharla = false;
                int num = 1;
                foreach (ListarParticipantesPorCharlas_Result c in resulParaticipalntes)
                {
                    //&& asistio.FechaFinal > DateTime.Today
                    if (c.Id_Participante.ToString() == Id_Participante.ToString())
                    {
                        swEstaenLaCharla = true;
                        HrefRemover = " <a href=\"#\"   onclick=\"javacript:__doPostBack('EliminarParticipante', '')\" >Eliminar</a>";

                    }
                    else if(c.Id_Participante.ToString() == Id_Participante.ToString())
                    {
                        swEstaenLaCharla = false;
                        HrefRemover = "";

                    }
                    else
                    {
                        HrefRemover = "";
                    }
                    Parti += " <label class=\"form-check-label\">"+ num + ". " + c.NB_Primero + " " + c.AP_Primero + "</label> " + HrefRemover + "<br> ";
                    num++;
                }
                //&& asistio.FechaFinal > DateTime.Today
                if (swEstaenLaCharla == false)
                    HreAdicionar = NombreParticipante + " <a href=\"#\" class=\"btn btn-secondary\" onclick=\"javacript:__doPostBack('AnadirParticipante', '')\" >Añadir Particpante</A>";
                else
                    HreAdicionar = "";

                mydata.Participantes = Parti;
                mydata.AdcionarParticipante = HreAdicionar;
                

                return mydata;
            }

        }

        [WebMethod]
        public InfoCharla GetInfoCharla(int Id_CharlaGrupal)
        {
            InfoCharla myData = new InfoCharla();

            using (Ley22Entities mylib = new Ley22Entities())
            {

            }

            return myData;
        }

        [WebMethod]
        public static string Prueba(int Id_CharlaGrupal)
        {
             
            return Id_CharlaGrupal.ToString();
        }


        [WebMethod]
        public DataCharla BindModalParticipantes(int Id_CharlaGrupal, string userId)
        //  public DataCharla BindModalAsistencia()

        {

            //int Id_CharlaGrupal = 1;
            //int Id_Participante= 1;
            //string NombreParticipante = "aaa";
            DataCharla mydata = new DataCharla();

            CultureInfo ci = new CultureInfo("en-US");

            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

           

            using (Ley22Entities mylib = new Ley22Entities())
            {
                List<ListarParticipantesPorCharlas_Result> resulParaticipalntes = mylib.ListarParticipantesPorCharlas(Id_CharlaGrupal).ToList();
                List<DetalleCharlaGrupal_Result> resulDetalle = mylib.DetalleCharlaGrupal(Id_CharlaGrupal).ToList();

                mydata.NroCharla = resulDetalle[0].NumeroCharla.ToString();
                mydata.TipoCharlaNivel = resulDetalle[0].TipodeCharla + ",  " + resulDetalle[0].Nivel + " - Numero de Charla:#" + mydata.NroCharla; 
                // derale de la charla
                DateTime TheDate = resulDetalle[0].FechaInicial;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PR");
                mydata.FechaHoraCharla = TheDate.ToLongDateString() + ", " + resulDetalle[0].Horas;

                DateTime FE_Charla = Convert.ToDateTime(resulDetalle[0].FechaInicial.ToString());
                TimeSpan ts = DateTime.Now.Subtract(FE_Charla);

                // se cargan los participante 

                string Parti = string.Empty;
                
                string HrefRemover = string.Empty;
                string HreAdicionar = string.Empty;
                string HrefAsistio = string.Empty;
                string HrefEstatus = string.Empty;
                string HrefPrint = string.Empty;
                string HrefPermiso = string.Empty;

                if(ts.Days > 7)
                {
                    HrefPermiso = "";
                    HreAdicionar = "";
                }
                else
                {
                    HrefPermiso = "href=\"#\"";

                    if (resulParaticipalntes.Where(u => u.Asistio == 1).Count() > 0)
                    {
                        HreAdicionar = "";
                    }
                    else
                    {
                        HreAdicionar = "<a role=\"button\" class=\"btn btn-secondary btn - lg\" onclick=\"javacript:__doPostBack('TodosAsistieron','" + Id_CharlaGrupal + "')\" style=\"background - color:#8fbc8f\"><strong>Todos Asistieron</strong></a>";
                    }
                }

                foreach (ListarParticipantesPorCharlas_Result c in resulParaticipalntes)
                {
                    string EliminarOnclick = string.Empty;
                    string AsistioOnclick = string.Empty;
                    string NoAsistioOnclick = string.Empty;

                    var orden = dsLey22.ParticipantesPorCharlas.Where(u => u.Id_ParticipantePorCharlaGrupal.Equals(c.Id_ParticipantePorCharlaGrupal)).Select(p => p.Id_OrdenJudicial).SingleOrDefault();
                    var cargos = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal == orden).Select(a => a.Cargos).SingleOrDefault();
                    var pagos = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal == orden).Select(a => a.Pagos).SingleOrDefault();

                    var activa = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal == orden).Select(a => a.Activa).SingleOrDefault();

                    var balance = cargos - pagos;

                    var status = dsLey22.ParticipantesPorCharlas.Where(u => u.Id_Participante.Equals(c.Id_Participante)).Where(p => p.Id_OrdenJudicial == orden).Select(a => a.Asistio).Sum();

                    if(ts.Days > 7 || activa == 0)
                    {
                        EliminarOnclick = "";
                        AsistioOnclick = " onclick=\"javascript: alert('Fecha expirada para poder modificar asistencia de este participante')\"";
                        NoAsistioOnclick = " onclick=\"javascript: alert('Fecha expirada para poder modificar asistencia de este participante')\"";
                        HrefRemover = "";
                        HreAdicionar = "";
                    }
                    else
                    {
                        EliminarOnclick = " onclick=\"javacript:__doPostBack('EliminarParticipante','" + c.Id_Participante + "')\"";
                        AsistioOnclick = " onclick=\"javacript:__doPostBack('AsistioParticipante','" + c.Id_ParticipantePorCharlaGrupal + "')\"";
                        NoAsistioOnclick = "onclick =\"javacript:__doPostBack('NoAsistioParticipante','" + c.Id_ParticipantePorCharlaGrupal + "')\"";
                        HrefRemover = " <a " + HrefPermiso + EliminarOnclick + " >Eliminar</a>  -  ";
                    }

                    
                    if(c.Asistio == 0)
                    {
                        HrefAsistio = "<a " + HrefPermiso + "  id=\"asistioID\""+ AsistioOnclick + "style=\"color: #FF5733\">No Asistio</a>";
                        //if (balance.Equals(Convert.ToDecimal(0.00)))
                        //{
                        //   HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Debe</a></div><div class=\"col-md-2\"></div><div class=\"col-md-6\"><a>$0.00</a></div></div></div>";
                        //}
                        //else 
                        //{
                            HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Debe</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance + "</a></div></div></div>";
                      //  }
                    }
                    else
                    {
                        if(balance.Equals(Convert.ToDecimal(0.00)) && status == 5)
                        {
                           
                            HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + " style=\"color: #0bbd0d\">Asistio </a>";
                            if (activa == 0 && (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor")))
                            {
                                HrefPrint = "<a href=\"#\"   OnClick='imprimirCertificado(" + c.Id_Participante.ToString() + "," + orden.ToString() + ")' </a> <img src=\"../images/print.png\" alt=\"ASSMCA\">";
                            }
                            else
                            {
                                HrefPrint = "";
                            }
                                HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Completado</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance + "</a></div></div></div>";
                            
                        }
                        else if(balance.Equals(Convert.ToDecimal(0.00)) && status < 5)
                        {
                            HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + " style=\"color: #0bbd0d\">Asistio</a>";
                            HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Debe</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$0.00</a></div></div></div>";
                        }
                        else if ((!balance.Equals(Convert.ToDecimal(0.00))) && status == 5)
                        {
                            HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + " style=\"color: #0bbd0d\">Asistio</a>";
                            HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Completado</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance+"</a></div></div></div>";
                        }
                        else
                        {
                            HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + "style=\"color: #0bbd0d\">Asistio</a>";
                            HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Debe</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance + "</a></div></div></div>";
                        }

                    }

                    //Parti += "<div class=\"col-md-4\">" + HrefPrint+ "<label class=\"form-check-label\">" + c.NB_Primero + " " + c.AP_Primero + "</label> </div> <div class=\"col-md-4\" style=\"text-align:center\">" + HrefRemover + "  -  " + HrefAsistio +"</div> "+ HrefEstatus;
                    Parti += "<div class=\"col-md-4\">" + HrefPrint + "<a href=\"#\" class=\"form-check-label\"  onclick=\"javacript:__doPostBack('ExpedienteParticipante','" + c.Id_Participante + "')\">" + c.NB_Primero + " " + c.AP_Primero+"</a> </div> <div class=\"col-md-4\" style=\"text-align:center\">" + HrefRemover + HrefAsistio + "</div> " + HrefEstatus;
                    HrefPrint = "";
                }

                
               
                

                mydata.Participantes = Parti;
                mydata.AdcionarParticipante = HreAdicionar;
                

                return mydata;
            }

        }
    }
}


