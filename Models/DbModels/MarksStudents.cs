using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    //asdasd
    public class MarksStudents
    {
        [Key] public int MarkID { get; set; }
        public int ID_Student { get; set; }
        public int Mark {  get; set; }
        public int ID_Teacher { get; set; }

    }
}
