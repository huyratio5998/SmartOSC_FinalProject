using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required, StringLength(10, MinimumLength = 1)]
        public string SortNameTask { get; set; }

        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project prt { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser usr { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status sts { get; set; }
    }
}
