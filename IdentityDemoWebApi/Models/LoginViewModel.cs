using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace corp.scm.security.web.api.Models
{
    public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}