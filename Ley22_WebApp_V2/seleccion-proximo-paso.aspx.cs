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
   // protected DataParticipante du;
    protected Data_SA_Persona du;
    protected OrdenesJudiciale ordenes;
    int Programa;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
            Session["MensajeError"] = "Por favor ingrese al sistema";
            Session["Redirect"] = "Account/Login.aspx";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }
        if (Session["SA_Persona"] == null)
        {
            Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
            Session["MensajeError"] = "Por favor seleccione el participante";
            Session["Redirect"] = "Entrada.aspx";
            Response.Redirect("Mensajes.aspx", false);
            return;
        }

        if (!Page.IsPostBack)
        {
            this.ley22 = new Ley22Entities();
            //du = (DataParticipante)Session["DataParticipante"];
            du = (Data_SA_Persona)Session["SA_Persona"];

            LitIUP.Text = du.PK_Persona.ToString();
           // LitLicencia.Text = "12345";
            Programa = Convert.ToInt32(Session["Programa"].ToString());
            NombreParticipante.Text = Session["NombreParticipante"].ToString();
            NombrePrograma.Text = Session["NombrePrograma"].ToString();
            LitExpediente.Text = Session["Expediente"].ToString();
            
            if(verificarOrdenJudicialAbierta())
            {
                LitEstatus.Text = "Abierto bajo este programa";

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
                LitEstatus.Text = "Cerrado bajo este programa";
            }
            verificarEpisodiosAnteriores(du.PK_Persona);
            verificarCasosAnteriores(du.PK_Persona);
            ConsultarCharlasPorParticipante(du.PK_Persona);
            verificarCitas(du.PK_Persona);
        }
    }

    bool verificarOrdenJudicialAbierta()
    {
        
        var orden = ley22.CasoCriminals.Where(u => u.Id_Participante.Equals(this.du.PK_Persona)).Where(a => a.Activa.Equals(1)).Where(p => p.FK_Programa == Programa);
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
        var orden = ley22.CasoCriminals.Where(u => u.Id_Participante.Equals(this.du.PK_Persona)).Where(a => a.Activa.Equals(1)).Select(q => q.Id_CasoCriminal);
        var docs = ley22.DocumentosPorParticipantes.Where(u => orden.Contains(u.Id_OrdenJudicial)).Select(p => p.Id_Documento);
        var docsFaltante = ley22.Documentos.Where(u => !docs.Contains(u.Id_Documento)).Where(a => a.Importante == 1).Select(p => p.Id_Documento).ToList();

        if (docsFaltante.Count() < 1)
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

            LnkBtnEpisodios.Text = myresul.Count().ToString() + " Episodios";

            if (myresul.Count > 0)
                LnkBtnEpisodios.Enabled = true;
            else
                LnkBtnEpisodios.Enabled = false;

        }

    }

    void verificarCasosAnteriores(int Pk_Persona)
    {
        using (Ley22Entities mylib = new Ley22Entities())
        {
            List<ConsultarCasosXPersona_Result> myresul = mylib.ConsultarCasosXPersona(Pk_Persona).ToList();

            GVListaDeCasos.DataSource = myresul;
            GVListaDeCasos.DataBind();

            LnkBtnCasos.Text = myresul.Count().ToString() + " Casos";

            if (myresul.Count > 0)
                LnkBtnCasos.Enabled = true;
            else
                LnkBtnCasos.Enabled = false;

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
            HLnkCitas.Text = TotaldeCitas.ToString() + " Citas: " + TotalAsistencias.ToString () + " Asistencias, "+ (TotaldeCitas - TotalAsistencias).ToString() + " Inasistencias.";
            LitResumenCitas.Text = TotaldeCitas.ToString() + " Citas: " + TotalAsistencias.ToString() + " Asistencias, " + (TotaldeCitas - TotalAsistencias).ToString() + " Inasistencias.";
            // totales por charls

            List <ResumendeAsistenciasCharlas_Result>  myresul2 = mylib.ResumendeAsistenciasCharlas(Pk_Persona).ToList();

            HLnkCharlas.Text = myresul2[0].TotalAsistencias .ToString() + " Charlas : " + myresul2[0].TotalAsistencias.ToString() + " Asistencias, " + myresul2[0].TotalInasistencias.ToString() + " Inasistencias.";


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

    protected void lnkCasoCriminal_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string caso = btn.CommandArgument;
        int caso_num = Convert.ToInt32(caso);

        //string title = "Episodio = ";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('" + title + "', '" + episodio_num + "');", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyPopup", "$('#MyPopup').modal();", true);
        Response.Redirect("OrdenNuevo.aspx?id_caso=" + caso_num, false);
    }

}