using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class Reportes : System.Web.UI.Page
    {
        ApplicationUser ExistingUser = new ApplicationUser();
        SEPSEntities1 dsPerfil = new SEPSEntities1();
        Ley22Entities dsLey22 = new Ley22Entities();
        static string userId = String.Empty;

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

            if (!Page.IsPostBack)
            {

                Div.Visible = false;
                ExistingUser = (ApplicationUser)Session["User"];
                userId = ExistingUser.Id;

                CargarProgramas();
            }

            
        }

        protected void CargarProgramas()
        {
            var usuarios_programas = new List<string>();
            var programas_usuario = new List<int>();
            programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
            var programas = dsPerfil.SA_PROGRAMA.Where(p => programas_usuario.Contains(p.PK_Programa)).Select(u => new ListItem { Value = u.PK_Programa.ToString(), Text = u.NB_Programa.Replace("EVALUACIÓN ", "") }).ToList();

            if (programas.Count > 1)
            {
                DivPrograma.Visible = true;
                ValidatorPrograma.Enabled = true;
                DdlPrograma.DataValueField = "Value";
                DdlPrograma.DataTextField = "Text";
                DdlPrograma.DataSource = programas;
                DdlPrograma.DataBind();
                DdlPrograma.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
            else if (programas.Count == 1)
            {
                ValidatorPrograma.Enabled = false;
                DivPrograma.Visible = false;

                DdlPrograma.DataValueField = "Value";
                DdlPrograma.DataTextField = "Text";
                DdlPrograma.DataSource = programas;
                DdlPrograma.DataBind();

                DdlPrograma.SelectedValue = programas[0].Value;

                MostrarReportes();
            }
            else
            {

            }
        }

        protected void DdlPrograma_Changed(object sender, EventArgs e)
        {
            if (DdlPrograma.SelectedValue != "0")
            {
                MostrarReportes();

            }
            else
            {
                Div.Visible = false;
            }


        }

        private void MostrarReportes()
        {
            string programa = "";
            //  Session["Programa"] = DdlPrograma.SelectedValue;

            this.DetalleIngresos.NavigateUrl = "";
            this.ServiciosDiarios.NavigateUrl = "";
            this.AgeingReport.NavigateUrl = "";
            this.ParticipantesPrograma.NavigateUrl = "";

           

            Div.Visible = true;

            switch (DdlPrograma.SelectedValue)
            {
                case "61":
                    programa = "SanJuan";
                    break;
                case "62":
                    programa = "Ponce";
                    break;
                case "63":
                    programa = "Mayaguez";
                    break;
                case "64":
                    programa = "Arecibo";
                    break;
                case "65":
                    programa = "Moca";
                    break;
                case "66":
                    programa = "Guayama";
                    break;
            }

            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            string URL_ReportingServices = ((string)(configurationAppSettings.GetValue("URL_ReportingServices", typeof(string))));
            string Folder_ReportingServices = ((string)(configurationAppSettings.GetValue("Folder_ReportingServices", typeof(string))));
            this.Session["URL_Reports"] = URL_ReportingServices + "?/" + Folder_ReportingServices + "/";

            this.DetalleIngresos.NavigateUrl = this.Session["URL_Reports"].ToString() + "DetalleIngresos_" + programa + "_Prueba";
            this.ServiciosDiarios.NavigateUrl = this.Session["URL_Reports"].ToString() + "ServiciosDiariosCobrados_" + programa + "_Prueba";
            this.AgeingReport.NavigateUrl = this.Session["URL_Reports"].ToString() + "AgeingReport_Prueba&Programa=" + DdlPrograma.SelectedValue;
            this.ParticipantesPrograma.NavigateUrl = this.Session["URL_Reports"].ToString() + "ReporteParticipantePrograma_Prueba&FK_Programa=" + DdlPrograma.SelectedValue;
            
        }

        
    }

    
}