using Ley22_WebApp_V2.Models;
using Ley22_WebApp_V2.Old_App_Code;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ley22_WebApp_V2
{
    public partial class Certificados_Participante : System.Web.UI.Page
    {
        protected Data_SA_Persona du;
        ApplicationUser ExistingUser = new ApplicationUser();
        static string userId = String.Empty;
        Ley22Entities dsLey22 = new Ley22Entities();
        SEPSEntities1 dsPerfil = new SEPSEntities1();
        ApplicationDbContext context = new ApplicationDbContext();
        int Programa;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["SA_Persona"] == null)
                {
                    Session["TipodeAlerta"] = ConstTipoAlerta.Info;
                    Session["MensajeError"] = "Por favor seleccione el participante";
                    Session["Redirect"] = "Entrada.aspx";
                    Response.Redirect("Mensajes.aspx", false);
                    return;
                }
                if (Session["User"] == null)
                {
                    Session["TipodeAlerta"] = ConstTipoAlerta.Info;
                    Session["MensajeError"] = "Por favor ingrese al sistema";
                    Session["Redirect"] = "Account/Login.aspx";
                    Response.Redirect("Mensajes.aspx", false);
                    return;
                }

                // this.du = (DataParticipante)Session["DataParticipante"];

                this.du = (Data_SA_Persona)Session["SA_Persona"];
                Programa = Convert.ToInt32(Session["Programa"].ToString());
                ExistingUser = (ApplicationUser)Session["User"];
                userId = ExistingUser.Id;
                
                CargarOrdenesJudiciales();
                CargarAdministracion();

            }
        }

        void CargarAdministracion()
        {
            var Rolsupervisor = context.Roles.SingleOrDefault(m => m.Name == "Supervisor");
            var IDsupervisoresTodos = Rolsupervisor.Users.Select(m => m.UserId).ToList();
            var IDsupervisores = dsLey22.USUARIO_PROGRAMA.Where(r => IDsupervisoresTodos.Contains(r.FK_Usuario)).Where(p => p.FK_Programa.Equals(Programa)).Select(a => a.FK_Usuario).ToList();
            var supervisores = context.Users.Where(m => IDsupervisores.Contains(m.Id)).Select(r => new ListItem { Value = r.Id.ToString(), Text = r.FirstName + " " + r.LastName }).ToList();


            var RolCoordinador = context.Roles.SingleOrDefault(m => m.Name == "CoordinadorCharlas");
            var IDcoordinadorTodos = RolCoordinador.Users.Select(m => m.UserId).ToList();
            var IDcoordinador = dsLey22.USUARIO_PROGRAMA.Where(r => IDcoordinadorTodos.Contains(r.FK_Usuario)).Where(p => p.FK_Programa.Equals(Programa)).Select(a => a.FK_Usuario).ToList();
            var coordinadores = context.Users.Where(m => IDcoordinador.Contains(m.Id)).Select(r => new ListItem { Value = r.Id.ToString(), Text = r.FirstName + " " + r.LastName }).ToList();



            if (supervisores.Count() == 1)
            {
                DdlSupervisor.DataValueField = "Value";
                DdlSupervisor.DataTextField = "Text";
                DdlSupervisor.DataSource = supervisores;
                DdlSupervisor.DataBind();
                DdlSupervisor.SelectedValue = supervisores[0].Value;


            }
            else
            {
                DdlSupervisor.DataValueField = "Value";
                DdlSupervisor.DataTextField = "Text";
                DdlSupervisor.DataSource = supervisores;
                DdlSupervisor.DataBind();
                DdlSupervisor.Items.Insert(0, new ListItem("-Seleccione-", "0"));


            }

            if (coordinadores.Count() == 1)
            {
                DdlAdiestrador.DataValueField = "Value";
                DdlAdiestrador.DataTextField = "Text";
                DdlAdiestrador.DataSource = coordinadores;
                DdlAdiestrador.DataBind();
                DdlAdiestrador.SelectedValue = coordinadores[0].Value;


            }
            else
            {
                DdlAdiestrador.DataValueField = "Value";
                DdlAdiestrador.DataTextField = "Text";
                DdlAdiestrador.DataSource = coordinadores;
                DdlAdiestrador.DataBind();
                DdlAdiestrador.Items.Insert(0, new ListItem("-Seleccione-", "0"));


            }
        }

        void CargarOrdenesJudiciales()
        {
            using (Ley22Entities mylib = new Ley22Entities())
            {

                DdlNumeroOrdenJudicial.DataTextField = "NumeroCasoCriminal";
                DdlNumeroOrdenJudicial.DataValueField = "Id_CasoCriminal";
                DdlNumeroOrdenJudicial.DataSource = mylib.ListarCasosCriminalesActivos(Convert.ToInt32(Session["Id_Participante"]), Convert.ToInt32(Session["Programa"]));
                DdlNumeroOrdenJudicial.DataBind();
                DdlNumeroOrdenJudicial.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
        }

        void BidGrid()
        {
           

            int Id = Convert.ToInt32(Session["Id_Participante"]);
            Programa = Convert.ToInt32(Session["Programa"].ToString());
            int Id_CasoCriminal = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);

            try
            {
               // string PathNameDocumento = "//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + Id_CasoCriminal + "/Certificaciones/Certificado_" + item.Id_CasoCriminal + ".pdf";

                if (Directory.Exists("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + Id_CasoCriminal + "/Certificaciones/"))
                {
                    string[] filesPaths = Directory.GetFiles("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + Id_CasoCriminal + "/Certificaciones/");
                    List<ListItem> files = new List<ListItem>();

                    foreach (string item in filesPaths)
                    {
                        files.Add(new ListItem(Path.GetFileName(item), item));
                    }
                    GvCertificados.DataSource = files;
                    GvCertificados.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnGenerarCertificados(object sender, EventArgs e)
        {

            int Id_Participante = Convert.ToInt32(Session["Id_Participante"]);
            int Id_CasoCriminal = Convert.ToInt32(DdlNumeroOrdenJudicial.SelectedValue);
            short Id_Programa = Convert.ToInt16(Session["Programa"].ToString());
            Programa = Convert.ToInt32(Session["Programa"].ToString());

            ExistingUser = (ApplicationUser)Session["User"];
            userId = ExistingUser.Id;

            try
            {
                var Caso = dsLey22.CasoCriminals.Where(r => r.Id_CasoCriminal.Equals(Id_CasoCriminal)).SingleOrDefault();
                string mensaje = string.Empty;

                var asistencias = dsLey22.ParticipantesPorCharlas.Where(u => u.Id_Participante.Equals(Id_Participante)).Where(p => p.Id_OrdenJudicial == Id_CasoCriminal).Select(a => a.Asistio).Sum();
                decimal balance = Convert.ToDecimal(Caso.Cargos) - Convert.ToDecimal(Caso.Pagos);

                //if (asistencias == 1 && balance.Equals(0.00))
                //{
                string Id = Id_Participante.ToString();
                string Nombre = dsPerfil.SA_PERSONA.Where(r => r.PK_Persona.Equals(Caso.Id_Participante)).Select(p => p.NB_Primero).SingleOrDefault();
                string Apellido = dsPerfil.SA_PERSONA.Where(r => r.PK_Persona.Equals(Caso.Id_Participante)).Select(p => p.AP_Primero).SingleOrDefault();
                string fecha = DateTime.Now.ToShortDateString();

                string tribunal = dsLey22.Tribunals.Where(r => r.Id_Tribunal.Equals(Caso.FK_Tribunal)).Select(a => a.NB_Tribunal).SingleOrDefault();
                var charlas = dsLey22.ParticipantesPorCharlas.Where(u => u.Id_Participante.Equals(Caso.Id_Participante)).Where(p => p.Id_OrdenJudicial == Caso.Id_CasoCriminal).Where(f => f.Asistio.Equals(1)).Select(a => a.Id_CharlaGrupal);

                var fechaInical = dsLey22.CharlaGrupals.Where(u => charlas.Contains(u.Id_CharlaGrupal)).Select(a => a.FechaInicial).Min();
                var fechaFinal = dsLey22.CharlaGrupals.Where(u => charlas.Contains(u.Id_CharlaGrupal)).Select(a => a.FechaInicial).Max();

                string nombrePrograma = dsPerfil.SA_PROGRAMA.Where(a => a.PK_Programa.Equals(Id_Programa)).Select(p => p.NB_Programa).SingleOrDefault();

                string PathNameDocumento = "//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + Caso.Id_CasoCriminal + "/Certificaciones/Certificado_" + Caso.Id_CasoCriminal + ".pdf";

                if (File.Exists(PathNameDocumento))
                {
                    DirectoryInfo directory = new DirectoryInfo("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + Id_CasoCriminal + "/Certificaciones/");
                    FileInfo[] fileInfo = directory.GetFiles();
                    int count = fileInfo.Count();
                    
                    foreach (FileInfo file in fileInfo)
                    {
                        
                        if (file.Name == "Certificado_" + Caso.Id_CasoCriminal+".pdf")
                        {
                            while (File.Exists(directory.FullName + "Certificado_" + Caso.Id_CasoCriminal + "_Version#" + count+".pdf"))
                            { count++; }

                            mensaje += "Documento " + file.Name + " modificado a " + file.Name + "_Version#" + count;
                            File.Move(file.FullName, file.FullName.Replace(file.Name, "Certificado_" + Caso.Id_CasoCriminal + "_Version#" + count+".pdf"));                            
                        }
                    }
                }

                if (!Directory.Exists("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + Caso.Id_CasoCriminal + "/Certificaciones/"))
                {
                    Directory.CreateDirectory("//Assmca-file/share2/APP-LEY22/DocumentosDeParticipantes/" + Programa + "/" + Id + "/" + Caso.Id_CasoCriminal + "/Certificaciones/");
                }

                string baseUrl = "C:/Users/alexie.ortiz/source/repos/Ley22_Fase-II/Ley22_WebApp_V2/images/";

                // webKitSettings.WebKitPath = "C:/Users/alexie.ortiz/source/repos/Ley22_Fase-II/Ley22_WebApp_V2/bin/QtBinaries/";

                string bodyPDF = CreateBodyPDF(fecha, Caso.NB_Juez, Caso.NumeroCasoCriminal, nombrePrograma, Nombre, Apellido, Caso.FechaSentencia.ToString(), tribunal, fechaInical.ToShortDateString(), fechaFinal.ToShortDateString(), DdlAdiestrador.SelectedItem.Text, DdlSupervisor.SelectedItem.Text);

                PdfPageSize pageSize = PdfPageSize.Letter;

                PdfPageOrientation pdfOrientation = PdfPageOrientation.Portrait;

                int webPageWidth = 850;
                int webPageHeight = 0;

                HtmlToPdf converter = new HtmlToPdf();

                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                converter.Options.WebPageWidth = webPageWidth;
                converter.Options.WebPageHeight = webPageHeight;

                PdfDocument doc = converter.ConvertHtmlString(bodyPDF, baseUrl);

                doc.Save(PathNameDocumento);

                doc.Close();

                mensaje += "Certificado para " + Nombre + " " + Apellido + " fue generado. <br/>";

                DdlAdiestrador.SelectedValue = "0";
                DdlSupervisor.SelectedValue = "0";

                BidGrid();
                //}



                if (mensaje != string.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Certificado", "sweetAlert('Certificado','" + mensaje + "','success')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Certificado", "sweetAlert('Certificado','El caso criminal para este participante se encuentra abierto. Favor verificar la asistencia de charlas y el balance.','error')", true);
                }
            }
            catch(Exception ex)
            {
                string mensaje = ex.Message;
                ScriptManager.RegisterClientScriptBlock(LnkGenerar, LnkGenerar.GetType(), "Certificado", "sweetAlert('Certificado','"+mensaje+"','error')", true);
            }

        }

        protected void DdlNumeroOrdenJudicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlNumeroOrdenJudicial.SelectedValue != "0")
            {              
                BidGrid();
            }
            else
            {
                GvCertificados.DataSource = null;
                GvCertificados.DataBind();
            }

            
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string filePath = btn.CommandArgument;
           

            File.Delete(filePath);           
            BidGrid();
            
        }
        protected void lnkImprimir_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string filePath = btn.CommandArgument;

            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filePath);
            Response.TransmitFile(filePath);
            Response.End();
           // Response.Redirect("/");
        }

        private string CreateBodyPDF(string Fecha, string Juez, string Caso, string RegionPrograma, string Nombre, string Apellido, string FechaSentencia, string NombreTribunal, string FechaInicial, string FechaFinal, string NombreAdiestrador, string NombreSupervisor)
        {
            string body = string.Empty;

            using (StreamReader reader = new StreamReader(Server.MapPath("~/Certificado.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Fecha}", Fecha);
            body = body.Replace("{Juez}", Juez);
            body = body.Replace("{CasoCriminal}", Caso);
            body = body.Replace("{RegionPrograma}", RegionPrograma);
            body = body.Replace("{NombreParticipante}", Nombre + " " + Apellido);
            body = body.Replace("{FechaSentencia}", FechaSentencia);
            body = body.Replace("{NombreTribunal}", NombreTribunal);
            body = body.Replace("{FechaInicio}", FechaInicial);
            body = body.Replace("{FechaFinal}", FechaFinal);
            body = body.Replace("{FechaHoy}", DateTime.Now.ToShortDateString());
            body = body.Replace("{NombreAdiestrador}", NombreAdiestrador);
            body = body.Replace("{NombreSupervisor}", NombreSupervisor);



            return body;

        }

    }
}