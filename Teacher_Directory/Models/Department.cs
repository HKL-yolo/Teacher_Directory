namespace Teacher_Directory.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
       = new List<Teacher>();

        public ICollection<Subject> Subjects { get; set; }
            = new List<Subject>();
    }
}

