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

namespace Ley22_WebApp_V2.Account
{
    public partial class AssignProgram : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        SEPSEntities1 dsPerfil = new SEPSEntities1();
        Ley22Entities dsLey22 = new Ley22Entities();
        ApplicationUser ExistingUser = new ApplicationUser();
        static string userId = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Session["TipodeAlerta"] = ConstTipoAlerta.Info;
                    Session["MensajeError"] = "Por favor ingrese al sistema";
                    Response.Redirect("Account/Login.aspx", false);
                    return;
                }
                ExistingUser = (ApplicationUser)Session["User"];
                userId = ExistingUser.Id;

                LoadDropDowns();
                int TotalReg = BindGridView(1);
                this.FillJumpToList(TotalReg);
            }
        }

        protected void LoadDropDowns()
        {
            //var programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

            //DdlPrograma.DataValueField = "Value";
            //DdlPrograma.DataTextField = "Text";
            //DdlPrograma.DataSource = programas;
            //DdlPrograma.DataBind();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var usuarios_programas = new List<string>();
            var programas_usuario = new List<int>();
            List<ListItem> email;

            DdlProgramA.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            DdlProgramD.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            if (userManager.IsInRole(userId, "Director"))
            {
                programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
                usuarios_programas = dsLey22.USUARIO_PROGRAMA.Where(u => programas_usuario.Contains(u.FK_Programa)).Select(p => p.FK_Usuario).ToList();
                email = context.Users.Where(p => usuarios_programas.Contains(p.Id)).Select(u => new ListItem { Value = u.Id, Text = u.Email }).ToList();
            }
            else
            {
                email = context.Users.Select(u => new ListItem { Value = u.Id, Text = u.Email }).ToList();
            }

            DdlEmailA.DataValueField = "Value";
            DdlEmailA.DataTextField = "Text";
            DdlEmailA.DataSource = email;
            DdlEmailA.DataBind();
            DdlEmailA.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            DdlEmailD.DataValueField = "Value";
            DdlEmailD.DataTextField = "Text";
            DdlEmailD.DataSource = email;
            DdlEmailD.DataBind();
            DdlEmailD.Items.Insert(0, new ListItem("-Seleccione-", "0"));
        }

        protected void LoadProgramsDdlA()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var programas_usuario = new List<int>();
            var programas_director = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
            List<ListItem> programas;
            string email = DdlEmailA.SelectedValue;

            if (userManager.IsInRole(userId, "Director"))
            {
                programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(email)).Select(p => p.FK_Programa).ToList();

                programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22"))
                    .Where(p => !programas_usuario.Contains(p.PK_Programa))
                    .Where(a => programas_director.Contains(a.PK_Programa))
                    .Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

            }
            else
            {
                programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(email)).Select(p => p.FK_Programa).ToList();

                programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Where(p => !programas_usuario.Contains(p.PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();
            }
                DdlProgramA.DataValueField = "Value";
                DdlProgramA.DataTextField = "Text";
                DdlProgramA.DataSource = programas;
                DdlProgramA.DataBind();
                DdlProgramA.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            
        }

        protected void LoadProgramsDdlD()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var programas_usuario = new List<int>();
            string email = DdlEmailD.SelectedValue;
            var programas_director = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
            List<ListItem> programas;

            if (userManager.IsInRole(userId, "Director"))
            {
                programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(email)).Select(p => p.FK_Programa).ToList();

                programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22"))
                    .Where(p => programas_usuario.Contains(p.PK_Programa))
                    .Where(a => programas_director.Contains(a.PK_Programa))
                    .Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

            }
            else
            {
                programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(email)).Select(p => p.FK_Programa).ToList();

                programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Where(p => programas_usuario.Contains(p.PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

            }

            DdlProgramD.DataValueField = "Value";
            DdlProgramD.DataTextField = "Text";
            DdlProgramD.DataSource = programas;
            DdlProgramD.DataBind();
            DdlProgramD.Items.Insert(0, new ListItem("-Seleccione-", "0"));

        }

        protected void DdlEmailA_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.LoadProgramsDdlA();
        }

        protected void DdlEmailD_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.LoadProgramsDdlD();
        }

        public void BtnAddProgram_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUser ExistingUser = context.Users.Where(u => u.Id.Equals(DdlEmailA.SelectedValue, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                string usuario = ExistingUser.Id;

                var up = dsLey22.Set<USUARIO_PROGRAMA>();
                up.Add(new USUARIO_PROGRAMA
                {
                    FK_Usuario = usuario,
                    FK_Programa = Convert.ToInt32(DdlProgramA.SelectedValue)
                });

                dsLey22.SaveChanges();
                int TotalReg = BindGridView(1);
                this.FillJumpToList(TotalReg);
                this.LoadProgramsDdlA();


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BtnDelProgram_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUser ExistingUser = context.Users.Where(u => u.Id.Equals(DdlEmailD.SelectedValue, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                string usuario = ExistingUser.Id;

                var up = dsLey22.Set<USUARIO_PROGRAMA>();
                var userprog = new USUARIO_PROGRAMA
                {
                    FK_Usuario = usuario,
                    FK_Programa = Convert.ToInt32(DdlProgramD.SelectedValue)
                };

                dsLey22.USUARIO_PROGRAMA.Attach(userprog);
                dsLey22.USUARIO_PROGRAMA.Remove(userprog);
                dsLey22.SaveChanges();
                int TotalReg = BindGridView(1);
                this.FillJumpToList(TotalReg);
                this.LoadProgramsDdlD();

            }
            catch (Exception)
            {
                throw;
            }
        }

        int BindGridView(int pagina)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var programas_director = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();
            var emails_programas_director = dsLey22.USUARIO_PROGRAMA.Where(u => programas_director.Contains(u.FK_Programa)).Select(p => p.FK_Usuario).ToList();
            List<ApplicationUser> emails_programas;

            if (userManager.IsInRole(userId, "Director"))
            {
                emails_programas = context.Users.Where(u => emails_programas_director.Contains(u.Id)).ToList();//Emails de usuarios con programas asignados
            }
            else
            {
                emails_programas = context.Users.ToList();//Emails de usuarios con programas asignados
            }


            var usuario_programa = (from a in dsLey22.USUARIO_PROGRAMA select new { a.FK_Usuario}).Distinct();//PK de usuarios con programas asignados

            var programa_usuario = dsLey22.USUARIO_PROGRAMA.ToList();//PK de programas con usuarios asignados

            var sprogramas = dsPerfil.SA_PROGRAMA.ToList();

            var programas = (from m in sprogramas
                             join f in programa_usuario
                             on m.PK_Programa equals f.FK_Programa
                             select new
                             {
                                 m.PK_Programa,
                                 m.NB_Programa,
                                 f.FK_Usuario
                             });

            var UserProgram = (from user in emails_programas join up in usuario_programa on user.Id equals up.FK_Usuario
                               select new
                               {
                                   Email = user.Email,
                                   Program = (from programs in programas where programs.FK_Usuario == user.Id
                                              select programs.NB_Programa).ToList()
                               }).ToList();
                                var UserPrograms = UserProgram.Select(p => new UserProgramModel()
                               {
                                   Email = p.Email,
                                   Program = string.Join(" - ", p.Program)
                               }).ToList();
         

            LitCantidadUsuarios.Text = UserPrograms.Count.ToString();

            GridView1.PageIndex = pagina - 1;
            GridView1.DataSource = UserPrograms;
            GridView1.DataBind();
            return UserPrograms.Count();

        }

        protected IEnumerable<string> GetPrograms(string PK_Usuario)
        {
            var programa_usuario = dsLey22.USUARIO_PROGRAMA.ToList();
            var saprograms = dsPerfil.SA_PROGRAMA.ToList();

            var programas = (from m in saprograms
                            join f in programa_usuario
                            on m.PK_Programa equals f.FK_Programa
                            select new
                            {
                                m.PK_Programa,
                                m.NB_Programa,
                                f.FK_Usuario
                            });

            return (from programs in programas where programs.FK_Usuario == PK_Usuario select programs.NB_Programa);
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)

            {
                ViewState["SortDirection"] = "ASC";
                GridView1.PageIndex = 0;
            }

            else if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }

            else if (ViewState["SortDirection"].ToString() == "DESC")
            {
                ViewState["SortDirection"] = "ASC";
            }

            ViewState["SortExpression"] = e.SortExpression;
            //  BindGridView();
        }

        private void FillJumpToList(int TotalRows)

        {
            int PageCount = this.CalculateTotalPages(TotalRows);
            for (int i = 1; i <= PageCount; i++)
            {
                ddlJumpTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            //  BindGridView();
        }

        protected void PageNumberChanged(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpTo.SelectedItem.Value);
            this.BindGridView(PageNo);
        }

        private int CalculateTotalPages(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(GridView1.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
        }
    }
}