using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class AspNetRolesViewModel
    {
        public AspNetRolesViewModel() { }
        public AspNetRolesViewModel(AspNetRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}