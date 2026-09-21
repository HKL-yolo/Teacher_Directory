using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teacher_Directory.Areas.Identity.Data;
using Teacher_Directory.Models;

namespace Teacher_Directory.Areas.Identity.Data;

public class DBContext : IdentityDbContext<User>
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    // Customize the ASP.NET Identity model and override the defaults if needed.
    //    // For example, you can rename the ASP.NET Identity table names and more.
    //    // Add your customizations after calling base.OnModelCreating(builder);
    //}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Delete Teacher -> delete their Courses
        builder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Course)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        // Delete Subject -> keep Courses, SubjectId becomes null
        builder.Entity<Course>()
            .HasOne(c => c.Subject)
            .WithMany(s => s.Course)
            .HasForeignKey(c => c.SubjectId)
            .OnDelete(DeleteBehavior.SetNull);

        // Delete Department -> keep Teachers, DepartmentId becomes null
        builder.Entity<Teacher>()
            .HasOne(t => t.Department)
            .WithMany(d => d.Teachers)
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        // Delete Department -> keep Subjects, DepartmentId becomes null
        builder.Entity<Subject>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Subjects)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    public DbSet<Teacher_Directory.Models.Course> Course { get; set; } = default!;

public DbSet<Teacher_Directory.Models.Department> Department { get; set; } = default!;

public DbSet<Teacher_Directory.Models.Subject> Subject { get; set; } = default!;

public DbSet<Teacher_Directory.Models.Teacher> Teacher { get; set; } = default!;
}
