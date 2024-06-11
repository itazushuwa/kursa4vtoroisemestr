using System.ComponentModel.DataAnnotations;

namespace rep.Models.DbModels
{
    //asdasd
    public class Review
    {
        [Key] public int ReviewID { get; set; }
        public int ReviewStudent { get; set; }
        public double ReviewRating { get; set; }
        public string? ReviewTitle { get; set; }
    }
}
