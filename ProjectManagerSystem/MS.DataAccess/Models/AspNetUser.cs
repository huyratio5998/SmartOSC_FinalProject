using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MS.DataAccess.Models
{
 
    public class AspNetUser : IdentityUser
    {
        public AspNetUser()
        {
        }
        public AspNetUser(string id,string userName, string fullname, string password, string email, string urlAvatar)
        {
            Id = id;
            UserName = userName;
            PasswordHash = password;
            Email = email;
            UrlAvatar = urlAvatar;
            FullName = fullname;
            
        }
       

        public string UrlAvatar { get; set; }

        [Required, StringLength(32, MinimumLength = 2)]
        public string FullName { get; set; }
        
        
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AspNetUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
}
