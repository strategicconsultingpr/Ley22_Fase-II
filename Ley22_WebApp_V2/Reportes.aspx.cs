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
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            string URL_ReportingServices = ((string)(configurationAppSettings.GetValue("URL_ReportingServices", typeof(string))));
            string Folder_ReportingServices = ((string)(configurationAppSettings.GetValue("Folder_ReportingServices", typeof(string))));
            this.Session["URL_Reports"] = URL_ReportingServices + "?/" + Folder_ReportingServices + "/";
            this.ReporteSemanal_l.NavigateUrl = this.Session["URL_Reports"].ToString() + this.ReporteSemanal_l.NavigateUrl.ToString();
        }
    }
}