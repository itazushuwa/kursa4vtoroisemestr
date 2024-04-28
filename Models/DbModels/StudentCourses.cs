using Microsoft.EntityFrameworkCore;

namespace rep.Models.DbModels
{
    [Keyless]
    public class StudentCourses
    {

        public int StudentID { get; set; }
        public int CourseID { get; set; }  

    }
}
