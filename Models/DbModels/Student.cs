using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    //asdasd
    public class Student
    {
        [Key] public int StudentID { get; set; }
        public string? UserRole { get; set; }
        public string? StudentName { get; set; }
    }
}
