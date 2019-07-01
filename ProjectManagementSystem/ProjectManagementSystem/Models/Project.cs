using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        // dem tu tang ở task.        
        public int CountTask { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(4, MinimumLength = 1)]
        public string SortName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public virtual ICollection<ApplicationUser> User { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }

    }
}