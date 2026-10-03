using System.ComponentModel.DataAnnotations;
using cse325_group_project.Data;

namespace cse325_group_project.Models;

public class Attendance
{
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int SessionId { get; set; }

    public Session? Session { get; set; }

    [Required]
    public string StudentId { get; set; } = string.Empty;

    public ApplicationUser? Student { get; set; }

    public bool IsPresent { get; set; }
}
