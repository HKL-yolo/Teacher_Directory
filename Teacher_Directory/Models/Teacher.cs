using System.ComponentModel.DataAnnotations;

namespace Teacher_Directory.Models
{
    public enum Gender
    {
        Male, Female, Other, PreferNotToSay
    }
    public class Teacher
    {
        public required int Id { get; set; }
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Teacher code should be 3 capital letter")]

        public required string Teachercode { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string? Email { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Gender Gender { get; set; }
        public string? PhotoURL { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public string? Position { get; set; }
        public Department? Department { get; set; }
        public ICollection<Course>? Course { get; set; }

        public string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }
    }
}
