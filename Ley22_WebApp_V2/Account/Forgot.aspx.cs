using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Ley22_WebApp_V2.Models;

namespace Ley22_WebApp_V2.Account
{
    public partial class ForgotPassword : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user's email address
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "The user either does not exist or is not confirmed.";
                    ErrorMessage.Visible = true;
                    return;
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                string code = manager.GeneratePasswordResetToken(user.Id);
                string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);


                string mensaje = " <div class=\"container h-100\">" +
                           "<div class=\"row align-items-center h-100\">" +
                           " <div class=\"col\"> " +
                            "</div>" +
                            "<div class=\"col-lg-6 col-md-8 col-sm-10\">" +
                             " <div class=\"card card-login\">" +
                               " <div class=\"card-block text-center\">" +
                                    "<div class=\"logo-login\">" +
                                     " <img src = \"images/assmca-big-logo.png\" alt=\"ASSMCA\">" +
                                   " </div>" +
                                 " <div class=\"row\">" +
                                  "  <div class=\"col\"></div>" +
                                  "  <div class=\"col-10\">" +
                                 "       <hr />" +
                                  "      Favor de restablecer su contraseña presionando" +
                                   "     <br /><br />" +
                                   "      < a href = \"" + callbackUrl + "\" class=\"btn btn-primary\">Restablecer Contraseña</a> " +
                                  "   </div>" +
                                  "   < div class=\"col\"></div>" +
                                "   </div>" +
                              "   </div>" +
                            "   </div>" +
                           "  </div>" +
                          "   < div class=\"col\">" +
                         "    </div>" +
                       "    </div>" +
                      "   </div> ";


                manager.SendEmail(user.Id, "Reset Password",  callbackUrl);
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }

        protected void Login(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login");
            return;
        }
    }
}