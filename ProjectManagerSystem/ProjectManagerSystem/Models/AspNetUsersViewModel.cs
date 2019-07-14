﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class AspNetUsersViewModel
    {
        public AspNetUsersViewModel()
        {
            Roles = new List<string>();
        }
        public string Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public List<string> Roles { get; set; }

    }
}