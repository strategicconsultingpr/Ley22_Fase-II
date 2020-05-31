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

    public class DataCharla2
    {
        public string TipoCharlaNivel;
        public string FechaHoraCharla;
        public string Participantes;
        public string AdcionarParticipante;
        public string NroCharla;
        public string EliminarParticipante;
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
        public DataCharla2 BindModalAsistencia(int Id_CharlaGrupal, string Id_Participante, string NombreParticipante, int Id_CasoCriminal)
        {
            DataCharla2 mydata = new DataCharla2();

            CultureInfo ci = new CultureInfo("en-US");
            using (Ley22Entities mylib = new Ley22Entities())
            {
                List<ListarParticipantesPorCharlasCasoCriminal_Result> resulParaticipalntes = mylib.ListarParticipantesPorCharlasCasoCriminal(Id_CharlaGrupal).ToList();
                List<DetalleCharlaGrupal_Result> resulDetalle = mylib.DetalleCharlaGrupal(Id_CharlaGrupal).ToList();
                var asistio = mylib.CharlaGrupals.Where(u => u.Id_CharlaGrupal.Equals(Id_CharlaGrupal)).Single();

                var activa = mylib.CasoCriminals.Where(u => u.Id_CasoCriminal.Equals(Id_CasoCriminal)).Single();

                mydata.NroCharla = resulDetalle[0].NumeroCharla.ToString();
                mydata.TipoCharlaNivel = resulDetalle[0].TipodeCharla + ",  " + resulDetalle[0].Nivel + " - Numero de Charla:#"+ mydata.NroCharla;

                // derale de la charla
                DateTime TheDate = resulDetalle[0].FechaInicial;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PR");
                mydata.FechaHoraCharla = TheDate.ToLongDateString() + ", " + resulDetalle[0].Horas;

                // se cargan los participante 
                List<ListarCharlasCasoCriminal_Result> CharlasDelCaso = mylib.ListarCharlasCasoCriminal(Id_CasoCriminal).ToList();

                var primeraCharla = CharlasDelCaso.Where(u => u.NumeroCharla == 1).Count();

                var charlaRepetida = CharlasDelCaso.Where(u => u.NumeroCharla == resulDetalle[0].NumeroCharla).Where(p => p.Id_CharlaGrupal != Id_CharlaGrupal).Count();


                string Parti = string.Empty;
                string HrefRemover = string.Empty;
                string HreAdicionar = string.Empty;
                bool swEstaenLaCharla = false;
                int num = 1;
                string participanteEliminar = string.Empty;

                foreach (ListarParticipantesPorCharlasCasoCriminal_Result c in resulParaticipalntes)
                {
                    if (c.Id_Participante.ToString() == Id_Participante.ToString())
                    {
                        swEstaenLaCharla = true;

                        if(c.Id_OrdenJudicial.ToString() == Id_CasoCriminal.ToString())
                        {
                            if(activa.Activa == 1)
                            {
                                if (c.Asistio == 1)
                                {
                                    //HrefRemover = " <a href=\"#\" onclick=\"javacript:asistioParticipante()\" placeholder=\"'Presione para obtener más información'\"> - PARTICIPANTE NO SE PUEDE ELIMINAR</a>";
                                    //HrefRemover = " <a href=\"#\"><img src=\"../images/person-dash.svg\" alt=\"\" width=\"32\" height=\"32\" title=\"PARTICIPANTE ASISTIÓ A CHARLA\"></a>";
                                    HrefRemover = "<td class=\"col-9\" style=\"text-align:center\"><h6><strong>" + c.NB_Primero + " " + c.AP_Primero + "</strong></h6></td><td class=\"col-2\" style=\"text-align:center\" bgcolor=\"#D5EB98\" ><img src=\"images/person.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"PARTICIPANTE ASISTIÓ A CHARLA\"></td>";
                                }
                                else if (c.Asistio == 0 && resulDetalle[0].FechaInicial > DateTime.Today)
                                {
                                    HrefRemover = "<td class=\"col-9\" style=\"text-align:center\"><h6><strong>" + c.NB_Primero + " " + c.AP_Primero + "</strong></h6></td><td class=\"col-2\" style=\"text-align:center\" bgcolor=\"#E9CA6D\"><img src=\"images/person.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"CHARLA A REALIZARCE\"></td>";
                                    participanteEliminar = c.NB_Primero + " " + c.AP_Primero + " &nbsp; <a href=\"#\" class=\"btn btn-secondary\" style=\"background-color:#E96D6D\" onclick=\"javacript:eliminarParticipante()\" ><img src=\"images/x-circle.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"ELIMINAR PARTICIPANTE DE CHARLA\"></a>";
                                }
                                else
                                {
                                    //HrefRemover = "<label class=\"form-check-label\"> - PARTICIPANTE ACTUAL </label>";
                                    HrefRemover = "<td class=\"col-9\" style=\"text-align:center\"><h6><strong>" + c.NB_Primero + " " + c.AP_Primero + "</strong></h6></td><td class=\"col-2\" style=\"text-align:center\" bgcolor=\"#E96D6D\"><img src=\"images/person.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"PARTICIPANTE NO HA ASISTIÓ A CHARLA\"></td>";
                                    participanteEliminar = c.NB_Primero + " " + c.AP_Primero + " &nbsp; <a href=\"#\" class=\"btn btn-secondary\" style=\"background-color:#E96D6D\" onclick=\"javacript:eliminarParticipante()\" ><img src=\"images/x-circle.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"ELIMINAR PARTICIPANTE DE CHARLA\"></a>";

                                }
                            }
                            else
                            {
                                //HrefRemover = "<label class=\"form-check-label\"> - CASO CRIMINAL SE ENCUENTRA CERRADO </label>";
                                HrefRemover = "<td class=\"col-9\" style=\"text-align:center\"><h6><strong>" + c.NB_Primero + " " + c.AP_Primero + "</strong></h6></td><td class=\"col-2\" style=\"text-align:center\"><img src=\"images/person.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"PARTICIPANTE ASISTIÓ A CHARLA\"></td>";
                            }
                        }
                        else
                        {
                            //HrefRemover = "<label class=\"form-check-label\"> - PARTICIPANTE YA ESTA EN ESTA CHARLA BAJO OTRO CASO CRIMINAL </label>";
                            HrefRemover = "<td class=\"col-9\" style=\"text-align:center\"><h6><strong>" + c.NB_Primero + " " + c.AP_Primero + "</strong></h6></td><td class=\"col-2\" style=\"text-align:center\"><img src=\"images/person.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"PARTICIPANTE ASIGNADO A CHARLA BAJO OTRO CASO CRIMINAL\"></td>";
                        }
                    }
                    else
                    {
                        HrefRemover = "<td class=\"col-9\" style=\"text-align:center\">" + c.NB_Primero + " " + c.AP_Primero + "</td><td class=\"col-2\" style=\"text-align:center\"></td>";
                    }

                    //Parti += " <label class=\"form-check-label\">"+ num + ". " + c.NB_Primero + " " + c.AP_Primero + "</label> " + HrefRemover + "<br> ";
                    Parti += "<tr class=\"d-flex\"> <td class=\"col-1\" style=\"text-align:center\">" + num + "</td>" + HrefRemover + "</tr>";
                    num++;
                }

                if (swEstaenLaCharla == false)
                {
                    if(primeraCharla < 1 && resulDetalle[0].NumeroCharla != 1)
                    {
                        HreAdicionar = NombreParticipante + " &nbsp;<a href=\"#\" class=\"btn btn-secondary\" style=\"background-color:gold\" onclick=\"javacript:sweetAlert('Falta de Charla','Participante no se encuentra asignado a una primera charla.','warning')\" ><img src=\"images/exclamation-circle.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"FALTA DE PRIMERA CHARLA\"></a>";
                        
                    }
                    else if (charlaRepetida > 0)
                    {
                        HreAdicionar = NombreParticipante + " &nbsp;<a href=\"#\" class=\"btn btn-secondary\" style=\"background-color:gold\" onclick=\"javacript:sweetAlert('Charla Repetida','Participante se encuentra asignado a otra charla con este numero.','warning')\" ><img src=\"images/exclamation-circle.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"PARTICIPANTE YA ASIGNADO A OTRA CHARLA #" + resulDetalle[0].NumeroCharla.ToString() + "\"></a>";
                    }
                    else
                    {
                        HreAdicionar = NombreParticipante + " &nbsp;<a href=\"#\" class=\"btn btn-secondary\" style=\"background-color:#D5EB98\" onclick=\"javacript:__doPostBack('AnadirParticipante', '')\" ><img src=\"images/plus-circle.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"AGREGAR PARTICIPANTE A CHARLA\"></a>";
                    }
                }
                else
                {
                    HreAdicionar = "";
                }

                mydata.Participantes = Parti;
                mydata.AdcionarParticipante = HreAdicionar;
                mydata.EliminarParticipante = participanteEliminar;
                

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
        {
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
                //string HrefPrint = string.Empty;
                string HrefPermiso = string.Empty;

                bool charlaRealizada = FE_Charla < DateTime.Today;

                //if(ts.Days > 7)
                //{
                //    HrefPermiso = "";
                //    HreAdicionar = "";
                //}
                //else
                //{
                HrefPermiso = "href=\"#\"";

                    if (resulParaticipalntes.Where(u => u.Asistio == 1).Count() > 0)
                    {
                        HreAdicionar = "";
                    }
                    else
                    {
                        HreAdicionar = "<a role=\"button\" class=\"btn btn-secondary btn - lg\" onclick=\"javacript:__doPostBack('TodosAsistieron','" + Id_CharlaGrupal + "')\" style=\"background - color:#8fbc8f\"><strong>Todos Asistieron</strong></a>";
                    }
              //  }

                foreach (ListarParticipantesPorCharlas_Result c in resulParaticipalntes)
                {
                    string EliminarOnclick = string.Empty;
                    string AsistioOnclick = string.Empty;
                    string NoAsistioOnclick = string.Empty;

                    string Estatus = string.Empty;
                    string charlasDeuda = string.Empty;
                    string dineroDeuda = string.Empty;
                    string Accion = string.Empty;

                    string HrefPrint = string.Empty;

                    var orden = dsLey22.ParticipantesPorCharlas.Where(u => u.Id_ParticipantePorCharlaGrupal.Equals(c.Id_ParticipantePorCharlaGrupal)).Select(p => p.Id_OrdenJudicial).SingleOrDefault();
                    var cargos = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal == orden).Select(a => a.Cargos).SingleOrDefault();
                    var pagos = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal == orden).Select(a => a.Pagos).SingleOrDefault();

                    var activa = dsLey22.CasoCriminals.Where(p => p.Id_CasoCriminal == orden).Select(a => a.Activa).SingleOrDefault();

                    var balance = cargos - pagos;


                    var charlasRegulares = dsLey22.ListarAsistenciaCharlasRegulares(c.Id_Participante, orden).SingleOrDefault();

                    var victima = dsLey22.ListarAsistenciaCharlasImpacto(c.Id_Participante, orden).SingleOrDefault();

                    var status = dsLey22.ParticipantesPorCharlas.Where(u => u.Id_Participante.Equals(c.Id_Participante)).Where(p => p.Id_OrdenJudicial == orden).Select(a => a.Asistio).Sum();

                    //var infoCharlas = dsLey22.ParticipantesPorCharlas.Where(u => u.Id_OrdenJudicial == orden).Select(a => a.Id_CharlaGrupal);

                    var asistenciaPrimeraCharla = (from participantes in dsLey22.ParticipantesPorCharlas
                                                  join charlas in dsLey22.CharlaGrupals on participantes.Id_CharlaGrupal equals charlas.Id_CharlaGrupal
                                                  where participantes.Id_OrdenJudicial == orden && charlas.NumeroCharla == 1
                                                  select new { Asistio = participantes.Asistio }).SingleOrDefault();

                    //if(activa == 0)
                    //{
                    //    EliminarOnclick = "";
                    //    AsistioOnclick = " onclick=\"javascript: asistenciaAlerta('Caso Cerrado','Este caso criminal se encuentra cerrado. No puede modificar la asistencia de este participante','warning')\"";
                    //    NoAsistioOnclick = " onclick=\"javascript: asistenciaAlerta('Caso Cerrado','Este caso criminal se encuentra cerrado. No puede modificar la asistencia de este participante','warning')\"";
                    //    HrefRemover = "";
                    //    HreAdicionar = "";
                    //}
                    //else
                    //{
                    //    EliminarOnclick = " onclick=\"javacript:__doPostBack('EliminarParticipante','" + c.Id_Participante+","+orden + "')\"";
                    //    AsistioOnclick = " onclick=\"javacript:__doPostBack('AsistioParticipante','" + c.Id_ParticipantePorCharlaGrupal + "')\"";
                    //    NoAsistioOnclick = "onclick =\"javacript:__doPostBack('NoAsistioParticipante','" + c.Id_ParticipantePorCharlaGrupal + "')\"";
                    //    HrefRemover = " <a " + HrefPermiso + EliminarOnclick + " >Eliminar</a>  -  ";
                    //}


                    //if(c.Asistio == 0)
                    //{
                    //    if (charlasRegulares > 9 && (victima == 1 || victima == -1))
                    //    {
                    //        HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Completado</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance + "</a></div></div></div>";
                    //    }
                    //    else
                    //    {
                    //        if(Convert.ToInt32(mydata.NroCharla) != 1 && asistenciaPrimeraCharla.Asistio != 1)
                    //        {
                    //            AsistioOnclick = " onclick=\"javascript: asistenciaAlerta('Falta de Asistencia','El participante NO ha asistido a su primera charla bajo este caso criminal. No puede modificar la asistencia de este participante. Favor de verificar asistencia de su primera charla','warning')\"";
                    //        }

                    //        HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Debe</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance + "</a></div></div></div>";
                    //    }

                    //    HrefAsistio = "<a " + HrefPermiso + "  id=\"asistioID\"" + AsistioOnclick + "style=\"color: #FF5733\">No Asistio</a>";
                    //}
                    //else
                    //{
                    //    if(balance.Equals(Convert.ToDecimal(0.00)) && charlasRegulares > 9 && (victima == 1 || victima == -1))
                    //    {

                    //        HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + " style=\"color: #0bbd0d\">Asistio </a>";
                    //        if (activa == 0 && (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor")))
                    //        {
                    //            HrefPrint = "<a href=\"#\"   OnClick='imprimirCertificado(" + c.Id_Participante.ToString() + "," + orden.ToString() + ")' </a> <img src=\"../images/print.png\" alt=\"ASSMCA\">";
                    //        }
                    //        else
                    //        {
                    //            HrefPrint = "";
                    //        }
                    //            HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Completado</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance + "</a></div></div></div>";

                    //    }
                    //    else if(balance.Equals(Convert.ToDecimal(0.00)) && (charlasRegulares < 10 || victima == 0))
                    //    {
                    //        HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + " style=\"color: #0bbd0d\">Asistio</a>";
                    //        HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Debe</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$0.00</a></div></div></div>";
                    //    }
                    //    else if ((!balance.Equals(Convert.ToDecimal(0.00))) && charlasRegulares > 9 && (victima == 1 || victima == -1))
                    //    {
                    //        HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + " style=\"color: #0bbd0d\">Asistio</a>";
                    //        HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Completado</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance+"</a></div></div></div>";
                    //    }
                    //    else
                    //    {
                    //        HrefAsistio = "<a " + HrefPermiso + NoAsistioOnclick + "style=\"color: #0bbd0d\">Asistio</a>";
                    //        HrefEstatus = "<div class=\"col-md-4\"><div class=\"row\"><div class=\"col-md-4\"><a>Debe</a></div><div class=\"col-md-2\"></div><div class=\"col-md-4\"><a>$" + balance + "</a></div></div></div>";
                    //    }

                    //}

                    ////Parti += "<div class=\"col-md-4\">" + HrefPrint+ "<label class=\"form-check-label\">" + c.NB_Primero + " " + c.AP_Primero + "</label> </div> <div class=\"col-md-4\" style=\"text-align:center\">" + HrefRemover + "  -  " + HrefAsistio +"</div> "+ HrefEstatus;
                    //Parti += "<div class=\"col-md-4\">" + HrefPrint + "<a href=\"#\" class=\"form-check-label\"  onclick=\"javacript:__doPostBack('ExpedienteParticipante','" + c.Id_Participante + "')\">" + c.NB_Primero + " " + c.AP_Primero+"</a> </div> <div class=\"col-md-4\" style=\"text-align:center\">" + HrefRemover + HrefAsistio + "</div> " + HrefEstatus;
                    //HrefPrint = "";

                    if (activa == 0)
                    {
                        Accion = "<td class=\"col-2\" style=\"text-align:center\">Caso Cerrado</td>";
                        HreAdicionar = "";

                        if (c.Asistio == 0)
                        {
                            Estatus = "<td class=\"col-2\" style=\"text-align:center\">No Asistió</td>";
                        }
                        else
                        {
                            Estatus = "<td class=\"col-2\" style=\"text-align:center\">Asistió</td>";
                        }

                        if (charlasRegulares > 9 && (victima == 1 || victima == -1))
                        {
                            charlasDeuda = "<td class=\"col-2\" style=\"text-align:center\">Completadas</td>";

                            if (balance.Equals(Convert.ToDecimal(0.00)) && (userManager.IsInRole(userId, "SuperAdmin") || userManager.IsInRole(userId, "Supervisor")))
                            {
                                HrefPrint = "<a href=\"#\"   OnClick='imprimirCertificado(" + c.Id_Participante.ToString() + "," + orden.ToString() + ")' </a> <img src=\"images/print.png\" alt=\"ASSMCA\">";
                            }
                        }
                        else
                        {
                            charlasDeuda = "<td class=\"col-2\" style=\"text-align:center\">En Deuda</td>";
                        }

                    }
                    else
                    {
                        if (c.Asistio == 0)
                        {
                            if (charlaRealizada)
                            {
                                Estatus = "<td class=\"col-2\" style=\"text-align:center\">No Asistió</td>";
                            }
                            else
                            {
                                Estatus = "<td class=\"col-2\" style=\"text-align:center\">A Realizarce</td>";
                            }

                            if (Convert.ToInt32(mydata.NroCharla) != 1)
                            {
                                if (asistenciaPrimeraCharla == null)
                                {
                                    Accion = "<td class=\"col-2\" style=\"text-align:center\"><a href=\"#\" onclick=\"javascript: asistenciaAlerta('Falta de Asistencia','El participante NO ha asistido a su primera charla bajo este caso criminal. No puede modificar la asistencia de este participante. Favor de verificar asistencia de su primera charla','warning')\"><img src=\"images/exclamation-circle.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"FALTA DE PRIMERA CHARLA\"></a></td>";
                                }
                                else if (asistenciaPrimeraCharla.Asistio != 1)
                                {
                                    Accion = "<td class=\"col-2\" style=\"text-align:center\"><a href=\"#\" onclick=\"javascript: asistenciaAlerta('Falta de Asistencia','El participante NO ha asistido a su primera charla bajo este caso criminal. No puede modificar la asistencia de este participante. Favor de verificar asistencia de su primera charla','warning')\"><img src=\"images/exclamation-circle.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"FALTA DE PRIMERA CHARLA\"></a></td>";
                                }
                            }
                            else
                            {
                                Accion = "<td class=\"col-2\" style=\"text-align:center\"><a href=\"#\" onclick=\"javascript:__doPostBack('AsistioParticipante','" + c.Id_ParticipantePorCharlaGrupal + "')\"> <img src=\"images/person-check.svg\" alt=\"\" width=\"28\" height=\"28\" id=\"Img1\" runat=\"server\" title=\"CAMBIAR PARTICIPANTE A SI ASISTIÓ\"></a>"
                                + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\" onclick=\"javascript:__doPostBack('EliminarParticipante','" + c.Id_Participante + "," + orden + "')\"><img src=\"images/x-circle.svg\" alt=\"\" width=\"25\" height=\"25\" runat=\"server\" title=\"ELMINIAR PARTICIPANTE DE CHARLA\"></a></td>";
                            }
                        }
                        else
                        {
                            Estatus = "<td class=\"col-2\" style=\"text-align:center\">Asistió</td>";

                            Accion = "<td class=\"col-2\" style=\"text-align:center\"><a href=\"#\" onclick=\"javascript:__doPostBack('NoAsistioParticipante','" + c.Id_ParticipantePorCharlaGrupal + "')\"><img src=\"images/person-dash.svg\" alt=\"\" width=\"28\" height=\"28\" title=\"CAMBIAR PARTICIPANTE A NO ASISTIÓ\"></a></td>";
                        }

                        if (charlasRegulares > 9 && (victima == 1 || victima == -1))
                        {
                            charlasDeuda = "<td class=\"col-2\" style=\"text-align:center\">Completadas</td>";
                        }
                        else
                        {
                            charlasDeuda = "<td class=\"col-2\" style=\"text-align:center\">En Deuda</td>";
                        }

                    }

                    dineroDeuda = "<td class=\"col-2\" style=\"text-align:center\">$" + balance + "</td>";

                    Parti += "<tr class=\"d-flex\"> <td class=\"col-4 \" style=\"text-align:center\">" + HrefPrint + "<a href=\"#\" class=\"form-check-label\"  onclick=\"javacript:__doPostBack('ExpedienteParticipante','" + c.Id_Participante + "')\">" + c.NB_Primero + " " + c.AP_Primero + "</a> </td>" + Estatus + charlasDeuda + dineroDeuda + Accion;
                  //  HrefPrint = "";
                }

                
               
                

                mydata.Participantes = Parti;
                mydata.AdcionarParticipante = HreAdicionar;
                

                return mydata;
            }

        }
    }
}


