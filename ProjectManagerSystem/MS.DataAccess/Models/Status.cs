using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MS.DataAccess.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
    }
}