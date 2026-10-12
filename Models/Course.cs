using System.ComponentModel.DataAnnotations;

namespace cse325_group_project.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    // Identity user id of the teacher who owns this course
    public string TeacherId { get; set; } = string.Empty;

    // Weekdays the class meets, e.g. "Tuesday" or "Monday, Thursday"
    [Required]
    [StringLength(40)]
    public string ScheduleDays { get; set; } = string.Empty;

    // Local clock time the class starts (e.g. 19:00 for 7:00 PM)
    public TimeOnly StartTime { get; set; }

    // 1 = one 90-minute class per week; 2 = two 45-minute classes per week
    [Range(1, 2)]
    public int SessionsPerWeek { get; set; } = 1;

    [Range(15, 240)]
    public int MinutesPerSession { get; set; } = 90;

    // Semester length in weeks; institute courses typically run 14
    [Range(1, 30)]
    public int Weeks { get; set; } = 14;
}
