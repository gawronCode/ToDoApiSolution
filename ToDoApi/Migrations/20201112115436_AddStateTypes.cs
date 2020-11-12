using Microsoft.EntityFrameworkCore.Migrations;
using ToDoApi.Models;


namespace ToDoApi.Migrations
{
    public partial class AddStateTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("State", "Name", "To Do");
            migrationBuilder.InsertData("State", "Name", "In Progress");
            migrationBuilder.InsertData("State", "Name", "Done");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("State", "Name", "To Do");
            migrationBuilder.DeleteData("State", "Name", "In Progress");
            migrationBuilder.DeleteData("State", "Name", "Done");
        }
    }
}
