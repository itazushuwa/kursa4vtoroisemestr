using Microsoft.EntityFrameworkCore;

namespace rep.Models.DbModels
{
    [Keyless]
    public class StudentGrades
    {
        public int SudentID { get; set; }
        public int GradeID { get; set; }
    }
}
