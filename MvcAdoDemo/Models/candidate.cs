using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAdoDemo.Models
{
    public class candidate
    {
        public string Name { get; set; } [Required]
        public int Regno { get; set; }  [Required]
        public string Email { get; set; }   [Required]
        public string Phoneno { get; set; } [Required]
        public string Dept { get; set; }
        public string skills { get; set; }
        public Nullable<int> Yearofpassing { get; set; }
        public Nullable<double> CGPA { get; set; }
        public Nullable<int> Backlogs { get; set; }
    }

}