using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    public class Course
    {
        [Key] public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public int CoursePrice { get; set; }
        public int CourseTeacher { get; set; }
    }
}
