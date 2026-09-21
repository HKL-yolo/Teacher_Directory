using System.ComponentModel.DataAnnotations;

namespace Teacher_Directory.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public required string SubjectName { get; set; }
        public ICollection<Course>? Course { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
