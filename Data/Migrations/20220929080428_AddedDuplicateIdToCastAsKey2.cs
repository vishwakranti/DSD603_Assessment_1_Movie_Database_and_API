using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data.Migrations
{
    public partial class AddedDuplicateIdToCastAsKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "DuplicateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cast",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "Id");
        }
    }
}
