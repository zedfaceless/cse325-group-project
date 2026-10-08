using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cse325_group_project.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendanceTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "Attendances",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Attendances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Attendances",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_SessionId_StudentId",
                table: "Attendances",
                columns: new[] { "SessionId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Sessions_SessionId",
                table: "Attendances",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Sessions_SessionId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_SessionId_StudentId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Attendances");
        }
    }
}
