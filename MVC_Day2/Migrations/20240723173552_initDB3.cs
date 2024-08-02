using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Day2.Migrations
{
    /// <inheritdoc />
    public partial class initDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CrsResult",
                keyColumn: "Id",
                keyValue: 7,
                column: "CourseId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CrsResult",
                keyColumn: "Id",
                keyValue: 7,
                column: "CourseId",
                value: 1);
        }
    }
}
