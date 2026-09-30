using System.ComponentModel.DataAnnotations;
using cse325_group_project.Data;

namespace cse325_group_project.Models;

public class Enrollment
{
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Select a course.")]
    public int CourseId { get; set; }

    [Required(ErrorMessage = "Select a student.")]
    public string StudentId { get; set; } = string.Empty;

    public Course? Course { get; set; }
    public ApplicationUser? Student { get; set; }
}
