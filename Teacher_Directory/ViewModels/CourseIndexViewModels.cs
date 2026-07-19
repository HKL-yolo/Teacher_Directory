using Teacher_Directory.Models;
namespace Teacher_Directory.ViewModels
{
    public class CourseIndexViewModels
    {
        public int Id { get; set; }
        public required string CourseName { get; set; }
        public string Room_Num { get; set; }
        public int Year { get; set; }
        public required Teacher Teacher { get; set; }
        public required Subject Subject { get; set; }
    }
}