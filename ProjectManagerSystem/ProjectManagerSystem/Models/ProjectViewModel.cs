using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        [Required, StringLength(4, MinimumLength = 1)]
        public string SortNameProject { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public bool isDeleted { get; set; }
        public AspNetUsersViewModel User { get; set; }
        
    }
}