using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.FunctionApp.Migrations
{
    public partial class AddAllowance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Allowance",
                table: "Students",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allowance",
                table: "Students");
        }
    }
}
