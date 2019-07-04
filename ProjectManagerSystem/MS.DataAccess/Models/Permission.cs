using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.DataAccess.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual IdentityRole IdentityRole { get; set; }
        public int FunctionID { get; set; }
        [ForeignKey("FunctionID")]
        public virtual Function Function { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }


    }
}
