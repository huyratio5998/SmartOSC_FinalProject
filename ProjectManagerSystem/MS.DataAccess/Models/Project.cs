using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MS.DataAccess.Models
{
    public class Project
    {
        public Project()
        {
        }

        public Project(int id, string name, string sortNameProject, DateTime? startDate, DateTime? endDate, bool isDeleted, string pmId)
        {
            Id = id;            
            Name = name;
            SortNameProject = sortNameProject;
            StartDate = startDate;
            EndDate = endDate;
            this.isDeleted = isDeleted;
            PmId = PmId;
        }

        [Key]
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

        public string PmId { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}