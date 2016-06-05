using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityDemo.Models
{
    public class User : IdentityUser
    {
        public string Skype { get; set; }
        public double Salary { get; set; }
    }
}