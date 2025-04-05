using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Demo03.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Course { get; set; }

        [Required]
        [StringLength(20)]
        public string YearOfStudy { get; set; }

        // Navigation properties
        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<Document> Documents { get; set; }

        public Student()
        {
            Meetings = new HashSet<Meeting>();
            Documents = new HashSet<Document>();
        }
    }
} 