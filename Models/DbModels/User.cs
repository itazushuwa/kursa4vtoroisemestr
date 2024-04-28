using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    public class User
    {
        [Key] public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? UserRole { get; set; }
        public DateTime UserRegDate { get; set; }
    }
}
