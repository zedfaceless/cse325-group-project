using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cse325_group_project.Data;

// Our app's user. Inherits all Identity fields (email, password hash, etc.)
public class ApplicationUser : IdentityUser
{
    // Shown to students on the course catalog so they know who teaches what.
    // Falls back to the email when not set.
    [StringLength(100)]
    public string? FullName { get; set; }
}
