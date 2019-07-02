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
    [Table("AspNetUsers")]
    public class AspNetUsers : IdentityUser
    {
        public string UrlAvatar { get; set; }

        [Required, StringLength(32, MinimumLength = 2)]
        public string FullName { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual ICollection<Project> Prj { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AspNetUsers> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
}
