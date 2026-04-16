using Microsoft.EntityFrameworkCore;
using Task1.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<StudentModel> Students { get; set; }
    public DbSet<TeacherModel> Teachers { get; set; }
    public DbSet<CourseModel> Courses { get; set; }
    public DbSet<EnrollmentModel> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Prevent duplicate enrollments (same student + same course)
        modelBuilder.Entity<EnrollmentModel>()
            .HasIndex(e => new { e.StudentId, e.CourseId })
            .IsUnique();

        // Unique emails
        modelBuilder.Entity<StudentModel>()
            .HasIndex(s => s.Email).IsUnique();

        modelBuilder.Entity<TeacherModel>()
            .HasIndex(t => t.Email).IsUnique();

        // Unique course code
        modelBuilder.Entity<CourseModel>()
            .HasIndex(c => c.CourseCode).IsUnique();
    }
}