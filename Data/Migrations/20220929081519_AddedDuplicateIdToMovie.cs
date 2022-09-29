using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data.Migrations
{
    public partial class AddedDuplicateIdToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DuplicateId",
                table: "Movie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuplicateId",
                table: "Movie");
        }
    }
}
