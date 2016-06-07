using corp.scm.security.web.api.Models;
using IdentityDemoWebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityDemoWebApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json("WebApi works if you see this");
        }
        [HttpGet]
        public async Task<IHttpActionResult> User()
        {
            var db = new IdentityDbContext<IdentityUser>("IdentityContext");
            var store = new UserStore<IdentityUser>(db);
            var manager = new UserManager<IdentityUser>(store);
            var email = "andy@gmail.com";
            var password = "Pass123";
            var user = await manager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email,
                    Email = email
                };
                await manager.CreateAsync(user, password);
            }
            return Json("Create user successfully");
        }

        [HttpGet]
        public async Task<IHttpActionResult> User2()
        {
            var db = new IdentityDbContext<User>("IdentityContext");
            var store = new UserStore<User>(db);
            var manager = new UserManager<User>(store);
            var email = "andy@gmail.com";
            var password = "Pass123";
            var user = await manager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    Skype = "andy@skype.com",
                    Salary = 3000
                };
                await manager.CreateAsync(user, password);
            }
            return Json("Create custom user successfully");
        }
        [HttpGet]
        public async Task<IHttpActionResult> User3()
        {
            var db = new IdentityDbContext<User>("IdentityContext");
            var store = new UserStore<User>(db);
            var manager = new UserManager<User>(store);
            var email = "juan@gmail.com";
            var password = "pass123";
            var user = await manager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    Skype = "juan@skype.com",
                    Salary = 3000
                };
                await manager.CreateAsync(user, password);
            }
            return Json("Create custom user successfully");
        }
        [Authorize]
        [HttpGet]
        public IHttpActionResult Secure()
        {
            return Json("successfully logged in if you see this");
        }
        [Authorize]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            var Name = ClaimsPrincipal.Current.Identity.Name;
            //var Name1 = User.Identity.Name;

            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Login()
        {
            var db = new IdentityDbContext<User>("IdentityContext");
            var store = new UserStore<User>(db);
            var manager = new UserManager<User>(store);
            var signinManager = new SignInManager<User, string>(manager, Request.GetOwinContext().Authentication);
            var email = "andy@gmail.com";
            var password = "Pass123";
            var result = await signinManager.PasswordSignInAsync(email, password, true, false);
            switch (result)
            {
                case SignInStatus.Success:
                    return Json("You already signed in");
                case SignInStatus.Failure:
                case SignInStatus.LockedOut:
                default:
                    return Json("sign in failed");
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> Login(LoginViewModel loginModel)
        {
            var db = new IdentityDbContext<User>("IdentityContext");
            var store = new UserStore<User>(db);
            var manager = new UserManager<User>(store);
            var signinManager = new SignInManager<User, string>(manager, Request.GetOwinContext().Authentication);
            var username = loginModel.username;
            var password = loginModel.password;
            var result = await signinManager.PasswordSignInAsync(username, password, true, false);
            switch (result)
            {
                case SignInStatus.Success:
                    return Json("You already signed in");
                case SignInStatus.Failure:
                case SignInStatus.LockedOut:
                default:
                    return BadRequest("sign in failed");
            }
        }
    }
}
