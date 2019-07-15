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
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        public bool isDeleted { get; set; }        
        public string PmId { get; set; }
        public string ProjectManagerName { get; set; }
        public int Tasks { get; set; }
    }
}