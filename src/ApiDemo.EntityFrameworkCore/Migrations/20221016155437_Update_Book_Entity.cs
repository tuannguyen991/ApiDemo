using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDemo.Migrations
{
    public partial class Update_Book_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Authors",
                table: "AppBooks",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookType",
                table: "AppBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authors",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "BookType",
                table: "AppBooks");
        }
    }
}
