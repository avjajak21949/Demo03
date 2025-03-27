using System.Collections.Generic;

namespace Demo03.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public string ScheduleInfo { get; set; }
        public int MaxCapacity { get; set; } = 30;
        public ICollection<StudentClass> StudentClasses { get; set; }
    }
}
