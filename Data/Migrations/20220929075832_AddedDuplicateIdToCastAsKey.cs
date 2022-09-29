using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data.Migrations
{
    public partial class AddedDuplicateIdToCastAsKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DuplicateId",
                table: "Cast",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuplicateId",
                table: "Cast");
        }
    }
}
