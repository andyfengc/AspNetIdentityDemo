using IdentityDemoWebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
[assembly: OwinStartupAttribute(typeof(IdentityDemoWebApi.Startup))]
namespace IdentityDemoWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //// cookie based
            //app.UseCookieAuthentication(new CookieAuthenticationOptions()
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            //});

            // token based
            OAuthAuthorizationServerOptions serverOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };
            // token generation
            app.UseOAuthAuthorizationServer(serverOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            //enable cors
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }

    internal class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using ( var db = new IdentityDbContext<User>("IdentityContext"))
            {
                var store = new UserStore<User>(db);
                var userManager = new UserManager<User>(store);
                var user = await userManager.FindByEmailAsync(context.UserName);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);

                //// return roles
                ////http://stackoverflow.com/questions/24096634/return-user-roles-from-bearer-token-of-web-api
                //ClaimsIdentity oAuthIdentity = await userManager.CreateIdentityAsync(user,
                //context.Options.AuthenticationType);
                //ClaimsIdentity cookiesIdentity = await userManager.CreateIdentityAsync(user,
                //    CookieAuthenticationDefaults.AuthenticationType);
                //var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                //AuthenticationProperties properties = CreateProperties(user.UserName, Newtonsoft.Json.JsonConvert.SerializeObject(roles.Select(x => x.Value)));
                //AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
                //context.Validated(ticket);
                //context.Request.Context.Authentication.SignIn(cookiesIdentity);
            }

        }

        private AuthenticationProperties CreateProperties(string userName, string Roles)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
        {
            { "userName", userName },
            {"roles",Roles}
        };
            return new AuthenticationProperties(data);
        }
    }
}