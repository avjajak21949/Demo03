using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo03.Models
{
    public class StudentEnrollment
    {
        [Key]
        public int SEID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        public string FullName => Name;  // Using Name as FullName for simplicity

        public ICollection<StudentClass> StudentClasses { get; set; }

        public StudentEnrollment()
        {
            StudentClasses = new HashSet<StudentClass>();
        }
    }
}