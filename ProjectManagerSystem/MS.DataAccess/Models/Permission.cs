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
        public Permission()
        {
        }

        public Permission(int id, string roleId, int functionID, bool canRead, bool canCreate, bool canUpdate, bool canDelete)
        {
            Id = id;
            RoleId = roleId;
            
            FunctionID = functionID;
            
            CanRead = canRead;
            CanCreate = canCreate;
            CanUpdate = canUpdate;
            CanDelete = canDelete;
        }

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
