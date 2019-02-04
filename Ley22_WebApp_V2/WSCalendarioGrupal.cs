using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Globalization;
namespace Ley22_WebApp_V2.Old_App_Code
{
    public class DataCharla
    {
        public string TipoCharlaNivel;
        public string FechaHoraCharla;
        public string Participantes;
        public string AdcionarParticipante;
    }

    public class InfoCharla
    {
        public int Id_CharlaGrupal;
        public DateTime FechaInicial;
        public DateTime FechaFinal;
        public int Id_TipoCharla;
        public int Id_Nivel;
        public int NrodeParticipantes;

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

        public WSCalendarioGrupal()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public DataCharla BindModalAsistencia(int Id_CharlaGrupal, int Id_Participante, string NombreParticipante)
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


                mydata.TipoCharlaNivel = resulDetalle[0].TipodeCharla + ",  " + resulDetalle[0].Nivel;
                // derale de la charla
                DateTime TheDate = resulDetalle[0].FechaInicial;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PR");
                mydata.FechaHoraCharla = TheDate.ToLongDateString() + ", " + resulDetalle[0].Horas;

                // se cargan los participante 

                string Parti = string.Empty;
                string HrefRemover = string.Empty;
                string HreAdicionar = string.Empty;
                bool swEstaenLaCharla = false;
                foreach (ListarParticipantesPorCharlas_Result c in resulParaticipalntes)
                {

                    if (c.Id_Participante.ToString() == Id_Participante.ToString())
                    {
                        swEstaenLaCharla = true;
                        HrefRemover = " <a href=\"#\"   onclick=\"javacript:__doPostBack('EliminarParticipante', '')\" >Eliminar</a>";

                    }
                    else
                    {
                        swEstaenLaCharla = false;
                        HrefRemover = "";

                    }
                    Parti += " <label class=\"form-check-label\">" + c.NB_Primero + " " + c.AP_Primero + "</label> " + HrefRemover + "<br> ";
                }

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
        public DataCharla BindModalParticipantes(int Id_CharlaGrupal)
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


                mydata.TipoCharlaNivel = resulDetalle[0].TipodeCharla + ",  " + resulDetalle[0].Nivel;
                // derale de la charla
                DateTime TheDate = resulDetalle[0].FechaInicial;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PR");
                mydata.FechaHoraCharla = TheDate.ToLongDateString() + ", " + resulDetalle[0].Horas;

                // se cargan los participante 

                string Parti = string.Empty;
                string HrefRemover = string.Empty;
                string HreAdicionar = string.Empty;

                foreach (ListarParticipantesPorCharlas_Result c in resulParaticipalntes)
                {

                    HrefRemover = " <a href=\"#\"   onclick=\"javacript:__doPostBack('EliminarParticipante', '')\" >Eliminar</a>";


                    Parti += " <label class=\"form-check-label\">" + c.NB_Primero + " " + c.AP_Primero + "</label> " + HrefRemover + "<br> ";
                }


                HreAdicionar = "";

                mydata.Participantes = Parti;
                mydata.AdcionarParticipante = HreAdicionar;

                return mydata;
            }

        }
    }
}


