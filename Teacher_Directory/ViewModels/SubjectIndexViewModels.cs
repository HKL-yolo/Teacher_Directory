using Teacher_Directory.Models;
namespace Teacher_Directory.ViewModels
{
    public class SubjectIndexViewModels
    {
        public int Id { get; set; }
        public required string SubjectName { get; set; }
        public string DepartmentName { get; set; }
        public int CourseCount { get; set; }

    }
}