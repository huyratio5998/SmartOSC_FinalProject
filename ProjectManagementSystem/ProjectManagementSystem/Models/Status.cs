using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProjectManagementSystem.Models;
namespace ProjectManagementSystem.Models
{
    public class Status
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public int TaskID { get; set; }
        [ForeignKey("TaskID")]
        public virtual Tasks Task { get; set; }
    }
}