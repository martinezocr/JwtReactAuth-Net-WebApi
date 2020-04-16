using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJwt.Model
{
    public class LoginModel
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        
    }

    public class Users
    {
        public string Firstname { get; set; }
        public string User { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string token { get; set; }
    }
}
