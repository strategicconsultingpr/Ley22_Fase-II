using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;

public partial class WUC_WUCRegion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack )
            using (Ley22Entities mylib = new Ley22Entities())
            {
                DdlRegion.DataTextField = "Region";
                DdlRegion.DataValueField = "Id_Region";
                DdlRegion.DataSource = mylib.sp_READALL_Regiones();
                DdlRegion.DataBind();
                DdlRegion.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
    }

    protected void DdlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}