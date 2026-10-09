using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cse325_group_project.Migrations
{
    [Microsoft.EntityFrameworkCore.Infrastructure.DbContext(typeof(cse325_group_project.Data.ApplicationDbContext))]
    [Migration("20261009130000_AddClassMaterials")]
    public partial class AddClassMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "Title", table: "Materials", type: "TEXT", maxLength: 150, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "Description", table: "Materials", type: "TEXT", maxLength: 1000, nullable: true);
            migrationBuilder.AddColumn<string>(name: "FileName", table: "Materials", type: "TEXT", maxLength: 255, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "StorageId", table: "Materials", type: "TEXT", maxLength: 100, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<DateTime>(name: "UploadedAtUtc", table: "Materials", type: "TEXT", nullable: false, defaultValue: new DateTime(2026, 10, 9, 0, 0, 0, DateTimeKind.Utc));
            migrationBuilder.AddColumn<int>(name: "CourseId", table: "Materials", type: "INTEGER", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<string>(name: "UploadedByTeacherId", table: "Materials", type: "TEXT", nullable: false, defaultValue: "");
            migrationBuilder.CreateIndex(name: "IX_Materials_CourseId", table: "Materials", column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Materials_CourseId", table: "Materials");
            migrationBuilder.DropColumn(name: "Title", table: "Materials");
            migrationBuilder.DropColumn(name: "Description", table: "Materials");
            migrationBuilder.DropColumn(name: "FileName", table: "Materials");
            migrationBuilder.DropColumn(name: "StorageId", table: "Materials");
            migrationBuilder.DropColumn(name: "UploadedAtUtc", table: "Materials");
            migrationBuilder.DropColumn(name: "CourseId", table: "Materials");
            migrationBuilder.DropColumn(name: "UploadedByTeacherId", table: "Materials");
        }
    }
}
