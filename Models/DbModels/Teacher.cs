using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    public class Teacher
    {
        [Key] public int TeacherId { get; set; }
        public string? UserRole { get; set; }
        public string? TeacherName { get; set; }
        public string? TeacherProfile { get; set; }
        public double TeacherExperience { get; set; }
    }
}
