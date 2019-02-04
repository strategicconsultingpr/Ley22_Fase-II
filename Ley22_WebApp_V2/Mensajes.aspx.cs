using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;

public partial class Mensajes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Session["TipodeAlerta"] = 4;
        //Session["MensajeError"] = "mi emnsaje";

        if (!Page.IsPostBack)
        {

            LitMensaje.Text = Session["MensajeError"].ToString();
            int TipodeAlerta = (int)Session["TipodeAlerta"];
            string TipoAlertaCss=string.Empty;
            switch (TipodeAlerta)
            {
                case ConstTipoAlerta.Success:   //  Success
                    TipoAlertaCss = "alert alert-success mb-4";
                    break;
                case ConstTipoAlerta.Info: //info
                    TipoAlertaCss = "alert alert-info mb-4";
                    break;
                case ConstTipoAlerta.Warning:     //warning
                    TipoAlertaCss = "alert alert-warning mb-4";
                    break;
                case ConstTipoAlerta.Danger:       //danger
                    TipoAlertaCss = "alert alert-danger mb-4";
                    break;
            }
            ColorBarra.Attributes["class"]=TipoAlertaCss;



        }
    }
}