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
    public partial class OrdenNuevo : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        ApplicationUser ExistingUser = new ApplicationUser();
        Data_SA_Persona sa_persona = new Data_SA_Persona();
        Ley22Entities dsLey22 = new Ley22Entities();
        SEPSEntities1 dsPerfil = new SEPSEntities1();
        int Id_Caso;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if(Session["SA_Persona"] == null)
            {
                Session["TipodeAlerta"] = ConstTipoAlerta.Info;
                Session["MensajeError"] = "Por favor seleccione un participante";
                Session["Redirect"] = "Entrada.aspx";
                Response.Redirect("Mensajes.aspx", false);
                return;
            }
            if (Session["User"] == null)
            {
                Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
                Session["MensajeError"] = "Por favor ingrese al sistema";
                Session["Redirect"] = "Account/Login.aspx";
                Response.Redirect("Mensajes.aspx", false);
                return;
            }
            ExistingUser = (ApplicationUser)Session["User"];
            sa_persona = (Data_SA_Persona)Session["SA_Persona"];

            if (!Page.IsPostBack)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (Request.UrlReferrer != null)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }

                TxtIUP.Text = sa_persona.PK_Persona.ToString();
                LoadDropDownList();
                LoadDdlTribunal();

                NombreParticipante.Text = Session["NombreParticipante"].ToString();
                NombrePrograma.Text = Session["NombrePrograma"].ToString();

                if (Request.QueryString["id_caso"] != null)
                {
                    this.Id_Caso = Convert.ToInt32(Request.QueryString["id_caso"].ToString());

                    short idPrograma = Convert.ToInt16(Session["Programa"]);

                    var caso = dsLey22.CasoCriminals.Where(a => a.Id_CasoCriminal.Equals(Id_Caso)).SingleOrDefault();

                    var CasoExpediente = dsPerfil.SA_PERSONA_PROGRAMA.Where(b => b.FK_Programa.Equals(idPrograma)).Where(c => c.FK_Persona.Equals(sa_persona.PK_Persona)).Select(f => f.NR_Expediente).SingleOrDefault();
                  
                    TxtNroCasoCriminal.Text = caso.NumeroCasoCriminal;

                    if(caso.NumeroCasoCriminalDos != "" && caso.NumeroCasoCriminalDos != null)
                    {
                        TxtNroCasoCriminal2.Text = caso.NumeroCasoCriminalDos;
                        TxtNroCasoCriminal3.Text = caso.NumeroCasoCriminalTres;

                        CasoDos.Attributes.Add("style", "visibility:visible");
                        CasoTres.Attributes.Add("style", "visibility:visible");

                        ChkCaso.Checked = true;
                    }
                    TxtExpediente.Text = CasoExpediente;
                    TxtFechaOrden.Text = Convert.ToDateTime(caso.FechaOrden).ToString("MM/dd/yyyy");
                    TxtSentencia.Text = Convert.ToDateTime(caso.FechaSentencia).ToString("MM/dd/yyyy");
                    Txtalcohol.Text = caso.Alcohol;
                    DdlTribunal.SelectedValue = caso.FK_Tribunal.ToString();
                    TxtJuez.Text = caso.NB_Juez;
                    TxtLicencia.Text = caso.NumLicencia.ToString();
                    DdlEstadoCivil.SelectedValue = caso.FK_EstadoCivil.ToString();
                    TxtEmail.Text = caso.Email;
                    TxtCelular.Text = caso.TelCelular;
                    TxtTelHogar.Text = caso.TelHogar;
                    TxtTelefonoFamiliarMasCercano.Text = caso.TelTrabajo;
                    TxtDireccionLinea1.Text = caso.DireccionLinea1;
                    TxtDireccionLinea2.Text = caso.DireccionLinea2;
                    DdlPueblo.SelectedValue = caso.FK_Pueblo.ToString();
                    TxtCodigoPostal.Text = caso.CodigoPostal;
                    TxtPostalLinea1.Text = caso.DireccionLinea1Postal;
                    TxtPostalLinea2.Text = caso.DireccionLinea2Postal;
                    DdlPuebloPostal.SelectedValue = caso.FK_PuebloPostal.ToString();
                    TxtCodigoPostalPostal.Text = caso.CodigoPostalPostal;
                    DdlPlanMedico.SelectedValue = caso.FK_PlanMedico.ToString();
                    DdlTratamiento.SelectedValue = caso.CondicionSalud;
                    DdlImpedimento.SelectedValue = caso.Impedimento;
                    DdlGrado.SelectedValue = caso.FK_Grado.ToString();
                    TxtTrabajo.Text = caso.LugarTrabajo;
                    TxtOcupacion.Text = caso.Ocupacion;
                    if (caso.Veterano == 1)
                    {
                        ChkNoTrabajo.Checked = true;
                    }
                    else
                    {
                        ChkNoTrabajo.Checked = false;
                    }
                    DdlDesempleado.SelectedValue = caso.FK_DesempleoRazon.ToString();
                    TxtFamiliar.Text = caso.CantidadFamilia.ToString();
                    TxtPareja.Text = caso.NB_Pareja;
                    TxtPadre.Text = caso.NB_Padre;
                    TxtMadre.Text = caso.NB_Madre;

                    BtnActualizar.Visible = true;

                    DateTime FE_Creacion = Convert.ToDateTime(caso.FechaCreacion.ToString());
                    TimeSpan ts = DateTime.Now.Subtract(FE_Creacion);

                    if (!(caso.Activa == 1 && (userManager.IsInRole(ExistingUser.Id, "SuperAdmin") || userManager.IsInRole(ExistingUser.Id, "Supervisor") || userManager.IsInRole(ExistingUser.Id, "TrabajadorSocial") || userManager.IsInRole(ExistingUser.Id, "CoordinadorCharlas") || ts.Days < 8)) || caso.FK_Programa != Convert.ToInt32(Session["Programa"]))
                    {
                        TxtNroCasoCriminal.ReadOnly = true;
                        TxtNroCasoCriminal2.ReadOnly = true;
                        TxtNroCasoCriminal3.ReadOnly = true;
                        TxtFechaOrden.ReadOnly = true;
                        TxtSentencia.ReadOnly = true;
                        Txtalcohol.ReadOnly = true;
                        DdlTribunal.Enabled = false;
                        TxtJuez.ReadOnly = true;
                        TxtLicencia.ReadOnly = true;
                        DdlEstadoCivil.Enabled = false;
                        TxtEmail.ReadOnly = true;
                        TxtCelular.ReadOnly = true;
                        TxtTelHogar.ReadOnly = true;
                        TxtTelefonoFamiliarMasCercano.ReadOnly = true;
                        TxtDireccionLinea1.ReadOnly = true;
                        TxtDireccionLinea2.ReadOnly = true;
                        DdlPueblo.Enabled = false;
                        TxtCodigoPostal.ReadOnly = true;
                        TxtPostalLinea1.ReadOnly = true;
                        TxtPostalLinea2.ReadOnly = true;
                        DdlPuebloPostal.Enabled = false;
                        TxtCodigoPostalPostal.ReadOnly = true;
                        DdlPlanMedico.Enabled = false;
                        DdlTratamiento.Enabled = false;
                        DdlImpedimento.Enabled = false;
                        DdlGrado.Enabled = false;
                        TxtTrabajo.ReadOnly = true;
                        TxtOcupacion.ReadOnly = true;
                        ChkNoTrabajo.Enabled = false;
                        DdlDesempleado.Enabled = false;
                        TxtFamiliar.ReadOnly = true;
                        TxtPareja.ReadOnly = true;
                        TxtPadre.ReadOnly = true;
                        TxtMadre.ReadOnly = true;

                        BtnActualizar.Visible = false;

                        if (caso.Activa == 0 && (userManager.IsInRole(ExistingUser.Id, "SuperAdmin") || userManager.IsInRole(ExistingUser.Id, "Supervisor")))
                        {
                            BtnReabrir.Visible = true;
                        }
                    }

                    BtnCrear.Visible = false;

                    var cargosVacio = (from casos in dsLey22.CasoCriminals
                                     join control in dsLey22.ControldePagoes on casos.Id_CasoCriminal equals control.FK_CasoCriminal
                                     where casos.Id_CasoCriminal == this.Id_Caso
                                     select new { resultado = casos.Id_CasoCriminal }
                                    ).Count();

                    var documentosVacio = (from casos in dsLey22.CasoCriminals
                                           join documentos in dsLey22.DocumentosPorParticipantes on casos.Id_CasoCriminal equals documentos.Id_OrdenJudicial
                                           where casos.Id_CasoCriminal == this.Id_Caso
                                           select new { resultado = casos.Id_CasoCriminal }
                                    ).Count();

                    if (caso.Activa == 1 && (userManager.IsInRole(ExistingUser.Id, "SuperAdmin") || userManager.IsInRole(ExistingUser.Id, "Supervisor")) && cargosVacio == 0 && documentosVacio == 0)
                    {
                        BtnEliminar.Visible = true;
                    }



                }
                else
                {
                    if (Session["Expediente"] != null)
                    {
                        TxtExpediente.Text = Session["Expediente"].ToString();

                    }
                    else
                    {
                        Response.Redirect("ParticipanteNuevo.aspx", false);
                    }
                }

                
            }

            if (Page.Request.Params["__EVENTTARGET"] == "EliminarCasoCriminal")
            {
                Eliminar_Caso();
                return;
            }
        }

        void LoadDropDownList()
        {           
            

            var estados_civiles = dsPerfil.SA_LKP_TEDS_ESTADO_MARITAL.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_EstadoMarital.ToString(), Text = r.DE_EstadoMarital }).ToList();

            DdlEstadoCivil.DataValueField = "Value";
            DdlEstadoCivil.DataTextField = "Text";
            DdlEstadoCivil.DataSource = estados_civiles;
            DdlEstadoCivil.DataBind();
            DdlEstadoCivil.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var pueblos = dsPerfil.SA_LKP_MUNICIPIO_RESIDENCIA.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_Municipio.ToString(), Text = r.DE_Municipio }).ToList();

            DdlPueblo.DataValueField = "Value";
            DdlPueblo.DataTextField = "Text";
            DdlPueblo.DataSource = pueblos;
            DdlPueblo.DataBind();
            DdlPueblo.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            DdlPuebloPostal.DataValueField = "Value";
            DdlPuebloPostal.DataTextField = "Text";
            DdlPuebloPostal.DataSource = pueblos;
            DdlPuebloPostal.DataBind();
            DdlPuebloPostal.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var planesmedicos = dsPerfil.SA_LKP_TEDS_SEGURO_SALUD.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_SeguroSalud.ToString(), Text = r.DE_SeguroSalud }).ToList();

            DdlPlanMedico.DataValueField = "Value";
            DdlPlanMedico.DataTextField = "Text";
            DdlPlanMedico.DataSource = planesmedicos;
            DdlPlanMedico.DataBind();
            DdlPlanMedico.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var grados = dsPerfil.SA_LKP_TEDS_GRADO.Where(a => a.Active == true).Select(r => new ListItem { Value = r.PK_Grado.ToString(), Text = r.DE_Grado}).ToList();

            DdlGrado.DataValueField = "Value";
            DdlGrado.DataTextField = "Text";
            DdlGrado.DataSource = grados;
            DdlGrado.DataBind();
            DdlGrado.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var desempleorazon = dsLey22.DesempleoRazons.Select(r => new ListItem { Value = r.Id_DesempleoRazon.ToString(), Text = r.NB_DesempleoRazon }).ToList();

            DdlDesempleado.DataValueField = "Value";
            DdlDesempleado.DataTextField = "Text";
            DdlDesempleado.DataSource = desempleorazon;
            DdlDesempleado.DataBind();
            
         //   DdlDesempleado.Items.Insert(0, new ListItem("-Seleccione-", "0"));
        }

        void LoadDdlTribunal()
        {
            var tribunales = dsLey22.Tribunals.OrderBy(a => a.NB_Tribunal).Select(r => new ListItem { Value = r.Id_Tribunal.ToString(), Text = r.NB_Tribunal }).ToList();

            DdlTribunal.DataValueField = "Value";
            DdlTribunal.DataTextField = "Text";
            DdlTribunal.DataSource = tribunales;
            DdlTribunal.DataBind();
            DdlTribunal.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var categorias = dsLey22.TribunalCategorias.OrderBy(a => a.NB_TribunalCategoria).Select(r => new ListItem { Value = r.Id_TribunalCategoria.ToString(), Text = r.NB_TribunalCategoria }).ToList();

            DdlCategoriaTribunal.DataValueField = "Value";
            DdlCategoriaTribunal.DataTextField = "Text";
            DdlCategoriaTribunal.DataSource = categorias;
            DdlCategoriaTribunal.DataBind();
            DdlCategoriaTribunal.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var regiones = dsLey22.TribunalRegions.OrderBy(a => a.NB_TribunalRegion).Select(r => new ListItem { Value = r.Id_TribunalRegion.ToString(), Text = r.NB_TribunalRegion }).ToList();

            DdlRegionTribunal.DataValueField = "Value";
            DdlRegionTribunal.DataTextField = "Text";
            DdlRegionTribunal.DataSource = regiones;
            DdlRegionTribunal.DataBind();
            DdlRegionTribunal.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            TxtNombreTribunal.Text = "";
            TxtTelefonoTribunal1.Text = "";
            TxtTelefonoTribunal2.Text = "";
            TxtTelefonoTribunal3.Text = "";
            TxtDireccionTribunal.Text = "";
            DdlPaisTribunal.SelectedValue = "1";
            TxtBoxTribunal.Text = "";
            TxtCategoriaTribunal.Text = "";
            TxtRegionTribunal.Text= "";

            ChkCategoria.Checked = false;
            ChkRegion.Checked = false;

        }
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            try
            {
                using (Ley22Entities mylib = new Ley22Entities())
                    mylib.GuardarCasoCriminal(Convert.ToInt32(sa_persona.PK_Persona), TxtNroCasoCriminal.Text.ToUpper(), TxtNroCasoCriminal2.Text.ToUpper(), TxtNroCasoCriminal3.Text.ToUpper(), Convert.ToDateTime(TxtFechaOrden.Text),
                        Convert.ToDateTime(TxtSentencia.Text), Txtalcohol.Text, Convert.ToInt32(DdlTribunal.SelectedValue), TxtJuez.Text,
                        ExistingUser.Id, Convert.ToInt32(Session["Programa"]), Convert.ToInt32(TxtLicencia.Text),
                        Convert.ToInt32(DdlEstadoCivil.SelectedValue), TxtEmail.Text, TxtCelular.Text, TxtTelHogar.Text,
                        TxtTelefonoFamiliarMasCercano.Text, TxtDireccionLinea1.Text, TxtDireccionLinea2.Text, Convert.ToInt32(DdlPueblo.SelectedValue), TxtCodigoPostal.Text,
                        TxtPostalLinea1.Text, TxtPostalLinea2.Text, Convert.ToInt32(DdlPuebloPostal.SelectedValue), TxtCodigoPostalPostal.Text,
                        Convert.ToInt32(DdlPlanMedico.SelectedValue), DdlTratamiento.SelectedValue, DdlImpedimento.SelectedValue, Convert.ToInt32(DdlGrado.SelectedValue),
                        TxtTrabajo.Text, TxtOcupacion.Text, ChkNoTrabajo.Checked == true ? Convert.ToByte(1) : Convert.ToByte(2), Convert.ToInt32(DdlDesempleado.SelectedValue), Convert.ToInt32(TxtFamiliar.Text),
                        TxtPareja.Text.ToUpper(), TxtPadre.Text.ToUpper(), TxtMadre.Text.ToUpper());

                mensaje = "El caso criminal #" + TxtNroCasoCriminal.Text + " se añadió correctamente.";

               
                ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Registrado", "sweetAlertRef('Caso Criminal Registrado','" + mensaje + "','success','seleccion-proximo-paso.aspx');", true);


                //Response.Redirect("seleccion-proximo-paso.aspx", false);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }
            
            // mylib.GuardarOrdenJudicial(Convert.ToInt32(Session["Id_Participante"]), TxtNroCasoCriminal.Text, Convert.ToDateTime(TxtFechaOrden.Text), Convert.ToInt32(Session["Id_UsuarioApp"]), Convert.ToInt32(Session["Programa"]));
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.Id_Caso = Convert.ToInt32(Request.QueryString["id_caso"].ToString());
            string mensaje = string.Empty;

            try
            {
                using (Ley22Entities mylib = new Ley22Entities())
                    mylib.ModificarCasoCriminal(this.Id_Caso, TxtNroCasoCriminal.Text.ToUpper(), TxtNroCasoCriminal2.Text.ToUpper(), TxtNroCasoCriminal3.Text.ToUpper(), Convert.ToDateTime(TxtFechaOrden.Text),
                        Convert.ToDateTime(TxtSentencia.Text), Txtalcohol.Text, Convert.ToInt32(DdlTribunal.SelectedValue), TxtJuez.Text,
                        Convert.ToInt32(TxtLicencia.Text),
                        Convert.ToInt32(DdlEstadoCivil.SelectedValue), TxtEmail.Text, TxtCelular.Text, TxtTelHogar.Text,
                        TxtTelefonoFamiliarMasCercano.Text, TxtDireccionLinea1.Text, TxtDireccionLinea2.Text, Convert.ToInt32(DdlPueblo.SelectedValue),
                        TxtCodigoPostal.Text,
                        TxtPostalLinea1.Text, TxtPostalLinea2.Text, Convert.ToInt32(DdlPuebloPostal.SelectedValue), TxtCodigoPostalPostal.Text,
                        Convert.ToInt32(DdlPlanMedico.SelectedValue), DdlTratamiento.SelectedValue, DdlImpedimento.SelectedValue, Convert.ToInt32(DdlGrado.SelectedValue),
                        TxtTrabajo.Text, TxtOcupacion.Text, ChkNoTrabajo.Checked == true ? Convert.ToByte(1) : Convert.ToByte(2), Convert.ToInt32(DdlDesempleado.SelectedValue), Convert.ToInt32(TxtFamiliar.Text),
                        TxtPareja.Text.ToUpper(), TxtPadre.Text.ToUpper(), TxtMadre.Text.ToUpper());

                mensaje = "El caso criminal #" + TxtNroCasoCriminal.Text + " se actualizó correctamente.";


               // ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Registrado", "sweetAlert('Caso Criminal Registrado','" + mensaje + "','success')", true);
                ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Registrado", "sweetAlertRef('Caso Criminal Registrado','" + mensaje + "','success','seleccion-proximo-paso.aspx');", true);

                //Response.Redirect("seleccion-proximo-paso.aspx", false);
            }
            catch (Exception ex)
            {

                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }
            
        }

        protected void BtnReabrir_Click(object sender, EventArgs e)
        {
            this.Id_Caso = Convert.ToInt32(Request.QueryString["id_caso"].ToString());

            try
            {
                using (Ley22Entities mylib = new Ley22Entities())
                    mylib.ReabrirCasoCriminal(this.Id_Caso);

                string mensaje = "El caso criminal #" + TxtNroCasoCriminal.Text + " fue reabierto correctamente.";


                // ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Registrado", "sweetAlert('Caso Criminal Registrado','" + mensaje + "','success')", true);
                ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Reabierto", "sweetAlertRef('Caso Criminal Reabierto','" + mensaje + "','success','seleccion-proximo-paso.aspx');", true);

                //Response.Redirect("seleccion-proximo-paso.aspx", false);
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }

        }

        protected void BtnTribunal_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            string nombre = TxtNombreTribunal.Text;
            string telefono = TxtTelefonoTribunal1.Text + "-" + TxtTelefonoTribunal2.Text + "-" + TxtTelefonoTribunal3.Text;
            string direccion = TxtDireccionTribunal.Text;
            string pais = DdlPaisTribunal.SelectedItem.Text;
            string pobox = TxtBoxTribunal.Text;
            string catTxt = TxtCategoriaTribunal.Text;
            string regTxt = TxtRegionTribunal.Text;

            int catDdl = Convert.ToInt32(DdlCategoriaTribunal.SelectedValue);
            int regDdl = Convert.ToInt32(DdlRegionTribunal.SelectedValue);

            try
            {
                dsLey22.GuardarTribunal(nombre, telefono, direccion, pais, pobox, catTxt, regTxt, catDdl, regDdl);

                mensaje = "El tribunal " + nombre + " fue registrado correctamente.";


                // ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Registrado", "sweetAlert('Caso Criminal Registrado','" + mensaje + "','success')", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Tribunal Registrado", "sweetAlert('Tribunal Registrado','" + mensaje + "','success')", true);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }

            LoadDdlTribunal();
        }
        void Eliminar_Caso()
        {
            this.Id_Caso = Convert.ToInt32(Request.QueryString["id_caso"].ToString());
            string mensaje = string.Empty;

            try
            {
                //using (Ley22Entities mylib = new Ley22Entities())
                //    mylib.ReabrirCasoCriminal(this.Id_Caso);

                dsLey22.EliminarCasoCriminal(this.Id_Caso);

                mensaje = "El caso criminal #" + TxtNroCasoCriminal.Text + " fue eliminado correctamente.";


                // ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Registrado", "sweetAlert('Caso Criminal Registrado','" + mensaje + "','success')", true);
                ClientScript.RegisterStartupScript(this.GetType(), "Caso Criminal Reabierto", "sweetAlertRef('Caso Criminal Eliminado','" + mensaje + "','success','seleccion-proximo-paso.aspx');", true);

                //Response.Redirect("seleccion-proximo-paso.aspx", false);
            }
            catch (Exception ex)
            {

                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            if(prevPage != "ParticipanteNuevo.aspx")
            {
                Response.Redirect(prevPage, false);
            }
            else
            {
                Response.Redirect("seleccion-proximo-paso.aspx", false);
            }
            
        }
    }
}