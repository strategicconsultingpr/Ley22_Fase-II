using Ley22_WebApp_V2.Old_App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class wucTakeHome : System.Web.UI.UserControl
    {
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;
        protected SA_PROGRAMA sa_programa;
        protected int participa, etapa;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dsPerfil = new SEPSEntities1();
                this.vw_perfil = (VW_PERFIL)Session["vw_perfil"];
                this.vw_episodio = (VW_EPISODIO)Session["vw_episodio"];
                this.vw_persona = (VW_PERSONA)Session["vw_persona"];
                this.sa_programa = (SA_PROGRAMA)Session["sa_programa"];

                if (!EsProgramaMetadona(Convert.ToInt32(sa_programa.PK_Programa.ToString())))
                {
                    this.divTakeHome.Visible = false;
                    this.divTakeHome.Disabled = true;
                }
                else
                {
                    
                    this.setValues();
                   // lbxRazon();                                       
                    //if(etapa != 1)
                    //{
                    //    lblTHEtapa.Text = etapa.ToString();
                    //}
                    //lblTHBelong.Text = participa.ToString();
                }

            }
        }

        public bool EsProgramaMetadona(int PK_PROGRAMA)
        {
            bool esProgramaMetadona = false;
            switch ((PKPrograma)PK_PROGRAMA)
            {
                case (PKPrograma.CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_SAN_JUAN):     // PK_Programa =  1
                case (PKPrograma.CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_CAGUAS):       // PK_Programa =  2
                case (PKPrograma.CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_PONCE):        // PK_Programa =  3
                case (PKPrograma.CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_AGUADILLA):    // PK_Programa =  4
                case (PKPrograma.CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_BAYAMÓN):      // PK_Programa =  6
                case (PKPrograma.CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_CAYEY):        // PK_Programa = 43
                    esProgramaMetadona = true; break;
                default: break;
            }
            return esProgramaMetadona;
        }

        public void setValues()
        {
            //var Dref = from m in dsPerfil.SA_Metadona.Where(u => u.FK_Perfil.Equals(vw_perfil.PK_NR_Perfil))
            //           join f in dsPerfil.SA_LKP_TakeHomeFrecuenciaBotellas
            //           on m.FK_FrecuenciaBotellas equals Convert.ToInt32(f.PK_Frecuencia.ToString())
            //           into a from b in a.DefaultIfEmpty()
            //           select new { m.FK_Participa, m.FK_Etapa, m.FE_Entrada, m.FE_Salida, m.NR_Botellas, m.FK_FrecuenciaBotellas,
            //               DE_FrecuenciaBotellas = b.DE_Frecuencia };
            // var Dref = Dref2.Select(u => new { u.FK_Participa, u.FK_Etapa, u.FE_Entrada, u.FE_Salida, u.NR_Botellas, u.FK_FrecuenciaBotellas, u.DE_FrecuenciaBotellas }).Single(); 
            // participa = Convert.ToInt32(Dref.FirstOrDefault().FK_Participa.ToString());
            // etapa = Convert.ToInt32(Dref.FirstOrDefault().FK_Etapa.ToString());

            var Dref2 = from m in dsPerfil.SA_Metadona
                       join f in dsPerfil.SA_LKP_TakeHomeFrecuenciaBotellas
                       on m.FK_FrecuenciaBotellas equals f.PK_Frecuencia
                       into a
                       from b in a.DefaultIfEmpty()
                       select new
                       {   m.FK_Perfil,
                           m.FK_Participa,
                           m.FK_Etapa,
                           m.FE_Entrada,
                           m.FE_Salida,
                           m.NR_Botellas,
                           m.FK_FrecuenciaBotellas,
                           DE_FrecuenciaBotellas = b.DE_Frecuencia
                       };
            
            var Dref = from m in Dref2 where m.FK_Perfil == vw_perfil.PK_NR_Perfil select new { m.FK_Participa, m.FK_Etapa,m.FE_Entrada, m.FE_Salida, m.NR_Botellas, m.FK_FrecuenciaBotellas, m.DE_FrecuenciaBotellas };
           // participa = Convert.ToInt32(Dref.)
            try
            {
                if (Dref.ToList().Count() > 0)
                {                                       
                        if (Dref.First().FE_Entrada != null)
                        {
                            lblFE_In.Text = ((DateTime)Dref.First().FE_Entrada).ToShortDateString();
                        }
                        else
                        {
                            lblFE_In.Text = "No disponible";
                        }
                        if (Dref.First().FE_Salida != null)
                        {
                            lblFE_Out.Text = ((DateTime)Dref.First().FE_Salida).ToShortDateString();
                        }
                        else
                        {
                            lblFE_Out.Text = "No dispobible";
                        }
                        if (Dref.First().NR_Botellas != null)
                        {
                            this.lblCantidadBotellas.Text = Dref.First().NR_Botellas.ToString();
                        }
                        if (Dref.First().FK_FrecuenciaBotellas != null)
                        {
                            this.lblFrecuenciaBotellas.Text = Dref.First().FK_FrecuenciaBotellas.ToString();
                        }                    
                    
                }
                lbxRazon(Convert.ToInt32(Dref.First().FK_Participa));
                if (Convert.ToInt32(Dref.First().FK_Etapa) != 1)
                {
                    lblTHEtapa.Text = Dref.First().FK_Etapa.ToString();
                }
                lblTHBelong.Text = Dref.First().FK_Participa.ToString();

                
            }
            catch (Exception ex)
            {
                Trace.Write("setValues()::" + ex.Message);
                throw ex;
            }
        }

        private void lbxRazon(int participa)
        {
            
                if (participa == 2/*=No*/)
                {
                    string selectedValuesString = "";

                    var fk_razon = dsPerfil.SA_Ref_RazonTH.Where(p => p.FK_Perfil.Equals(vw_perfil.PK_NR_Perfil)).Select(u => u.FK_Razon);
                    var Dref = dsPerfil.SA_LKP_RAZONTH.Where(p => fk_razon.Contains(p.PK_RAZON)).Select(u => new ListItem { Value = u.PK_RAZON.ToString(), Text = u.DE_RAZON }).ToList();


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
                    lblRazon.Text = selectedValuesString;

                divParticipa.Visible = false;
                divLblRazon.Visible = true;
                }
                else
                {
                divParticipa.Visible = true;
                divLblRazon.Visible = false;
                }                      
        }
    }
}