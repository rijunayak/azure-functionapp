using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.FunctionApp.Migrations
{
    public partial class RemoveLunchMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LunchMoney",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LunchMoney",
                table: "Students",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
