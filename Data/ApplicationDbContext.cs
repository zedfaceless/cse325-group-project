using Microsoft.EntityFrameworkCore;
using cse325_group_project.Models;

namespace cse325_group_project.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Material> Materials => Set<Material>();
}