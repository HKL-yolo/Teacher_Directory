using Teacher_Directory.Models;
namespace Teacher_Directory.ViewModels
{
    public class TeacherSubjectViewModels
    {
        public IEnumerable<Teacher> Teachers { get; set; } = new List<Teacher>();
        public IEnumerable<Subject> Subject { get; set; } = new List<Subject>();

    }
}
