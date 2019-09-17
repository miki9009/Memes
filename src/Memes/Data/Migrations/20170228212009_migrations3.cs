using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Memes.Data.Migrations
{
    public partial class migrations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "Meme");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Meme",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Meme");

            migrationBuilder.AddColumn<bool>(
                name: "Video",
                table: "Meme",
                nullable: false,
                defaultValue: false);
        }
    }
}
