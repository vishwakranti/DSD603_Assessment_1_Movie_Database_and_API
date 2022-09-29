using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data.Migrations
{
    public partial class ChangedDuplicateIdToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DuplicateId",
                table: "Cast",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cast",
                newName: "DuplicateId");
        }
    }
}
