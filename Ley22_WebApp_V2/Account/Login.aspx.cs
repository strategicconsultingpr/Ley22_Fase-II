﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Ley22_WebApp_V2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace Ley22_WebApp_V2.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                ApplicationDbContext context = new ApplicationDbContext();

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = manager.FindByName(EmailInput.Text);
                if (user != null)
                {
                    if (!user.EmailConfirmed && user.Email != "admin@assmca.pr.gov")
                    {
                        FailureText.Text = "Invalid login attempt. You must have a confirmed email account.";
                        ErrorMessage.Visible = true;
                        ResendConfirm.Visible = true;
                    }
                    else
                    {
                        // This doen't count login failures towards account lockout
                        // To enable password failures to trigger lockout, change to shouldLockout: true
                        var result = signinManager.PasswordSignIn(EmailInput.Text, PasswordInput.Text, RememberMe.Checked, shouldLockout: false);

                        switch (result)
                        {
                            case SignInStatus.Success:
                                try
                                {
                                    ApplicationUser ExistingUser = context.Users.Where(u => u.Email.Equals(EmailInput.Text, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                                    var rol = userManager.GetRoles(ExistingUser.Id);
                                    Session["Role_Usuario"] = rol[0];
                                    Session["User"] = ExistingUser;
                                    Session["Id_Participante"] = 0;
                                    Session["NombreParticipante"] = "";
                                    if (ExistingUser.PasswordChanged)
                                    {
                                        if (userManager.IsInRole(ExistingUser.Id, "SuperAdmin") || userManager.IsInRole(ExistingUser.Id, "Director") || userManager.IsInRole(ExistingUser.Id, "TrabajadorSocial") || userManager.IsInRole(ExistingUser.Id, "CoordinadorCharlas"))
                                        {
                                            Response.Redirect("~/Dashboard-Usuarios");
                                        }
                                        else if (userManager.IsInRole(ExistingUser.Id, "Recepcion"))
                                        {
                                            Response.Redirect("~/Entrada");
                                        }
                                        else if (userManager.IsInRole(ExistingUser.Id, "Recaudador"))
                                        {
                                            Response.Redirect("~/recaudos-busqueda-usuario");
                                        }
                                        else
                                        {
                                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }


                                break;
                            case SignInStatus.LockedOut:
                                Response.Redirect("/Account/Lockout");
                                break;
                            case SignInStatus.RequiresVerification:
                                Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                                Request.QueryString["ReturnUrl"],
                                                                RememberMe.Checked),
                                                  true);
                                break;
                            case SignInStatus.Failure:
                            default:
                                FailureText.Text = "Invalid login attempt";
                                ErrorMessage.Visible = true;
                                break;
                        }
                    }
                }
            }
        }

        protected void SendEmailConfirmationToken(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(EmailInput.Text);
            if (user != null)
            {
                if (!user.EmailConfirmed)
                {
                    string code = manager.GenerateEmailConfirmationToken(user.Id);
                    string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    manager.SendEmail(user.Id, "Confirm your account", callbackUrl);

                    FailureText.Text = "Confirmation email sent. Please view the email and confirm your account.";
                    ErrorMessage.Visible = true;
                    //ResendConfirm.Visible = false;
                }
            }
        }
    }
}