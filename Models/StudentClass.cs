namespace Demo03.Models
{
    public class StudentClass
    {
        public int StudentClassID { get; set; }
        public int ClassID { get; set; }
        public Class Class { get; set; }
        public int SEID { get; set; }
        public StudentEnrollment StudentEnrollment { get; set; }
    }
}
