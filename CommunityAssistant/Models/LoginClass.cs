using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistant.Models
{
    public class LoginClass
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginClass() { }
        public LoginClass(string user, string password)
        {
            Username = user;
            Password = password;
        }
    }
}