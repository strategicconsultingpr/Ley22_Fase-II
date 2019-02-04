using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class wucDatosDemograficosPerfil : System.Web.UI.UserControl
    {
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dsPerfil = new SEPSEntities1();
                this.vw_perfil = (VW_PERFIL)Session["vw_perfil"];
                this.vw_episodio = (VW_EPISODIO)Session["vw_episodio"];
                this.vw_persona = (VW_PERSONA)Session["vw_persona"];

                lbxCompFamiliar();
                LeerRegistro();

            }
        }

        private void lbxCompFamiliar()
        {
            string selectedValuesString = "";
            var fk_compfamilia = dsPerfil.SA_Ref_CompFamilia.Where(p => p.FK_Perfil.Equals(vw_perfil.PK_NR_Perfil)).Select(u => u.FK_CompFamilia);
            var Dref = dsPerfil.SA_LKP_COMPOSICION_FAMILIAR.Where(p => fk_compfamilia.Contains(p.PK_Familiar)).Select(u => new ListItem { Value = u.PK_Familiar.ToString(), Text = u.DE_Familiar }).ToList();

            if (Dref.Count > 0)
            {
                foreach (var item in Dref)
                {
                    selectedValuesString += item.Text + ", ";
                }

                selectedValuesString = selectedValuesString.Substring(0, selectedValuesString.Length - 2);
            }
            else
            {
                selectedValuesString = "No hay valores seleccionados";
            }

            lblCompFamiliar.Text = selectedValuesString;
        }

        private void LeerRegistro()
        {
            this.lblArrestado.Text = this.vw_perfil.DE_Arrestado30dias;
            this.lblArrestos30.Text = this.vw_perfil.NR_Arrestos30dias.ToString();
            this.lblSituacionEscolar.Text = this.vw_perfil.DE_SituacionEscolar;
            this.lblCondLaboral.Text = this.vw_perfil.DE_CondLaboral;
            this.lblDesertorEscolar.Text = this.vw_perfil.DE_DesertorEscolar;
            this.lblEducacionEspecial.Text = this.vw_perfil.DE_EducEspecial;
            this.lblEstadoMarital.Text = this.vw_perfil.DE_EstadoMarital;
            this.lblGrado.Text = this.vw_perfil.DE_Grado;
            this.lblNoFueraLaboral.Text = this.vw_perfil.DE_NoFuerzaLaboral;
            this.lblNumFamilia.Text = this.vw_perfil.NR_Familiar.ToString();
            this.lblNumNinos.Text = this.vw_perfil.NR_Hijos.ToString();
            this.lblResidencia.Text = this.vw_perfil.DE_Residencia;
            this.lblFreq_AutoAyuda.Text = this.vw_perfil.DE_FreqAutoAyuda; 
        }
    }
}