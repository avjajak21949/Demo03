using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [StringLength(100)]
        [Display(Name = "Location")]
        public string Place { get; set; }

        [Required]
        [Display(Name = "Course Time")]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Course Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [Range(1, 6)]
        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; } = 3;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Course Price")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
