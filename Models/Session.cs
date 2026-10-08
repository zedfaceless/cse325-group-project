using System.ComponentModel.DataAnnotations;

namespace cse325_group_project.Models;

public class Session
{
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Select a course.")]
    public int CourseId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [MaxLength(200)]
    public string Topic { get; set; } = string.Empty;

    public Course? Course { get; set; }
}
