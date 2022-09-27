using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data.Migrations
{
    public partial class AddCastTableToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "Cast");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Cast",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieId",
                table: "Cast",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Cast_MovieId",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Cast");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
