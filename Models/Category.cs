using System.Collections.Generic;

namespace Demo03.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
