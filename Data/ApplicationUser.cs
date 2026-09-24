using Microsoft.AspNetCore.Identity;

namespace cse325_group_project.Data;

// Our app's user. Inherits all Identity fields (email, password hash, etc.)
// Add profile fields here later (e.g., DisplayName) if needed.
public class ApplicationUser : IdentityUser
{
}
