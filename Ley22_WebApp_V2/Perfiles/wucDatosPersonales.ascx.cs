
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Ley22_WebApp_V2.Old_App_Code;


    public partial class wucDatosPersonales : System.Web.UI.UserControl
    {
        protected SEPSEntities1 dsPerfil;
        protected VW_PERFIL vw_perfil;
        protected VW_EPISODIO vw_episodio;
        protected VW_PERSONA vw_persona;
        private bool tieneConvenio;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.vw_perfil = (VW_PERFIL)Session["vw_perfil"];
            this.vw_episodio = (VW_EPISODIO)Session["vw_episodio"];
            this.vw_persona = (VW_PERSONA)Session["vw_persona"];
            if (!this.IsPostBack)
            {
                this.dsPerfil = new SEPSEntities1();

            this.lblUID.Text = vw_persona.PK_Persona.ToString();
            this.lblExpediente.Text = "Hay que buscar";
            this.lblNSS.Text = vw_persona.NR_SeguroSocial;
            this.lblSexo.Text = vw_persona.DE_Sexo;
            this.lblPrimerApellido.Text = vw_persona.AP_Primero;
            this.lblSegundoApellido.Text = vw_persona.AP_Segundo;
            this.lblPrimerNombre.Text = vw_persona.NB_Primero;
            this.lblSegundoNombre.Text = vw_persona.NB_Segundo;
            this.lblFENacimiento.Text = DateTime.Parse(vw_persona.FE_Nacimiento.ToString()).ToShortDateString();
            this.lblEdad.Text = vw_persona.NR_Edad.ToString();
            this.lblVeterano.Text = vw_persona.DE_Veterano;
            this.lblGrupoEtnico.Text = vw_persona.DE_GrupoEtnico;

                //datospersonalesInfo.DataSource = this.vw_persona;
                //datospersonalesInfo.DataBind();
            this.lblFechaAdmision.Visible = true;
                //this.lblExpediente.Visible = true;
                //this.txtExpediente.Visible = false;
                this.ddlTipoDeAdmision.Visible = false;
                this.ddlMes.Visible = false;
                this.ddlDía.Visible = false;
                this.txtAño.Visible = false;
                this.ddlFechaConvenioDía.Visible = false;
                this.ddlFechaConvenioMes.Visible = false;
                this.txtFechaConvenioAño.Visible = false;

                this.lblFechaAdmision.Text = DateTime.Parse(this.vw_episodio.FE_Episodio.ToString()).ToShortDateString();

                this.load();
                dataRead();
            }
        }

        public void load()
        {
            ddlGeneroAll();
            ddlMilitarAll();
            ddlTipoDeAdmisionAll();
            this.setValues();
        }

        private void dataRead()
        {
            ddlGenero.Visible = false;
            ddlMilitar.Visible = false;
            ddlFamiliaMilitar.Visible = false;
            lblFamMilitar.Text = ddlFamiliaMilitar.SelectedItem.Text;
            lblMilitar.Text = ddlMilitar.SelectedItem.Text;
            lblGenero.Text = ddlGenero.SelectedItem.Text;
            if (tieneConvenio)
            {
                try
                {
                    lblFechaConvenio.Text = DateTime.Parse(vw_episodio.FE_FechaConvenio.ToString()).ToShortDateString();
                }
                catch { }
            }

            lblTipoDeAdmision.Text = ddlTipoDeAdmision.SelectedItem.Text;

        }

        private void ddlGeneroAll()
        {
            var generos = dsPerfil.SA_LKP_GENERO.Where(u => u.Active == true).Select(r => new ListItem { Value = r.PK_Genero.ToString(), Text = r.DE_Genero }).ToList();
            this.ddlGenero.DataSource = generos;
            this.ddlGenero.DataValueField = "Value";
            this.ddlGenero.DataTextField = "Text";
            this.ddlGenero.ClearSelection();
            try
            {
                this.ddlGenero.DataBind();
            }
            catch
            {
                this.ddlGenero.SelectedValue = "";
            }
        }

        private void ddlMilitarAll()
        {
            var militar = dsPerfil.SA_LKP_MILITAR.Where(u => u.Active == true).Select(r => new ListItem { Value = r.PK_MILITAR.ToString(), Text = r.DE_MILITAR }).ToList();
            this.ddlMilitar.DataSource = militar;
            this.ddlMilitar.DataValueField = "Value";
            this.ddlMilitar.DataTextField = "Text";
            try
            {
                this.ddlMilitar.DataBind();
            }
            catch
            {
                this.ddlMilitar.SelectedValue = "";
            }
        }

        private void ddlTipoDeAdmisionAll()
        {
            var tipo = dsPerfil.SA_LKP_TEDS_TIPO_ADMISION.Select(r => new ListItem { Value = r.PK_TipoAdmision.ToString(), Text = r.DE_TipoAdmision }).ToList();
            this.ddlTipoDeAdmision.DataSource = tipo;
            this.ddlTipoDeAdmision.DataValueField = "Value";
            this.ddlTipoDeAdmision.DataTextField = "Text";
            this.ddlTipoDeAdmision.DataBind();
        }

        public void setValues()
        {
            this.dsPerfil = new SEPSEntities1();
            var newdata = dsPerfil.SA_NewData.Where(u => u.FK_Perfil.Equals(vw_perfil.PK_NR_Perfil)).FirstOrDefault();
            var tipo = vw_perfil.FK_TipoAdmision;

            if (newdata != null)
            {
                ddlMilitar.ClearSelection();
                ddlFamiliaMilitar.ClearSelection();
                ddlGenero.ClearSelection();
                ddlMilitar.SelectedValue = newdata.FK_Militar.ToString();
                ddlFamiliaMilitar.SelectedValue = newdata.FK_FamMilitar.ToString();
                ddlGenero.SelectedValue = newdata.FK_Genero.ToString();
            }

            if (tipo != null)
            {
                if (tipo.ToString() != "0")
                {
                    ddlTipoDeAdmision.ClearSelection();
                    ddlTipoDeAdmision.SelectedValue = tipo.ToString();
                }
                else
                {
                    ddlTipoDeAdmision.ClearSelection();
                }
            }

        }

        public bool TieneConvenio(int PK_PROGRAMA)
        {
            bool tieneConvenio = EsProgramaDesvio(PK_PROGRAMA);
            return tieneConvenio;
        }

        public bool EsProgramaDesvio(int PK_PROGRAMA)
        {
            bool esProgramaDesvio = false;
            switch ((PKPrograma)PK_PROGRAMA)
            {
                case (PKPrograma.TASC_SAN_JUAN):
                case (PKPrograma.TASC_BAYAMÓN):
                case (PKPrograma.TASC_AIBONITO):
                case (PKPrograma.TASC_CAGUAS):
                case (PKPrograma.TASC_MOCA):
                case (PKPrograma.TASC_MAYAGUEZ):
                case (PKPrograma.TASC_GUAYAMA):
                case (PKPrograma.TASC_ARECIBO):
                case (PKPrograma.TASC_FAJARDO):
                case (PKPrograma.TASC_HUMACAO):
                case (PKPrograma.TASC_UTUADO):
                case (PKPrograma.TASC_PONCE):
                case (PKPrograma.TASC_CAROLINA):
                case (PKPrograma.TASC_JUVENIL_SAN_JUAN):
                case (PKPrograma.TASC_JUVENIL_CAGUAS):
                case (PKPrograma.TASC_JUVENIL_ARECIBO):
                case (PKPrograma.TASC_JUVENIL_DE_BAYAMON):
                case (PKPrograma.AMBULATORIO_ADULTOS_ARECIBO):
                case (PKPrograma.AMBULATORIO_ADULTOS_CAROLINA):
                case (PKPrograma.AMBULATORIO_DROGAS_DE_GUAYAMA):
                case (PKPrograma.AMBULATORIO_ADULTOS_HUMACAO):
                case (PKPrograma.AMBULATORIO_ADULTOS_MAYAGUEZ):
                case (PKPrograma.AMBULATORIO_ADULTOS_PONCE):
                case (PKPrograma.AMBULATORIO_ADULTOS_SAN_JUAN):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_ARECIBO):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_BAYAMÓN):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_CAGUAS):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_CAROLINA):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_FAJARDO):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_GUAYAMA):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_HUMACAO):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_MAYAGUEZ):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_PONCE):
                case (PKPrograma.PROGRAMA_DE_CORTE_DE_DROGA_DE_SAN_JUAN):
                    esProgramaDesvio = true; break;
                default: break;
            }
            return esProgramaDesvio;
        }


        protected void lblFENacimiento_Load(object sender, EventArgs e)
        {   
            //string FechaNacimiento = lblFENacimiento.Text;
            //int Tamaño = FechaNacimiento.Length;
            //int indice = FechaNacimiento.IndexOf("/", 0);
            //int indice2 = FechaNacimiento.LastIndexOf("/", indice);
            //int indice3 = FechaNacimiento.LastIndexOf("/", Tamaño);
            //Session["Mes"] = FechaNacimiento.Substring(0, indice).ToString();
            //Session["dia"] = FechaNacimiento.Substring((indice + 1), (indice2 - 1)).ToString();
            //Session["año"] = FechaNacimiento.Substring((indice3 + 1), 4).ToString();
            //ddlMesHidden.Value = Session["Mes"].ToString();
            //ddlDíaHidden.Value = Session["dia"].ToString();
            //txtAñoHidden.Value = Session["año"].ToString();
            //this.lblFENacimientoHidden.Value = this.lblFENacimiento.Text;

        }

        protected void lblEdad_Load(object sender, EventArgs e)
        {
            //Session["edad"] = lblEdad.Text;
        }

        public VW_PERFIL Perfil
        {
            set
            {
                try
                {
                    this.vw_perfil = value;
                }
                catch { }
            }
        }

        public VW_PERSONA Persona
        {
            set
            {
                try
                {
                    this.vw_persona = value;
                }
                catch { }
            }
        }

    public enum PKPrograma { CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_SAN_JUAN = 1, CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_CAGUAS = 2, CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_PONCE = 3, CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_AGUADILLA = 4, RESIDENCIAL_DE_MUJERES_SAN_JUAN = 5, CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_BAYAMÓN = 6, AMBULATORIO_ADULTOS_SAN_JUAN = 7, AMBULATORIO_ADULTOS_CAGUAS = 8, AMBULATORIO_ADULTOS_PONCE = 9, AMBULATORIO_ADULTOS_ARECIBO = 10, AMBULATORIO_ADULTOS_MANATÍ = 11, TRATAMIENTO_AMBULATORIO_MENORES_CAGUAS = 12, CENTRO_DE_SALUD_MENTAL_MAYAGUEZ_NIÑOS_Y_ADOLESCENTES = 13, TRATAMIENTO_AMBULATORIO_MENORES_ARECIBO = 14, TRATAMIENTO_AMBULATORIO_MENORES_BAYAMÓN = 15, ALCOHOLISMO_AMBULATORIO_CAGUAS = 16, ALCOHOLISMO_AMBULATORIO_ARECIBO = 17, ALCOHOLISMO_AMBULATORIO_PONCE = 18, ALCOHOLISMO_AMBULATORIO_RIO_PIEDRAS = 19, ALCOHOLISMO_EMERGENCIA_SAN_JUAN = 20, CENTRO_DETOX_SAN_JUAN = 21, CENTRO_DETOX_CAGUAS_EVALUACIÓN = 22, CENTRO_DETOX_PONCE_EVALUACIÓN_Y_DETOX = 23, CENTRO_DETOX_MAYAGUEZ_EVALUACIÓN = 24, CENTRO_DETOX_ARECIBO_EVALUACIÓN = 25, UNIDAD_CENTRAL_DE_ADMISIONES = 26, TASC_AIBONITO = 27, PROGRAMA_DE_CORTE_DE_DROGA_DE_BAYAMÓN = 28, RESIDENCIAL_DE_VARONES_DE_PONCE = 29, RESIDENCIAL_DE_VARONES_DE_SAN_JUAN = 30, TASC_ARECIBO = 31, TASC_BAYAMÓN = 32, TASC_CAROLINA = 33, TASC_CAGUAS = 34, TASC_FAJARDO = 35, TASC_HUMACAO = 36, TASC_SAN_JUAN = 37, TASC_PONCE = 38, TASC_MAYAGUEZ = 39, TASC_MOCA = 40, TASC_UTUADO = 41, TASC_GUAYAMA = 42, CENTRO_CON_MANTENIMIENTO_CON_METADONA_DE_CAYEY = 43, UNIDAD_MÓVIL_DE_LLORÉNS_TORRES = 44, UNIDAD_MÓVIL_DE_BERWIND = 45, PROGRAMA_DE_CORTE_DE_DROGA_DE_CAROLINA = 46, PROGRAMA_DE_CORTE_DE_DROGA_DE_SAN_JUAN = 47, PROGRAMA_DE_CORTE_DE_DROGA_DE_ARECIBO = 48, PROGRAMA_DE_CORTE_DE_DROGA_DE_GUAYAMA = 49, PROGRAMA_DE_CORTE_DE_DROGA_DE_PONCE = 50, PROGRAMA_DE_CORTE_DE_DROGA_DE_MAYAGUEZ = 51, PROGRAMA_DE_CORTE_DE_DROGA_DE_HUMACAO = 52, ALCOHOLISMO_AMBULATORIO_MAYAGUEZ = 53, TRATAMIENTO_AMBULATORIO_MENORES_PONCE = 54, PROYECTO_INICIATIVA_CISNNAF_LLORÉNS_TORRES = 55, CENTRO_DE_SALUD_MENTAL_DE_SAN_PATRICIO = 56, CENTRO_DE_SALUD_MENTAL_DE_VIEQUES = 57, HOSPITAL_DE_PSIQUIATRÍA_GENERAL_DE_RÍO_PIEDRAS = 58, HOSPITAL_DE_PSIQUIATRÍA_FORENSE_DE_SAN_JUAN = 59, HOSPITAL_DE_PSIQUIATRÍA_FORENSE_DE_PONCE = 60, EVALUACIÓN_LEY_22_DE_SAN_JUAN = 61, EVALUACIÓN_LEY_22_DE_PONCE = 62, EVALUACIÓN_LEY_22_DE_MAYAGUEZ = 63, EVALUACIÓN_LEY_22_DE_ARECIBO = 64, EVALUACIÓN_LEY_22_MOCA = 65, EVALUACIÓN_LEY_22_DE_GUAYAMA = 66, CENTRO_DE_SALUD_MENTAL_DE_COAMO = 67, CENTRO_DE_SALUD_MENTAL_DE_ARECIBO = 68, ALCOHOLISMO_AMBULATORIO_DE_MOCA = 69, PROGRAMA_PACE_DE_SAN_JUAN = 70, PROGRAMA_PACE_DE_MAYAGUEZ = 71, AMBULATORIO_ADULTOS_CAROLINA = 72, AMBULATORIO_ADULTOS_HUMACAO = 73, AMBULATORIO_ADULTOS_MAYAGUEZ = 74, RESIDENCIAL_SALUD_MENTAL_NIÑOS_Y_ADOLESCENTES = 75, RESIDENCIAL_DROGA_ALCOHOL_NIÑOS_Y_ADOLESCENTES = 76, PROYECTO_INICIATIVA_CISNNAF__GURABO = 77, TRATAMIENTO_AMBULATORIO_MENORES_MOCA = 78, CLÍNICA_DE_NIÑOS_Y_ADOLESCENTES_RIO_PIEDRAS = 79, SERVICIOS_TRANSICIONALES_NIVEL_CENTRAL_REHA = 80, CENTRO_DE_REHABILITACION_PSICOSOCIAL_DE_TRUJILLO_ALTO = 81, CENTRO_DE_REHABILITACION_PSICOSOCIAL_DE_CAYEY = 82, CENTRO_DE_REHABILITACION_PSICOSOCIAL_DE_SAN_JUAN = 83, CENTRO_DE_SALUD_MENTAL_DE_MOCA = 84, PROGRAMA_DE_HOGARES = 85, PROGRAMA_DE_DEAMBULANTES = 86, CENTRO_DE_SALUD_MENTAL_MAYAGUEZ = 87, CLINICA_HOARE_DE_SAN_JUAN = 88, TASC_JUVENIL_ARECIBO = 91, CENTRO_RESIDENCIAL_DEAMBULANTES_VARONES_BAYAMÓN = 92, PROGRAMA_REHABILITACION_PONCE = 93, CENTRO_DE_SALUD_MENTAL_DE_FAJARDO = 94, PROGRAMA_DE_CORTE_DE_DROGA_DE_FAJARDO = 95, TASC_JUVENIL_DE_BAYAMON = 96, TASC_JUVENIL_SAN_JUAN = 97, TASC_JUVENIL_CAGUAS = 99, UNIDAD_TRATAMIENTO_AMB_INTEGRADO_NIÑOS, _ADOL_SAN_PATRICIO = 114, PROGRAMA_SERE_DE_SAN_JUAN = 115, PROGRAMA_JUGADORES_COMPULSIVOS_DE_SAN_JUAN = 116, PROGRAMA_PATH_DE_BAYAMON = 117, CENTRO_PONCEÑO_DE_AUTISMO = 118, PROGRAMA_SERE_DE_MAYAGUEZ = 119, PROGRAMA_JUGADORES_COMPULSIVOS_DE_MAYAGUEZ = 120, PROGRAMA_DE_SERVICIOS_TRANSICIONALES_DE_PONCE = 122, PROGRAMA_DE_ALCANCE_COMUNITARIO_DE_ADULTOS_DE_ARECIBO = 124, SALA_DE_OBSERVACION_DE_ARECIBO = 125, PROGRAMA_DE_CORTE_DE_DROGA_DE_CAGUAS = 127, CLINICA_DE_BUPREORFINA_DE_MAYAGUEZ = 128, PROYECTO_INICIATIVA_DE_FAJARDO = 129, PROYECTO_INICIATIVA_DE_CULEBRA = 130, PROYECTO_INICIATIVA_DE_VIEQUES = 131, UNIDAD_DE_SERVICIOS_ESPECIALIZADOS_EN_LA_COMUNIDAD = 132, AMBULATORIO_DROGAS_DE_GUAYAMA = 133 }

    }
