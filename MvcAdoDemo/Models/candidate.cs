using System.ComponentModel.DataAnnotations;

namespace MvcAdoDemo.Models
{
    // Retain the original property names to remain compatible with the 2020 Razor views.
    public class candidate
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Regno { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, EmailAddress, StringLength(254)]
        public string Email { get; set; }

        [Required, Phone, StringLength(30)]
        public string Phoneno { get; set; }

        [StringLength(20)]
        public string Dept { get; set; }

        [StringLength(100)]
        public string skills { get; set; }

        public int? Yearofpassing { get; set; }
        public double? CGPA { get; set; }
        public int? Backlogs { get; set; }
    }
}
