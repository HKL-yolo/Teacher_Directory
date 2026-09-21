using System.ComponentModel.DataAnnotations;

namespace Teacher_Directory.Models
{
    public enum Gender
    {
        Male, Female, Other, PreferNotToSay
    }
    public class Teacher
    {
        public int Id { get; set; }

        public required string Teachercode { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be at least 2 characters.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Please enter correct first name")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be at least 2 characters.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Please enter correct last name")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        public string? PhotoURL { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a position.")]
        public string? Position { get; set; }

        [Display(Name = "Office")]
        [StringLength(50, ErrorMessage = "Office location cannot exceed 50 characters.")]
        public string? OfficeLocation { get; set; }

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
