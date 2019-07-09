using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class TasksViewModel
    {
        public int Id { get; set; }

      
        // sornametask = projectsortname + task.count trong project do.
        [Required, StringLength(10, MinimumLength = 1)]
        public string SortNameTask { get; set; }

        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public int StatusId { get; set; }
        public virtual ProjectViewModel prt { get; set; }

     
        public virtual AspNetUsersViewModel usr { get; set; }

     
        public virtual StatusViewModel sts { get; set; }
    }
}