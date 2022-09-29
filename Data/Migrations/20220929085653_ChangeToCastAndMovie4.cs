using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data.Migrations
{
    public partial class ChangeToCastAndMovie4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieDuplicateId",
                table: "Cast");

            migrationBuilder.RenameColumn(
                name: "DuplicateId",
                table: "Movie",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MovieDuplicateId",
                table: "Cast",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_MovieDuplicateId",
                table: "Cast",
                newName: "IX_Cast_MovieId");

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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "DuplicateId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Cast",
                newName: "MovieDuplicateId");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_MovieId",
                table: "Cast",
                newName: "IX_Cast_MovieDuplicateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movie_MovieDuplicateId",
                table: "Cast",
                column: "MovieDuplicateId",
                principalTable: "Movie",
                principalColumn: "DuplicateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
