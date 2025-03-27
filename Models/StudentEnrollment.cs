using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo03.Models
{
    public class StudentEnrollment
    {
        [Key]
        public int SEID { get; set; }
        public string Name { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
    }
}