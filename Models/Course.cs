using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo03.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(250, 50000)]
        public int Price { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Time { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool IsApproved { get; set; } = false; // Default is false (not approved)
        public ICollection<Class> Classes { get; set; }
    }
}
