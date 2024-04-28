using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    public class Grades
    {
        [Key] public int GradeID { get; set; }
        public int Grade { get; set; }
        public string? GradeDescription { get; set; }
        public int GradeCourse { get; set; }
        public DateOnly? GradeDate { get; set; }
    }
}
