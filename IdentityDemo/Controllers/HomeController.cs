﻿using IdentityDemo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Content("Mvc works if you see this");
        }

        public async Task<ActionResult> User()
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
            return Content("Create user successfully");
        }

        public async Task<ActionResult> User2()
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
            return Content("Create user successfully");
        }
    }
}