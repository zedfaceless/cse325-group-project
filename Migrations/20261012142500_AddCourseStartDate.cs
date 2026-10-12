using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cse325_group_project.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseStartDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Courses");
        }
    }
}
