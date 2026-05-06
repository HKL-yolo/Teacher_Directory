namespace Teacher_Directory.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public required string SubjectName { get; set; }
        public ICollection<Course>? Course { get; set; }
    }
}
