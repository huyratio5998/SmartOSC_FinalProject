using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class AspNetUsersViewModel
    {
        //public AspNetUsersViewModel()
        //{
        //    Roles = new List<string>();
        //}

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string Avatar { get; set; }
        public string Role { get; set; }
    }
}