using cse325_group_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace cse325_group_project.Data;

// Creates demo accounts and sample data on startup. Safe to run repeatedly.
// Render's free disk is ephemeral, so this rebuilds the demo state after every restart.
public static class DemoDataSeeder
{
    // Self-registration only creates Students, so teachers are provisioned here.
    private static readonly (string Email, string FullName)[] Teachers =
    {
        ("teacher@institute.test", "Institute Teacher"),
        ("teacher.smith@test.com", "Teacher Smith"),
        ("teacher.jones@test.com", "Teacher Jones"),
        ("teacher.brown@test.com", "Teacher Brown"),
        ("teacher.davis@test.com", "Teacher Davis"),
        ("teacher.miller@test.com", "Teacher Miller"),
        ("teacher.wilson@test.com", "Teacher Wilson"),
        ("teacher.moore@test.com", "Teacher Moore")
    };

    private static readonly (string Email, string FullName)[] Students =
    {
        ("student@institute.test", "Demo Student"),
        ("juan.delacruz@institute.test", "Juan Dela Cruz"),
        ("maria.santos@institute.test", "Maria Santos"),
        ("pedro.ramos@institute.test", "Pedro Ramos"),
        ("ana.cruz@institute.test", "Ana Cruz")
    };

    public static async Task SeedAsync(IServiceProvider services, IConfiguration config)
    {
        // Demo-only passwords; override with environment variables in production.
        var teacherPassword = config["DemoSeed:TeacherPassword"] ?? "Teacher123$";
        var studentPassword = config["DemoSeed:StudentPassword"] ?? "Student123$";

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var context = services.GetRequiredService<ApplicationDbContext>();

        var teachers = new List<ApplicationUser>();
        foreach (var (email, name) in Teachers)
            teachers.Add(await EnsureUserAsync(userManager, email, name, teacherPassword, "Teacher"));

        var students = new List<ApplicationUser>();
        foreach (var (email, name) in Students)
            students.Add(await EnsureUserAsync(userManager, email, name, studentPassword, "Student"));

        // Sample course data only on an empty database.
        if (await context.Courses.AnyAsync())
            return;

        var startDate = DateOnly.FromDateTime(DateTime.Today).AddDays(-14);

        // Course 1: students enrolled and sessions ready, so attendance can be marked right away.
        var demoCourse = NewCourse("Demo Institute Class", "Sample course for the demo.",
            teachers[0].Id, "Tuesday", startDate);

        // Course 2: another teacher's course with nobody enrolled, so students
        // can try Enroll / Drop class from the catalog.
        var openCourse = NewCourse("Study Skills Workshop", "Open course to try enrolling and dropping.",
            teachers[1].Id, "Wednesday", startDate);

        context.Courses.AddRange(demoCourse, openCourse);
        await context.SaveChangesAsync();

        context.Enrollments.AddRange(students.Select(s => new Enrollment { CourseId = demoCourse.Id, StudentId = s.Id }));

        // Sessions on real class dates so the teacher can mark attendance
        // and students see it on My Attendance.
        var lesson = 1;
        foreach (var date in SemesterCalendar.ClassDates(demoCourse.ScheduleDays, startDate, demoCourse.SessionsPerWeek, demoCourse.Weeks).Take(3))
        {
            context.Sessions.Add(new Session
            {
                CourseId = demoCourse.Id,
                Date = date.ToDateTime(TimeOnly.MinValue),
                Topic = $"Lesson {lesson++}"
            });
        }
        await context.SaveChangesAsync();
    }

    private static Course NewCourse(string name, string description, string teacherId, string day, DateOnly startDate) => new()
    {
        Name = name,
        Description = description,
        TeacherId = teacherId,
        ScheduleDays = day,
        StartTime = new TimeOnly(19, 0),
        SessionsPerWeek = 1,
        MinutesPerSession = 90,
        Weeks = 14,
        StartDate = startDate
    };

    private static async Task<ApplicationUser> EnsureUserAsync(
        UserManager<ApplicationUser> userManager, string email, string fullName, string password, string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
        {
            user = new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, FullName = fullName };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
        return user;
    }
}