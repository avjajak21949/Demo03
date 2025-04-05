using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo03.Models
{
    public class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
        }

        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        public string Title => Name;  // For backward compatibility

        public int Id => CourseID;    // For backward compatibility

        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }

        // Navigation property
        [Range(250, 50000)]
        public int Price { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Time { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool IsApproved { get; set; } = false; // Default is false (not approved)
        public virtual ICollection<Class> Classes { get; set; }
    }
}
