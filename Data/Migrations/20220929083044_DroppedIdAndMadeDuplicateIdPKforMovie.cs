using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSD603_Asseessment_1_Movie_Database_and_API.Data.Migrations
{
    public partial class DroppedIdAndMadeDuplicateIdPKforMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Cast_MovieId",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Movie");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "MovieDuplicateId",
            //    table: "Cast",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "DuplicateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieDuplicateId",
                table: "Cast",
                column: "MovieDuplicateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movie_MovieDuplicateId",
                table: "Cast",
                column: "MovieDuplicateId",
                principalTable: "Movie",
                principalColumn: "DuplicateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieDuplicateId",
                table: "Cast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Cast_MovieDuplicateId",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "MovieDuplicateId",
                table: "Cast");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

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
    }
}
