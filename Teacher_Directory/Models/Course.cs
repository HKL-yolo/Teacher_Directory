using System.ComponentModel.DataAnnotations;

namespace Teacher_Directory.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        [RegularExpression(@"^[A-E]\d{2}$", ErrorMessage = "Please enter correct room number")]
        public string Room_Num { get; set; }
        [Range(9, 13, ErrorMessage = "Please enter correct year level")]
        public int Year { get; set; }
        [Display(Name = "Teacher")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        [Display(Name = "Subject")]
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
