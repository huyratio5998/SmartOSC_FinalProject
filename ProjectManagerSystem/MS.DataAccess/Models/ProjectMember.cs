using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.DataAccess.Models
{
    public class ProjectMember
    {
        public ProjectMember()
        {
        }

        public ProjectMember(string userId, int projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }
        [Key]
        public int Id { get; set; }        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AspNetUser User { get; set; }        
        public int ProjectId { get; set; }    
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
