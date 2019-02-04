using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class wucEpisodioAdmision : System.Web.UI.UserControl
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

                lbxMaltrato();
                lbxProbJusticia();
                LeerRegistro();

            }

        }

        private void LeerRegistro()
        {
            this.lblArrestado.Text = this.vw_episodio.DE_ArrestadoAnteriormente;
            this.lblArrestado30.Text = this.vw_perfil.DE_Arrestado30dias;
            this.lblArrestos30.Text = this.vw_perfil.NR_Arrestos30dias.ToString();

            //DSM IV if its available
            this.lblClinPrim.Text = this.vw_perfil.DE_DSMIV_TCP;
            this.lblClinSec.Text = this.vw_perfil.DE_DSMIV_TCS;
            this.lblClinTerc.Text = this.vw_perfil.DE_DSMIV_TCT;
            this.lblRMPrim.Text = this.vw_perfil.DE_DSMIV_TPP;
            this.lblRMSec.Text = this.vw_perfil.DE_DSMIV_TPS;
            this.lblRMTerc.Text = this.vw_perfil.DE_DSMIV_TPT;
            this.lblIIIP.Text = this.vw_perfil.CO_CondicionesMedicasPrimario;
            this.lblIIIS.Text = this.vw_perfil.CO_CondicionesMedicasSecundario;
            this.lblIIIT.Text = this.vw_perfil.CO_CondicionesMedicasTerciario;
            this.lblIVPrim.Text = this.vw_perfil.DE_DSMIV_IV_P;
            this.lblIVSec.Text = this.vw_perfil.DE_DSMIV_IV_S;
            this.lblIVTerc.Text = this.vw_perfil.DE_DSMIV_IV_T;
            this.lblDual.Text = this.vw_episodio.DE_DiagnosticoDual;
            this.lblEscalaGAF.Text = this.vw_perfil.NR_EscalaGAF.ToString();
            if ((this.lblIVPrim.Text == "") && (this.lblIVSec.Text == "") && (this.lblIVTerc.Text == "") && (this.lblClinPrim.Text == "") && (this.lblClinSec.Text == "") && (this.lblClinTerc.Text == "") && (this.lblRMPrim.Text == "") && (this.lblRMSec.Text == "") && (this.lblRMTerc.Text == ""))
            {
                DSMIV_DIV.Visible = false;
            }

            #region DSMV
            this.lblDSMVClinPrim.Text = this.vw_perfil.DE_DSMV_TrastornosClinicos1;
            this.lblDSMVClinSec.Text = this.vw_perfil.DE_DSMV_TrastornosClinicos2;
            this.lblDSMVClinTer.Text = this.vw_perfil.DE_DSMV_TrastornosClinicos3;
            this.lblDSMVRMPrim.Text = this.vw_perfil.DE_DSMV_TrastornosPersonalidadRM1;
            this.lblDSMVRMSec.Text = this.vw_perfil.DE_DSMV_TrastornosPersonalidadRM2;
            this.lblDSMVRMTer.Text = this.vw_perfil.DE_DSMV_TrastornosPersonalidadRM3;
            this.lblDSMVPsicoAmbiPrim.Text = this.vw_perfil.DE_DSMV_ProblemasPsicosocialesAmbientales1;
            this.lblDSMVPsicoAmbiSec.Text = this.vw_perfil.DE_DSMV_ProblemasPsicosocialesAmbientales2;
            this.lblDSMVPsicoAmbiTer.Text = this.vw_perfil.DE_DSMV_ProblemasPsicosocialesAmbientales3;
            this.lblDSMVDiagDual.Text = this.vw_perfil.DE_DSMV_DiagnosticoDual;

            this.lblDSMVFnGlobal.Text = this.vw_perfil.NR_DSMV_FuncionamientoGlobal;
            this.lblDSMVOtrasObs.Text = this.vw_perfil.DE_DSMV_OtrasObservaciones;
            this.lblDSMVComentarios.Text = this.vw_perfil.DE_DSMV_Comentarios;
            #endregion
            this.lblCodependiente.Text = this.vw_episodio.DE_CodDependiente;
            this.lblDíasMental.Text = this.vw_episodio.NR_DiasEsperaMental.ToString();
            this.lblDíasMentUlt.Text = this.vw_episodio.NR_DiasUltimaAltaMental.ToString();
            this.lblDíasSustancias.Text = this.vw_episodio.NR_DiasEsperaSustancias.ToString();
            this.lblDíasSustUlt.Text = this.vw_episodio.NR_DiasUltimaAltaSustancias.ToString();
            this.lblDrogaPrim.Text = this.vw_perfil.DE_Droga_P;
            this.lblDrogaSec.Text = this.vw_perfil.DE_Droga_S;
            this.lblDrogaTerc.Text = this.vw_perfil.DE_Droga_T;
            this.lblEdadPrim.Text = this.vw_perfil.IN_EdadInicioPrimario.ToString();
            this.lblEdadSec.Text = this.vw_perfil.IN_EdadInicioSecundario.ToString();
            this.lblEdadTerc.Text = this.vw_perfil.IN_EdadInicioTerciario.ToString();
            this.lblEstadoLegal.Text = this.vw_episodio.DE_EstadoLegal;
            this.lblEtapaServicio.Text = this.vw_episodio.DE_EtapaServicio;
            this.lblFrecPrim.Text = this.vw_perfil.DE_Frecuencia_P;
            this.lblFrecSec.Text = this.vw_perfil.DE_Frecuencia_S;
            this.lblFrecTerc.Text = this.vw_perfil.DE_Frecuencia_T;
            this.lblFuenteReferido.Text = this.vw_episodio.DE_Referido;
            this.lblMaltratoNinez.Text = this.vw_episodio.DE_Maltrato;
            this.lblMesesMentUlt.Text = this.vw_episodio.NR_MesesUltimaAltaMental.ToString();
            this.lblMesesSustUlt.Text = this.vw_episodio.NR_MesesUltimaAltaSustancias.ToString();
            this.lblMetadona.Text = this.vw_episodio.DE_Metadona;
            this.lblNivelCuidadoSaludMental.Text = this.vw_episodio.DE_SaludMental;
            this.lblNivelCuidadoSustancias.Text = this.vw_episodio.DE_AbusoSustancias;
            this.lblNivelSustancias.Text = this.vw_episodio.DE_AbusoSustanciasAnterior;
            this.lblNivelMental.Text = this.vw_episodio.DE_SaludMentalAnterior;
            this.lblPreviosMental.Text = this.vw_episodio.DE_EpisodiosPreviosMental;
            this.lblPreviosSustancias.Text = this.vw_episodio.DE_EpisodiosPreviosSustancias;
            this.lblFreq_AutoAyuda.Text = this.vw_perfil.DE_FreqAutoAyuda;
            this.lblReunionesGrupos.Text = this.vw_perfil.DE_ParticReunGrupos;
            this.lblSuicidios.Text = this.vw_episodio.DE_Suicida;
            this.lblIdeaSuicida.Text = this.vw_episodio.DE_IdeaSuicida;
            this.lblUltMental.Text = this.vw_episodio.DE_TiempoUltTratMental;
            this.lblUltSustancias.Text = this.vw_episodio.DE_TiempoUltTratSustancias;
            this.lblViaPrim.Text = this.vw_perfil.DE_Via_P;
            this.lblViaSec.Text = this.vw_perfil.DE_Via_S;
            this.lblViaTerc.Text = this.vw_perfil.DE_Via_T;
            this.lblVioDomestic.Text = this.vw_episodio.DE_ViolenciaDomestica;
        }

        private void lbxMaltrato()
        {
            string selectedValuesString = "";
            var fk_maltrato = dsPerfil.SA_Ref_Maltrato.Where(p => p.FK_Episodio.Equals(vw_episodio.PK_Episodio)).Select(u => u.FK_Maltrato);
            var Dref = dsPerfil.SA_LKP_MALTRATO.Where(p => fk_maltrato.Contains(p.PK_Maltrato)).Select(u => new ListItem { Value = u.PK_Maltrato.ToString(), Text = u.DE_Maltrato }).ToList();

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

            lblMaltrato.Text = selectedValuesString;
        }

        private void lbxProbJusticia()
        {
            string selectedValuesString = "";
            var fk_probjusticia = dsPerfil.SA_Ref_ProbJusticia.Where(p => p.FK_Episodio.Equals(vw_episodio.PK_Episodio)).Select(u => u.FK_ProbJusticia);
            var Dref = dsPerfil.SA_LKP_PROBLEMA_JUSTICIA.Where(p => fk_probjusticia.Contains(p.PK_ProbJusticia)).Select(u => new ListItem { Value = u.PK_ProbJusticia.ToString(), Text = u.DE_ProbJusticia }).ToList();

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

            lblProbJusticia.Text = selectedValuesString;
        }
    }
}