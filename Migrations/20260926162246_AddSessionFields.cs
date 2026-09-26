using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cse325_group_project.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Sessions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Sessions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Sessions",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CourseId",
                table: "Sessions",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Courses_CourseId",
                table: "Sessions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Courses_CourseId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CourseId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Sessions");
        }
    }
}
