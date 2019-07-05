using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models.CustomTasksViewModels
{
    public class CustomTasksViewModels
    {
        public IEnumerable<ProjectViewModel> projectViewModels { get; set; }
        public IEnumerable<AspNetUsersViewModel> aspNetUsersViewModels { get; set; }
        public IEnumerable<StatusViewModel> statusViewModels { get; set; }
    }
}