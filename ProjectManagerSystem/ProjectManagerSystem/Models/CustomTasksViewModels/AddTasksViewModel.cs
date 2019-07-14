using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models.CustomTasksViewModels
{
    public class AddTasksViewModel
    {
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
    }
}