namespace Teacher_Directory.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Teacher>? Teacher { get; set; }
    }
}

