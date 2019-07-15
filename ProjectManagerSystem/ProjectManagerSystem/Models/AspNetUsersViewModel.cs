using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { set; get; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required]
        [Display(Name = "Password")]
        public string Password { set; get; }
        [Required]
        [StringLength(32, MinimumLength = 2)]
        [Display(Name = "User Name")]
        public string UserName { set; get; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public int Projects { get; set; }
        public int Tasks { get; set; }
    }
}