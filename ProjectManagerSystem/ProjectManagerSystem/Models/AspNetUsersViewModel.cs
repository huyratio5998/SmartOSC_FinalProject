using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class AspNetUsersViewModel
    {
        public AspNetUsersViewModel()
        {
        }

        public AspNetUsersViewModel(string id, string fullName, string email, string password, string userName, string avatar)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
            UserName = userName;
            Avatar = avatar;
          
        }

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
        public string RoleId { get; set; }
        public int Projects { get; set; }
        public int Tasks { get; set; }
    }
}