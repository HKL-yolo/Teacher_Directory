using System.ComponentModel.DataAnnotations;

namespace Teacher_Directory.Models
{
    public class Course
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-E]\d{2}$", ErrorMessage = "Room number is not valid.")]
        public string Room_Num { get; set; }
        [Range(9, 13, ErrorMessage = "Please enter correct year level")]
        public int Year { get; set; }
        
        // Del Name later 
        public string Name { get; set; }
        [Display(Name = "Teacher code")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        [Display(Name = "Subject")]
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
