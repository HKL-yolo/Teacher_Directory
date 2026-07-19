using Teacher_Directory.Models;
namespace Teacher_Directory.ViewModels
{
    public class DepartmentIndexViewModels
    {
        public int Id { get; set; }
        public required string DepartmentName { get; set; }
        public int TeacherCount { get; set; }
        public int SubjectCount { get; set; }
    }
}
