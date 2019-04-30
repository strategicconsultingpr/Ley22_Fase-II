using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ley22_WebApp_V2
{
    public partial class ParticipanteNuevo : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        ApplicationUser ExistingUser = new ApplicationUser();
        Ley22Entities dsLey22 = new Ley22Entities();

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
            ExistingUser = (ApplicationUser)Session["User"];

            if (!Page.IsPostBack)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (Request.UrlReferrer != null)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }

                LoadDropDownList();

                //Si participante existe en base de datos SEPS
                if (Session["SA_Persona"] != null)
                {
                    
                    //Seleccion de datos del participante
                    Data_SA_Persona sa_persona = (Data_SA_Persona)Session["SA_Persona"];
                    string ssn = sa_persona.NR_SeguroSocial;
                    if(!(ssn.Contains(" ") || ssn.Contains("*") || ssn.Contains("S")))
                    {
                      string asterisk = new string('*', ssn.Length - 4);
                      string last = ssn.Substring(ssn.Length - 4);
                      TxtNroSeguroSocial.Text = asterisk + last;
                    }
                    else
                    {
                      TxtNroSeguroSocial.Text = ssn;
                    }

                    TxtIUP.Text = sa_persona.PK_Persona.ToString();
                    
                    DdlSexo.SelectedValue = sa_persona.FK_Sexo.ToString();
                    TxtPrimerNombre.Text = sa_persona.NB_Primero;
                    TxtSegundoNombre.Text = sa_persona.NB_Segundo;
                    TxtPrimerApellido.Text = sa_persona.AP_Primero;
                    TxtSegundoApellido.Text = sa_persona.AP_Segundo;
                    TxtFechaNacimiento.Text = sa_persona.FE_Nacimiento.ToString("MM/dd/yyyy");
                    ChkVeterano.Checked = sa_persona.FK_Veterano == 1 ? true : false;
                    DdlGrupoEtnico.SelectedValue = sa_persona.FK_GrupoEtnico.ToString();

                    //Bloqueo de campos para poder modificarlos
                    TxtNroSeguroSocial.ReadOnly = true;
                    RegularExpressionValidator1.EnableClientScript = false; //Se elimina validacion de tipo de entrada, ya que participantes antiguos contienen caracteres
                    
                    DdlSexo.Enabled = false;
                    TxtPrimerNombre.ReadOnly = true;
                    TxtSegundoNombre.ReadOnly = true;
                    TxtPrimerApellido.ReadOnly = true;
                    TxtSegundoApellido.ReadOnly = true;
                    TxtFechaNacimiento.ReadOnly = true;
                    ChkVeterano.Enabled = false;
                    DdlGrupoEtnico.Enabled = false;

                    BtnCrear.Visible = false;
                    
                    //Si participante tiene expediente bajo este programa
                    if (Session["Expediente"] != null)
                    {
                        TxtExpediente.Text = Session["Expediente"].ToString();
                        TxtExpediente.ReadOnly = true;

                        DateTime FE_Creacion = Convert.ToDateTime(sa_persona.FE_Edicion.ToString());
                        TimeSpan ts = DateTime.Now.Subtract(FE_Creacion);
                        Char TI = sa_persona.TI_Edicion;

                        //Si el usuario tiene acceso a modificacion de participante
                        if ((userManager.IsInRole(ExistingUser.Id, "SuperAdmin") || userManager.IsInRole(ExistingUser.Id, "Supervisor") || (ts.Days < 8 && TI == 'C')))
                        {
                            if((userManager.IsInRole(ExistingUser.Id, "SuperAdmin") || userManager.IsInRole(ExistingUser.Id, "Supervisor")) && (ts.Days < 8))
                            {
                                TxtNroSeguroSocial.Text = ssn;
                                TxtNroSeguroSocial.ReadOnly = false;
                                RegularExpressionValidator1.EnableClientScript = true;
                            }
                            else if((ts.Days < 8 && TI == 'C'))
                            {
                                TxtNroSeguroSocial.Text = ssn;
                                TxtNroSeguroSocial.ReadOnly = false;
                                RegularExpressionValidator1.EnableClientScript = true;
                            }
                            
                            DdlSexo.Enabled = true;
                            TxtPrimerNombre.ReadOnly = false;
                            TxtSegundoNombre.ReadOnly = false;
                            TxtPrimerApellido.ReadOnly = false;
                            TxtSegundoApellido.ReadOnly = false;
                            TxtFechaNacimiento.ReadOnly = false;
                            ChkVeterano.Enabled = true;
                            DdlGrupoEtnico.Enabled = false;
                            TxtExpediente.ReadOnly = false;

                            BtnActualizar.Visible = true;
                        }
                        

                    }
             
                }
            }
        }

        void LoadDropDownList()
        {
            using (SEPSEntities MyLib = new SEPSEntities())
            {

                DdlSexo.DataValueField = "PK_SEXO";
                DdlSexo.DataTextField = "DE_SEXO";
                DdlSexo.DataSource = MyLib.SP_READALL_Sexo();
                DdlSexo.DataBind();
                DdlSexo.Items.Insert(0, new ListItem("-Seleccione-", "0"));


                DdlGrupoEtnico.DataValueField = "PK_GrupoEtnico";
                DdlGrupoEtnico.DataTextField = "DE_GrupoEtnico";

                DdlGrupoEtnico.DataSource = MyLib.SP_READALL_GrupoEtnico();
                DdlGrupoEtnico.DataBind();
                DdlGrupoEtnico.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            }

        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            Data_SA_Persona sa_persona;
            int PK_Persona_out;

            System.Data.Entity.Core.Objects.ObjectParameter myOutputParamString = new System.Data.Entity.Core.Objects.ObjectParameter("PK_Persona", typeof(int));
            try
            {
                using (SEPSEntities1 seps = new SEPSEntities1())
                {
                    short programa = Convert.ToInt16(Session["Programa"]);

                    var spc = seps.SPC_PERSONA(
                        TxtNroSeguroSocial.Text,
                        programa,
                        TxtExpediente.Text,
                        Convert.ToByte(DdlSexo.SelectedValue.ToString()),
                        TxtPrimerApellido.Text,
                        TxtSegundoApellido.Text,
                        TxtPrimerNombre.Text,
                        TxtSegundoNombre.Text,
                        DateTime.Parse(TxtFechaNacimiento.Text),
                        Convert.ToByte(ChkVeterano.Checked == true ? 1 : 2),
                        Convert.ToByte(DdlGrupoEtnico.SelectedValue),
                        Guid.NewGuid(),
                        myOutputParamString
                        );

                    PK_Persona_out = Convert.ToInt32(myOutputParamString.Value);

                    sa_persona = new Data_SA_Persona()
                    {
                        PK_Persona = PK_Persona_out,
                        NR_SeguroSocial = TxtNroSeguroSocial.Text,
                        FK_Sexo = Convert.ToInt32(DdlSexo.SelectedValue),
                        NB_Primero = TxtPrimerNombre.Text,
                        NB_Segundo = TxtSegundoNombre.Text,
                        AP_Primero = TxtPrimerApellido.Text,
                        AP_Segundo = TxtSegundoApellido.Text,
                        FE_Nacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text),
                        FK_Veterano = Convert.ToInt32(ChkVeterano.Checked),
                        FK_GrupoEtnico = Convert.ToInt32(DdlGrupoEtnico.SelectedValue),
                        FE_Edicion = DateTime.Now,
                        TI_Edicion = 'C'

                    };

                    Session["SA_Persona"] = sa_persona;
                    Session["Expediente"] = TxtExpediente.Text;

                    string mensaje = "El participante " + TxtPrimerNombre.Text + " " + TxtPrimerApellido.Text + " se añadió correctamente.";

                    
                    ClientScript.RegisterStartupScript(this.GetType(), "ParticipanteRegistrado", "sweetAlertRef('Participante Registrado','" + mensaje + "','success','OrdenNuevo.aspx');", true);
                   // Response.Redirect("OrdenNuevo.aspx", false);

                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "sweetAlert('Error','" + mensaje + "','error')", true);

            }


        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            Data_SA_Persona sa_persona;
            short programa = Convert.ToInt16(Session["Programa"]);
            try
            {
                using (SEPSEntities1 seps = new SEPSEntities1())
                {


                    var sa_personas = seps.SPU_PERSONA(
                        Convert.ToInt32(TxtIUP.Text),
                        programa,
                        TxtExpediente.Text,
                        TxtNroSeguroSocial.Text,
                        Convert.ToByte(DdlSexo.SelectedValue.ToString()),
                        TxtPrimerApellido.Text,
                        TxtSegundoApellido.Text,
                        TxtPrimerNombre.Text,
                        TxtSegundoNombre.Text,
                        DateTime.Parse(TxtFechaNacimiento.Text),
                        ChkVeterano.Checked == true ? "1" : "2",
                        DdlGrupoEtnico.SelectedValue,
                        Guid.NewGuid()
                        );

                    sa_persona = new Data_SA_Persona()
                    {
                        PK_Persona = Convert.ToInt32(TxtIUP.Text),
                        NR_SeguroSocial = TxtNroSeguroSocial.Text,
                        FK_Sexo = Convert.ToInt32(DdlSexo.SelectedValue),
                        NB_Primero = TxtPrimerNombre.Text,
                        NB_Segundo = TxtSegundoNombre.Text,
                        AP_Primero = TxtPrimerApellido.Text,
                        AP_Segundo = TxtSegundoApellido.Text,
                        FE_Nacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text),
                        FK_Veterano = Convert.ToInt32(ChkVeterano.Checked),
                        FK_GrupoEtnico = Convert.ToInt32(DdlGrupoEtnico.SelectedValue),
                        FE_Edicion = DateTime.Now,
                        TI_Edicion = 'U'

                    };
                }

                Session["SA_Persona"] = sa_persona;
                Session["Expediente"] = TxtExpediente.Text;

                string mensaje = "El participante " + TxtPrimerNombre.Text + " " + TxtPrimerApellido.Text + " se actualizo correctamente.";

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Participante Actualizado", "sweetAlert('Participante Actualizado','" + mensaje + "','success')", true);

                var casos = dsLey22.CasoCriminals.Where(u => u.Id_Participante.Equals(sa_persona.PK_Persona)).Where(a => a.Activa.Equals(1)).Where(p => p.FK_Programa == programa);
                if (casos.Count() > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Participante Actualizado", "sweetAlertRef('Participante Actualizado','" + mensaje + "','success','seleccion-proximo-paso.aspx');", true);
                   // Response.Redirect("seleccion-proximo-paso.aspx", false);
                }
                else
                {
                    mensaje += " Este participante NO contiene algun caso abierto, favor agregar caso.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Participante Actualizado", "sweetAlertRef('Participante Actualizado','" + mensaje + "','success','OrdenNuevo.aspx');", true);
                   // Response.Redirect("OrdenNuevo.aspx", false);
                }
            }
            catch(Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "sweetAlert('Error','" + mensaje + "','error')", true);
                
            }

                
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage, false);
        }

    }
}