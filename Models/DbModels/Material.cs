using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    public class Material
    {
        [Key] public int MaterialID { get; set; }
        public string? MaterialTitle { get; set; }
        public string? MaterialType { get; set; }
        public int MaterialCourse { get; set; }
        public string? MaterialDescription { get; set; }
    }
}
