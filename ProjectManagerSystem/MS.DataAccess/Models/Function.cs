using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.DataAccess.Models
{
    public class Function
    {
        public Function()
        {
        }

        public Function(int id, string name, string uRL, string parentId, string iconCss, int sortOrder)
        {
            Id = id;
            Name = name;
            URL = uRL;
            ParentId = parentId;
            IconCss = iconCss;
            SortOrder = sortOrder;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string URL { get; set; }
        public string ParentId { get; set; }
        public string IconCss { get; set; }
        public int SortOrder { get; set; }
    }
}
