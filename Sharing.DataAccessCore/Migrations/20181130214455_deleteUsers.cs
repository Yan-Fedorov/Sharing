using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharing.DataAccessCore.Migrations
{
    public partial class deleteUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Users_LessorId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_RenteredMachines_Users_RenterId",
                table: "RenteredMachines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Renter_FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Renter_LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Renter_Money",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Renters");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Renters",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Renters",
                table: "Renters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Lessors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Money = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Lessors_LessorId",
                table: "Machines",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RenteredMachines_Renters_RenterId",
                table: "RenteredMachines",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Lessors_LessorId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_RenteredMachines_Renters_RenterId",
                table: "RenteredMachines");

            migrationBuilder.DropTable(
                name: "Lessors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Renters",
                table: "Renters");

            migrationBuilder.RenameTable(
                name: "Renters",
                newName: "Users");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Users",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Renter_FirstName",
                table: "Users",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Renter_LastName",
                table: "Users",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Renter_Money",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Users_LessorId",
                table: "Machines",
                column: "LessorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RenteredMachines_Users_RenterId",
                table: "RenteredMachines",
                column: "RenterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
