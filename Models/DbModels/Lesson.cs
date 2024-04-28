using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    public class Lesson
    {
        [Key] public int LessonID { get; set; }
        public DateTime LessonStartDate { get; set; }
        public DateTime LessonEndDate { get; set; }
        public string? LessonDayOfWeek { get; set; }
        public string? LessonName { get; set; }
        public int LessonDuration { get; set; }
        public int LessonCourse { get; set; }
        public int LessonTeacher { get; set; }
    }
}
