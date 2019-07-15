using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class ProjectMemberViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProjectId { get; set; }
    }
}