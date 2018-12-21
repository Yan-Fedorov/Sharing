using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharing.DataAccessCore.Migrations
{
    public partial class addisActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "RenteredMachines",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "RenteredMachines");
        }
    }
}
