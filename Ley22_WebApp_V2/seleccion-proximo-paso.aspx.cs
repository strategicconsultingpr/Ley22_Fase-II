using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;

public partial class seleccion_proximo_paso : System.Web.UI.Page
{
    protected Ley22Entities ley22;
    protected DataParticipante du;
    protected OrdenesJudiciale ordenes;
    int Programa;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["DataParticipante"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Info;
            Session["MensajeError"] = "Por favor seleccione el participante";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }

        if (!Page.IsPostBack)
        {
            this.ley22 = new Ley22Entities();
           du = (DataParticipante)Session["DataParticipante"];

            LitIUP.Text = du.IUP.ToString();
            LitLicencia.Text = du.Licencia;
            Programa = Convert.ToInt32(Session["Programa"].ToString());
            NombrePrograma.Text = Session["NombrePrograma"].ToString();
            LitExpediente.Text = du.Expediente;
            
            if(verificarOrdenJudicialAbierta())
            {
                LitEstatus.Text = "Tiene caso Abierto bajo este programa";

                if(verificarFaltaDeDocumento())
                {
                    inboxImg.Attributes["src"] = "../images/inbox-rojo.png";
                }
                else
                {
                    inboxImg.Attributes["src"] = "../images/recepcion-documentos.png";
                }
            }
            else
            {
                LitEstatus.Text = "Tiene caso Cerrado bajo este programa";
            }
            verificarEpisodiosAnteriores(du.Id_Participante);
            ConsultarCharlasPorParticipante(du.Id_Participante);
            verificarCitas(du.Id_Participante);
        }
    }

    bool verificarOrdenJudicialAbierta()
    {
        
        var orden = ley22.OrdenesJudiciales.Where(u => u.Id_Participante.Equals(this.du.Id_Participante)).Where(a => a.Activa.Equals(1)).Where(p => p.Id_Programa == Programa);
        if(orden.Count() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }

    bool verificarFaltaDeDocumento()
    {
        var orden = ley22.OrdenesJudiciales.Where(u => u.Id_Participante.Equals(this.du.Id_Participante)).Where(a => a.Activa.Equals(1)).Select(q => q.Id_OrdenJudicial);
        var docs = ley22.DocumentosPorParticipantes.Where(u => orden.Contains(u.Id_OrdenJudicial)).Select(p => p.Id_Documento);

        if((docs.Contains(1) && docs.Contains(7) && docs.Contains(10) && docs.Contains(18) && (docs.Contains(6) || docs.Contains(8))))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void verificarEpisodiosAnteriores(int Pk_Persona)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            List<ConsultarEpisodiosXPersona_Result> myresul = mylib.ConsultarEpisodiosXPersona(Pk_Persona).ToList();

            GVListadeEpisodios.DataSource = myresul;
            GVListadeEpisodios.DataBind();

            HyperLink1.Text = myresul.Count().ToString() + " Episodios";

            if (myresul.Count > 0)
                HyperLink1.Enabled = true;
            else
                HyperLink1.Enabled = false;

        }

    }


    void verificarCitas(int Pk_Persona)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            List<Sp_Read_CalendariobyId_Result> myresul = mylib.Sp_Read_CalendariobyId(Pk_Persona).ToList();

            GVListadeCitas.DataSource = myresul;
            GVListadeCitas.DataBind();

            var ListaCitasXDia = myresul.FindAll(delegate (Sp_Read_CalendariobyId_Result bk)
            {
                return bk.Asistio == 1;
            });

             // totales por citas
            int TotaldeCitas = myresul.Count();
            int TotalAsistencias = ListaCitasXDia.Count();
            HLCitas.Text = TotaldeCitas.ToString() + " Citas: " + TotalAsistencias.ToString () + " Asistencias, "+ (TotaldeCitas - TotalAsistencias).ToString() + " Inasistencias.";
            LitResumenCitas.Text = TotaldeCitas.ToString() + " Citas: " + TotalAsistencias.ToString() + " Asistencias, " + (TotaldeCitas - TotalAsistencias).ToString() + " Inasistencias.";
            // totales por charls

            List <ResumendeAsistenciasCharlas_Result>  myresul2 = mylib.ResumendeAsistenciasCharlas(Pk_Persona).ToList();

            HlCharlas.Text = myresul2[0].TotalAsistencias .ToString() + " Charlas : " + myresul2[0].TotalAsistencias.ToString() + " Asistencias, " + myresul2[0].TotalInasistencias.ToString() + " Inasistencias.";


        }

    }
    void ConsultarCharlasPorParticipante(int Pk_Persona)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {

            GVResumenCharlas.DataSource = mylib.ConsultarCharlasPorParticipante(Pk_Persona);
            GVResumenCharlas.DataBind();
         }

    }

    protected void lnkEpisodio_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string episodio = btn.CommandArgument;
        int episodio_num = Convert.ToInt32(episodio);

        //string title = "Episodio = ";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + episodio_num + "');", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyPopup", "$('#MyPopup').modal();", true);
        Response.Redirect("listado_perfiles.aspx?pk_episodio=" + episodio, false);
    }

}