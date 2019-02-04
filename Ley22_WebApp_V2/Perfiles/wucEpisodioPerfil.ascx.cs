using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class wucEpisodioPerfil : System.Web.UI.UserControl
    {
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;
        protected SA_PROGRAMA sa_programa;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dsPerfil = new SEPSEntities1();
                this.vw_perfil = (VW_PERFIL)Session["vw_perfil"];
                this.vw_episodio = (VW_EPISODIO)Session["vw_episodio"];
                this.vw_persona = (VW_PERSONA)Session["vw_persona"];
                this.sa_programa = (SA_PROGRAMA)Session["sa_programa"];

                ManagePracticasBasadasEnEvidencia();
                LbxCondicionesDiagnosticadas();
                LeerRegistro();

            }
        }

        private void LeerRegistro()
        {          

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
            //if (this.hDSMVClinPrim.Value == "")
            //{
            //    this.hDSMVClinPrim.Value = "761";
            //}
            //if (this.hDSMVClinSec.Value == "")
            //{
            //    this.hDSMVClinSec.Value = "761";
            //}
            //if (this.hDSMVClinTer.Value == "")
            //{
            //    this.hDSMVClinTer.Value = "761";
            //}
            //if (this.hDSMVRMPrim.Value == "")
            //{
            //    this.hDSMVRMPrim.Value = "761";
            //}
            //if (this.hDSMVRMSec.Value == "")
            //{
            //    this.hDSMVRMSec.Value = "761";
            //}
            //if (this.hDSMVRMTer.Value == "")
            //{
            //    this.hDSMVRMTer.Value = "761";
            //}
            this.lblDSMVFnGlobal.Text = this.vw_perfil.NR_DSMV_FuncionamientoGlobal;
            this.lblDSMVOtrasObs.Text = this.vw_perfil.DE_DSMV_OtrasObservaciones;
            this.lblDSMVComentarios.Text = this.vw_perfil.DE_DSMV_Comentarios;
            #endregion
            this.lblDrogaPrim.Text = this.vw_perfil.DE_Droga_P;
            this.lblDrogaSec.Text = this.vw_perfil.DE_Droga_S;
            this.lblDrogaTerc.Text = this.vw_perfil.DE_Droga_T;
            this.lblEdadPrim.Text = this.vw_perfil.IN_EdadInicioPrimario.ToString();
            this.lblEdadSec.Text = this.vw_perfil.IN_EdadInicioSecundario.ToString();
            this.lblEdadTerc.Text = this.vw_perfil.IN_EdadInicioTerciario.ToString();
            this.lblEscalaGAF.Text = this.vw_perfil.NR_EscalaGAF.ToString();
            this.lblFrecPrim.Text = this.vw_perfil.DE_Frecuencia_P;
            this.lblFrecSec.Text = this.vw_perfil.DE_Frecuencia_S;
            this.lblFrecTerc.Text = this.vw_perfil.DE_Frecuencia_T;
            this.lblNivelCuidadoSaludMental.Text = this.vw_episodio.DE_SaludMental;
            this.lblNivelCuidadoSustancias.Text = this.vw_episodio.DE_AbusoSustancias;
            this.lblViaPrim.Text = this.vw_perfil.DE_Via_P;
            this.lblViaSec.Text = this.vw_perfil.DE_Via_S;
            this.lblViaTerc.Text = this.vw_perfil.DE_Via_T;
        }

        private void ManagePracticasBasadasEnEvidencia()
        {
            if (EsProgramaMental(Convert.ToInt32(this.sa_programa.PK_Programa.ToString())))
            {
                PKAdministracion pkAdmin = (PKAdministracion)Convert.ToInt32(this.vw_episodio.PK_Administracion.ToString());                                
                    
                        divPracticasBasadasEnEvidencia.Visible = true;
                        divPracticasBasadasEnEvidencia.Disabled = false;
                       
                        if (pkAdmin == PKAdministracion.NinosYAdolecentes)
                        {
                            h3PracticasBasadasEnEvidenciaNinoOAdulto.InnerText = "Niños y adolescentes";
                            LbxPracticasBasadasEvidencia();
                        }
                        else
                        {
                            h3PracticasBasadasEnEvidenciaNinoOAdulto.InnerText = "Adultos";
                            LbxPracticasBasadasEvidencia("Adultos");
                        }            
            }
            else
            {
                divPracticasBasadasEnEvidencia.Visible = false;
                divPracticasBasadasEnEvidencia.Disabled = true;
            }
        }

        private void LbxCondicionesDiagnosticadas()
        {
            string selectedValuesString = "";

            var fk_diagnostico = dsPerfil.SA_Ref_CondicionesDiagnosticadas.Where(p => p.FK_Perfil.Equals(vw_perfil.PK_NR_Perfil)).Select(u => u.FK_Diagnostico);
            var Dref = dsPerfil.SA_LKP_DIAGNOSTICO.Where(p => fk_diagnostico.Contains(p.PK_Diagnostico)).Select(u => new ListItem { Value = u.PK_Diagnostico.ToString(), Text = u.DE_Diagnostico }).ToList();

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

            lblCondicionesDiagnosticadas.Text = selectedValuesString;
        }

        private void LbxPracticasBasadasEvidencia(string adultos = "")
        {
            
            string selectedValuesString = "";
               
            var fk_practica = dsPerfil.SA_Ref_PracticasBasadasEnEvidencia.Where(p => p.FK_Perfil.Equals(vw_perfil.PK_NR_Perfil)).Select(u => u.FK_Practica);
            var Dref = dsPerfil.SA_LKP_PracticasBasadasEnEvidencia.Where(p => fk_practica.Contains(p.PK_Practica)).Select(u => new ListItem { Value = u.PK_Practica.ToString(), Text = u.DE_Practica }).ToList();

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
            lblPracticasBasadasEvidencia.Text = selectedValuesString;

        }

        public bool EsProgramaMental(int pkPrograma)
        {
            bool esProgramaMental = false;
            switch (pkPrograma)
            {
                case (116):
                case (120):
                case (115):
                case (119):
                case (76):
                case (59):
                case (60):
                case (58):
                case (12):
                case (57):
                case (87):
                case (56):
                case (85):
                case (81):
                case (82):
                case (15):
                case (129):
                case (131):
                case (130):
                case (79):
                case (117):
                case (122):

                case (138):
                case (139):
                case (141):
                case (142):
                case (143):
                case (144):
                case (145):
                case (146):
                case (149):
                case (150):
                case (151):
                case (152):
                case (153):
                case (154):
                case (155):
                case (156):
                case (157):
                case (158):
                case (160):
                case (163):
                case (166):

                    esProgramaMental = true; break;
                default: break;
            }
            return esProgramaMental;
        }
    }
}