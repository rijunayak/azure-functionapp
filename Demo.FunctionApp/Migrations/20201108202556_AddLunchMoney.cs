using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.FunctionApp.Migrations
{
    public partial class AddLunchMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LunchMoney",
                table: "Students",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LunchMoney",
                table: "Students");
        }
    }
}
