using System.ComponentModel.DataAnnotations;

namespace cse325_group_project.Models;

public class Material
{
    public int Id { get; set; }

    [Required, StringLength(150, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required, StringLength(255)]
    public string FileName { get; set; } = string.Empty;

    // Random identifier stored on disk; never use the supplied filename as a path.
    [Required, StringLength(100)]
    public string StorageId { get; set; } = string.Empty;

    public DateTime UploadedAtUtc { get; set; } = DateTime.UtcNow;

    [Range(1, int.MaxValue)]
    public int CourseId { get; set; }

    [Required]
    public string UploadedByTeacherId { get; set; } = string.Empty;

    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public string CourseName { get; set; } = string.Empty;
}
