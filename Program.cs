using cse325_group_project.Components;
using cse325_group_project.Components.Pages;
using cse325_group_project.Data;
using cse325_group_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---- Identity (auth) ----
// AddDefaultIdentity: user manager, sign-in manager, password hashing,
// plus the prebuilt UI pages at /Identity/Account/* (Register, Login, ...).
// AddRoles: enables the role system we need for Teacher/Student.
// AddEntityFrameworkStores: users and roles persist through our DbContext.
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false; // no email confirm step (no mail server in dev)
        options.Password.RequireNonAlphanumeric = false; // friendlier for class demo accounts
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Identity's pages are Razor Pages, so the app must serve those too.
builder.Services.AddRazorPages();

// Lets Blazor components receive the logged-in user via cascading state
// (what AuthorizeView and [Authorize] read from).
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// ---- Seed roles + a first teacher account on startup ----
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    foreach (var role in new[] { "Teacher", "Student" })
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var teacherEmail = "teacher@institute.test";
    if (await userManager.FindByEmailAsync(teacherEmail) is null)
    {
        var teacher = new ApplicationUser { UserName = teacherEmail, Email = teacherEmail, EmailConfirmed = true };
        await userManager.CreateAsync(teacher, "Teacher123$");
        await userManager.AddToRoleAsync(teacher, "Teacher");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!db.Courses.Any())
    {
        db.Courses.Add(new Course());
        db.SaveChanges();
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Serves the Identity UI pages (/Identity/Account/Login etc.)
app.MapRazorPages();

app.Run();
