using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Memes.Data.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Video",
                table: "Meme",
                nullable: false,
                defaultValue: false);

            migrationBuilder.RenameColumn(
                name: "user",
                table: "Meme",
                newName: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "Meme");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Meme",
                newName: "user");
        }
    }
}
