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
}
