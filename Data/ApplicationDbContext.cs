using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using cse325_group_project.Models;

namespace cse325_group_project.Data;

// IdentityDbContext gives us the Users/Roles tables on top of our own entities.
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Material> Materials => Set<Material>();
}
