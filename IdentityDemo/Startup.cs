using IdentityDemo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(IdentityDemo.Startup))]
namespace IdentityDemo
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           app.UseCookieAuthentication(new CookieAuthenticationOptions()
           {
               AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
           });
            // copy and cheat
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //    Provider = new CookieAuthenticationProvider
            //    {
            //        // Enables the application to validate the security stamp when the user logs in
            //        // This is a security feature which is used when you change a password or add an external login to your account.  
            //        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager<User>, User>(
            //            validateInterval: TimeSpan.FromMinutes(30),
            //            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            //    }
            //});
        }
    }
}