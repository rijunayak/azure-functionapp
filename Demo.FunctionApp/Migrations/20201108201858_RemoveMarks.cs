using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.FunctionApp.Migrations
{
    public partial class RemoveMarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marks",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Marks",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
