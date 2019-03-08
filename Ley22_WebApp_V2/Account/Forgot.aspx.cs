using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Ley22_WebApp_V2.Models;
using System.IO;

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
                    FailureText.Text = "EL usuario no existe o no se ha confirmado la cuenta.";
                    ErrorMessage.Visible = true;
                    return;
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                string code = manager.GeneratePasswordResetToken(user.Id);
                string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);

                string body = CreateBody(callbackUrl, user.FirstName, user.LastName);
                manager.SendEmail(user.Id, "Restablecer Cuenta", body);


               // manager.SendEmail(user.Id, "Reset Password",  callbackUrl);
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }

        protected void Login(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login");
            return;
        }

        private string CreateBody(string Code, string FirstName, string LastName)
        {
            string body = string.Empty;                
            string code = "<a href =\"" + Code + "\" class=\"es-button\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:18px;color:#4A7EB0;border-style:solid;border-color:#EFEFEF;border-width:10px 25px;display:inline-block;background:#EFEFEF;border-radius:0px;font-weight:normal;font-style:normal;line-height:22px;width:auto;text-align:center;\">Crear Contraseña</a>";

            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailPassword.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{NombreCompleto}", FirstName + " " + LastName);
            body = body.Replace("{botonCrear}", code);

            return body;

        }

    }
}