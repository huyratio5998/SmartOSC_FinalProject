using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    
    public class Tasks
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        // SortName + CountTask.
        public string TaskID { get; set; }
        [Required,StringLength(100,MinimumLength =2)]
        public string Name { get; set; }
        [Required, StringLength(500, MinimumLength = 2)]
        public string Description { get; set; }

        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Projects { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]        
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Status> Status { get; set; }
    }
}