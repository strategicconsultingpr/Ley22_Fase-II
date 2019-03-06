using System;
using System.Xml.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Ley22_WebApp_V2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI.WebControls;
using Ley22_WebApp_V2.Old_App_Code;
using System.Collections.Generic;

namespace Ley22_WebApp_V2.Account
{
    public partial class Register : Page
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

                LoadDropDownList();
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = EmailInput.Text, Email = EmailInput.Text, FirstName = FirstNameInput.Text, LastName = LastNameInput.Text };
            IdentityResult result = manager.Create(user, PasswordInput.Text);
            if (result.Succeeded)
            {
                ApplicationUser newuser = context.Users.Where(u => u.UserName.Equals(EmailInput.Text, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.AddToRole(newuser.Id, DdlRol.SelectedValue);
                string usuario = newuser.Id;
                //var programas_usuario = dsLey22.USUARIO_PROGRAMA.Where(u => newuser.Id.Contains(u.FK_Usuario.ToString())).Select(p => p.FK_Programa);
                //int prog = Convert.ToInt32(DdlPrograma.SelectedValue);
                //var programa = dsLey22.USUARIO_PROGRAMA.Where(u => programas_usuario.Contains(u.FK_Programa)).Select(p => p.FK_Programa);
                var up = dsLey22.Set<USUARIO_PROGRAMA>();
                up.Add(new USUARIO_PROGRAMA
                {
                    FK_Usuario = usuario,
                    FK_Programa = Convert.ToInt32(DdlPrograma.SelectedValue)
                });
                try
                {
                    dsLey22.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                manager.SendEmail(user.Id, "Confirm your account", callbackUrl);

                // signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                Response.Redirect("Register.aspx", false);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        void LoadDropDownList()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var usuarios_programas = new List<int>();
            List<ListItem> roles;

            if (userManager.IsInRole(userId, "Director"))
            {
                usuarios_programas = dsLey22.USUARIO_PROGRAMA.Where(u => u.FK_Usuario.Equals(userId)).Select(p => p.FK_Programa).ToList();

                roles = context.Roles.Where(p => !p.Name.Equals("SuperAdmin")).Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();

                DdlRol.DataValueField = "Value";
                DdlRol.DataTextField = "Text";
                DdlRol.DataSource = roles;
                DdlRol.DataBind();
                DdlRol.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
            else
            {
                usuarios_programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Select(p => p.PK_Programa).ToList().Select<short, int>(i => i).ToList();

                roles = context.Roles.Select(r => new ListItem { Value = r.Name, Text = r.Name }).ToList();

                DdlRol.DataValueField = "Value";
                DdlRol.DataTextField = "Text";
                DdlRol.DataSource = roles;
                DdlRol.DataBind();
                DdlRol.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }

              

            var programas = dsPerfil.SA_PROGRAMA.Where(u => u.NB_Programa.Contains("LEY 22")).Where(p => usuarios_programas.Contains(p.PK_Programa)).Select(r => new ListItem { Value = r.PK_Programa.ToString(), Text = r.NB_Programa }).ToList();

            if (usuarios_programas.Count() == 1)
            {
                DdlPrograma.DataValueField = "Value";
                DdlPrograma.DataTextField = "Text";
                DdlPrograma.DataSource = programas;
                DdlPrograma.DataBind();
                DdlPrograma.SelectedValue = programas[0].Value;              
            }
            else
            {
                DdlPrograma.DataValueField = "Value";
                DdlPrograma.DataTextField = "Text";
                DdlPrograma.DataSource = programas;
                DdlPrograma.DataBind();
                DdlPrograma.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
        }
    }
}