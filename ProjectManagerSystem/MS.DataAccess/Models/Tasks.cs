using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.DataAccess.Models
{
    public class Tasks
    {
        public Tasks()
        {
        }

        public Tasks(int id, int projectId, string userId, int statusId, string sortNameTask, string name, string description)
        {
            Id = id;
            ProjectId = projectId;
            UserId = userId;
            StatusId = statusId;
            SortNameTask = sortNameTask;
            Name = name;
            Description = description;
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int StatusId { get; set; }
        // sornametask = projectsortname + task.count trong project do.
        [Required, StringLength(10, MinimumLength = 1)]
        public string SortNameTask { get; set; }

        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project prt { get; set; }

        [ForeignKey("UserId")]
        public virtual AspNetUser usr { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status sts { get; set; }
    }
}
