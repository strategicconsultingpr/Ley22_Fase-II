using Ley22_WebApp_V2.Models;
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
    public partial class AssignRole : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDropDowns();
                int TotalReg = BindGridView(1);
                this.FillJumpToList(TotalReg);
            }
            
        }

        protected void LoadDropDowns()
        {
            var roles = context.Roles.Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();

            DdlRol.DataValueField = "Value";
            DdlRol.DataTextField = "Text";
            DdlRol.DataSource = roles;
            DdlRol.DataBind();
            DdlRol.Items.Insert(0, new ListItem("-Seleccione-", "0"));

            var email = context.Users.Select(u => new ListItem { Value = u.Email, Text = u.Email }).ToList();

            DdlEmail.DataValueField = "Value";
            DdlEmail.DataTextField = "Text";
            DdlEmail.DataSource = email;
            DdlEmail.DataBind();
            DdlEmail.Items.Insert(0, new ListItem("-Seleccione-", "0"));
        }

        public void BtnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUser ExistingUser = context.Users.Where(u => u.Email.Equals(DdlEmail.SelectedValue, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                if (!userManager.IsInRole(ExistingUser.Id, DdlRol.SelectedValue))
                {
                    userManager.AddToRole(ExistingUser.Id, DdlRol.SelectedValue);

                    int TotalReg = BindGridView(1);
                    this.FillJumpToList(TotalReg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BtnDelRole_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUser ExistingUser = context.Users.Where(u => u.Email.Equals(DdlEmail.SelectedValue, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                if (userManager.IsInRole(ExistingUser.Id, DdlRol.SelectedValue))
                {
                    userManager.RemoveFromRole(ExistingUser.Id, DdlRol.SelectedValue);

                    int TotalReg = BindGridView(1);
                    this.FillJumpToList(TotalReg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        int BindGridView(int pagina)
        {
            

            var UserRoles = (from user in context.Users
                             select new
                             {
                                 Email = user.Email,
                                 Role = (from userRoles in user.Roles
                                         join role in context.Roles on userRoles.RoleId equals role.Id
                                         select role.Name).ToList()
                             }).ToList().Select(p => new UserViewModel()
                             {
                                 Email = p.Email,
                                 Role = string.Join(",", p.Role)
                             }).ToList();

            LitCantidadUsuarios.Text = UserRoles.Count.ToString();

            GridView1.PageIndex = pagina - 1;
            GridView1.DataSource = UserRoles;
            GridView1.DataBind();
            return UserRoles.Count();

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