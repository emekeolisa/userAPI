using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UserRegistrationAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "UserRegistrationDB",
                 columns: table => new
                 {
                     Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                     FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     AccountNumber = table.Column<string>(type: "varchar(max)", nullable: false),
                     Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                     ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                     Status = table.Column<bool>(type: "bit", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_UserDB", x => x.Id);
                 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersDB");
        }
    }
}
