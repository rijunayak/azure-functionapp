using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.FunctionApp.Migrations
{
    public partial class RenameAllowanceToBudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allowance",
                table: "Students");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Students",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Students");

            migrationBuilder.AddColumn<decimal>(
                name: "Allowance",
                table: "Students",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
