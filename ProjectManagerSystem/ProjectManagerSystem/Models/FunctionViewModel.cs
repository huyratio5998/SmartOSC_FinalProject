using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class FunctionViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        [StringLength(250)]
        public string URL { set; get; }


        [StringLength(128)]
        //so sanh với Id của các function.
        public string ParentId { set; get; }

        public string IconCss { get; set; }
        public int SortOrder { set; get; }
    }
}