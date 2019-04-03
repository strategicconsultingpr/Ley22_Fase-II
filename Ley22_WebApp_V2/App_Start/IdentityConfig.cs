﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Ley22_WebApp_V2.Models;

using System.Net.Mail;
using System.Web;
using System.Net.Mime;
using System.Configuration;

namespace Ley22_WebApp_V2
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.Factory.StartNew(() =>
            {
                sendMail(message);
            });
        }

        public Task SendAsyncCita(string email, string subject, string body)
        {
            // Plug in your email service here to send an email.
            return Task.Factory.StartNew(() =>
            {
                sendMailCita(email,subject,body);
            });
        }

        void sendMail(IdentityMessage message)
        {
            string text = string.Empty;
            string html = string.Empty;

            //if (message.Subject == "Reset Password")
            //{
            //    #region formatter
            //     text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
            //     html = "Favor de restablecer su contraseña presionando <br/><br/> <a href=\"" + message.Body + "\">Restablecer Contraseña</a><br/><br/><br/>";

            //    html += HttpUtility.HtmlEncode(@"O presione esta referencia para restablecer su contraseña: " + message.Body);
            //    #endregion
            //}
            //else
            //{
            //   // text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
            //    html = message.Body;

            //    //html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser: " + message.Body);
            //}

            AlternateView imgview = AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html);
            LinkedResource lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/logo_1.jpg");
            lr.ContentId = "logo_1";
            imgview.LinkedResources.Add(lr);

            lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/logo_2.png");
            lr.ContentId = "logo_2";
            imgview.LinkedResources.Add(lr);

            lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/twitter-circle-colored.png");
            lr.ContentId = "twitter";
            imgview.LinkedResources.Add(lr);

            lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/facebook-circle-colored.png");
            lr.ContentId = "facebook";
            imgview.LinkedResources.Add(lr);



            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(imgview);
            msg.Body = lr.ContentId;

           // msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
           // msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient("vassmcaweb", Convert.ToInt32(25));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtpClient.Credentials = credentials;
           // smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
        }

        void sendMailCita(string email, string subject, string body)
        {
            AlternateView imgview = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            LinkedResource lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/logo_1.jpg");
            lr.ContentId = "logo_1";
            imgview.LinkedResources.Add(lr);

            lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/logo_2.png");
            lr.ContentId = "logo_2";
            imgview.LinkedResources.Add(lr);

            lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/twitter-circle-colored.png");
            lr.ContentId = "twitter";
            imgview.LinkedResources.Add(lr);

            lr = new LinkedResource("//vassmcaweb/wwwroot/LEY22/images/facebook-circle-colored.png");
            lr.ContentId = "facebook";
            imgview.LinkedResources.Add(lr);


            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
            msg.To.Add(new MailAddress(email));
            msg.Subject = subject;
            msg.AlternateViews.Add(imgview);
            msg.Body = lr.ContentId;

            SmtpClient smtpClient = new SmtpClient("vassmcaweb", Convert.ToInt32(25));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtpClient.Credentials = credentials;
            //smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
